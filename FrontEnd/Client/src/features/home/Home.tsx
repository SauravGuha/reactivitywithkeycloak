import { Group } from "@mui/icons-material";
import { Box, Button, Container, Typography } from "@mui/material";
import { Link } from "react-router-dom";



export default function Home() {
    return (
        <Container sx={{
            display: 'flex',
            justifyContent: 'center',
            alignItems: 'center',
            flexDirection: 'column',
            gap: 3,
            background: 'lightblue',
            color:'white'
        }}>
            <Box sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
                <Group fontSize="large" />
                <Typography variant="h1">Reactivity</Typography>
            </Box>
            <Typography variant="h3">Welcome to reactivity</Typography>
            <Button component={Link} to='/activities'
                variant="outlined">Take me to Activities</Button>
        </Container>
    )
}
