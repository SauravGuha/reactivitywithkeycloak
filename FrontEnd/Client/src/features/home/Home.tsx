import { Group } from "@mui/icons-material";
import { Box, Button, Paper, Typography } from "@mui/material";
import { Link } from "react-router-dom";



export default function Home() {
    return (
        <Paper sx={{
            display: 'flex',
            justifyContent: 'center',
            alignContent: 'center',
            alignItems: 'center',
            flexDirection: 'column',
            gap: 6,
            backgroundImage: 'linear-gradient(135deg, #182a73 0%, #218aae 69%, #20a7ac 89%)',
            color: 'white',
            height: '100vh'
        }}>
            <Box sx={{ display: 'flex', alignContent: 'center', alignItems: 'center', color: 'white' }}>
                <Group sx={{ height: 100, width: 100 }} />
                <Typography variant="h1">Reactivity</Typography>
            </Box>
            <Typography variant="h3">Welcome to reactivity</Typography>
            <Button component={Link} to='/activities' size='large'
                variant="contained">Take me to Activities</Button>
        </Paper>
    )
}
