import { createBrowserRouter } from "react-router-dom";
import Home from "../features/home/Home";
import Dashboard from "../features/activity/dashboard/DashBoard";
import App from "./App";


export const appRouter = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            {
                path: '',
                element: <Home />
            },
            {
                path: '/activities',
                element: <Dashboard />
            }
        ]
    }
]);