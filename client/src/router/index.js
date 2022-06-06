import { createRouter, createWebHistory } from "vue-router";
import AppHeader from "@/components/AppShared/AppHeader/AppHeader";
import AppFooter from "@/components/AppShared/AppFooter/AppFooter";
const routes = [
  {
    path: "/",
    name: "HomeView",
    components: {
      default: () => import("@/views/HomeView"),
      AppHeader,
      AppFooter,
    },
  },
  {
    path: "/about",
    name: "AboutView",
    components: {
      default: () => import("@/views/AboutView"),
      AppHeader,
      AppFooter,
    },
  },
  {
    path: "/detail/:id",
    name: "PostDetailView",
    components: {
      default: () => import("@/views/PostDetailView"),
      AppHeader,
      AppFooter,
    },
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
