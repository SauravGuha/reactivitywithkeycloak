
import { Add, Logout, Person } from '@mui/icons-material';
import { Avatar, Box, ListItemIcon, ListItemText } from '@mui/material';
import Button from '@mui/material/Button';
import Menu from '@mui/material/Menu';
import MenuItem from '@mui/material/MenuItem';
import { useState } from 'react';
import { NavLink } from 'react-router-dom';
import { keycloakClient } from '../../hooks/authenticationHook';
import useUsers from '../../hooks/userQueryHook';

export default function UserMenu() {
    const { userInfo, isFetchingUserInfo } = useUsers();
    const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
    const open = Boolean(anchorEl);
    const handleClick = (event: React.MouseEvent<HTMLElement>) => {
        setAnchorEl(event.currentTarget);
    };
    const handleClose = () => {
        setAnchorEl(null);
    };

    const onLogout = async () => {
        keycloakClient.logout({
            redirectUri: window.location.origin
        });
    }

    if (isFetchingUserInfo) return <></>;

    return (
        <>
            <Button
                sx={{ color: 'inherit' }}
                id="basic-button"
                onClick={handleClick}
                size="large"
            >
                <Box sx={{ display: 'flex', alignItems: 'center', gap: 2 }}>
                    <Avatar
                        key={userInfo?.keycloakUserId}
                        alt={userInfo?.displayName}
                        src="userData!.imageUrl" />
                    {userInfo?.displayName}
                </Box>

            </Button>
            <Menu
                id="basic-menu"
                anchorEl={anchorEl}
                open={open}
                onClose={handleClose}
                slotProps={{
                    list: {
                        'aria-labelledby': 'basic-button',
                    },
                }}
            >
                <MenuItem component={NavLink} to='/createactivity'>
                    <ListItemIcon>
                        <Add />
                    </ListItemIcon>
                    <ListItemText>Create Activity</ListItemText>
                </MenuItem>
                <MenuItem component={NavLink} to={`/profile/userData!.id`}>
                    <ListItemIcon>
                        <Person />
                    </ListItemIcon>
                    <ListItemText>User Profile</ListItemText>
                </MenuItem>
                <MenuItem onClick={onLogout}>
                    <ListItemIcon>
                        <Logout />
                    </ListItemIcon>
                    <ListItemText>Logout</ListItemText>
                </MenuItem>
            </Menu>
        </>
    )
}
