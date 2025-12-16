import { useEffect, useState } from "react";
import type { Activity } from "../../types/activityType";
import { getAllActivities } from "../../library/reactivityapi";
import { useIsLoading } from "../../hooks/appContext";

export default function DashBoard() {
    const [activities, setActivities] = useState<Activity[]>([]);
    const { setLoader } = useIsLoading();

    useEffect(() => {
        setLoader(true);
        getAllActivities()
            .then(response => setActivities(response))
            .finally(() => { setLoader(false) });
    }, []);

    return (
        <>
            {activities.map(a => <>{a.title}</>)}
        </>
    )
}