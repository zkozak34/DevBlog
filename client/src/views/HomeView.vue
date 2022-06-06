<template>
  <welcome-jumbotron></welcome-jumbotron>
  <app-body>
    <section id="articles">
      <article class="mt-3 p-2 bg-primary text-light border-bottom border-dark border-5">
        <h1 class="display-5 text-center" style="font-weight: 400">Son Yazılar</h1>
      </article>
      <post-list></post-list>
    </section>
  </app-body>
</template>

<script>
import WelcomeJumbotron from "@/components/AppShared/WelcomeJumbotron.vue";
import AppBody from "@/components/AppShared/AppBody/AppBody.vue";
import PostList from "@/components/AppShared/PostList/PostList.vue";
import { mapGetters } from "vuex";
export default {
  name: "HomeView",
  data() {
    return {
      pagination: {
        pageSize: 3,
        page: null,
      },
    };
  },
  computed: {
    ...mapGetters({
      postList: "post/getList",
    }),
  },
  mounted() {
    this.pagination.page = Math.ceil(this.postList?.length / this.pagination.pageSize);
  },
  components: { WelcomeJumbotron, AppBody, PostList },
};
</script>
