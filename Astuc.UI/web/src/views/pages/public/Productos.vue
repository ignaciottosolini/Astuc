<template>
    <div class="container mx-auto min-h-screen p-10">
        <div class="flex flex-col gap-10 justify-center">
            <div class="flex flex-col gap-5 text-center">
                <p class="text-4xl font-monserrat">Nuestros Productos</p>
                <p class="text-2xl text-gray-500 font-monserrat">Selección de productos exclusivos y variedades únicas en nuestra tienda online.
                   </p>
            </div>
            <div class="grid grid-cols-1 md:grid-cols-4  gap-12">
                <div v-for="(producto, index) in productos" class="flex flex-col gap-2">

                    <div class="h-1/2 w-full">

                        <img :src="producto.imagenPrincipal" class="w-full h-full object-fit" alt="">
                    </div>
                    <p class="text-bold text-2xl font-rubik">{{ producto.nombre }}</p>
                    <p class="text-gray-400 text-2md font-rubik">{{ producto.precioVenta }}</p>
                    <router-link :to="`/producto/${changeSpaces(producto.nombre)}`" class="text-gray-900 bg-white border border-gray-300 focus:outline-none hover:bg-gray-100 
                        focus:ring-4 focus:ring-gray-200 font-medium rounded-lg text-sm p-8 py-2.5 me-2 mb-2 dark:bg-gray-800 dark:text-white dark:border-gray-600 dark:hover:bg-gray-700 
                        dark:hover:border-gray-600 dark:focus:ring-gray-700">
                        Ver más
                    </router-link>

                </div>



            </div>
            <div class="flex justify-end">
                <router-link to="/tienda">
                    <button type="button"
                        class="text-gray-900 bg-white border border-gray-300 focus:outline-none hover:bg-gray-100
                         focus:ring-4 focus:ring-gray-200 font-medium rounded-lg text-sm p-8 py-2.5 me-2 mb-2
                          dark:bg-gray-800 dark:text-white dark:border-gray-600 dark:hover:bg-gray-700
                           dark:hover:border-gray-600 dark:focus:ring-gray-700">
                           Más productos</button>
                </router-link>
            </div>

        </div>

    </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import insumoService from "../../../services/insumoService"
const productos = ref([])
const getProductos = async () => {
    const res = await insumoService.getAll();
    productos.value = res.slice(0, 4)
}
const changeSpaces = (texto) => {
            return texto.replace(/ /g, '-');
        }
onMounted(async () => {
    await getProductos()
}


)
</script>