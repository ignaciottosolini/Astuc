<template>
  <div class="relative bg-blue-900 text-white">
    <!-- Hero Section -->
    

    <!-- Banner Section -->
    <div class="grid mx-auto h-[44vh] md:h-[95vh] md:grid-cols-2 md:grid-rows-2 bg-img2 bg-center">
      <div></div>
      <div></div>
      <!-- <div class="bg-opacity-75 p-10 ">
        <h1 class="text-xl md:text-3xl  mb-4 pl-5">{{ heroContent.title }}</h1>
        <h2 class="text-2xl pl-5 ">{{ heroContent.subtitle }}</h2>
      </div> -->
    </div>

    <!-- Bottom Section -->
    <!-- <div class="absolute bottom-0 left-0 w-full py-2 bg-black bg-opacity-50 text-sm">
      <div class="container mx-auto px-4 flex justify-between">
        <p>{{ bottomLeftText }}</p>
        <p>© {{ currentYear }} ASTUC</p>
      </div>
    </div> -->
  </div>
</template>

<script setup>
import { ref, computed } from 'vue';

// Datos dinámicos
const menuItems = ref([
  { text: 'Quienes Somos', href: '#nosotros' },
  { text: 'Noticias', href: '#noticias' },
  { text: 'Servicios', href: '#servicios' },
  { text: 'Contacto', href: '#contacto' },
  { text: 'Productos', href: '#productos' },
]);

const heroContent = ref({
  title: 'Banners con información relevante',
  subtitle: 'actualizada mensualmente',
});

const logoUrl = ref('../../../assets/logo.png');
const ctaText = ref('Quiero Asociarme'); // Texto dinámico para el botón de CTA
const ctaLink = ref('#'); // Enlace dinámico para el botón de CTA
const bottomLeftText = ref('Body'); // Texto dinámico para la sección inferior izquierda

// Año actual dinámico
const currentYear = computed(() => new Date().getFullYear());
</script>

<style scoped>
.bg-img1{
  background-image: url("../../../assets/image1.png");
  background-repeat: no-repeat;
  background-size: cover;
}
.bg-img2{
  background-image: url("../../../assets/astucopt.png");
  background-repeat: no-repeat;
  background-size: cover;
}

</style>
