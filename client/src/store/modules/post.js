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
    fetchList({ commit, dispatch }) {
      commit("setIsLoaded", false);
      appAxios
        .get("posts")
        .then(({ data }) => {
          commit("setList", data.data);
          commit("setIsLoaded", true);
          dispatch("loadApp", "", { root: true });
        })
        .catch((e) => console.error(e));
    },
  },
};
