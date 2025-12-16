
import axios from "axios";
import type { Activity } from "../types/activityType";

const baseUrl = import.meta.env.VITE_BASEURL

const instance = axios.create({
    baseURL: baseUrl
});

function delayer() {
    return new Promise((resolve, _) => {
        setTimeout(() => {
            resolve("Delayed");
        }, 3000);
    });
}

instance.interceptors.request.use(async value => {
    await delayer();
    return value;
});

const getAllActivities = async function () {
    const result = await instance.get<Activity[]>("/api/Activity/GetAllActivities");
    return result.data;
}

export { getAllActivities };