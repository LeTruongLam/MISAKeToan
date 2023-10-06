<template>
  <div id="success" class="popup-container">
    <div class="popup-wrappper">
      <div class="popup-content">
        <div class="popup-left">
          <p
            :class="{
              'success-icon': type === notifyType.Success,
              'error-notify-icon': type === notifyType.Error,
              'warning-notify-icon': type === notifyType.Warning,

              
            }"
          ></p>
          <p>
            {{ title }}
            <span> {{ message }} </span>
          </p>
        </div>
        <div class="popup-right">
          <div class="close-icon-mini"></div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "MisaNotify",
  props: ["message", "type", "title"],
  methods: {},
  data() {
    return {
      notifyType: {
        Error: this.$MISAEnum.MISANotify.Error.id,
        Success: this.$MISAEnum.MISANotify.Success.id,
        Warning: this.$MISAEnum.MISANotify.Warning.id,
        Info: this.$MISAEnum.MISANotify.Info.id,
      },
      notifyTitle: {
        TitleError: this.$MISAEnum.MISANotify.Error.title,
        TitleSuccess: this.$MISAEnum.MISANotify.Success.title,
        TitleWarning: this.$MISAEnum.MISANotify.title,
        TitleInfo: this.$MISAEnum.MISANotify.Info.title,
      },
    };
  },
};
</script>

<style></style>
