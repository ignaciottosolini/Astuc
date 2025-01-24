<template>

  <div class="flex h-screen flex-col">
    <Navbar></Navbar>
    <div class="flex flex-col md:flex-row my-auto md:pt-0 h-[93vh] mx-auto lg:py-0">

      <div class="md:w-1/2 basis-1/2 container md:my-auto gap-16 items-center flex flex-col text-center mt-5">
        <div class="flex justify-center flex-col items-center">
          <h1 class="text-4xl font-monserrat">Olvidaste tu contraseña?</h1>
          <h2 class="text-2xl text-center font-monserrat">No te preocupes! Esto ocurre. Por favor ingresa tu email
            asociado a tu cuenta</h2>
        </div>
        <div class="p-6 w-full space-y-6 gap-10 md:space-y-6 sm:p-8 bg-white   dark:border 
      md:mt-0 sm:max-w-md xl:p-0 dark:bg-gray-800 dark:border-gray-700">

          <form class="space-y-10 md:space-y-8" @submit.prevent="sendData">
            <div class="flex flex-col items-center">
              <!-- <label for="email" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Correo</label> -->
              <input type="email" v-model="form.email" name="email" id="email"
                class="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm 
              rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-3/4 
              p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" placeholder="Email"
                required="">
            </div>

            <div class="flex flex-col gap-5 items-center">

              <button type="submit"
                class="w-3/4 text-white bg-black hover:bg-primary-700 focus:ring-4 focus:outline-none focus:ring-primary-300 
                  font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-primary-600 dark:hover:bg-primary-700 dark:focus:ring-primary-800">Enviar
                Codigo</button>
              <label v-if="isEnviado" class="text text-red-700 text-sm">{{alertMessage}}</label>
            </div>
          </form>
        </div>
      </div>
      <div class="basis-1/2 md:w-1/2">
        <img class="w-full h-full object-fit" src="../../../assets/login.jpg">

      </div>
    </div>
  </div>
  <Toast :visible="toastVisible" :message="alertMessage" @closeModal="toggleAlert"></Toast>
</template>

<script>

import { reactive, toRefs, ref, computed, onMounted } from 'vue'
import { toUrl } from '@/helpers/routing.js'
import Navbar from "../public/Navbar.vue";
import Toast from '../../components/Toast.vue';
import authService from '@/services/authService';
import router from '../../../router';


export default {
  name: "ResetPassword",
  components: {
    Navbar,
    Toast
  },
  setup() {
    const form = ref({})
    const showDialog = ref()
    const isEnviado = ref(false)
    const alertMessage = ref("Codigo Enviado, verifique su correo")
    const toastVisible = ref(false)

    const sendData = () => {
      isEnviado.value = false

      authService.forgotPassword(form.value).then(res => {

        if (res.message && res.message.succeeded) {
          alertMessage.value = "Codigo Enviado, verifique su correo"
          setAlert()
        }
        //.log(res)
        if (res.errors[0].description == "NotFound") {
          alertMessage.value = "No existe un usuario con ese email"
          setAlert()
        }
        isEnviado.value = true

      })
    }
    const toggleAlert = () =>
    {
      toastVisible.value = !toastVisible.value
    }
    const setAlert = () =>{
      toggleAlert()
      setTimeout(() => {
          toggleAlert()

      }, 3000);
    }
    onMounted(() => {


    })

    return {
      form,
      showDialog,
      sendData,
      isEnviado,
      alertMessage,
      toastVisible,
      toggleAlert


    };
  }
};
</script>

<style></style>