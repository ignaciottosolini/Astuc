<template>
  <div class="mx-auto min-h-screen">
    <div class="flex h-full flex-col justify-center py-6">
      <div class="text-center mb-6 mt-2">
        <h2 class="text-4xl font-bold text-gray-800">Industria</h2>
        <p class="text-2xl text-gray-600 mt-2">Parcelas disponibles para la investigación y desarrollo de la industria cannábica</p>
      </div>
      <div class="flex flex-col md:flex-row flex-1 max-sm:grid-rows-2 gap-4">
        <div class="space-y-6 md:p-16 h-auto flex gap-3 flex-col justify-between md:w-1/2">

          <div class="bg-white m-8 md:text-left text-center">
            <h4 class="text-2xl font-bold mb-14 text-gray-800">Desarrollo de Investigaciones</h4>
            <p class="text-2xl text-gray-600 leading-loose">Brindamos espacios dedicados para investigadores, empresas y emprendedores comprometidos 
              con el avance de la ciencia y tecnología del cannabis. Estas parcelas ofrecen un entorno propicio para estudios detallados, pruebas genéticas y experimentación, 
              todo respaldado por instalaciones de vanguardia y un equipo comprometido en facilitar el progreso sostenible de la industria.</p>
              <div class="">
                <router-link to="">
                    <button type="button"
                        class="text-gray-900 bg-white border border-gray-300 focus:outline-none hover:bg-gray-100 focus:ring-4 focus:ring-gray-200 
                        font-medium rounded-lg text-sm p-8 py-2.5 me-2 mb-2 dark:bg-gray-800 dark:text-white dark:border-gray-600 dark:hover:bg-gray-700 
                        dark:hover:border-gray-600 dark:focus:ring-gray-700">Más Información
                        </button>
                </router-link>
            </div>
          </div>
          
        </div>

        <div class="mt-6 mb-6 md:w-1/2 md:mr-20 flex justify-center items-center">
          <img src="../../../assets/image4.png" alt="Imagen representativa" class="rounded-lg shadow-xl max-w-full h-auto" />
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

</script>
  
<style scoped>
/* Aquí puedes añadir estilos adicionales si es necesario, aunque Tailwind CSS manejará la mayoría */

</style>
  