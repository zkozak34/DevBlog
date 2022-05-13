<template>
  <div class="container-xl">
    <router-view name="AppHeader" />
    <router-view />
    <router-view name="AppFooter" />
  </div>
</template>
<script>
export default {
  mounted() {
    this.$store.dispatch("initApp");
  },
};
</script>
