<template>
    <Navbar  :cartAmount="cartAmount" @fetchCart="fetchCart"  @toggleCart="toggleCartHandler"></Navbar>
    <Cart @getAmount="getAmount" ref="cart"></Cart>

  <div class="min-h-screen mx-auto container pt-16 ">
    <div class="flex flex-col h-full justify-center gap-8 ">

      <div class="text-center flex gap-8 flex-col justify-center">
        <i class="flex justify-center">
          <svg class="w-12 h-12 text-black" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor"
            viewBox="0 0 24 24">
            <path fill-rule="evenodd"
              d="M12 4a4 4 0 1 0 0 8 4 4 0 0 0 0-8Zm-2 9a4 4 0 0 0-4 4v1c0 1.1.9 2 2 2h8a2 2 0 0 0 2-2v-1a4 4 0 0 0-4-4h-4Z"
              clip-rule="evenodd" />
          </svg>
        </i>
        <h2 class="text-4xl">Mi cuenta</h2>
      </div>
      <div class="flex items-center flex-col gap-4">
        <div class="md:w-1/2 h-fit rounded-xl  p-4 flex flex-col gap-3">
          <button @click="handleEdit()" class="bg-[#99BAE3] text-white py-4 px-6 rounded-xl flex justify-center items-center text-center">
            Datos Personales
          </button>
        </div>
        <div class="md:w-1/2 h-fit rounded-xl  p-4 flex flex-col gap-3">
          <button @click="handleEditPassword()" class="bg-[#99BAE3] text-white py-4 px-6 rounded-xl flex justify-center items-center text-center">
            Cambiar Contraseña
          </button>
        </div>
        <div class="md:w-1/2 h-fit rounded-xl  p-4 flex flex-col gap-3">
          <button class="bg-[#99BAE3] text-white py-4 px-6 rounded-xl flex justify-center items-center text-center">
            Mi REPROCAINN
          </button>
        </div>
        <div class="md:w-1/2 h-fit rounded-xl  p-4 flex flex-col gap-3">
          <router-link to="/membresias">

            <button class="bg-[#99BAE3] w-full text-white py-4 px-6 rounded-xl flex justify-center items-center text-center">
              Mi Membresia
            </button>
          </router-link>
        </div>
        <div class="md:w-1/2 h-fit rounded-xl  p-4 flex flex-col gap-3">
          <router-link to="/mis-ordenes">

            <button class="bg-[#99BAE3] w-full text-white py-4 px-6 rounded-xl flex justify-center items-center text-center">
              Mis Compras
            </button>
          </router-link>
        </div>
        <div v-if="user.role == 'Admin'" class="md:w-1/2 h-fit rounded-xl  p-4 flex flex-col gap-3">
          <router-link to="/admin">

            <button class="bg-[#99BAE3] w-full text-white py-4 px-6 rounded-xl flex justify-center items-center text-center">
              Panel Admin
            </button>
          </router-link>
        </div>
        <div @click="logout()" class="md:w-1/2 h-fit rounded-xl  p-4 flex flex-col gap-3">
          <button class="bg-[#99BAE3] text-white py-4 px-6 rounded-xl flex justify-center items-center text-center">
            Cerrar Sesión
          </button>
        </div>

      </div>
    </div>

  </div>
  <Edit :visible="editVisible" :usuario="userEditable" @update="updateData" @close="handleClose"></Edit>
  <EditPassword :visible="editPassVisible" :email="user.email"  @closePass="handleClosePass"></EditPassword>

</template>
<script>
import { ref, onMounted, } from 'vue'
import router from '../../../../router';
import authService from '../../../../services/AuthService'
import Navbar from '../../public/Navbar.vue';
import Cart from '../../../layout/Cart.vue';
import Edit from './Edit.vue';
import EditPassword from './EditPassword.vue';

export default {
  name: "PanelUsuario",
  components: {Navbar,Cart,Edit,
    EditPassword

  },
  setup() {
    const editVisible = ref(false)
    const cart = ref(null)
    const cartAmount = ref(0)
    const user = ref({})
    const userEditable = ref({})
    const editPassVisible = ref(false)
    const logout = () =>{
      authService.logout().then(res => router.push('/iniciar-sesion'))

    }
    const toggleCartHandler =() =>{
      cart.value.toggleDrawer()
    }
    const fetchCart = async  () => {
      await cart.value.fetchData()
      await cart.value.returnAmount()

    }
    const getAmount = (amount) => {
      cartAmount.value = amount
    }
    const updateData = async (data) => {
        await authService.edit(data.id,data).then(res =>{
        
          getUsers()
        })
      };
      
      const handleClose = () => {
        userEditable.value = {}
        editVisible.value= false;
      };
      
      const handleClosePass = () => {
        editPassVisible.value= false;
      };
      const handleEdit=()=>{
        userEditable.value = user.value;
        editVisible.value= true;

      }
      const handleEditPassword=()=>{
        editPassVisible.value= true;

      }
    onMounted(async () => {
      await authService.getUserLogged().then(res => {
        if(res.status == 401) router.push("/")
        user.value= res
      })
    })
    return {
      user,
      logout,
      toggleCartHandler,
      cart,
      getAmount,
      fetchCart,
      cartAmount,
      updateData,
      handleClose,
      editVisible,
      editPassVisible,
      handleEdit,
      userEditable,
      handleEditPassword,
      handleClosePass,

    }
  }

}
</script>