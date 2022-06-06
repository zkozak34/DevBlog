<template>
  <div class="col-md-12 mx-auto">
    <!-- Start: App-Header Area -->
    <!-- Header -->
    <div id="header" class="zk-header py-5 px-3 bg-white">
      <h1 class="display-5">Zeynel KOZAK</h1>
      <span class="fst-italic">Bir alaylının gözünden...</span>
    </div>
    <!-- Header -->
    <!-- Navbar -->
    <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
      <div class="container-fluid">
        <router-link class="navbar-brand" :to="{ name: 'HomeView' }" active-class="active">ZKDev</router-link>
        <button
          class="navbar-toggler"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#navbarNav"
          aria-controls="navbarNav"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
          <ul class="navbar-nav">
            <li class="nav-item">
              <router-link class="nav-link" :to="{ name: 'HomeView' }" active-class="active">Ana Sayfa</router-link>
            </li>
            <li class="nav-item" v-for="category in categoryList" :key="category.id">
              <a class="nav-link" href="#">{{ category.title }}</a>
            </li>
            <li class="nav-item">
              <router-link class="nav-link" :to="{ name: 'AboutView' }" active-class="active">Hakkımda</router-link>
            </li>
          </ul>
        </div>
      </div>
    </nav>
    <!-- Navbar -->
    <!-- End: App-Header Area -->
  </div>
</template>
<script>
import { mapGetters } from "vuex";
export default {
  computed: {
    ...mapGetters({ categoryList: "category/getList" }),
  },
};
</script>
