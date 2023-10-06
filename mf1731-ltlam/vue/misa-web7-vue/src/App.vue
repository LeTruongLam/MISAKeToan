<template>
  <div>
    <TheHeader></TheHeader>
    <TheSidebar></TheSidebar>
    <TheContainer></TheContainer>
  </div>
</template>

<script>
import TheSidebar from "./components/layout/TheSidebar.vue";
import TheHeader from "./components/layout/TheHeader.vue";
import TheContainer from "./components/layout/TheContainerMain.vue";
import "./css/main.css";


export default {
  name: "App",
  components: {
    TheHeader,
    TheSidebar,
    TheContainer,
  },

};
</script>

<style></style>
