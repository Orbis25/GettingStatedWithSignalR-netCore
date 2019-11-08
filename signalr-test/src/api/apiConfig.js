import Axios from "axios";

export default Axios.create({
  baseURL: "https://localhost:5001/api",
  responseType: "json"
});
