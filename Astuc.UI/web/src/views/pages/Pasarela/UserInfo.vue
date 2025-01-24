<template>
    <div class="relative p-4 w-full max-w-2xl h-full md:h-auto">
        <button @click="goBack()">
            <svg xmlns="http://www.w3.org/2000/svg" class="pl-6 w-14 h-10" viewBox="0 0 320 512">
                <path
                    d="M9.4 233.4c-12.5 12.5-12.5 32.8 0 45.3l192 192c12.5 12.5 32.8 12.5 45.3 0s12.5-32.8 0-45.3L77.3 256 246.6 86.6c12.5-12.5 12.5-32.8 0-45.3s-32.8-12.5-45.3 0l-192 192z" />
            </svg>
        </button>
        <!-- Modal content -->
        <div class="relative p-4 bg-white rounded-lg shadow dark:bg-gray-800 sm:p-5">
            <div class="mb-6 w-14 h-10">


            </div>
            <!-- Modal header -->
            <div class="flex justify-between items-center pb-4 mb-4 rounded-t sm:mb-5 dark:border-gray-600">
                <hp class="text-lg font-semibold text-gray-900 dark:text-white">
                    Mis Datos
                </hp>

            </div>
            <form @submit.prevent="goPago()">
                <div class="grid gap-4 mb-4 sm:grid-cols-2">
                    <div>
                        <label for="email"
                            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Email</label>
                        <input type="text" v-model="userData.email" id="email" required
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500">
                    </div>
                    <div>
                        <label for="name"
                            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Nombre</label>
                        <input type="text" v-model="userData.name" id="name" required
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500">
                    </div>
                    <div>
                        <label for="lastName"
                            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Apellido</label>
                        <input type="text" v-model="userData.lastName" id="lastName" required
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500">
                    </div>
                    <div>
                        <label for="phone"
                            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Celular</label>
                        <input type="number" v-model="userData.phone" id="phone" required
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500">
                    </div>
                    <div>
                        <label for="address"
                            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Dirección</label>
                        <input type="text" v-model="userData.address" id="lastName" required
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500">
                    </div>
                    <div>
                        <label for="cp" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Código
                            Postal</label>
                        <input type="number" v-model="userData.postalCode" id="lastName" required
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500">
                    </div>
                    <div>
                        <label for="city"
                            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Ciudad</label>
                        <input type="text" v-model="userData.city" id="city" required
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500">
                    </div>


                </div>
                <div class="flex items-center space-x-4">

                    <button type="submit" class="bg-black text-white p-2 rounded-xl">
                        Pagar
                    </button>

                </div>
            </form>
        </div>
    </div>
</template>
<script>
import { ref, onMounted } from 'vue'
import authService from '../../../services/AuthService'

export default {
    name: "UserInfo",
    components: {

    },
    setup(props, { emit }) {
        const userData = ref({})

        const getUser = async () => {
            const res = await authService.getUserLogged()
            userData.value = res
        };
        const goPago = () => {
            //.log("gopago")
            emit("initBrick", 'pagoTab')

        }
        const goBack = () => {
            emit("goNextSection", "pedido-tab")
        }

        onMounted(async () => {
            await getUser()
        });

        return {
            userData,
            getUser,
            goPago,
            goBack
        }

    }
}

</script>