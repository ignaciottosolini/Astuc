<template>
    <div class="text-center hidden">
        <button
            class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 dark:bg-blue-600 dark:hover:bg-blue-700 focus:outline-none dark:focus:ring-blue-800"
            type="button" data-drawer-target="drawer-navigation" data-drawer-show="drawer-navigation"
            aria-controls="drawer-navigation">
            Show navigation
        </button>
    </div>
    <!-- <button @click="toggleDrawer"> asdsada</button> -->
    <div id="drawer-navigation" style="right:0px !important"
        class="fixed  top-0  z-[100] w-72 h-screen p-4 overflow-y-auto transition-transform -translate-x-full bg-white dark:bg-gray-800"
        tabindex="-1" aria-labelledby="drawer-navigation-label">
        <div class="w-full flex justify-between">
            <p class="text text-xl font-rubik">Carrito</p>
            <button type="button" @click="toggleDrawer"
                class="text-gray-400  items-right bg-transparent hover:bg-gray-200 hover:text-gray-900 rounded-lg text-sm p-1.5  top-2.5 end-2.5 inline-flex  dark:hover:bg-gray-600 dark:hover:text-white">
                <svg aria-hidden="true" class="w-5 h-5" fill="currentColor" viewBox="0 0 20 20"
                    xmlns="http://www.w3.org/2000/svg">
                    <path fill-rule="evenodd"
                        d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z"
                        clip-rule="evenodd"></path>
                </svg>
                <span class="sr-only">Close menu</span>
            </button>
        </div>

        <div class="py-4 overflow-y-auto  ">
            <ul class="space-y-2 font-medium  p-1 ">
                <li v-if="userLogged === false">
                    <div class="flex justify-center  items-center">
                        <p class="font-poppins">Inicie sesión para ver su carrito</p>
                    </div>
                </li>
                <li v-else v-for="prod in insumos" class="flex flex-col gap-5 text-md shadow-xl border rounded-md ">
                    <div class="flex relative pt-2">
                        <p class="text-center text-md px-7  font-poppins basis-full">{{ prod.insumo.nombre }}</p>
                        <button type="button" @click="removeInsumo(prod.id)"
                            class="text-gray-400 absolute right-0  items-right bg-transparent hover:bg-gray-200 hover:text-gray-900 rounded-lg
                             text-sm p-1.5  end-2.5 inline-flex  dark:hover:bg-gray-600 dark:hover:text-white">
                            <svg aria-hidden="true" class="w-5 h-5" fill="#ff0000" viewBox="0 0 20 20"
                                xmlns="http://www.w3.org/2000/svg">
                                <path fill-rule="evenodd"
                                    d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z"
                                    clip-rule="evenodd"></path>
                            </svg>
                            <span class="sr-only">Delete Product</span>
                        </button>
                    </div>
                    
                    <div class="h-36 relative">
                            <router-link :to="`/producto/${prod.insumo.id}`" @click="toggleDrawer" >
                            <img class="w-72 h-36 hover:opacity-50  rounded-md" :src="prod.insumo.imagenPrincipal">
                            <div
                            class="absolute inline-flex right-0 items-center justify-center w-6 h-6 text-xs font-bold text-white bg-blue-500 border-2 border-white rounded-full -top-2 -end-2 dark:border-gray-900">
                            {{ prod.cantidad }}</div>
                            
                        </router-link>
                        </div>


                </li>
                <li v-if="userLogged != false && insumos.length > 0">
                    <router-link to="/pedido" @click="toggleDrawer">

                        <button class="bg-black w-full text-white p-2 rounded-xl">
                             Comprar
                        </button>
                    </router-link>
                </li>

            </ul>
        </div>
    </div>
</template>
<script>
import { ref, onMounted, toRefs } from 'vue'
import { Drawer } from 'flowbite'
import cartService from '../../services/CartService'
export default {
    name: "Cart",
    props: {
        visible: {
            type: Boolean,
        },
    },
    components: {

    },
   

    setup(props, { emit }) {
        const { visible } = toRefs(props);
        const drawer = ref()
        const userLogged = ref(false)
        const insumos = ref([])
        const cartAmount = ref(0)
        const cartId = ref()


      
        const initDrawer = () => {
            const $targetEl = document.getElementById("drawer-navigation")
            const options = {
                placement: "left",
                backdrop: true,
                onToggle: () => {
                    //.log('element has been toggled');
                },
            }
            drawer.value = new Drawer($targetEl, options)



        }
        const toggleDrawer = () => {
            drawer.value.toggle()
        }
        const fetchData = async () => {
            if (!localStorage.getItem('token')) {
                userLogged.value = false;
                return
            }
            const data = await cartService.getCartByUserId()
            userLogged.value = true;
            cartId.value = data.id
            if(data){

                insumos.value = data.insumos;
                cartAmount.value = insumos.value.length
            }

            returnAmount()

        }
        const returnAmount = () =>{

            emit("getAmount", cartAmount.value)
        }
        const removeInsumo = async (id) => {
            await cartService.remove(id).then(res => {
                fetchData()

                
            })

        }
        onMounted(() => {
            initDrawer()
            // fetchData()
        })
        return {
            visible,
            initDrawer,
            drawer,
            toggleDrawer,
            fetchData,
            userLogged,
            insumos,
            removeInsumo,
            cartAmount,
            returnAmount,
            cartId

        }
    }
}
</script>