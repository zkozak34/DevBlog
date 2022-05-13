<template>
  <article class="card mt-3 p-2 bg-white rounded">
    <div class="row">
      <div class="col-lg-4">
        <a href="detail.html"><img class="img-fluid rounded-start" :src="post.thumbnailImage" alt="" /></a>
      </div>
      <div class="col-lg-8 d-flex justify-content-center align-items-center">
        <div class="card-body">
          <a href="detail.html" class="text-decoration-none text-dark">
            <h1 class="card-title display-6 post-title">{{ post.title }}</h1>
          </a>
          <p class="card-text lead post-text">
            Lorem ipsum dolor sit amet consectetur adipisicing elit. Placeat eaque corporis expedita ipsum tempora hic praesentium quod animi aliquam
            molestias rerum, totam incidunt. Voluptas, natus laudantium. Incidunt reprehenderit et quasi.
          </p>
          <div>
            <span class="badge bg-primary fs-7 mx-1"><i class="fa fa-user-o"></i> {{ post.author.fullName }} </span>
            <span class="badge bg-primary fs-7 mx-1"><i class="fa fa-clock-o"></i> {{ convertDate(post.createdDate) }} </span>
            <span class="badge bg-primary fs-7 mx-1"><i class="fa fa-list"></i> {{ post.category.title }} </span>
          </div>
        </div>
      </div>
    </div>
  </article>
</template>

<script>
export default {
  props: ["post"],
};
</script>
