<template>
  <div class="container">
    <router-view></router-view>
    <m-loading v-if="showLoading"></m-loading>
  </div>
</template>

<script>
export default {
  name: "ContainerEmployee",
   mounted() {
    // Loading trong 1 giây thì ẩn đi
    setTimeout(() => {
      this.showLoading = false;
    }, 1000);
  },
  data() {
    return {
      showLoading: true,
    };
  },
 
};
</script>

<style></style>