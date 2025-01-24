<template>
  <div class="container mx-auto min-h-screen  ">
    <div class="flex h-full flex-col justify-center py-6">

      <div class="text-center mb-6 mt-2">
        <h2 class="text-4xl font-bold text-gray-800">Servicios para Socios:</h2>
        <p class="text-2xl text-gray-600 mt-2">Breve descripción</p>
      </div>
      <div class="flex flex-col md:flex-row flex-1 max-sm:grid-rows-2 gap-4 ">
        <div class="space-y-6 p-5 h-auto flex gap-3 flex-col justify-between md:w-3/4">


          <div v-for="servicio in servicios" :key="servicio.titulo" class="bg-white gap-3 ">
            <h4 class="text-xl font-bold mb-1 text-gray-800">{{ servicio.titulo }}</h4>
            <p class="text-xl text-gray-600">{{ servicio.descripcion }}</p>
          </div>
        </div>

        
      </div>
    </div>
  </div>
</template>
  
<script setup>
import { ref } from 'vue';

const servicios = ref([
  {
    titulo: 'Asesoramiento Legal y de Cultivo',
    descripcion: 'Descripción de los servicios legales y de cultivo proporcionados por expertos en la materia.'
  },
  {
    titulo: 'Médicos Especialistas en Cannabis',
    descripcion: 'Información sobre profesionales de la salud especializados en el uso médico del cannabis.'
  },
  {
    titulo: 'Gestión de Permisos Reprocan',
    descripcion: 'Explicación detallada de cómo ASTUC facilita la obtención de permisos legales para el cultivo y uso de cannabis.'
  },
  {
    titulo: 'Abogados Penalistas',
    descripcion: 'Servicios legales específicos para situaciones legales relacionadas con el cannabis.'
  },
  {
    titulo: 'Desarrollo de Investigaciones',
    descripcion: 'Descripción de proyectos de investigación apoyados por ASTUC y cómo los miembros pueden contribuir.'
  },
  {
    titulo: 'Charlas de Tenencia Responsable',
    descripcion: 'Información sobre eventos y charlas educativas promovidas por ASTUC para fomentar el uso responsable del cannabis.'
  }
  // Puedes agregar más servicios aquí si es necesario
]);

const imagenRandom = ref('https://source.unsplash.com/random/800x600');
</script>
  
<style scoped>
/* Aquí puedes añadir estilos adicionales si es necesario, aunque Tailwind CSS manejará la mayoría */

</style>
  