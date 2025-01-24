<script>
import { onMounted,ref } from 'vue'
import Servicios from "../public/Servicios.vue";
import Industria from "../public/Industria.vue";
import Toast from '../../components/Toast.vue';
import Hero from "../public/Hero.vue";
import Actualizaciones from "../public/Actualizaciones.vue";
import Contacto from "../public/Contacto.vue";
import Nosotros from "../public/Nosotros.vue";
import Productos from "../public/Productos.vue";
import Resennas from "../public/Resennas.vue";
import Cart from '../../layout/Cart.vue';
import Navbar from "../public/Navbar.vue"
import Footer from "./Footer.vue";
import Tienda from "../public/Tienda.vue"
export default {
  name: "Landing",
  components: {
    Navbar,
    Hero,
    Servicios,
    Actualizaciones,
    Contacto,
    Industria,
    Nosotros,
    Productos,
    Resennas,
    Footer,
    Tienda,
    Cart,
    Toast
  },
  setup(props, { emit }) {
    const cart = ref(null)
    const cartAmount = ref(0)
    const showToast = ref(false)
    const toggleCartHandler =() =>{
      cart.value.toggleDrawer()

      // //.log("asd")
    }
    const fetchCart = async  () => {
      await cart.value.fetchData()
      await cart.value.returnAmount()

    }
    const getAmount = (amount) => {
      cartAmount.value = amount
    }
    const closeToast = () => {

      showToast.value = false
    }
    onMounted(() => {
      const hash = window.location.hash;
      if (hash) {
        const section = hash.substring(1); // Eliminar el símbolo de almohadilla (#)
        const element = document.getElementById(section);
        if (element) {
          element.scrollIntoView({ behavior: 'smooth' });
        }
      }
      if(hash == '#inicio'){
        showToast.value = true;
      }
    })
    return {
      visible: false,
      toggleCartHandler,
      cart,
      cartAmount,
      fetchCart,
      getAmount,
      showToast,
      closeToast
        }
  },
};
</script>

<template>
  <Navbar :cartAmount="cartAmount" @fetchCart="fetchCart" :inLanding="true" @toggleCart="toggleCartHandler"></Navbar>
  <Cart @getAmount="getAmount" ref="cart"></Cart>
  <Toast :message="'Ya puede comenzar a comprar productos'" :visible="showToast"  @closeModal="closeToast"></Toast>
  <Hero></Hero>
  <Nosotros id="nosotros"></Nosotros>
  <Servicios id="servicios"></Servicios>
  <Productos id="productos"></Productos>
  <Resennas></Resennas>
  <Industria id="industria"></Industria>
  <Actualizaciones id="noticias"></Actualizaciones>
  <Contacto id="contacto"></Contacto>
  <Footer></footer>
  <!-- <div class="p-4 sm:ml-64" :class="{'w-auto': visible}">
    <div
      class="p-4 mt-6">
      <router-view></router-view>
    </div>
  </div> -->
</template>

<style scoped>
/* Estilos adicionales si necesitas ajustes fuera de Tailwind */
</style>

