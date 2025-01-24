<template>
     <Navbar  :cartAmount="cartAmount" @fetchCart="fetchCart" @toggleCart="toggleCartHandler"></Navbar>
    <Cart @getAmount="getAmount" ref="cart"></Cart>
    <div class="container mx-auto px-4">
        <h1 class="text-2xl font-bold mb-4">Pedidos</h1>

        <!-- Búsqueda -->
        <div class="mt-8">
            <!-- <h2 class="text-lg font-bold mb-2">Buscar por DNI:</h2> -->
            <!-- <div class="items-center justify-between block sm:flex md:divide-x md:divide-gray-100 dark:divide-gray-700">
                <div class="flex items-center mb-4 sm:mb-0">
                    <form class="sm:pr-3">
                        <div class="relative w-48 mt-1 sm:w-64 xl:w-96">
                            <Search :modelValue="searchQuery" @update:modelValue="searchQuery = $event"
                                placeholder="Buscar..." />
                        </div>
                    </form>

                </div>
                <button @click="editVisible = true"
                    class="text-white bg-blue-500 focus:ring-1 focus:ring-primary-300 font-medium rounded-lg text-sm px-5 py-2.5 dark:bg-primary-600 dark:hover:bg-primary-700 focus:outline-none dark:focus:ring-primary-800"
                    type="button" data-drawer-target="drawer-create-product-default"
                    data-drawer-show="drawer-create-product-default" aria-controls="drawer-create-product-default"
                    data-drawer-placement="right">
                    Añadir nuevo
                </button>
            </div> -->

            <Table :headers="table.headers" :items="pedidos" :actions="table.actions" @action="handleAction" />
            <!-- Asegúrate de importar el componente Edit adecuado para los insumos -->
            <Details ref="details" :visible="detailsVisible"  @close="handleCloseDetails" />
        </div>
    </div>
</template>

<script>
import { reactive, toRefs, ref, computed } from 'vue'
import { toUrl } from '@/helpers/routing.js'
import Table from '@/views/components/Table.vue'; // Asegúrate de que la ruta sea correcta
import Search from '@/views/components/filters/Search.vue'; // Asegúrate de que la ruta sea correcta
import pedidoService from '@/services/pedidoService';
import Details from './Details.vue';
import Navbar from '../../public/Navbar.vue';
import Cart from '../../../layout/Cart.vue';
export default {
    name: "MisOrdenes",
    components: {
        Table,
        Search,
        Details,
        Navbar,
    Cart
    },
    setup() {

        const details = ref (null)
        const pedidoEditable = ref({});
        const pedidos = ref([])

        const toggleCartHandler =() =>{
      cart.value.toggleDrawer()
    }
    const cart = ref(null)
    const cartAmount = ref(0)
    const fetchCart = async  () => {
      await cart.value.fetchData()
      await cart.value.returnAmount()

    }
    const getAmount = (amount) => {
      cartAmount.value = amount
    }
        // State reactiva para el componente
        const state = reactive({
            visible: false,
            data: [],
            detailsVisible:false



        });

        const formatearFecha = (fecha) => {
            const fechaFormateada = new Date(fecha);
            const year = fechaFormateada.getFullYear();
            const month = String(fechaFormateada.getMonth() + 1).padStart(2, '0');
            const day = String(fechaFormateada.getDate()).padStart(2, '0');
            const hours = String(fechaFormateada.getHours()).padStart(2, '0');
            const minutes = String(fechaFormateada.getMinutes()).padStart(2, '0');
            return `${year}-${month}-${day} ${hours}:${minutes}`;
        };
         

        const fetchPedidos = async () => {
            try {
                const data = await pedidoService.getPedidosByUserId();
                state.data = data.map((d) => ({
                    ...d,
                }));
                pedidos.value = data.map((d) => ({
                    ...d,
                    fechaPedido: formatearFecha(d.fechaPedido)
                }));
                pedidos.value.forEach(p => {
                    delete p.userId
                })
            } catch (error) {
                //.error(error);
            }
        };



        const handleCloseDetails = () => {
            pedidoEditable.value = {}
            state.detailsVisible = false;
        };

        

        const table = reactive({
            headers: [ 'Email', 'Fecha de pedido', 'Estado', 'Total', "Direccion","Ciudad", "Código Postal","Celular",'Nro Pedido',],
            actions: {
              showDetails:{
                    id:"showDetails",
                    name: "showDetails",
                    icon:"fa fa-eye",
                    showName: false,
                    danger: false
                }
            },
        })


        const handleAction = ({ actionId, item }) => {
           if(actionId.id == "showDetails"){
                details.value.idPedido = item.id
                //.log(details.value.idPedido)    
                state.detailsVisible = true;
                details.value.getDetailsOrder()

            }
        };


        fetchPedidos();


        // Exponer las propiedades y funciones reactivas
        return {
            pedidoEditable,
            ...toRefs(state),
            table,
            handleAction
            ,
            fetchPedidos,
            formatearFecha,
            pedidos,
            details,
            handleCloseDetails,
            toggleCartHandler,
            cart,
            cartAmount,
            fetchCart,
            getAmount

        };
    }
};
</script>

<style></style>