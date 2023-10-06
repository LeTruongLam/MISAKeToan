<template>
  <div class="search-bar">
    <input type="text" :placeholder="content" />
    <label for="search-box" class="search-icon"></label>
  </div>
</template>
<script>
export default {
  name: "MisaSearch",
  props: ["content"],
  methods: {},
  data() {
    return {};
  },
};
</script>

<style></style>
