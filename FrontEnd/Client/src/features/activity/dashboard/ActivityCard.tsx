import { Box, Button, Card, CardContent, Chip, Typography } from "@mui/material";
import type { Activity } from "../../../types/activityType";



export default function ActivityCard({ activity }: { activity: Activity }) {
    return (
        <Card sx={{ marginBottom: 2 }}>
            <CardContent>
                <Typography gutterBottom sx={{ color: 'text.secondary', fontSize: 14 }}>
                    {activity.title}
                </Typography>
                <Typography gutterBottom sx={{ color: 'text.secondary', fontSize: 11, fontWeight: "light" }}>
                    {activity.eventDate}
                </Typography>
                <Typography gutterBottom sx={{ color: 'text.secondary', fontSize: 11, fontWeight: "bold" }}>
                    {activity.description}
                </Typography>
                <Typography gutterBottom sx={{ color: 'text.secondary', fontSize: 11, fontWeight: "bold" }}>
                    {activity.city}/{activity.venue}
                </Typography>
                <Box sx={{ display: 'flex', justifyContent: "space-between", paddingTop: 1 }}>
                    <Chip label={activity.category} variant="outlined" />
                    <Box sx={{ display: 'flex', justifyContent: 'space-between', gap: 3 }}>
                        <Button variant="contained">View</Button>
                        <Button variant="contained" color='secondary'>Delete</Button>
                    </Box>

                </Box>
            </CardContent>
        </Card>
    )
}
