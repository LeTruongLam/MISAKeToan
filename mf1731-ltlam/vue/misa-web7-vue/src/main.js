import { createApp } from "vue";
import App from "./App.vue";

createApp(App).mount("#app");

import MisaDialog from "./components/base/MISADialog.vue";
import MisaButton from "./components/base/MISAButton.vue";
import MisaCombobox from "./components/base/MISACombobox.vue";
import MisaContextMenu from "./components/base/MISAContextmenu.vue";
import MisaSearch from "./components/base/MISASearch.vue";
import MisaInput from "./components/base/MISAInput.vue";
import MisaNotify from "./components/base/MISANotify.vue";
import MisaLoading from "./components/base/MISALoading.vue";
import MISAHelper from "./js/MISAHelper";
import MISAResource from "./js/MISAResource";
import MISAEnum from "./js/MISAEnum";
import MScombobox from "ms-combobox";
import axios from "axios";
import vuerouter from "./router/router.js";
import emitter from "tiny-emitter/instance";
import moment from "moment";
import MISAApi from "./js/MISAApi.js";

const app = createApp(App);

app.component("m-dialog", MisaDialog);
app.component("m-button", MisaButton);
app.component("m-combobox", MisaCombobox);
app.component("ms-combobox", MScombobox);
app.component("m-contextmenu", MisaContextMenu);
app.component("m-search", MisaSearch);
app.component("m-notify", MisaNotify);
app.component("m-input", MisaInput);
app.component("m-loading", MisaLoading);

app.config.globalProperties.$MISAHelper = MISAHelper;
app.config.globalProperties.$MISAResource = MISAResource;
app.config.globalProperties.$MISAEnum = MISAEnum;
app.config.globalProperties.$axios = axios;
app.config.globalProperties.$emitter = emitter;
app.config.globalProperties.$moment = moment;
app.config.globalProperties.$MISAApi = MISAApi;

app.use(vuerouter);
app.mount("#app");
