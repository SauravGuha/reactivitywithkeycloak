
import { Grid } from "@mui/material";
import ActivityCard from "./ActivityCard";
import useActivities from "../../../hooks/activityQueryHooks";

export default function DashBoard() {

    const { activities, isLoadingActivities } = useActivities();

    if (isLoadingActivities) return <></>;

    return (
        <>
            <Grid container spacing={2}>
                <Grid size={8}>
                    {activities
                        ? activities.map(a => <ActivityCard key={a.id} activity={a} />)
                        : "Not activity found"}
                </Grid>
            </Grid>
        </>
    )
}