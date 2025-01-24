<script>
import SideBar from "./views/layout/SideBar.vue";

export default {
  name: "App",
  components: {
    SideBar,
  },
  data() {
    return {
      visible: false
    }
  },
  
}

</script>

<template>

  <!-- <SideBar></SideBar> -->
  <!-- <div class="p-4 sm:ml-64" :class="{'w-auto': visible}">
    <div
      class="p-4 mt-6"> -->
      <router-view></router-view>
    <!-- </div>
  </div> -->
</template>

<style></style>
