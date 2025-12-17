import { createBrowserRouter } from "react-router-dom";
import App from "./App";
import DashBoard from "../features/activity/dashboard/DashBoard";


export const appRouter = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            {
                path: '/activities',
                element: <DashBoard />
            }
        ]
    }
]);