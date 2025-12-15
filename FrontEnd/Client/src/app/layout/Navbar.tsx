import { Group } from "@mui/icons-material";
import { AppBar, Box, Container, MenuItem, Toolbar, Typography } from "@mui/material";


export default function Navbar() {
    return (
        <Box sx={{ flexGrow: 1 }}>
            <AppBar position="fixed">
                <Container maxWidth='xl'>
                    <Toolbar sx={{ display: "flex", justifyContent: "space-between" }}>
                        <Box>
                            <MenuItem sx={{ display: 'flex', gap: 2 }}>
                                <Group fontSize="large" />
                                <Typography variant="h4" fontWeight='bold'>Reactivity</Typography>
                            </MenuItem>
                        </Box>
                        <Box sx={{ display: 'flex', gap: 2 }}>
                            <MenuItem sx={{ fontWeight: 'bold', textTransform: 'uppercase' }}>Activities</MenuItem>
                            <MenuItem sx={{ fontWeight: 'bold', textTransform: 'uppercase' }}>About</MenuItem>
                            <MenuItem sx={{ fontWeight: 'bold', textTransform: 'uppercase' }}>Contact</MenuItem>
                        </Box>
                        <Box>
                            Login
                        </Box>
                    </Toolbar>
                </Container>
            </AppBar>
        </Box>
    )
}
