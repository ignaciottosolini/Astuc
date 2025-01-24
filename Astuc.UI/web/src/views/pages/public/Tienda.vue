<template>
    <Navbar :inLanding="false" :cartAmount="cartAmount" @fetchCart="fetchCart" @toggleCart="toggleCartHandler">
    </Navbar>
    <Cart @getAmount="getAmount" ref="cart"></Cart>
    <div class="container flex flex-col mx-auto min-h-screen p-10 gap-14">
        <div class="w-full md:w-1/2 ">
            <h1 class="text-5xl">Tienda</h1>
            <p class="text-xl">Toda nuestra veridad de productos cannabicos disponibles.
            </p>
        </div>
        <div class="flex flex-col md:flex-row gap-14">
            <div class="flex flex-1 flex-col gap-2">
                <p class="font-bold text-xl">Filtros</p>
                <div class="flex gap-4">
                    <p class="text-sm font-bold">Categories</p>
                    <a @click="resetFilters"
                        class="text-xs underline cursor-pointer text-gray-500 text-opacity-50">Limpiar Filtros </a>
                </div>

                <div class="flex flex-auto md:flex-row justify-between flex-col gap-10">
                    <div class="basis-1/4 flex justify-end flex-col ">
                        <ul class="h-full pb-3  text-sm text-gray-700 dark:text-gray-200">
                            <li>
                                <div class="flex items-center  rounded hover:bg-gray-100 dark:hover:bg-gray-600">
                                    <input id="checkbox-item-1" type="checkbox" value="" v-model="checkOil"
                                        class="w-4 h-4 text-blue-600  border-gray-300 rounded focus:ring-blue-500 dark:focus:ring-blue-600 dark:ring-offset-gray-700 dark:focus:ring-offset-gray-700 focus:ring-2 dark:bg-gray-600 dark:border-gray-500">
                                    <label for="checkbox-item-1"
                                        class="w-full px-2 ms-2 text-sm font-medium text-gray-900 rounded dark:text-gray-300">Aceites</label>
                                </div>
                            </li>
                            <li>
                                <div class="flex items-center  rounded hover:bg-gray-100 dark:hover:bg-gray-600">
                                    <input id="checkbox-item-2" type="checkbox" value="" v-model="checkCosmetic"
                                        class="w-4 h-4 text-blue-600  border-gray-300 rounded focus:ring-blue-500 dark:focus:ring-blue-600 dark:ring-offset-gray-700 dark:focus:ring-offset-gray-700 focus:ring-2 dark:bg-gray-600 dark:border-gray-500">
                                    <label for="checkbox-item-2"
                                        class="w-full px-2 ms-2 text-sm font-medium text-gray-900 rounded dark:text-gray-300">Cosméticos
                                    </label>
                                </div>
                            </li>
                            <li>
                                <div class="flex items-center  rounded hover:bg-gray-100 dark:hover:bg-gray-600">
                                    <input id="checkbox-item-3" type="checkbox" value="" v-model="checkKits"
                                        class="w-4 h-4 text-blue-600  border-gray-300 rounded focus:ring-blue-500 dark:focus:ring-blue-600 dark:ring-offset-gray-700 dark:focus:ring-offset-gray-700 focus:ring-2 dark:bg-gray-600 dark:border-gray-500">
                                    <label for="checkbox-item-3"
                                        class="w-full px-2 ms-2 text-sm font-medium text-gray-900 rounded dark:text-gray-300">Kits
                                    </label>
                                </div>
                            </li>
                            <li>
                                <div class="flex items-center  rounded hover:bg-gray-100 dark:hover:bg-gray-600">
                                    <input id="checkbox-item-4" type="checkbox" value="" v-model="checkVarious"
                                        class="w-4 h-4 text-blue-600  border-gray-300 rounded focus:ring-blue-500 dark:focus:ring-blue-600 dark:ring-offset-gray-700 dark:focus:ring-offset-gray-700 focus:ring-2 dark:bg-gray-600 dark:border-gray-500">
                                    <label for="checkbox-item-4"
                                        class="w-full px-2 ms-2 text-sm font-medium text-gray-900 rounded dark:text-gray-300">Varios
                                    </label>
                                </div>
                            </li>
                        </ul>
                    </div>
                    <div class="flex flex-col">
                        <div class=" flex border border-gray-300 focus:border-blue-500 focus:ring-blue-500">

                            <button class=" z-10 inline-flex items-center py-2.5 md:pl-4  font-medium  text-gray-900 text-sm  
                            w-auto" type="button">Ordenar por: </button>
                            <select id="sort" placeholder="sort by {{ sortSelected }}" v-model="sortSelected" class="rounded-lg border-0 font-bold
                             text-gray-900 text-sm  
                            block md:p-2.5 md:pr-1 ">
                                <option selected value="popular">Popular</option>
                                <option value="latest">Ultimos añadidos</option>

                            </select>
                        </div>
                        <p class="text-end text-sm px-11" for="">Mostrando {{ filteredInsumos.length }} insumos</p>
                    </div>
                </div>
                <div class="grid md:grid-cols-3 mx-auto gap-16 md:gap-2 ">
                    <div v-for="insumo in filteredInsumos" class="mb-8">
                        <router-link :to="`/producto/${changeSpaces(insumo.nombre)}`" class="flex flex-col gap-2 md:h-64 h-96  ">

                            <img :src=insumo.imagenPrincipal
                                class="h-3/4  hover:transition-all ease-in-out delay-100  hover:scale-y-105">
                            <div class="flex flex-row h-1/4">
                                <div class=" w-3/4 ">

                                    <p class="text-lg sm:text-xl md:text-xl">{{ insumo.nombre }}</p>
                                    <p class="font-bold text-md sm:text-lg md:text-xl"> ${{ insumo.precioVenta }}</p>
                                </div>
                                <!-- <div class="justify-end flex w-1/2">
                               

                                    <button type="button"
                                        class="text-gray-900 bg-white border border-gray-300 focus:outline-none hover:bg-gray-100 focus:ring-4
                                    focus:ring-gray-200 font-medium rounded-lg text-sm p-8 py-2.5 me-2 mb-2 dark:bg-gray-800
                                    dark:text-white dark:border-gray-600 dark:hover:bg-gray-700 dark:hover:border-gray-600 dark:focus:ring-gray-700">
                                        Ver</button>
                                    </div> -->

                            </div>
                        </router-link>

                    </div>
                </div>
                <div class="flex justify-center items-center">

                    <button v-if="!showMore" type="button" v-on:click="showMore = !showMore"
                        class="text-gray-900 bg-white border border-gray-300 focus:outline-none hover:bg-gray-100 focus:ring-4
                     focus:ring-gray-200 font-medium rounded-lg text-sm p-8 py-2.5 me-2 mb-2 dark:bg-gray-800
                      dark:text-white dark:border-gray-600 dark:hover:bg-gray-700 dark:hover:border-gray-600 dark:focus:ring-gray-700">
                        Mostrar mas productos</button>
                </div>
            </div>
        </div>


    </div>
</template>

<script>
import { ref, onMounted, computed } from 'vue'
import insumoService from '../../../services/insumoService'
import Navbar from './Navbar.vue'
import Cart from '../../layout/Cart.vue'
export default {
    name: "Tienda",
    components: {
        Navbar,
        Cart
    },
    setup() {
        const cart = ref(null)
        const cartAmount = ref(0)
        const sortSelected = ref("popular")
        const showMore = ref(false)
        const insumos = ref([])
        const checkOil = ref(false)
        const checkCosmetic = ref(false)
        const checkKits = ref(false)
        const checkVarious = ref(false)
        const getInsumos = async () => {
            await insumoService.getAll().then(res => {
                insumos.value = res
            })
            //.log(insumos.value)
        }
        const filteredInsumos = computed(() => {
            const data = insumos.value

            if (checkOil.value || checkCosmetic.value || checkKits.value || checkVarious.value) {
                return data.filter(producto => {
                    if (checkOil.value && producto.categoria == 'Aceite') return true;
                    if (checkCosmetic.value && producto.categoria == 'Cosmetico') return true;
                    if (checkKits.value && producto.categoria.toLowerCase() == 'kit') return true;
                    if (checkVarious.value && producto.categoria.toLowerCase() == 'varios') return true;
                    return false;
                });
            } else {
                if (!showMore.value) {
                    return data.slice(0, 6)
                }
                return data

            }



        })
        const resetFilters = () => {
            sortSelected.value = "popular"
            checkCosmetic.value = false
                ; checkKits.value = false;
            checkOil.value = false;
            checkVarious.value = false
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
        const changeSpaces = (texto) => {
            return texto.replace(/ /g, '-');
        }
        onMounted(async () => {
            await getInsumos()
            window.scrollTo({
          top: 0,
          behavior: "smooth"
        });
        })
        return {
            sortSelected,
            insumos,
            getInsumos,
            showMore,
            filteredInsumos,
            getAmount,
            fetchCart,
            toggleCartHandler,
            cartAmount,
            cart,
            resetFilters,
            checkOil,
            checkKits,
            checkVarious,
            checkCosmetic,
            changeSpaces
        }
    }
}
</script>