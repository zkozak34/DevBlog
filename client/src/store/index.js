import { createStore } from "vuex";

import category from "./modules/category";
import post from "./modules/post";

export default createStore({
  state: {
    isLoadedData: false,
  },
  getters: {
    getIsLoadedData: (state) => state.isLoadedData,
  },
  mutations: {
    setIsLoadedData(state, status) {
      state.isLoadedData = status;
    },
  },
  actions: {
    initApp({ dispatch }) {
      dispatch("category/fetchList");
      dispatch("post/fetchList");
    },
    loadApp(context) {
      if (context.rootState.category.isLoaded && context.rootState.post.isLoaded) {
        context.commit("setIsLoadedData", true);
      }
    },
  },
  modules: {
    category,
    post,
  },
});
