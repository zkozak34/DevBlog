<template>
  <section class="bg-primary pt-3 my-3 d-flex justify-content-center align-items-center">
    <ul class="pagination">
      <li class="page-item" v-for="page in paging" :key="page">
        <a class="page-link bg-primary border-primary text-light fw-bold fs-5" href="#"> {{ page }}</a>
      </li>
    </ul>
  </section>
</template>
<script>
export default {
  props: ["paging"],
};
</script>
