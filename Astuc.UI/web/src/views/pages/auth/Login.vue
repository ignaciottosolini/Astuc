<template>

  <div class="flex h-screen flex-col">
    <Navbar></Navbar>
    <Toast :visible="visibleToast" :message="'Error al ingresar, verifique los datos ingresados'"></Toast>
    <div class="flex flex-1 flex-col md:flex-row my-auto md:pt-0 h-[93vh] mx-auto lg:py-0">

      <div class="md:w-1/2 basis-1/2 container my-auto gap-16 items-center flex flex-col ">
        <div class="flex justify-center flex-col items-center">
          <h1 class="text-4xl font-monserrat">Iniciar Sesión</h1>
          <h2 class="text-2xl text-center font-monserrat">Crea una cuenta y comienza a descubrir nuestra lista de productos!</h2>
        </div>
        <div class="p-6 w-full space-y-6 gap-10 md:space-y-6 sm:p-8 bg-white   dark:border 
      md:mt-0 sm:max-w-md xl:p-0 dark:bg-gray-800 dark:border-gray-700">

          <form class="space-y-10 md:space-y-8 text-center" @submit.prevent="login">
            <div class="flex flex-col items-center">
              <!-- <label for="email" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Correo</label> -->
              <input type="email" v-model="form.email" name="email" id="email"
                class="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm 
              rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-3/4 
              p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" placeholder="Email"
                required="">
            </div>
            <div class="flex flex-col items-center">
              <!-- <label for="password" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Contraseña</label> -->
              <input type="password" v-model="form.password" name="password" id="password" placeholder="Contraseña"
                class="bg-gray-50 border border-gray-300 text-gray-900 
            sm:text-sm rounded-lg focus:ring-primary-600 
            focus:border-primary-600 block w-3/4 p-2.5
            dark:bg-gray-700 dark:border-gray-600
            dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" required="">
            </div>
            <p id="helper-text-explanation text-center" class="mt-2 text-sm text-gray-500 dark:text-gray-400">Olvidaste
              tu contraseña ?<RouterLink to="/recuperar-contrasena"> <a href="#"
                  class="font-medium underline text-gray-400 hover:underline dark:text-blue-500">Recuperar</a>
              </RouterLink>.</p>
            <div class="flex flex-col items-center">

              <button type="submit"
                class="w-3/4 text-white bg-black hover:bg-primary-700 focus:ring-4 focus:outline-none focus:ring-primary-300 
                  font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-primary-600 dark:hover:bg-primary-700 dark:focus:ring-primary-800">Ingresar</button>
            </div>
          
          </form>
        </div>
      </div>
      <div class="basis-1/2 md:w-1/2 md:block hidden">
        <img class="w-full h-full object-fit" src="../../../assets/login.jpg">

      </div>
    </div>
  </div>

</template>

<script>

import { reactive, toRefs, ref, computed, onMounted } from 'vue'
import { toUrl } from '@/helpers/routing.js'
import Navbar from "../public/Navbar.vue";
import authService from '@/services/authService';
import router from '../../../router';
import Toast from '../../components/Toast.vue';

export default {
  name: "Login",
  components: {
    Navbar,
    Toast
  },
  setup() {
    const form = ref({})
    const showDialog = ref()
    const visibleToast = ref(false)
    const login = () => {
      authService.login(form.value).then(res => {
        if (res.status == 401) setAlert()
      })
    }
   
    const setAlert = () => {
      visibleToast.value = true;
      setTimeout(() => {
        visibleToast.value = false;
      }, 3000);
    }
    onMounted(() => {
      // authService.getUserLogged().then(res =>{
      //  res ?  router.push('admin') : null
      // })

    })

    return {
      form,
      showDialog,
      login,
      setAlert,
      visibleToast

    };
  }
};
</script>

<style></style>