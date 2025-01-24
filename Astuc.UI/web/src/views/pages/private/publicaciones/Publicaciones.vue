<template>
    <div class="container mx-auto px-4">
      <h1 class="text-2xl font-bold mb-4">Publicaciones</h1>
  
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
  
        <Table :headers="table.headers" :items="publicacionesFiltrados" :actions="table.actions" @action="handleAction" />
        <!-- Asegúrate de importar el componente Edit adecuado para los insumos -->
        <Edit :visible="editVisible" :publicacion="publicacionEditable" @update="handleUpdate" @close="handleClose" />
  
      </div>
    </div>
  </template>
  
  <script>
  import Edit from '@/views/pages/private/publicaciones/Edit.vue'; // Asegúrate de que la ruta sea correcta
  import { reactive, toRefs, ref, computed } from 'vue'
  import { toUrl } from '@/helpers/routing.js'
  import Table from '@/views/components/Table.vue'; // Asegúrate de que la ruta sea correcta
  import Search from '@/views/components/filters/Search.vue'; // Asegúrate de que la ruta sea correcta
  import publicacionService from '@/services/publicacionService';
  
  
  export default {
    name: "publicacion",
    components: {
      Table,
      Edit,
      Search
  
    },
    setup() {
  
      const publicacionEditable = ref({});
      const searchQuery = ref('');
  
      // State reactiva para el componente
      const state = reactive({
        visible: false,
        data: [],
        editVisible: false,
        ocultarGuardar: false
  
      });

      
  
  
      const fetchPublicaciones = async () => {
        try {
          const data = await publicacionService.getPublicaciones();
          state.data = data;
        } catch (error) {
          //.error(error);
        }
      };
  
      const handleUpdate = async (data) => {
        state.editVisible = false;
  
        if (data.isNew) {
          await publicacionService.add(data)
          fetchPublicaciones()
        }
        else {
          await publicacionService.edit(data.id, data)
  
        }
      };
  
      const handleClose = () => {
        publicacionEditable.value = {}
        state.editVisible = false;
      };
  
      const eliminarData = async (data) => {
        await publicacionService.remove(data)
        fetchPublicaciones()
      };
  
      const updateData = async (data) => {
        publicacionEditable.value = data;
      };
  
      const createData = async (data) => {
        await publicacionService.add(data)
      };
  
      const publicacionesFiltrados = computed(() => {
        return searchQuery.value
          ? state.data.filter((publicacion) =>
          publicacion.nombre.toLowerCase().includes(searchQuery.value.toLowerCase())
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
        headers: ['Id', 'Descripcion', 'Titulo', 'ImagenPrincipal'],
        actions: {
          edit: {
            id: 'edit',
            name: 'Edit',
            icon: "fa fa-edit",
            showName: false,
            to: toUrl('/admin/publicaciones/{id}/edit'),
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
          publicacionEditable.value = item;
          state.editVisible = true;
        } else if (actionId.id === 'delete' && confirm('¿Estás seguro de que deseas eliminar estos datos?')) {
          eliminarData(item.id);
        }
      };
  
  
      fetchPublicaciones();
  
  
      // Exponer las propiedades y funciones reactivas
      return {
        publicacionEditable,
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
        publicacionesFiltrados,
        searchQuery,
        fetchPublicaciones
      };
    }
  };
  </script>
  
  <style></style>
  