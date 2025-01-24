<script>
import authService from '../../services/AuthService';
  export default {
  emits: ['logout'],

    setup(props,{emit}) {
      const showSidebar= () =>{
        this.showNav = !this.showNav
      },
      logout = () =>{
        emit('logout')
      }
    
      return {
        showNav: true,
        logout
        // SubMenu: false
      }
    },
    methods:{
      
      // showSubMenu(){
      //   this.SubMenu = !this.SubMenu
      // }
    }
  };
</script>

<template>

  <nav class="relative top-0 z-50 w-full bg-white border-b border-gray-200">
    <div class="px-3 py-3 lg:px-5 lg:pl-3">
      <div class="flex items-center justify-between">
        <div class="flex items-center justify-start">
          <a href="#" class="flex ml-5 md:mr-24">
            
            <span class="self-center text-xl font-semibold whitespace-nowrap dark:text-white">Astuc Admin</span>

          </a>
        </div>
        <div class="flex items-center">
          <div class="flex items-center ml-3">
          </div>
        </div>
      </div>
    </div>
  </nav>

  <button v-on:click="showSidebar" class="z-50 ml-8 mt-6 top-0 inline-flex items-center text-sm text-gray-500 rounded-lg sm:hidden hover:bg-gray-100 focus:outline-none focus:ring-2 focus:ring-gray-200  ">
    <svg class="w-6 h-6" aria-hidden="true" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
        <path clip-rule="evenodd" fill-rule="evenodd" d="M2 4.75A.75.75 0 012.75 4h14.5a.75.75 0 010 1.5H2.75A.75.75 0 012 4.75zm0 10.5a.75.75 0 01.75-.75h7.5a.75.75 0 010 1.5h-7.5a.75.75 0 01-.75-.75zM2 10a.75.75 0 01.75-.75h14.5a.75.75 0 010 1.5H2.75A.75.75 0 012 10z"></path>
    </svg>
  </button>

  <aside class="border fixed top-0 left-0 z-40 w-64 h-screen transition-transform "
        :class="{'sm:translate-x-0 -translate-x-full': showNav}" >
    <div class="h-full px-3 py-4 overflow-y-auto bg-gray-50 ">
        <ul class="space-y-2 font-medium mt-12 sm:mt-20">
            <li>
                <button v-on:click="showSidebar" class="z-50 ml-5 mt-3 top-0 inline-flex items-center text-sm text-gray-500 rounded-lg sm:hidden hover:bg-gray-100 focus:outline-none focus:ring-2 focus:ring-gray-200  ">
                    <svg class="w-6 h-6" aria-hidden="true" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                        <path clip-rule="evenodd" fill-rule="evenodd" d="M2 4.75A.75.75 0 012.75 4h14.5a.75.75 0 010 1.5H2.75A.75.75 0 012 4.75zm0 10.5a.75.75 0 01.75-.75h7.5a.75.75 0 010 1.5h-7.5a.75.75 0 01-.75-.75zM2 10a.75.75 0 01.75-.75h14.5a.75.75 0 010 1.5H2.75A.75.75 0 012 10z"></path>
                    </svg>
                </button>
            </li>
            <!--<li>
                <router-link to="/">
                    <a href="#"
                       class="flex items-center p-2 ml-4 text-gray-900 rounded-lg hover:bg-gray-100">
                        <svg class="w-5 h-5 text-gray-500 transition duration-75  group-hover:text-gray-900 " aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 22 21">
                            <path d="M16.975 11H10V4.025a1 1 0 0 0-1.066-.998 8.5 8.5 0 1 0 9.039 9.039.999.999 0 0 0-1-1.066h.002Z" />
                            <path d="M12.5 0c-.157 0-.311.01-.565.027A1 1 0 0 0 11 1.02V10h8.975a1 1 0 0 0 1-.935c.013-.188.028-.374.028-.565A8.51 8.51 0 0 0 12.5 0Z" />
                        </svg>
                        <span class="ml-4">Dashboard</span>
                    </a>
                </router-link>
            </li>-->
            <li>
                <router-link to="/admin/insumos">
                    <a href="#"
                       class="flex items-center p-2 ml-3 text-gray-900 rounded-lg hover:bg-gray-100">
                        <svg aria-hidden="true"
                             class="w-6 h-6 text-gray-500 transition duration-75 group-hover:text-gray-900"
                             fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                            <path fill-rule="evenodd" d="M10 9a3 3 0 100-6 3 3 0 000 6zm-7 9a7 7 0 1114 0H3z" clip-rule="evenodd">
                            </path>
                        </svg>
                        <span class="ml-4">Insumos</span>
                    </a>
                </router-link>
            </li>
            <li>
                <router-link to="/admin/usuarios">
                    <a href="#"
                       class="flex items-center p-2 ml-3 text-gray-900 rounded-lg hover:bg-gray-100">
                        <svg aria-hidden="true"
                             class="w-6 h-6 text-gray-500 transition duration-75 group-hover:text-gray-900"
                             fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                            <path fill-rule="evenodd" d="M10 9a3 3 0 100-6 3 3 0 000 6zm-7 9a7 7 0 1114 0H3z" clip-rule="evenodd">
                            </path>
                        </svg>
                        <span class="ml-4">Usuarios</span>
                    </a>
                </router-link>
            </li>
            <!--<li>
                <RouterLink to="/admin/eventos">
                    <a href="#"
                       v-on:click="showSubMenu"
                       class="flex items-center p-2 ml-4 text-gray-900 rounded-lg hover:bg-gray-100">
                        <i class="fas fa-receipt fa-lg text-gray-500 transition duration-75  group-hover:text-gray-900"></i>
                        <span class="ml-5">Eventos</span>
                    </a>
                </RouterLink>
            </li>-->
            <li>
                <RouterLink to="/admin/publicaciones">
                    <a href="#"
                       v-on:click="showSubMenu"
                       class="flex items-center p-2 ml-4 text-gray-900 rounded-lg hover:bg-gray-100">
                        <i class="fas fa-pen fa-lg text-gray-500 transition duration-75  group-hover:text-gray-900"></i>                                                
                        <span class="ml-5">Publicaciones</span>
                    </a>
                </RouterLink>
            </li>
            <li>
                <RouterLink to="/admin/pedidos">
                    <a href="#"
                       v-on:click="showSubMenu"
                       class="flex items-center p-2 ml-4 text-gray-900 rounded-lg hover:bg-gray-100">
                        <i class="fas fa-pen fa-lg text-gray-500 transition duration-75  group-hover:text-gray-900"></i>                                                
                        <span class="ml-5">Pedidos</span>
                    </a>
                </RouterLink>
            </li>
            <!-- <li>
                <router-link to="/categorias">
                    <a href="#"
                       class="flex items-center p-2 ml-3 text-gray-900 rounded-lg hover:bg-gray-100">
                        <svg class="w-5 h-5 text-gray-500 dark:text-white" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 20 14">
                            <path d="M18 0H2a2 2 0 0 0-2 2v10a2 2 0 0 0 2 2h16a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2ZM9 6v2H2V6h7Zm2 0h7v2h-7V6Zm-9 4h7v2H2v-2Zm9 2v-2h7v2h-7Z" />
                        </svg>
                        <span class="ml-4">Categorias</span>
                    </a>
                </router-link>
            </li>
            <li>
                <router-link to="/localidades">
                    <a href="#"
                       class="flex items-center p-2 ml-3 text-gray-900 rounded-lg hover:bg-gray-100">
                       <svg class="w-5 h-5 text-gray-500 dark:text-white" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 16 20">
    <path d="M8 0a7.992 7.992 0 0 0-6.583 12.535 1 1 0 0 0 .12.183l.12.146c.112.145.227.285.326.4l5.245 6.374a1 1 0 0 0 1.545-.003l5.092-6.205c.206-.222.4-.455.578-.7l.127-.155a.934.934 0 0 0 .122-.192A8.001 8.001 0 0 0 8 0Zm0 11a3 3 0 1 1 0-6 3 3 0 0 1 0 6Z"/>
  </svg>
                        <span class="ml-4">Localidades</span>
                    </a>
                </router-link>
            </li>
            <li>
                <router-link to="/productos">
                    <a href="#"
                       class="flex items-center p-2 ml-3 text-gray-900 rounded-lg hover:bg-gray-100">
                       <svg class="w-5 h-5 text-gray-500 dark:text-white" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 20 16">
                        <path d="M19 0H1a1 1 0 0 0-1 1v2a1 1 0 0 0 1 1h18a1 1 0 0 0 1-1V1a1 1 0 0 0-1-1ZM2 6v8a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V6H2Zm11 3a1 1 0 0 1-1 1H8a1 1 0 0 1-1-1V8a1 1 0 0 1 2 0h2a1 1 0 0 1 2 0v1Z"/>
                      </svg>
                        <span class="ml-4">Productos</span>
                    </a>
                </router-link>
            </li>
            <li>
                <router-link to="/ordenesV2">
                    <a href="#"
                       class="flex items-center p-2 ml-3 text-gray-900 rounded-lg hover:bg-gray-100">
                       <svg class="w-5 h-5 text-gray-500 dark:text-white" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 20 16">
                        <path d="M19 0H1a1 1 0 0 0-1 1v2a1 1 0 0 0 1 1h18a1 1 0 0 0 1-1V1a1 1 0 0 0-1-1ZM2 6v8a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V6H2Zm11 3a1 1 0 0 1-1 1H8a1 1 0 0 1-1-1V8a1 1 0 0 1 2 0h2a1 1 0 0 1 2 0v1Z"/>
                      </svg>
                        <span class="ml-4">Ordenes</span>
                    </a>
                </router-link>
            </li> -->
            <li>
                    <a v-on:click="logout()"
                       class="flex items-center p-2 ml-3 text-gray-900 rounded-lg hover:bg-gray-100">

                        <svg class="w-5 h-5 text-gray-500 transition duration-75 group-hover:text-gray-900 " aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 18 16">
                            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M1 8h11m0 0L8 4m4 4-4 4m4-11h3a2 2 0 0 1 2 2v10a2 2 0 0 1-2 2h-3" />
                        </svg>

                        <span class="ml-5">Cerra Sesión</span>
                    </a>
            </li>
        </ul>
    </div>
  </aside>


</template>