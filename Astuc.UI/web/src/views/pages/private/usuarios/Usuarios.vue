<template>
    <div class="container mx-auto px-4">
      <h1 class="text-2xl font-bold mb-4">Usuarios</h1>
  
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
        
        </div>
  
        <Table :headers="table.headers" :items="usersFilter" :actions="table.actions" @action="handleAction"></Table>
        <ModalDelete :message="'usuario'" :visible="visibleDelete" :id="userToDelete" @confirmDelete="eliminarData" @closeModal="closeModalDelete"></ModalDelete>
        <Edit :visible="editVisible" :usuario="userEditable" @update="updateData" @close="handleClose"></Edit>
      </div>
    </div>
    
  </template>
  
  <script>
  import Edit from '@/views/pages/private/usuarios/Edit.vue'; // Asegúrate de que la ruta sea correcta
  import { reactive, toRefs, ref, computed } from 'vue'
  import { toUrl } from '@/helpers/routing.js'
  import ModalDelete from '../../../components/ModalDelete.vue';
  import Table from '@/views/components/Table.vue'; // Asegúrate de que la ruta sea correcta
  import Search from '@/views/components/filters/Search.vue'; // Asegúrate de que la ruta sea correcta
  import authService from '../../../../services/AuthService';
  import membresiaService from  '../../../../services/membresiasService';
  
  export default {
    name: "Usuarios",
    components: {
      Table,
      Search,
      ModalDelete,
      Edit
  
    },
    setup() {
      const userToDelete= ref()
      const userEditable = ref({});
      const searchQuery = ref('');
      const users = ref()
      const membresias = ref()
      // State reactiva para el componente
      const state = reactive({
        visible: false,
        data: [],
        editVisible: false,
        ocultarGuardar: false,
        visibleDelete: false
  
      });
  
  
  
      const getUsers = async () => {
        try {
          state.data = []
          const data = await authService.getUsers();
          //.log(data)
          data.forEach( u =>{
            state.data.push({
                id:u.id,
                role: u.role,
                email: u.email,
                active: u.active ?'<div class="h-2.5 w-2.5 rounded-full bg-green-500 me-2"></div>' :  '<div class="h-2.5 w-2.5 rounded-full bg-red-500 me-2"></div> ',
                name: u.name,
                lastName: u.lastName,
                reprocainn: u.reprocainn ? "Si" : "No",
                address: u.address,
                city: u.city,
                postalCode: u.postalCode,
                phone: u.phone,
                membresia: membresias.value.find(e => e.id == u.membresiaId).tipo

            })
          })
          users.value = data;
        } catch (error) {
          //.error(error);
        }
      };
      const getMembresias = async () => {
        try {
          const data = await membresiaService.getAll();
          membresias.value = data
          getUsers();

          
        } catch (error) {
          
        }
      }
  
     
  
      const handleClose = () => {
        userEditable.value = {}
        state.editVisible = false;
      };
      const closeModalDelete = () =>{
        state.visibleDelete = false
      }
      const handleModalDelete= (id) =>{
        userToDelete.value = id
        //.log(userToDelete.value)
        state.visibleDelete = true

      }  
      const eliminarData = async (data) => {
        //.log(data)
        await authService.deleteUser(data)
        getUsers()

        state.visibleDelete = false

        
      };
  
      const updateData = async (data) => {
        await authService.edit(data.id,data).then(res =>{
          // //.log(res)
          // //.log("editado")
          getUsers()
        })
      };
  
      
  
      const usersFilter = computed(() => {
        return searchQuery.value
          ? state.data.filter((user) =>
          user.email.toLowerCase().includes(searchQuery.value.toLowerCase())
          )
          : state.data;
      });
  
  
      const filteredItems = computed(() => {
        if (!searchTerm.value) {
          return props.items;
        }
        return props.items.filter((item) =>
          item.email.toLowerCase().includes(searchTerm.value.toLowerCase())
        );
      });
  
      const filterItems = (query) => {
        searchQuery.value = query;
      };
  
      const table = reactive({
        headers: ["Id","Rol",'Email','Activo',"Nombre" ,"Apellido","Reprocainn","Direccion","Ciudad","Cp","Celular","Membresia"],
        actions: {
          edit: {
            id: 'edit',
            name: 'edit',
            icon: "fa fa-edit",
            showName: false,
            danger: false
          },
          delete: {
            id: 'delete',
            name: 'delete',
            icon: "fa fa-trash",
            showName: false,
            danger: true,
          }
        },
      })
  
  
      const handleAction = ({ actionId, item }) => {
        if (actionId.id === 'edit') {
          userEditable.value = users.value.find(u=> u.id == item.id);
          state.editVisible = true;
        } else if (actionId.id === 'delete') {
          handleModalDelete(item.id)
        }
      };
  
  
      getMembresias();
  
      // Exponer las propiedades y funciones reactivas
      return {
        userEditable,
        ...toRefs(state),
        eliminarData,
        handleClose,
        updateData,
        table,
        handleAction,
        filteredItems,
        filterItems,
        usersFilter,
        searchQuery,
        getUsers,
        closeModalDelete,
        handleModalDelete,
        userToDelete,
        users,
        membresias,
        getMembresias
      };
    }
  };
  </script>
  
  <style></style>
  