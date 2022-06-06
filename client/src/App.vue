<template>
  <div v-if="!isLoaded" class="d-flex justify-content-center align-items-center flex-column gap-2" style="height: 100vh">
    <div class="spinner-grow text-danger" role="status" style="width: 3rem; height: 3rem">
      <span class="visually-hidden"></span>
    </div>
    <span class="text-danger display-6">Loading...</span>
  </div>
  <div v-else class="container-xl">
    <router-view name="AppHeader" />
    <router-view />
    <router-view name="AppFooter" />
  </div>
</template>
<script>
import { mapGetters } from "vuex";
export default {
  mounted() {
    this.$store.dispatch("initApp");
  },
  computed: {
    ...mapGetters({
      isLoaded: "getIsLoadedData",
    }),
  },
};
</script>
