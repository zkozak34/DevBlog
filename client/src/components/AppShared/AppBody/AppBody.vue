<template>
  <!-- Start: App-Body Area -->
  <div class="col-md-12 mx-auto mb-4">
    <div class="content-area row">
      <app-left-bar>
        <slot />
      </app-left-bar>
      <app-right-bar></app-right-bar>
    </div>
  </div>
  <!-- Finish: App-Body Area -->
</template>
<script>
import AppRightBar from "./AppRightBar.vue";
import AppLeftBar from "./AppLeftBar.vue";
export default {
  components: { AppRightBar, AppLeftBar },
};
</script>
