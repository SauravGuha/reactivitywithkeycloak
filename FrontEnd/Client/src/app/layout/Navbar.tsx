import { Group } from "@mui/icons-material";
import { AppBar, Box, CircularProgress, Container, MenuItem, Toolbar, Typography } from "@mui/material";
import { useIsAuthenticated, useIsLoading } from "../../hooks/appContextHooks";
import { NavLink, useNavigate } from "react-router-dom";
import UserMenu from "./UserMenu";


export default function Navbar() {
    const { isLoading } = useIsLoading();
    const navigate = useNavigate();
    const isAuthenticated = useIsAuthenticated();

    return (
        <Box sx={{ flexGrow: 1 }}>
            <AppBar position="fixed">
                <Container maxWidth='xl'>
                    <Toolbar sx={{ display: "flex", justifyContent: "space-between" }}>
                        <Box>
                            <MenuItem sx={{ display: 'flex', gap: 2 }} onClick={() => { navigate("/") }}>
                                <Group fontSize="large" />
                                <Typography variant="h4" fontWeight='bold'>Reactivity</Typography>
                                <CircularProgress sx={{ display: isLoading ? "inline-flex" : "none" }} color="success" />
                            </MenuItem>
                        </Box>
                        <Box sx={{ display: 'flex', gap: 2 }}>
                            <MenuItem sx={{ fontWeight: 'bold', textTransform: 'uppercase' }}
                                onClick={() => navigate("/activities")}>Activities</MenuItem>
                            <MenuItem sx={{ fontWeight: 'bold', textTransform: 'uppercase' }}>About</MenuItem>
                            <MenuItem sx={{ fontWeight: 'bold', textTransform: 'uppercase' }}>Contact</MenuItem>
                        </Box>
                        <MenuItem>
                            {isAuthenticated ? <UserMenu /> :
                                <MenuItem component={NavLink} to='/login' sx={{
                                    '&.active': {
                                        color: 'yellow'
                                    }
                                }}>Login</MenuItem>
                            }
                        </MenuItem>
                    </Toolbar>
                </Container>
            </AppBar>
        </Box>
    )
}
