<template>
  <div class="content-area-right col-md-3">
    <div class="card mt-3">
      <div class="card-header bg-primary text-light border-bottom border-dark border-5">
        <h4 class="card-title">En Çok Okunan</h4>
      </div>
      <div class="card-body p-0">
        <div class="list-group">
          <div class="list-group-item d-flex justify-content-between flex-column" v-for="post in postList" :key="post.id">
            <p class="m-0">Temel SQL Komutları #2</p>
            <div>
              <span class="badge bg-primary mx-1"><i class="fa fa-clock-o"></i> {{ convertDate(post.createdDate) }}</span>
              <span class="badge bg-primary mx-1"><i class="fa fa-eye"></i> 0</span>
              <span class="badge bg-primary mx-1"><i class="fa fa-comment-o"></i> 0</span>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="card mt-3">
      <div class="card-header bg-primary text-light border-bottom border-dark border-5">
        <h4 class="card-title">Kategoriler</h4>
      </div>
      <div class="card-body p-0">
        <div class="list-group">
          <a href="#" class="list-group-item d-flex justify-content-between" v-for="category in categoryList" :key="category.id">
            {{ category.title }}
            <span class="badge bg-primary"> {{ this.postList?.filter((p) => p.category.path === category.path).length ?? 0 }} </span></a
          >
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { mapGetters } from "vuex";
export default {
  computed: {
    ...mapGetters({
      postList: "post/getList",
      categoryList: "category/getList",
    }),
  },
};
</script>
