
import axios from "axios";
import type { Activity } from "../types/activityType";

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
    return value;
});

const getAllActivities = async function () {
    const result = await instance.get<Activity[]>("/api/Activity/GetAllActivities");
    return result.data.map(a => { return { ...a, eventDate: a.eventDate + 'Z' }; });
}

const getById = async function (id: string) {
    const result = await instance.get<Activity>(`/api/activity/getactivitybyid?id=${id}`);
    const { data } = result;
    return { ...data, eventDate: data.eventDate + 'Z' };
}

const createActivity = async function (activity: Activity) {
    const result = await instance.post<Activity>('/api/activity', activity);
    return result.data;
}

const updateActivity = async function (id: string, activity: Activity) {
    const result = await instance.put<Activity>(`/api/activity?id=${id}`, activity);
    return result.data;
}

const deleteActivity = async function (id: string) {
    await instance.delete(`api/activity?id=${id}`);
    return "";
}

export { getAllActivities, getById, createActivity, updateActivity, deleteActivity };