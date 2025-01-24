<template>
    <div class="flex h-screen flex-col">

        <Navbar :inLanding="false" :cartAmount="cartAmount" @fetchCart="fetchCart" @toggleCart="toggleCartHandler">
        </Navbar>
        <Cart @getAmount="getAmount" ref="cart"></Cart>

        <div class="flex flex-col h-full md:pl-6  ">


            <div class="mb-4 border-b border-gray-200 dark:border-gray-700">
                <ul class="flex flex-wrap -mb-px text-sm font-medium text-center" id="default-styled-tab"
                    data-tabs-toggle="#tab-content" role="tablist">
                    <li class="me-2" role="presentation">
                        <button class="inline-block p-4 border-b-2 rounded-t-lg" id="pedido-btn"
                            data-tabs-target="#pedido" type="button" role="tab" aria-controls="profile"
                            aria-selected="false" disabled>Pedido</button>
                    </li>
                    <li class="me-2" role="presentation">
                        <button class="inline-block p-4 border-b-2 rounded-t-lg hover:text-gray-600
                             hover:border-gray-300 dark:hover:text-gray-300" id="datos-btn" data-tabs-target="#datos"
                            type="button" role="tab" aria-controls="datos" aria-selected="false" disabled>Datos</button>
                    </li>
                    <li class="me-2" role="presentation">
                        <button
                            class="inline-block p-4 border-b-2 rounded-t-lg hover:text-gray-600 hover:border-gray-300 dark:hover:text-gray-300"
                            id="pago-btn" data-tabs-target="#pago" type="button" role="tab" aria-controls="pagos"
                            disabled aria-selected="false">Pago</button>
                    </li>

                </ul>
            </div>
            <div id="tab-content">
                <div class="hidden  rounded-lg p-8" id="pedido" role="tabpanel" aria-labelledby="profile-tab">
                    <Order ref="order" :insumos="cartData" @getCart="fetchCart"  @goNextSection="goNextSection"></Order>
                </div>
                <div class="hidden p-4 rounded-lg bg-gray-50 dark:bg-gray-800" id="datos" role="tabpanel"
                    aria-labelledby="dashboard-tab">
                    <UserInfo ref="user" @goNextSection="goNextSection" @initBrick="initBrick"></UserInfo>
                </div>
                <div class="hidden p-4 rounded-lg bg-gray-50 dark:bg-gray-800" id="pago" role="tabpanel"
                    aria-labelledby="settings-tab">
                  <Payment :userInfo="userData" :cartId="cartId" ref="payment" :insumos="cartData" ></Payment>
                </div>

            </div>
        </div>
    </div>

</template>
<script>
import Navbar from '../public/Navbar.vue';
import Cart from '../../layout/Cart.vue';
import Order from './Order.vue';
import UserInfo from './UserInfo.vue'
import { ref, onMounted } from 'vue'
import { Tabs } from 'flowbite';
import Payment from './Payment.vue';
export default {
    name: "PaymentGateway",
    components: {
        Navbar,
        Cart,
        Order,
        UserInfo,
        Payment

    },
    setup() {
        const cart = ref(null)
        const user =ref()
        const userData = ref({})
        const cartId = ref ()
        const payment= ref(null)
        const cartAmount = ref(0)
        const tabs = ref()
        const cartData = ref()
        const toggleCartHandler = () => {
            cart.value.toggleDrawer()
        }
        const fetchCart = async () => {
            await cart.value.fetchData()
            await cart.value.returnAmount()
            cartData.value = cart.value.insumos
        }
        const getAmount = (amount) => {
            cartAmount.value = amount
        }
        const initTabs = () => {

            // create an array of objects with the id, trigger element (eg. button), and the content element
            const tabElements = [
                {
                    id: 'pedido-tab',
                    triggerEl: document.getElementById('pedido-btn'),
                    targetEl: document.getElementById('pedido'),
                },
                {
                    id: 'datosTab',
                    triggerEl: document.getElementById('datos-btn'),
                    targetEl: document.getElementById('datos'),
                },
                {
                    id: 'pagoTab',
                    triggerEl: document.getElementById('pago-btn'),
                    targetEl: document.getElementById('pago'),
                }

            ];

            // options with default values
            const options = {
                defaultTabId: 'settings',
                activeClasses:
                    'text-blue-600 hover:text-blue-600 dark:text-blue-500 dark:hover:text-blue-400 border-blue-600 dark:border-blue-500',
                inactiveClasses:
                    'text-gray-500 hover:text-gray-600 dark:text-gray-400 border-gray-100 hover:border-gray-300 dark:border-gray-700 dark:hover:text-gray-300',
                onShow: () => {
                    //.log('tab is shown');
                },
            };

            // instance options with default values
            const instanceOptions = {
                id: 'tab-content',
                override: true
            };

            tabs.value = new Tabs(tabElements, options, instanceOptions);
            //.log(tabs.value)
        }
        const goNextSection = (sec) => {
            tabs.value.show(sec)
        }
        const initBrick = async (sec) => {
            payment.value.initBrick()
            cartId.value = cart.value.cartId
            userData.value = user.value.userData
            goNextSection(sec)
        }
        onMounted(async () => {
            initTabs()
        })
        return {
            toggleCartHandler,
            cartAmount,
            cart, fetchCart, getAmount,
            tabs, initTabs, goNextSection,
            cartData,
            payment,initBrick,cartId,user,userData

        }
    }
}
</script>
