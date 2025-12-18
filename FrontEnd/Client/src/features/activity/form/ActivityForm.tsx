import { Box, Button, Checkbox, FormControlLabel, MenuItem, Paper, TextField, Typography } from "@mui/material";
import type { FormEvent } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import useActivities from "../../../hooks/activityQueryHooks";
import { categories } from "../../../library/common";
import { activityObject } from "../../../types/activityType";

export default function ActivityForm() {

    const { id } = useParams();
    const navigate = useNavigate();
    const { isUpdating, updateAsync, isCreating, createAsync, activity } = useActivities(id);

    const formActivity = activity ?? {
        id: "",
        category: "",
        city: "",
        description: "",
        eventDate: new Date().toISOString(),
        latitude: 0.0,
        longitude: 0.0,
        isCancelled: false,
        title: "",
        venue: ""
    }

    const eventDate = formActivity.eventDate.slice(0, formActivity.eventDate.indexOf('T'));

    async function onSubmit(ele: FormEvent<HTMLFormElement>) {
        ele.preventDefault();
        const formData = new FormData(ele.currentTarget);
        const postActivity = activityObject.parse(Object.fromEntries(formData.entries()));
        postActivity.eventDate = postActivity.eventDate + "T00:00:00.000Z";
        if (postActivity.id) {
            await updateAsync(postActivity);
        }
        else {
            const createdActivity = await createAsync(postActivity);
            postActivity.id = createdActivity!.id;
        }
        navigate(`/activity/${postActivity.id}`);
    }

    return (
        <Paper key={activity ? 'Update' : 'Create'}>
            <Typography variant="h5" gutterBottom color="Primary">
                {activity ? 'Update' : 'Create'} Activity
            </Typography>
            <Box onSubmit={onSubmit} component='form' sx={{ display: 'flex', flexDirection: 'column', gap: '2', padding: 1 }}
                autoComplete="off">
                <input type="hidden" id="id" name='id' defaultValue={formActivity.id} />
                <TextField sx={{ marginBottom: 1 }} required id='title' name='title' label="Title"
                    variant="outlined" defaultValue={formActivity.title} />
                <TextField sx={{ marginBottom: 1 }} required id='description' name='description' label="Description"
                    multiline maxRows={4} defaultValue={formActivity.description} />
                <TextField sx={{ marginBottom: 1 }} required type="date" id='eventDate' name="eventDate" label='Event Date'
                    defaultValue={eventDate} />
                <TextField sx={{ marginBottom: 1 }} select required
                    id='category' name='category' label="Category" variant="outlined"
                    defaultValue={formActivity.category.toLowerCase()}>
                    {
                        categories.map(item => <MenuItem key={item.value} value={item.value}>
                            {item.label}
                        </MenuItem>)
                    }
                </TextField>
                <FormControlLabel sx={{ mb: 1 }} control={<Checkbox defaultChecked={activity?.isCancelled} />}
                    label="Cancelled" name="isCancelled" id="isCancelled" />
                <TextField sx={{ marginBottom: 1 }} required id='city' name='city' label="City" variant="outlined"
                    defaultValue={formActivity.city} />
                <TextField sx={{ marginBottom: 1 }} required id='venue' name='venue' label="Venue" variant="outlined"
                    defaultValue={formActivity.venue} />
                <TextField sx={{ marginBottom: 1 }} required id='latitude' name='latitude' label="Latitude" variant="outlined"
                    defaultValue={formActivity.latitude} />
                <TextField sx={{ marginBottom: 1 }} required id='longitude' name='longitude' label="Longitude" variant="outlined"
                    defaultValue={formActivity.longitude} />
                <Box sx={{ display: "flex", justifyContent: 'end', gap: 3 }}>
                    <Button component={Link} to='/activities' color="warning" variant="contained">Cancel</Button>
                    <Button type="submit" loading={isUpdating || isCreating} color="success" variant="contained">Submit</Button>
                </Box>
            </Box>
        </Paper>
    )
}