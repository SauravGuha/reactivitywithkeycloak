
import axios from "axios";
import type { Activity } from "../types/activityType";

const baseUrl = import.meta.env.VITE_BASEURL

const instance = axios.create({
    baseURL: baseUrl
});

const getAllActivities = async function () {
    const result = await instance.get<Activity[]>("/api/Activity/GetAllActivities");
    return result.data;
}

export { getAllActivities };