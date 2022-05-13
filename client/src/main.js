import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";

import "@/assets/main.css";
import appAxios from "./adapters/appAxios";
import helperMixins from "./mixins/helperMixins";

const app = createApp(App);
app.config.globalProperties.$appAxios = appAxios;
app.mixin(helperMixins);
app.use(store);
app.use(router);
app.mount("#app");
