<template>
    <div class="container mx-auto px-4">
      <h1 class="text-2xl font-bold mb-4">Eventos</h1>
  
      <!-- Búsqueda -->
      <div class="mt-8">
        <!-- <h2 class="text-lg font-bold mb-2">Buscar por DNI:</h2> -->
        <div class="items-center justify-between block sm:flex md:divide-x md:divide-gray-100 dark:divide-gray-700">
          <div class="flex items-center mb-4 sm:mb-0">
            <form class="sm:pr-3">
              <div class="relative w-48 mt-1 sm:w-64 xl:w-96">
                <Search :modelValue="searchQuery" @update:modelValue="searchQuery = $event" placeholder="Buscar..." />
              </div>
            </form>
  
          </div>
          <button @click="editVisible = true"
            class="text-white bg-blue-500 focus:ring-1 focus:ring-primary-300 font-medium rounded-lg text-sm px-5 py-2.5 dark:bg-primary-600 dark:hover:bg-primary-700 focus:outline-none dark:focus:ring-primary-800"
            type="button" data-drawer-target="drawer-create-product-default"
            data-drawer-show="drawer-create-product-default" aria-controls="drawer-create-product-default"
            data-drawer-placement="right">
            Añadir nuevo
          </button>
        </div>
        
  
        <Table :headers="table.headers" :items="eventosFiltrados" :actions="table.actions" @action="handleAction" />
        <!-- Asegúrate de importar el componente Edit adecuado para los insumos -->
        <Edit :visible="editVisible" :evento="eventoEditable" @update="handleUpdate" @close="handleClose" />
  
      </div>
    </div>
  </template>
  
  <script>
  import Edit from '@/views/pages/private/eventos/Edit.vue'; // Asegúrate de que la ruta sea correcta
  import { reactive, toRefs, ref, computed } from 'vue'
  import { toUrl } from '@/helpers/routing.js'
  import Table from '@/views/components/Table.vue'; // Asegúrate de que la ruta sea correcta
  import Search from '@/views/components/filters/Search.vue'; // Asegúrate de que la ruta sea correcta
  import eventoService from '@/services/eventoService';
  
  export default {
    name: "Evento",
    components: {
      Table,
      Edit,
      Search
  
    },
    setup() {
      
  
      const eventoEditable = ref({});
      const searchQuery = ref('');
      const eventos = ref([])
      // State reactiva para el componente
      const state = reactive({
        visible: false,
        data: [],
        editVisible: false,
        ocultarGuardar: false

        
  
      });

      const formatearFecha = (fecha) => {
            const fechaFormateada = new Date(fecha);
            const year = fechaFormateada.getFullYear();
            const month = String(fechaFormateada.getMonth() + 1).padStart(2, '0');
            const day = String(fechaFormateada.getDate()).padStart(2, '0');
            const hours = String(fechaFormateada.getHours()).padStart(2, '0');
            const minutes = String(fechaFormateada.getMinutes()).padStart(2, '0');
            return `${day}-${month}-${year} ${hours}:${minutes}`;
        };
  

      const fetchEventos = async () => {
      try {
        const data = await eventoService.getEventos();
        state.data = data.map((d)=>({
          ...d,
          fechaYHora:formatearFecha(d.fechaYHora),
          esGratis: d.esGratis ? "Si" : "No"
        }));
       
        eventos.value = data
      } catch (error) {
        //.error(error);
      }
    };
    
  
      const handleUpdate = async (data) => {
        state.editVisible = false;
  
        if (data.isNew) {
          await eventoService.add(data)
          fetchEventos()
        } 
        else {
          await eventoService.edit(data.id, data)
          fetchEventos()
          
  
        }
      };
  
      const handleClose = () => {
        eventoEditable.value = {}
        state.editVisible = false;
      };
  
      const eliminarData = async (data) => {
        await eventoService.remove(data)
        fetchEventos()
      };
  
      const updateData = async (data) => {
        eventoEditable.value = data;
      };
  
      const createData = async (data) => {
        await eventoService.add(data)
      };
  
      const eventosFiltrados = computed(() => {
        return searchQuery.value
          ? state.data.filter((evento) =>{
            evento.nombre.toLowerCase().includes(searchQuery.value.toLowerCase())

          }
          )
          : state.data;
      });
  
  
      const filteredItems = computed(() => {
        if (!searchTerm.value) {
          return props.items;
        }
        return props.items.filter((item) =>
          item.nombre.toLowerCase().includes(searchTerm.value.toLowerCase())
        );
      });
  
      const filterItems = (query) => {
        searchQuery.value = query;
      };
  
      const table = reactive({
        headers: ['Id', 'Nombre', 'Descripcion', 'Fecha y Hora', 'Lugar', 'Precio', "Es Gratis" ],
        actions: {
          edit: {
            id: 'edit',
            name: 'Edit',
            icon: "fa fa-edit",
            showName: false,
            to: toUrl('/admin/eventos/{id}/edit'),
            danger: false
          },
          delete: {
            id: 'delete',
            name: 'Eliminar',
            icon: "fa fa-trash",
            showName: false,
            danger: true,
          }
        },
      })
  
  
      const handleAction = ({ actionId, item }) => {
        if (actionId.id === 'edit') {
          eventoEditable.value = eventos.value.find(e => e.id == item.id);
          state.editVisible = true;
        } else if (actionId.id === 'delete' && confirm('¿Estás seguro de que deseas eliminar estos datos?')) {
          eliminarData(item.id);
        }
      };
  
  
      fetchEventos();
  
  
      
      return {
        eventoEditable,
        ...toRefs(state),
        eliminarData,
        handleClose,
        updateData,
        createData,
        table,
        handleAction,
        handleUpdate,
        filteredItems,
        filterItems,
        eventosFiltrados,
        searchQuery,
        fetchEventos,
        formatearFecha,
        eventos
        
      };
    }
  };
  </script>
  
  <style></style>
  