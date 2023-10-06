<template>
  <div id="exclamation" class="form-hide">
    <div class="form-container">
      <div class="dialog-content">
        <div class="dialog-wrapper">
          <div class="dialog-title">
            <h1>{{ title }}</h1>
            <div class="close-icon" @click="onCloseDialog()"></div>
          </div>
          <div class="dialog-notification">
            <p
              :class="{
                'exclamation-icon': type === dialogType.typeInfo,
                'warning-icon': type === dialogType.typeWarning,
              }"
            ></p>
            <p>{{ content }}</p>
          </div>
          <div class="buttons">
            <a href="#">
              <button class="button" @click="onCloseDialog()">Đồng ý</button>
            </a>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "MisaDialog",
  props: ["title", "type", "content"],
  methods: {
    // Đóng Dialog
    onCloseDialog() {
      this.$emit("onClose");
    },
  },
  data() {
    return {
      // Các kiểu Dialog
      dialogType: {
        typeError: this.$MISAEnum["MISADialog"].Error.id,
        typeSuccess: this.$MISAEnum["MISADialog"].Success.id,
        typeWarning: this.$MISAEnum["MISADialog"].Warning.id,
        typeInfo: this.$MISAEnum["MISADialog"].Info.id,
      },
      // Các title Dialog
      dialogTitle: {
        titleError: this.$MISAEnum["MISADialog"].Error.title,
        titleSuccess: this.$MISAEnum["MISADialog"].Success.title,
        titleWarning: this.$MISAEnum["MISADialog"].Warning.title,
        titleInfo: this.$MISAEnum["MISADialog"].Info.title,
      },
    };
  },
};
</script>

<style></style>
