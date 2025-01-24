<template>
    <h1 class="text-4xl">Tu Pedido</h1>
    <div class="grid md:grid-cols-3 grid-rows-2 gap-16 ">
        <div class="flex gap-6 flex-col">
            <router-link to="/tienda">

                <p class="text-md text-blue-600">Continuar Compra</p>
            </router-link>
            <div v-for="insumo in insumos" :key="insumo.id">
                <div class="flex flex-row mb-6 gap-2 relative">
                    <a @click="removeInsumo(insumo.id)" class="z-50 absolute right-0 top-0 text-xs opacity-50 cursor-pointer underline">Eliminar</a>
                    <img class="w-32 h-24" :src="insumo.insumo.imagenPrincipal">
                    <div class="flex relative justify-between flex-col">
                        <p class="text-md font-bold">{{ insumo.insumo.nombre }}</p>
                        <p class="text-sm">Cantidad: {{ insumo.cantidad }}</p>
                        <p class="text-sm ">${{ insumo.insumo.precioVenta * insumo.cantidad }}</p>

                    </div>
                </div>
                <hr>
            </div>

            <div class="flex flex-col">
                <h2 class="text-bold"> Información de compra</h2>
                <hr>
                <div id="accordion-collapse" data-accordion="collapse">

                    <button type="button" class="flex  items-center justify-between w-full p-5"
                        data-accordion-target="#accordion-collapse-body-1" aria-expanded="true"
                        aria-controls="accordion-collapse-body-1">
                        <span>Política de devolución</span>
                        <svg data-accordion-icon class="w-3 h-3 rotate-180 shrink-0" aria-hidden="true"
                            xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 10 6">
                            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                d="M9 5 5 1 1 5" />
                        </svg>
                    </button>
                    <div id="accordion-collapse-body-1" class="" aria-labelledby="accordion-collapse-heading-1">
                        <div class="p-2 ">
                            <p class="mb-2 text-gray-500 dark:text-gray-400">Haremos el reembolso 3 días hábiles después
                                de
                                que llegue el producto, una vez que revisemos si cumple con las políticas de devolución.
                            </p>
                        </div>
                    </div>                 
                </div>
            </div>


        </div>
        <div class="flex flex-col gap-4">
            <p class="text-md font-bold">Resumen de compra</p>
            <input placeholder="Agrecar cupón" class="block w-full h-8 p-4 border-0 py-2.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300
                 placeholder:text-gray-400  focus:ring-inset focus:ring-gray-600 sm:text-sm sm:leading-6">
            <div class="flex justify-between">
                <p class="text-sm">Subtotal</p>
                <p class="text-sm">${{ total }}</p>
            </div>
            <div class="flex justify-between">
                <p class="text-sm">Envío</p>
                <p class="text-sm opacity-50">Envío gratis</p>
            </div>
            <hr>
            <div class="flex justify-between">
                <p class="text-sm">Total</p>
                <p class="text-sm">${{ total }}</p>
            </div>
            <button @click="goDatos" class="bg-black text-white p-2 rounded-xl">
                Continuar compra
            </button>
            
        </div>
        


    </div>
</template>
<script>
import { ref, onMounted,toRefs,computed } from 'vue'
import cartService from '../../../services/CartService'
export default {
    name: "Order",
    components: {

    },
    props:{
        insumos : Array
    },
    setup(props,{emit}) {
        const {insumos} = toRefs(props)
        const total = computed(() => {
            if(insumos.value){

                return insumos.value.reduce((total, insumo) => total + (insumo.cantidad * insumo.insumo.precioVenta), 0)
            }
        });
        
        const removeInsumo = async (id) => {
            await cartService.remove(id).then(res => {
                
                emit('getCart')
                
            })

        }
        const goDatos=() => {
            emit("goNextSection",'datosTab')
        }
        onMounted(async () => {
        });
        return {
            insumos,
            total,
            removeInsumo,
            goDatos
        }
    }
}
</script>