import axios from "axios";
import { toast } from "react-toastify";
import { appRouter } from "../app/AppRouter";
import type { ApiResponse, UserInfo } from "../types/activityType";
import { keycloakClient } from "../hooks/authenticationHook";

const baseUrl = import.meta.env.VITE_BASEURL

const instance = axios.create({
    baseURL: baseUrl
});

instance.interceptors.request.use(async value => {
    value.headers.Authorization = `Bearer ${keycloakClient.token}`;
    return value;
});

instance.interceptors.response.use(null, async error => {
    const status = error.status;
    const data = error.response.data;
    if (status > 399) {
        switch (status) {
            case 400:
                toast.error("Bad Request");
                break;
            case 401:
                toast.error("Unauthorised");
                break;
            case 404:
                toast.error("Not-Found");
                appRouter.navigate("/not-found");
                break;
            default:
                toast.error(data.errorMessage);
                break;
        }
    }
    throw data;
});

const getUserInfo = async function () {
    const result = await instance.get<ApiResponse<UserInfo>>("/api/user/GetUserInfo");
    return result.data.value;
}

export { getUserInfo }