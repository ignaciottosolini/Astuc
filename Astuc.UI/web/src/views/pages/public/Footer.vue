<template>
  <footer class="md:h-24 bg-white rounded-lg shadow mt-4 dark:bg-gray-800 font-bold ">
    <div class="w-full mx-auto max-w-screen-xl p-4 gap-5  flex md:items-center md:justify-between justify-center md:flex-nowrap flex-wrap">
      <a href="/" class="flex items-center  w-24 z-50 space-x-3 rtl:space-x-reverse" title="Inicio - ASTUC">
        <img :src="logoUrl" alt="Logo de ASTUC" class="">
      </a>


      <ul
        class="flex flex-wrap gap-2 items-center mt-3 text-sm font-medium text-gray-500 dark:text-gray-400 sm:mt-0 font-bold ">
        <li v-for="item in menuItems" :key="item.text">
          <a :href="item.href" class="hover:underline me-4 md:me-6" :title="'Ir a ' + item.text">{{ item.text }}</a>
        </li>
      </ul>

      <span class="text-sm text-gray-500 sm:text-center dark:text-gray-400">
        Copyright © {{ currentYear }} ASTUC | Todos los Derechos Reservados.
      </span>
    </div>
  </footer>
</template>

<script setup>
import { ref, computed } from 'vue';
import logoFooter from '../../../assets/logoFooter.jpg';

const logoUrl = logoFooter;

const menuItems = ref([
  { text: 'Quienes Somos', href: '#nosotros' },
  { text: 'Servicios', href: '#servicios' },
  { text: 'Productos', href: '#productos' },
  { text: 'Industria', href: '#industria' },
  { text: 'Noticias', href: '#noticias' },
  { text: 'Contacto', href: '#contacto' },
]);

const currentYear = computed(() => new Date().getFullYear());
</script>