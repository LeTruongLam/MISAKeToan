<template>
  <label class="combobox" id="combobox">
    <div class="combobox-wrapper">
      <a @click="closeCombobox" v-for="item in items"  :key="item" href="#">{{ item }}</a>
    </div>
  </label>
</template>
<script>
export default {
  name: "MisaCombobox",
  props: {
    items: {
      type: Array,
      required: true,
    },
  },
  methods:{
    // Đóng combobox
    closeCombobox(){
        this.$emit("onClose");
    }
  }
  ,
  data() {
    return {};
  },
};
</script>
<style scoped></style>
