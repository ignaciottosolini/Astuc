<template>
  <nav class="bg-[#020408] sticky w-full top-0 z-50 " ref="miNav">
    <div class="flex flex-wrap items-center gap-5 mx-auto p-4">
      <a href="/" class="flex items-center  w-24 space-x-3 rtl:space-x-reverse" title="Inicio - ASTUC">
        <img :src="logoUrl" alt="Logo de ASTUC" class="">
      </a>

      <button  type="button" id="btn-nav"
        class="basis-1/2 inline-flex items-center p-2 w-10 h-10 md:justify-center flex-1 justify-end grow text-sm text-gray-500 rounded-lg md:hidden focus:outline-none focus:ring-2 dark:text-gray-400 dark:hover:bg-gray-700 dark:focus:ring-gray-600"
        aria-controls="navbar-default" aria-expanded="false">
        <svg class="w-5 h-5" aria-hidden="true" fill="none" viewBox="0 0 17 14" xmlns="http://www.w3.org/2000/svg">
          <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
            d="M1 1h15M1 7h15M1 13h15" />
        </svg>
      </button>

      <div class="hidden w-full md:block md:w-auto" id="navbar-default">
        <ul
          class="font-medium flex flex-col p-4 md:p-0 mt-4 border rounded-lg md:flex-row md:space-x-8 rtl:space-x-reverse md:mt-0 md:border-0">
          <li v-for="nav in menuItems" :key="nav.text"
            class="text-gray-300 hover:text-white rounded-md py-2 text-sm font-medium">
            <router-link v-if="!inLanding" :to="`/${nav.href}`">

              <a :href="nav.href" class="block py-2 px-3 md:bg-transparent md:p-0" aria-current="page"
                :title="'Ir a ' + nav.text">{{ nav.text }}</a>

            </router-link>
            <a v-else href="" @click.prevent="scrollToSection(`${nav.href}`)" class="block py-2 px-3 md:bg-transparent md:p-0" aria-current="page"
              :title="'Ir a ' + nav.text">{{ nav.text }}</a>
          </li>
          <li v-if="userNotLogged" class="md:hidden block py-2 text-sm font-medium">
            <router-link to="/asociarse">
              <button class="rounded-lg bg-white p-2 font-bold text-black" title="Asociarse">Quiero asociarme</button>
            </router-link>
          </li>
          <li v-if="userNotLogged" class="md:hidden block py-2 text-sm font-medium">
            <router-link to="/iniciar-sesion">
              <button class="rounded-lg bg-[#365475] p-2 text-white" title="Iniciar Sesión">Iniciar Sesión</button>
            </router-link>
          </li>
        </ul>
      </div>
      <!-- Campo de Búsqueda -->
      <div class="relative">
        <div class="absolute inset-y-0 start-0 pl-2 flex items-center ps-3 pointer-events-none">
          <svg class="w-4 h-4 text-white" aria-hidden="true" fill="none" viewBox="0 0 20 20"
            xmlns="http://www.w3.org/2000/svg">
            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
              d="m19 19-4-4m0-7A7 7 0 1 1 1 8a7 7 0 0 1 14 0Z" />
          </svg>
        </div>
        <div class="relative">

          <input type="text" id="simple-search" v-model="searchQuery" autocomplete="off"
            class="bg-gray-600 border text-white text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full ps-10 p-2.5 pl-8"
            placeholder="Buscar" required>
          <div id="dropdown" v-if="insumosFiltrados.length > 0"
            class="z-50 fixed ml-4 mt-2 text-white bg-black divide-y divide-gray-100 rounded-lg shadow w-44 dark:bg-gray-700">
            <ul class="py-2 text-sm text-gray-700 dark:text-gray-200 rounded-md border border-white" aria-labelledby="dropdownDefaultButton">
              <li v-for="insumo in insumosFiltrados" class="flex items-center p-2 w-full" >
                <router-link :to="`/producto/${insumo.id}`" class="flex items-center ">

                <img :src="insumo.imagenPrincipal" class="w-[60px] h-[30px] rounded-full">

                <a href="#" class="block px-4 py-2 text-white">{{
                  insumo.nombre }}</a>
                </router-link>
              </li>

            </ul>
          </div>
        </div>

      </div>
      <div class="md:basis-1/4 justify-end gap-4 flex-1 flex">
        <a class="flex justify-end cursor-pointer relative" @click="toggleCart">
          <div v-if="cartAmount > 0"
            class="absolute inline-flex right-0 items-center justify-center w-6 h-6 text-xs font-bold text-white bg-blue-500 border-2 border-white rounded-full -top-2 -end-2 dark:border-gray-900">
            {{ cartAmount }}</div>
          <svg class="w-12 h-10 text-white" aria-hidden="true" fill="currentColor" viewBox="0 0 24 24"
            xmlns="http://www.w3.org/2000/svg">
            <path fill-rule="evenodd"
              d="M4 4c0-.6.4-1 1-1h1.5c.5 0 .9.3 1 .8L7.9 6H19a1 1 0 0 1 1 1.2l-1.3 6a1 1 0 0 1-1 .8h-8l.2 1H17a3 3 0 1 1-2.8 2h-2.4a3 3 0 1 1-4-1.8L5.7 5H5a1 1 0 0 1-1-1Z"
              clip-rule="evenodd" />
          </svg>
        </a>
        <div v-show="userNotLogged === false" class="w-12 h-10">
          <router-link to="/panel-usuario">
            <button class="bg-[#5981B2] w-full h-full rounded-md flex justify-center items-center"><i><svg
                  class="w-6 h-8 text-white" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor"
                  viewBox="0 0 24 24">
                  <path fill-rule="evenodd"
                    d="M12 4a4 4 0 1 0 0 8 4 4 0 0 0 0-8Zm-2 9a4 4 0 0 0-4 4v1c0 1.1.9 2 2 2h8a2 2 0 0 0 2-2v-1a4 4 0 0 0-4-4h-4Z"
                    clip-rule="evenodd" />
                </svg>
              </i></button>
          </router-link>

        </div>
        <div v-show="userNotLogged === true" class="hidden md:flex gap-4">
          <router-link to="/asociarse">
            <button class="rounded-lg bg-white p-2 font-bold text-black" title="Asociarse">Quiero asociarme</button>
          </router-link>
          <router-link to="/iniciar-sesion">
            <button class="rounded-lg bg-[#365475] p-2 text-white" title="Iniciar Sesión">Iniciar Sesión</button>
          </router-link>
        </div>
      </div>
    </div>
  </nav>
  <nav class="bg-[#020408]  hidden ">
    <div class="flex flex-wrap items-center gap-5 mx-auto p-4">
      <a href="/" class="flex items-center  w-24  space-x-3 rtl:space-x-reverse" title="Inicio - ASTUC">
        <img :src="logoUrl" alt="Logo de ASTUC" class="">
      </a>



      <div class="hidden w-full md:block md:w-auto" id="navbar-default">
        <ul
          class="font-medium flex flex-col p-4 md:p-0 mt-4 border rounded-lg md:flex-row md:space-x-8 rtl:space-x-reverse md:mt-0 md:border-0">
          <li v-for="nav in menuItems" :key="nav.text"
            class="text-gray-300 hover:text-white rounded-md py-2 text-sm font-medium">
            <router-link v-if="!inLanding" :to="`/${nav.href}`">

              <a :href="nav.href" class="block py-2 px-3 md:bg-transparent md:p-0" aria-current="page"
                :title="'Ir a ' + nav.text">{{ nav.text }}</a>
            </router-link>
            <a v-else :href="nav.href" class="block py-2 px-3 md:bg-transparent md:p-0" aria-current="page"
              :title="'Ir a ' + nav.text">{{ nav.text }}</a>
          </li>
          <li v-if="userNotLogged" class="md:hidden block py-2 text-sm font-medium">
            <router-link to="/asociarse">
              <button class="rounded-lg bg-white p-2 font-bold text-black" title="Asociarse">Quiero asociarme</button>
            </router-link>
          </li>
          <li v-if="userNotLogged" class="md:hidden block py-2 text-sm font-medium">
            <router-link to="/iniciar-sesion">
              <button class="rounded-lg bg-[#365475] p-2 text-white" title="Iniciar Sesión">Iniciar Sesión</button>
            </router-link>
          </li>
        </ul>
      </div>
      <!-- Campo de Búsqueda -->
      <div class="relative">
        <div class="absolute inset-y-0 start-0 pl-2 flex items-center ps-3 pointer-events-none">
          <svg class="w-4 h-4 text-white" aria-hidden="true" fill="none" viewBox="0 0 20 20"
            xmlns="http://www.w3.org/2000/svg">
            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
              d="m19 19-4-4m0-7A7 7 0 1 1 1 8a7 7 0 0 1 14 0Z" />
          </svg>
        </div>
        <div class="relative">

          <input type="text" id="simple-search"
            class="bg-gray-600 border text-white text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full ps-10 p-2.5 pl-8">


        </div>
      </div>
      <div class="md:basis-1/4 md:justify-end gap-4 flex-1 flex">
        <a class="flex justify-end">
          <svg class="w-12 h-10 text-white" aria-hidden="true" fill="currentColor" viewBox="0 0 24 24"
            xmlns="http://www.w3.org/2000/svg">
            <path fill-rule="evenodd"
              d="M4 4c0-.6.4-1 1-1h1.5c.5 0 .9.3 1 .8L7.9 6H19a1 1 0 0 1 1 1.2l-1.3 6a1 1 0 0 1-1 .8h-8l.2 1H17a3 3 0 1 1-2.8 2h-2.4a3 3 0 1 1-4-1.8L5.7 5H5a1 1 0 0 1-1-1Z"
              clip-rule="evenodd" />
          </svg>
        </a>
        <div v-show="userNotLogged === false" class="w-12 h-10">
          <router-link to="/panel-usuario">
            <button class="bg-[#5981B2] w-full h-full rounded-md flex justify-center items-center"><i><svg
                  class="w-6 h-8 text-white" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor"
                  viewBox="0 0 24 24">
                  <path fill-rule="evenodd"
                    d="M12 4a4 4 0 1 0 0 8 4 4 0 0 0 0-8Zm-2 9a4 4 0 0 0-4 4v1c0 1.1.9 2 2 2h8a2 2 0 0 0 2-2v-1a4 4 0 0 0-4-4h-4Z"
                    clip-rule="evenodd" />
                </svg>
              </i></button>
          </router-link>

        </div>
        <div v-show="userNotLogged === true" class="hidden md:flex gap-4">
          <router-link to="/asociarse">
            <button class="rounded-lg bg-white p-2 font-bold text-black" title="Asociarse">Quiero asociarme</button>
          </router-link>
          <router-link to="/iniciar-sesion">
            <button class="rounded-lg bg-[#365475] p-2 text-white" title="Iniciar Sesión">Iniciar Sesión</button>
          </router-link>
        </div>
      </div>
    </div>
  </nav>
</template>

<script>
import { ref, computed, onMounted, toRefs, onBeforeMount } from 'vue';
import { initFlowbite } from 'flowbite';
import LogoAstuc from '../../../assets/LogoAstuc.png';
import authService from '../../../services/AuthService';
import insumoService from '../../../services/insumoService';
import { Collapse } from 'flowbite'
export default {
  name: "Navbar",
  props: {
    inLanding: Boolean,
    cartAmount: Number
  },

  setup(props, { emit }) {
    const { inLanding, cartAmount } = toRefs(props)
    const searchQuery = ref()
    const userNotLogged = ref(null)
    const menuItems = ref([
      { text: 'Quienes Somos', href: '#nosotros' },
      { text: 'Servicios', href: '#servicios' },
      { text: 'Productos', href: '#productos' },
      { text: 'Industria', href: '#industria' },
      { text: 'Noticias', href: '#noticias' },
      { text: 'Contacto', href: '#contacto' },
    ]);
    const insumos = ref([])
    const logoUrl = LogoAstuc;
    const collapse = ref()
    const initCollapse = () => {
      const $targetEl = document.getElementById('navbar-default');

      // optionally set a trigger element (eg. a button, hamburger icon)
      const $triggerEl = document.getElementById('btn-nav');

      // optional options with default values and callback functions
      const options = {
        onCollapse: () => {
          // //.log('element has been collapsed');
        },
        onExpand: () => {
          // //.log('element has been expanded');
        },
        onToggle: () => {
          // //.log('element has been toggled');
        },
      };
      const instanceOptions = {
        id: 'targetEl',
        override: true
      };

       collapse.value = new Collapse($targetEl, $triggerEl, options, instanceOptions);

    }
   
    const toggleCart = () => {
      if(cartAmount.value == 0){
        window.location.href="/Tienda"
      }else{

        emit("toggleCart")
      }
    }
    const getInsumos = async () => {
      try {
       await insumoService.getAll().then(res => {
        insumos.value = res ? res : []
       })
        
      } catch (error) {
        //.lor(error)
      }
    }
    const miNav = ref()
    const scrollToSection = async (section) => {
      collapse.value.collapse()
      const sec = document.querySelector(section)
      if(sec){
      
        window.scrollTo({
          top: sec.offsetTop - miNav.value.offsetHeight,
          behavior: "smooth"
        });
      }
    }
    const insumosFiltrados = computed(() => {
      var searchTerm = searchQuery.value
      if (searchQuery.value && insumos.value.length > 0) {


        return insumos.value.filter((ins) => {
          return ins.nombre.toLowerCase().includes(searchTerm.toLowerCase())
        }
        )
      }
      return []


    });
    onBeforeMount(async () => {
      await authService.getUserLogged().then(res => {
        if (res && res.email) {
          userNotLogged.value = false
          emit("fetchCart")
          return
        }
        userNotLogged.value = true
        if (window.location.hash.length > 0 ) {
          scrollToSection(window.location.hash);
        }
      })
    }),
      onMounted(async () => {
        initCollapse()
        initFlowbite()
        getInsumos()
        if (window.location.hash.length > 0 ) {
          scrollToSection(window.location.hash);
        }
      }
      );
    return {
      menuItems,
      logoUrl,
      inLanding,
      userNotLogged,
      initCollapse,
      toggleCart,
      cartAmount,
      insumosFiltrados,
      insumos,
      searchQuery,
      scrollToSection,
      miNav,
    };
  }

}


</script>

<style scoped></style>