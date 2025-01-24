<!-- <template>
    <div class="mx-auto min-h-screen">
      <div class="flex h-full flex-col justify-center py-6">
        <div class="flex flex-col md:flex-row flex-1 gap-4">
          <div class="space-y-6 md:p-16 h-auto flex gap-3 flex-col justify-between">
            <div class="bg-white m-8">
              <p class="text-3xl font-bold mb-14 text-gray-800">Noticias:</p>
              <p class="text-2xl text-gray-600 leading-loose">
                Publicaciones reciente sobre novedades relacionadas con la legalización del cannabis, avances médicos y noticias de la asociación
                <br />
                Calendario de eventos próximos y pasados, incluyendo charlas, seminarios y actividades relacionadas con el cannabis.
              </p>
            </div>
            <div class="relative md:ml-8 ">
              <div class="flex  overflow-x-scroll no-scrollbar  items-start ">
                <div
                  v-for="(tarjeta, index) in publicaciones"
                  :key="index"
                  class="flex-none w-full md:w-1/2 border flex flex-col items-center"
                >
                  <div class="h-full w-full ">
                    <img :src="tarjeta.imagenPrincipal" class="w-full h-full object-cover transition-transform duration-300" alt="" />
                  </div>
                  <div class="p-4 text-center">
                    <p class="font-bold text-xl mb-4">{{ tarjeta.titulo }}</p>
                    <p class="text-2m">{{ tarjeta.descripcion }}</p>
                  </div>
                </div>
              </div>
              <button @click="prev" class="absolute left-0 top-1/2 transform -translate-y-1/2 bg-gray-800 text-white p-2">
                <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 19l-7-7 7-7" />
                </svg>
              </button>
              <button @click="next" class="absolute right-0 top-1/2 transform -translate-y-1/2 bg-gray-800 text-white p-2">
                <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5l7 7-7 7" />
                </svg>
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </template> -->
<template>
  <div class="mx-auto min-h-screen">
    <div class="flex h-full flex-col justify-center py-6">
      <div class="flex flex-col md:flex-row flex-1 gap-4">
        <div class="space-y-6 md:p-16 h-auto flex gap-3 flex-col justify-between">
          <div class="bg-white m-8">
            <p class="text-3xl font-bold mb-14 text-gray-800">Noticias:</p>
            <p class="text-2xl text-gray-600 leading-loose">
              Publicaciones reciente sobre novedades relacionadas con la legalización del cannabis, avances médicos y
              noticias de la asociación
              <br />
              Calendario de eventos próximos y pasados, incluyendo charlas, seminarios y actividades relacionadas con el
              cannabis.
            </p>
          </div>
          <div id="controls-carousel" class="relative w-full" data-carousel="static">
            <div class="flex  overflow-x-scroll no-scrollbar items-start h-full">
              <div v-for="(tarjeta, index) in publicaciones" :key="index"
                class="flex-none w-full md:w-1/2 border flex flex-col items-center h-full">

                <div class="w-full ">
                  <img :src="tarjeta.imagenPrincipal"
                    class="w-full h-full object-cover transition-transform duration-300" alt="" />
                </div>
                <div class="p-4 h-full text-center flex justify-between flex-col">
                  <p class="font-bold text-xl mb-4">{{ tarjeta.titulo }}</p>
                  <div class="flex justify-end">
                    <router-link :to="`/noticia/${changeSpaces(tarjeta.titulo)}`">
                      <button type="button" class="text-gray-900 bg-white border border-gray-300 focus:outline-none hover:bg-gray-100
                         focus:ring-4 focus:ring-gray-200 font-medium rounded-lg text-sm p-8 py-2.5 me-2 mb-2
                          dark:bg-gray-800 dark:text-white dark:border-gray-600 dark:hover:bg-gray-700
                           dark:hover:border-gray-600 dark:focus:ring-gray-700">
                        Ver más</button>
                    </router-link>
                  </div>
                  <!-- <p class="text-2m">{{ tarjeta.descripcion }}</p> -->
                </div>
              </div>
            </div>
            <button @click="prev" class="absolute left-0 top-1/2 transform -translate-y-1/2 bg-gray-800 text-white p-2">
              <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24"
                stroke="currentColor">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 19l-7-7 7-7" />
              </svg>
            </button>
            <button @click="next"
              class="absolute right-0 top-1/2 transform -translate-y-1/2 bg-gray-800 text-white p-2">
              <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24"
                stroke="currentColor">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5l7 7-7 7" />
              </svg>
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>



<script setup>
import { ref, onMounted, onUnmounted } from 'vue';
import publicacionService from "../../../services/publicacionService";


const publicaciones = ref([]);
const currentIndex = ref(0);

const getPublicaciones = async () => {
  const res = await publicacionService.getPublicaciones();
  publicaciones.value = res;
};

onMounted(async () => {
  await getPublicaciones();
  startAutoScroll();
});

onUnmounted(() => {
  clearInterval(autoScrollInterval);
});

const prev = () => {
  if (currentIndex.value > 0) {
    currentIndex.value--;
  } else {
    currentIndex.value = publicaciones.value.length - 1;
  }
  updateScroll();
};

const next = () => {
  if (currentIndex.value < publicaciones.value.length - 1) {
    currentIndex.value++;
  } else {
    currentIndex.value = 0;
  }
  updateScroll();
};
const changeSpaces = (texto) => {
  return texto.replace(/ /g, '-');
}

const updateScroll = () => {
  const slider = document.querySelector('.overflow-x-scroll');
  slider.scrollTo({
    left: currentIndex.value * slider.clientWidth,
    behavior: 'smooth'
  });
};

let autoScrollInterval;

const startAutoScroll = () => {
  autoScrollInterval = setInterval(next, 10000);
};


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
