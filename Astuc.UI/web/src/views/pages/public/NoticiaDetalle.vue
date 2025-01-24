<template>
    <Toast :visible="showToast" :message="toastMessage" @closeModal="closeToast"></Toast>
    <div class="h-screen flex flex-col">

        <Navbar :inLanding="false" :cartAmount="cartAmount" @fetchCart="fetchCart" @toggleCart="toggleCartHandler">
        </Navbar>
        <Cart @getAmount="getAmount" ref="cart">
        </Cart>
        

        <!-- Iteración sobre publicaciones -->
        <div class="grid grid-cols-1 lg:grid-cols-2 gap-4">
  <div class="flex justify-center items-center w-full h-auto mt-8">
    <img
      :src="publicacion.imagenPrincipal"
      class="w-full lg:w-3/4 h-auto object-cover transition-transform duration-300"
      alt=""
    />
  </div>
  <div class="p-3 text-center md:text-left lg:w-3/4 mt-6 mx-4 md:mx-6 lg:mx-8">
    <p class="font-bold text-2xl md:text-4xl mb-4">
      {{ publicacion.titulo }}
    </p>
    <p class="font-bold text-xl mb-4">{{ publicacion.descripcion }}</p>
  </div>
</div>


        



        <Footer></Footer>
    </div>
</template>

<script setup>
import { ref, onMounted, onUnmounted } from 'vue';
import publicacionService from "../../../services/publicacionService";
import Footer from './Footer.vue';
import Navbar from "../public/Navbar.vue";
import Toast from '../../components/Toast.vue';
import { eventBus } from './bus/publicacionBus';
import { useRoute } from 'vue-router';

const publicacion = ref({
    imagenPrincipal: '',titulo:'', descripcion:''
});
const currentIndex = ref(0);
const route = useRoute()




const getPublicacionByName = async (name) => {    
    await eventBus.value.getByNombreByBus(name).then(res => {  
        publicacion.value = res
    })
}

const changeDash = (texto) => {
            return texto.replace(/-/g, ' ');
        }


const noticiaWatcher = (id) => {
            getPublicacionByName(id);
        }



onMounted(async () => {
   
    
    await getPublicacionByName(changeDash(route.params.id));
    
   

});


</script>

<style scoped>
.no-scrollbar::-webkit-scrollbar {
    display: none;
}

.no-scrollbar {
    -ms-overflow-style: none;
    scrollbar-width: none;
}
</style>
