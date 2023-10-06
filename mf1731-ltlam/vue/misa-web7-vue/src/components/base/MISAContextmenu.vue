<template>
  <div class="contextmenu" id="contextmenu" ref="contextmenu">
    <div class="contextmenu-wrapper">
      <a v-for="(item, index) in menuItems" @click="onItemClick(index)" :key="item">{{ item }}</a>
    </div>
  </div>
</template>

<script>
export default {
  name: "MisaContextMenu",
  props: {
    menuItems: {
      type: Array,
      required: true,
    },
  },
  methods: {
    onItemClick(index) {
      this.$emit("onItemClick", index);
    },
    closeContextMenu() {
      this.$emit("onClose");
    },
    onCloseContextMenu(event) {
      if (!this.$refs.contextmenu.contains(event.target)) {
        this.closeContextMenu();
      }
    },
  },
  mounted() {
    document.addEventListener("click", this.onCloseContextMenu);
  },
  beforeUnmount() {
    document.removeEventListener("click", this.onCloseContextMenu);
  },
};
</script>

<style scoped>
.contextmenu {
  z-index: 100000000000000000000;
}

.contextmenu-wrapper a {
  color: #000;
}

.contextmenu-wrapper a:hover {
  color: #fff;
}
</style>