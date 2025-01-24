<script>
// import SideBar from "../views/layout/SideBar.vue";
import SideBar from '@/views/layout/SideBar.vue'
import { ref, computed, onMounted} from 'vue';
import authService from '../../../../services/AuthService';
import router from '../../../../router';

export default {
  name: "Index",
  components: {
    SideBar
  },
  setup() {
    onMounted(() => {
      authService.getUserLogged().then(res => res.role != "Admin" ? router.push('/iniciar-sesion'): null)
    });
    const logout = () =>{
      authService.logout().then(res => router.push('/iniciar-sesion'))

    }

      return {
      visible: false,
      logout
    }
  },
};
</script>

<template >
  <div>

    <SideBar @logout="logout"/>
    <div class="p-4 sm:ml-64" :class="{'w-auto': visible}">
      <div
      
      class="p-4 mt-6">
      <router-view></router-view>
    </div>
  </div>
</div>
</template>

<style></style>
