import appAxios from "@/adapters/appAxios";

export default {
  namespaced: true,
  state: {
    list: [],
  },
  getters: {
    getList: (state) => state.list,
  },
  mutations: {
    setList(state, list) {
      state.list = list;
    },
  },
  actions: {
    fetchList({ commit }) {
      appAxios.get("categories").then(({ data }) => {
        if (data.statusCode === 200 && data.data.length > 0) {
          commit("setList", data.data);
        }
      });
    },
  },
};
