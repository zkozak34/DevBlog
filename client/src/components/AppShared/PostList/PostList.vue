<template>
  <post-list-item v-for="post in postList" :key="post.id" :post="post"></post-list-item>
</template>
<script>
import { mapGetters } from "vuex";
import PostListItem from "./PostListItem.vue";
export default {
  computed: {
    ...mapGetters({
      postList: "post/getList",
    }),
  },
  components: {
    PostListItem,
  },
};
</script>
