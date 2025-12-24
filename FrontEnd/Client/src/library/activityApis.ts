
import axios from "axios";
import type { Activity, ApiResponse } from "../types/activityType";
import { toast } from "react-toastify";
import { appRouter } from "../app/AppRouter";
import { keycloakClient } from "../hooks/authenticationHook";

const baseUrl = import.meta.env.VITE_BASEURL

const instance = axios.create({
    baseURL: baseUrl
});

function delayer() {
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve("Delayed");
        }, 3000);
    });
}

instance.interceptors.request.use(async value => {
    await delayer();
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

const getAllActivities = async function () {
    const result = await instance.get<ApiResponse<Activity[]>>("/api/Activity/GetAllActivities");
    return result?.data.value.map(a => { return { ...a, eventDate: a.eventDate + 'Z' }; });
}

const getById = async function (id: string) {
    const result = await instance.get<ApiResponse<Activity>>(`/api/activity/getactivitybyid?id=${id}`);
    const { data } = result;
    return { ...data.value, eventDate: data.value.eventDate + 'Z' };
}

const createActivity = async function (activity: Activity) {
    const result = await instance.post<ApiResponse<Activity>>('/api/activity', activity);
    return result?.data.value;
}

const updateActivity = async function (id: string, activity: Activity) {
    const result = await instance.put<ApiResponse<Activity>>(`/api/activity?id=${id}`, activity);
    return result?.data.value;
}

const deleteActivity = async function (id: string) {
    await instance.delete(`api/activity?id=${id}`);
    return "";
}

export { getAllActivities, getById, createActivity, updateActivity, deleteActivity };