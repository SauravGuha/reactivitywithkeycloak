
import { Box, Grid } from "@mui/material";
import ActivityCard from "./ActivityCard";
import useActivities from "../../../hooks/activityQueryHooks";
import ActivityFilters from "./ActivityFilters";

export default function DashBoard() {

    const { activities, isLoadingActivities } = useActivities();

    if (isLoadingActivities) return <></>;

    return (
        <>
            <Grid container spacing={2}>
                <Grid size={8}>
                    <Box sx={{ display: "flex", flexDirection: "column", gap: 1 }}>
                        {activities
                            ? activities.map(a => <ActivityCard key={a.id} activity={a} />)
                            : "Not activity found"}
                    </Box>
                </Grid>
                <Grid size={4}>
                    <ActivityFilters />
                </Grid>
            </Grid>
        </>
    )
}