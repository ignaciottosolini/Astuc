<template>
    <Navbar  :cartAmount="cartAmount" @fetchCart="fetchCart" @toggleCart="toggleCartHandler"></Navbar>
    <Cart @getAmount="getAmount" ref="cart"></Cart>

    <div class="min-h-screen mx-auto container pt-16 ">
        <div class="flex flex-col h-full justify-center gap-8 ">

            <div class="text-center">
                <h2 class="text-[48px]">Membresías</h2>
                <p class="text-xl">Descubrí las ventajas de nuestras membresías exclusivas para socios de ASTUC</p>
            </div>
            <div class="flex items-center flex-col gap-4">
                <div v-for="(card, index) in cards" class="md:w-1/2 h-fit rounded-xl  p-4 flex flex-col gap-3">
                    <button
                        class="bg-black text-white py-4 px-6 rounded-xl flex justify-center items-center text-center">
                        <i><svg class="w-8 h-8 text-white dark:text-white" aria-hidden="true"
                                xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 24 24">
                                <path fill-rule="evenodd"
                                    d="M8 10V7a4 4 0 1 1 8 0v3h1a2 2 0 0 1 2 2v7a2 2 0 0 1-2 2H7a2 2 0 0 1-2-2v-7c0-1.1.9-2 2-2h1Zm2-3a2 2 0 1 1 4 0v3h-4V7Zm2 6c.6 0 1 .4 1 1v3a1 1 0 1 1-2 0v-3c0-.6.4-1 1-1Z"
                                    clip-rule="evenodd" />
                            </svg>
                        </i><span class="mt-1">{{ card.plan }}</span>
                    </button>
                </div>

            </div>
        </div>

    </div>
</template>
<script setup>
import { ref } from 'vue'
import Navbar from './Navbar.vue';
import Cart from '../../layout/Cart.vue';
components:{
    Navbar,
    Cart
}
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
const cards = ref([
    {

        plan: 'Basico',
        precio: 19,
        descripcion: 'Dictum aliquet arcu egestas massa sed tellus sed arcu velit tincidunt orci.',
        incluye: ['Manage 1.000 suscribers', '10 landing pages', 'Customizable domain', '15 + integrations', 'Basic support']
    },
    {
        plan: 'Medio',
        precio: 49,
        descripcion: 'Dictum aliquet arcu egestas massa sed tellus sed arcu velit tincidunt orci.',
        incluye: ['Manage 2.500 suscribers', '50 landing pages', 'Customizable domain', '25 + integrations', 'Normal support']
    },
    {
        plan: 'Premium',
        precio: 99,
        descripcion: 'Dictum aliquet arcu egestas massa sed tellus sed arcu velit tincidunt orci.',
        incluye: ['Unlimited suscribers', 'Unlimited landing pages', 'Customizable domain', '150 + integrations', 'Personalized support']
    }
])
</script>