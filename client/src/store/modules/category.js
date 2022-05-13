import appAxios from "@/adapters/appAxios";

export default {
  namespaced: true,
  state: {
    list: [],
    isLoaded: false,
  },
  getters: {
    getList: (state) => state.list,
    getIsLoaded: (state) => state.isLoaded,
  },
  mutations: {
    setList(state, list) {
      state.list = list;
    },
    setIsLoaded(state, status) {
      state.isLoaded = status;
    },
  },
  actions: {
    fetchList({ commit }) {
      commit("setIsLoaded", false);
      appAxios.get("categories").then(({ data }) => {
        if (data.statusCode === 200 && data.data.length > 0) {
          commit("setList", data.data);
          commit("setIsLoaded", true);
        }
      });
    },
  },
};
