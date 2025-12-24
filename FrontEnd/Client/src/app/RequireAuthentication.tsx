import { Outlet } from "react-router-dom";
import { useAuth } from "../hooks/authenticationHook";
import { IsAuthenticated } from "../hooks/appContextHooks";
import Navbar from "./layout/Navbar";


export default function RequireAuthentication() {
    const isLogin = useAuth();
    return (
        <>
            <IsAuthenticated.Provider value={isLogin}>
                <Navbar />
                <Outlet />
            </IsAuthenticated.Provider>
        </>
    )
}
