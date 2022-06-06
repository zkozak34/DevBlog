import axios from "axios";

const appAxios = axios.create({
  baseURL: "https://localhost:7143/api",
});

export default appAxios;
