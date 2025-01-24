<template>
    <div class="flex h-screen flex-col">
<Navbar></Navbar>
    <div class="flex-1 container mx-auto  w-1/2">
        <div class="flex flex-col h-full  ">
            <div class="text-center mb-6 mt-2">
                <h1 class="text-4xl  text-gray-800">Registro de Usuario</h1>
            </div>
            <h2 class="font-bold text-md">Información Personal:</h2>
            <form @submit.prevent="register">
                <div class="mt-7 grid grid-cols-1 gap-x-6 gap-y-8 sm:grid-cols-6 mb-6">
                    <div class="sm:col-span-3">
                        <label for="" class="block text-sm  leading-6 text-gray-600">NOMBRE</label>
                        <div class="mt-2">
                            <input required type="text" name="" v-model="form.Name"
                                class="block w-full l border-0 py-2.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300
                                 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-green-600 sm:text-sm sm:leading-6">
                        </div>
                    </div>

                    <div class="sm:col-span-3">
                        <label for="second-name" class="block text-sm  leading-6 text-gray-600">APELLIDO</label>

                        <div class="mt-2">
                            <input required type="text" name="" v-model="form.LastName"
                                class="block w-full l border-0 py-2.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300
                                 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-green-600 sm:text-sm sm:leading-6">
                        </div>
                    </div>
                    <div class="sm:col-span-3">
                        <label for="phone" class="block text-sm  leading-6 text-gray-600">TELEFONO CELULAR</label>

                        <div class="mt-2">
                            <input required type="number" name="" v-model="form.Phone"
                                class="block w-full l border-0 py-2.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300
                                 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-green-600 sm:text-sm sm:leading-6">
                        </div>
                    </div>

                    <div class="sm:col-span-3">
                        <label for="email" class="block text-sm  leading-6 text-gray-600">EMAIL</label>

                        <div class="mt-2">
                            <input required type="email" name="" v-model="form.Email"
                                class="block w-full l border-0 py-2.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300
                                 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-green-600 sm:text-sm sm:leading-6">
                        </div>
                    </div>
                    <div class="sm:col-span-3">
                        <label for="password" class="block text-sm  leading-6 text-gray-600">CONTRASEÑA</label>

                        <div class="mt-2">
                            <input required type="password" name="" v-model="form.Password"
                                class="block w-full l border-0 py-2.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300
                                 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-green-600 sm:text-sm sm:leading-6">
                       
                                </div>


                    </div>

                    <div class="sm:col-span-3">
                        <label for="confirmPassword" class="block text-sm  leading-6 text-gray-600">CONFIRMAR
                            CONTRASEÑA</label>

                        <div class="mt-2">
                            <input required name="" type="password" v-model="form.ConfirmPassword"
                                class="block w-full l border-0 py-2.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300
                                 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-green-600 sm:text-sm sm:leading-6">
                        </div>
                        <p class="mt-2 text-sm text-red-600 dark:text-red-500">{{ confirmPasswordError }}</p>

                    </div>
                    <div class="col-span-full">
                        <label for="address" class="block text-sm  leading-6 text-gray-600">DIRECCIÓN</label>

                        <div class="mt-2">
                            <input required type="text" name="street-address" id="street-address"
                                v-model="form.Address"
                                class="block w-full l border-0 py-2.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300
                                 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-green-600 sm:text-sm sm:leading-6">
                        </div>
                    </div>
                    <div class="sm:col-span-3">
                        <label for="city" class="block text-sm  leading-6 text-gray-600">LOCALIDAD</label>

                        <div class="mt-2">
                            <input required type="text" name="" v-model="form.City"
                                class="block w-full l border-0 py-2.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300
                                 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-green-600 sm:text-sm sm:leading-6">
                        </div>
                    </div>

                    <div class="sm:col-span-3">
                        <label for="cp" class="block text-sm  leading-6 text-gray-600">CÓDIGO POSTAL</label>

                        <div class="mt-2">
                            <input required type="number" name="" v-model="form.PostalCode"
                                class="block w-full l border-0 py-2.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300
                                 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-green-600 sm:text-sm sm:leading-6">
                        </div>
                    </div>
                </div>
                <p class="mt-2 text-sm text-red-600 dark:text-red-500" v-for="error in translatedErrors">{{ error}}</p>

                <hr>
                <div class="sm:col-span-3">
                    <label for="cp" class="block text-sm mt-8 leading-6 text-gray-600">¿CUENTA CON REPROCANN?</label>

                    <div class="flex gap-2">
                        <div class="flex items-center gap-2 me-4">
                            <input id="inline-radio" type="radio" value=true v-model="form.Reprocainn" name="inline-radio-group"
                                class="w-4 h-4 text-blue-600 bg-gray-100 border-gray-300 focus:ring-blue-500 dark:focus:ring-blue-600 dark:ring-offset-gray-800 focus:ring-2 dark:bg-gray-700 dark:border-gray-600">
                            <label for="inline-radio"
                                class="ms-2 text-sm font-medium font-poppins text-gray-900 dark:text-gray-300">Si</label>
                        </div>
                        <div class="flex items-center gap-2 me-4">
                            <input id="inline-2-radio" type="radio" value=false v-model="form.Reprocainn" name="inline-radio-group"
                                class="w-4 h-4 text-blue-600 bg-gray-100 border-gray-300 focus:ring-blue-500 dark:focus:ring-blue-600 dark:ring-offset-gray-800 focus:ring-2 dark:bg-gray-700 dark:border-gray-600">
                            <label for="inline-2-radio"
                                class="ms-2 text-sm font-medium font-poppins text-gray-900 dark:text-gray-300">No</label>
                        </div>
                    </div>
                </div>
                <div class="flex flex-row mt-6 gap-5">
                    <button type="submit"
                        class="text-white bg-gray-800 hover:bg-gray-900 focus:outline-none focus:ring-4 focus:ring-gray-300 font-medium  text-sm px-5 py-2.5 me-2 mb-2 dark:bg-gray-800 dark:hover:bg-gray-700 dark:focus:ring-gray-700 dark:border-gray-700">Enviar</button>
                    <button v-on:click="cleanForm()" type="button"
                        class="text-black hover:border-m border-0  focus:ring-4 focus:ring-gray-300 font-medium rounded-full text-sm px-5 py-2.5 me-2 mb-2 dark:bg-gray-800 dark:hover:border-gray-700 dark:focus:ring-gray-700 dark:border-gray-700">
                        <svg xmlns="http://www.w3.org/2000/svg" class="inline mr-1" height="16" width="12"
                            viewBox="0 0 384 512">
                            <path
                                d="M376.6 84.5c11.3-13.6 9.5-33.8-4.1-45.1s-33.8-9.5-45.1 4.1L192 206 56.6 43.5C45.3 29.9 25.1 28.1 11.5 39.4S-3.9 70.9 7.4 84.5L150.3 256 7.4 427.5c-11.3 13.6-9.5 33.8 4.1 45.1s33.8 9.5 45.1-4.1L192 306 327.4 468.5c11.3 13.6 31.5 15.4 45.1 4.1s15.4-31.5 4.1-45.1L233.7 256 376.6 84.5z" />
                        </svg>
                        Borrar todo</button>

                </div>
            </form>
        </div>

</div>
</div>
<Toast :visible="visibleToast" :message="'Usuario Registrado, iniciando sesión'"></Toast>
</template>
<script setup>
import Navbar from '../public/Navbar.vue';

import { ref, computed } from 'vue'
import authService from '../../../services/AuthService';
import Toast from '../../components/Toast.vue';
component:{
    Navbar,
    Toast
}
const form = ref({})
const errors = ref([])
const visibleToast= ref(false)
const confirmPasswordError = ref()
const cleanForm = () => {
    form.value = {}
    errors.value = []
    confirmPasswordError.value = null
}
const validatePasswords = () =>{
    if(form.value.Password === form.value.ConfirmPassword ){
        confirmPasswordError.value = null
        return true
    }else{
        confirmPasswordError.value = "La contraseña no coincide"
        return false
    }

}
const setAlert = ()=>{
    visibleToast.value =  true;
    setTimeout(() => {
        visibleToast.value =  false;
        const data = {
            Email:form.value.Email,
            Password:form.value.Password
        }
        authService.login(data)
        cleanForm()
    }, 3000);
}
const translatedErrors =computed(() =>{
    const translationMap = {
        "PasswordRequiresLower" : "La contraseña debe tener al menos una letra minuscula (a-z)",
        "PasswordTooShort": "La contraseña es demasiado corta",
        "PasswordRequiresNonAlphanumeric": "La contraseña debe tener al menos un carácter no alfanumérico.",
        "PasswordRequiresDigit": "La contraseña debe tener al menos un dígito ('0'-'9').",
        "PasswordRequiresUpper": "La contraseña debe tener al menos una letra mayúscula ('A'-'Z').",
        "DuplicateUserName": "Ya existe un usuario con ese Email",
      }
      return errors.value.map(error => translationMap[error.code]);


});
const register = async () => {

    if(!validatePasswords() ){
        return
    }
    form.value.Reprocainn = form.value == "false" ? false : true
    form.value.Phone = form.value.Phone.toString()
    try {
        errors.value  = []
        await authService.register(form.value).then(res => {
            //.log(res)
            res.errors ? (errors.value = res.errors) : null
            res.message ? (setAlert()) : null
        })
    } catch (error) {
        //.error(error)
    }
}
</script>
<style>label {
    font-family: Poppins;
}</style>