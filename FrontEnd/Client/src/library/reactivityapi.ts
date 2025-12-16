
import axios from "axios";
import type { Activity } from "../types/activityType";

const baseUrl = import.meta.env.BASEURL

const instance = axios.create({
    baseURL: baseUrl
});

const getAllActivities = async function () {
    const result = await instance.get<Activity[]>("/api/activity/getallactivities");
    return result.data;
}

export { getAllActivities };