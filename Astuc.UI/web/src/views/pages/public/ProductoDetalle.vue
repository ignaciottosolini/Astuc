<template>
    <Toast :visible="showToast" :message="toastMessage" @closeModal="closeToast"></Toast>
    <div class="h-screen flex flex-col">

        <Navbar :inLanding="false" :cartAmount="cartAmount" @fetchCart="fetchCart" @toggleCart="toggleCartHandler">
        </Navbar>
        <Cart @getAmount="getAmount" ref="cart">
        </Cart>
        <div class="container flex-1 pt-10 mx-auto">

            <!-- <div class="mb-6 w-14 h-10">

                    <svg xmlns="http://www.w3.org/2000/svg" class="pl-6 w-14 h-10" viewBox="0 0 320 512">
                        <path
                            d="M9.4 233.4c-12.5 12.5-12.5 32.8 0 45.3l192 192c12.5 12.5 32.8 12.5 45.3 0s12.5-32.8 0-45.3L77.3 256 246.6 86.6c12.5-12.5 12.5-32.8 0-45.3s-32.8-12.5-45.3 0l-192 192z" />
                    </svg>
            </div> -->
            <div class="flex md:flex-row flex-col gap-8">
                <div class="md:w-1/2 h-full m-4 md:m-0 flex justify-center">
                    <div class="justify-end ">
                        <h1 class="font-rubik">
                <router-link to="/tienda">

                            Tienda 
                </router-link>
                            <i class="fas fa-solid fa-chevron-right m-2"></i>
                            <strong>   {{ insumo.nombre }} </strong></h1>
                        <img class="w-[520px] h-[420px] shadow-xl border-spacing-8  border" :src="insumo.imagenPrincipal" alt="">
                    </div>
                </div>
                <div class="md:w-1/2  h-full flex flex-col">
                    <div class="flex md:justify-center ml-5 text-start flex-col h-4/5 gap-10">

                        <p class="text-3xl font-bold md:w-3/4 h-1/4">{{ insumo.nombre }}</p>
                        <div class="flex justify-start  text-2md text-white  ">
                            <p class="p-2 bg-blue-800 rounded-sm">ENVIO GRATIS </p>
                        </div>
                        <p class="text-sm">Insumo No {{ insumo.id }}</p>
                        <p class="text-2xl font-bold h-1/2">${{ insumo.precioVenta }}</p>
                        <hr>
                        <div class="flex md:justify-start justify-center items-center md:items-start flex-col gap-2">
                            <label for="cantidad">Seleccione una cantidad</label>
                            <div class="flex gap-8">

                                <!-- <input min="1" v-model="cantidad" class="w-36" type="number"> -->
                                <div class="relative flex items-center max-w-[8rem]">
                                    <button type="button" id="decrement-button" @click="cantidad !=0 ? cantidad-- : cantidad"
                                        class="bg-gray-100 dark:bg-gray-700 dark:hover:bg-gray-600 dark:border-gray-600 hover:bg-gray-200 border border-gray-300 rounded-s-lg p-3 h-11 focus:ring-gray-100 dark:focus:ring-gray-700 focus:ring-2 focus:outline-none">
                                        <svg class="w-3 h-3 text-gray-900 dark:text-white" aria-hidden="true"
                                            xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 18 2">
                                            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round"
                                                stroke-width="2" d="M1 1h16" />
                                        </svg>
                                    </button>
                                    <input type="text" id="quantity-input" data-input-counter
                                        aria-describedby="helper-text-explanation"
                                        class="bg-gray-50 border-x-0 border-gray-300 h-11 text-center text-gray-900 text-sm focus:ring-blue-500 focus:border-blue-500 block w-full py-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                                        min="1" v-model="cantidad" />
                                    <button type="button" id="increment-button" @click="cantidad++"
                                        class="bg-gray-100 dark:bg-gray-700 dark:hover:bg-gray-600 dark:border-gray-600 hover:bg-gray-200 border border-gray-300 rounded-e-lg p-3 h-11 focus:ring-gray-100 dark:focus:ring-gray-700 focus:ring-2 focus:outline-none">
                                        <svg class="w-3 h-3 text-gray-900 dark:text-white" aria-hidden="true"
                                            xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 18 18">
                                            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round"
                                                stroke-width="2" d="M9 1v16M1 9h16" />
                                        </svg>
                                    </button>
                                </div>
                                <button type="button" @click="addProduct"
                                    class="transition ease-in-out duration-200 animation-all delay-200 hover:scale-125 text-white bg-green-500 text-xl border border-green-500 focus:outline-none hover:bg-green-400 focus:ring-4
                focus:ring-green-200 font-medium rounded-lg p-8 py-2.5 me-2 mb-2 dark:bg-green-500
                dark:text-white dark:border-green-500 dark:hover:bg-green-400 dark:hover:border-green-500 dark:focus:ring-green-700">
                                    Comprar</button>
                            </div>
                        </div>
                        <hr>
                        <div class="flex justify-center md:justify-start">


                        </div>
                    </div>

                </div>
            </div>
            <div class="flex gap-8">
                <p class="font-bold text-center text-xl w-1/2">Descripcion</p>
                <p class="w-3/4">{{ insumo.descripcion }}</p>
            </div>
            <div class="flex gap-8">
                <p class="font-bold text-center text-xl w-1/2">Categoria</p>
                <p class="w-3/4">{{ insumo.categoria }}</p>
            </div>
            
        </div>
        <Footer></Footer>
    </div>
</template>
<script>
import { ref, onMounted } from 'vue';
import { useRoute } from 'vue-router';
import insumoService from '../../../services/insumoService';
import Navbar from "../public/Navbar.vue";
import Cart from '../../layout/Cart.vue';
import cartService from '../../../services/CartService';
import Toast from '../../components/Toast.vue';
import Footer from './Footer.vue';
import { eventBus } from './bus/insumoBus';

export default {
    name: 'ProductosDetalle',
    components: {
        Navbar,
        Cart,
        Toast,
        Footer
    },
    beforeRouteUpdate(to, from, next) {

        this.productWatcher(to.params.id);
        next();
    },
    setup() {
        const cart = ref(null)
        const cartAmount = ref(0)
        const insumo = ref({})
        const cantidad = ref(1)
        const route = useRoute()
        const showToast = ref(false);
        const toastMessage = ref("")
        const getInsumoById = async (id) => {
            await insumoService.getById(id).then(res => {
                insumo.value = res
            })
        }
        const getInsumoByName = async (name) => {
            await eventBus.value.getByNombreByBus(name).then(res => {
               
                insumo.value = res
            })
        }
        const productWatcher = (id) => {
            getInsumoByName(id);
        }
        const toggleCartHandler = () => {
            cart.value.toggleDrawer()
        }
        const fetchCart = async () => {
            await cart.value.fetchData()
            await cart.value.returnAmount()

        }

        const getAmount = (amount) => {
            cartAmount.value = amount
        }
        const closeToast = () => {

            showToast.value = false;
        }
        const addProduct = async () => {
            const cartData = {
                insumoId: insumo.value.id,
                cantidad: cantidad.value
            }
            if (cart.value.userLogged) {

                await cartService.addInsumoToCart(cartData).then(res => {
                    if (res.status == 201) {
                        cart.value.fetchData()
                        toastMessage.value = "Insumo añadido"
                        showToast.value = true;
                        cantidad.value = 1
                        toggleCartHandler()

                        setTimeout(() => {
                            showToast.value = false;

                        }, 3000);
                    }
                })
            }
            else {
                toastMessage.value = "Inicie Sesión para agregar productos al carrito"
                showToast.value = true;
            }
        }
        const changeDash = (texto) => {
            return texto.replace(/-/g, ' ');
        }
        onMounted(() => {
            getInsumoByName(changeDash(route.params.id))
        })
        return {
            insumo,
            getInsumoById,
            cantidad,
            toggleCartHandler,
            cart
            , addProduct,
            showToast,
            toastMessage,
            productWatcher,
            fetchCart,
            getAmount,
            cartAmount,
            closeToast,
            getInsumoByName,
            changeDash
        }

    }
}
</script>