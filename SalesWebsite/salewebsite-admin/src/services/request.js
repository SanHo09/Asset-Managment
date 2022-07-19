import axios from "axios";
import { UrlBackEnd } from "~/constants/oidc-config";

const config = {
    baseURL: UrlBackEnd
}

class RequestService {
    axios;

    constructor() {
        this.axios = axios.create(config);
        var token = localStorage.getItem("token");
        if(token)
            this.axios.defaults.headers["Authorization"] = `Bearer ${token}`;
    }
}

export default new RequestService();