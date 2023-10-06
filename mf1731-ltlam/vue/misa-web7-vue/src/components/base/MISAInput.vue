<template>
  <p class="text-boil" v-if="showTitle">
    {{ title }}
    <span v-if="showNote">*</span>
  </p>

  <div class="search-bar">
    <input type="text" placeholder="" v-model="inputValue" :tabIndex="tabIndex" />
    <label v-if="showIcon" for="search-box" class="down-icon-black"></label>
  </div>
  <!-- <label v-if="showNote" class="validate-form">{{ title }} không được để trống</label> -->
</template>

<script>
export default {
  name: "MInput",
  props: {
    showNote: {
      type: Boolean,
      default: false,
    },
    title: {
      type: String,
      required: true,
    },
    showTitle: {
      type: Boolean,
      default: false,
    },
    showIcon: {
      type: Boolean,
      default: false,
    },
    tabIndex: {
      type: Number,
      default: 0,
    },
    getValue: {
      type: Function,
    },
  },
  data() {
    return {
      inputValue: "",
    };
  },
  watch: {
    inputValue(newValue) {
      // Gọi hàm getValue truyền giá trị inputValue cho component cha
      if (this.getValue) {
        this.getValue(newValue);
      }
    },
  },
};
</script>

<style></style>