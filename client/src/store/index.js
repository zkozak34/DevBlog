import { createStore } from "vuex";

import category from "./modules/category";
import post from "./modules/post";

export default createStore({
  state: {},
  getters: {},
  mutations: {},
  actions: {
    initApp({ dispatch }) {
      dispatch("category/fetchList");
      dispatch("post/fetchList");
    },
  },
  modules: {
    category,
    post,
  },
});
