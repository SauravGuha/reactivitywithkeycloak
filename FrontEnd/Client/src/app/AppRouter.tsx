import { createBrowserRouter } from "react-router-dom";
import App from "./App";
import DashBoard from "../features/activity/dashboard/DashBoard";
import ActivityDetailsPage from "../features/activity/details/ActivityDetailsPage";
import ActivityForm from "../features/activity/form/ActivityForm";
import NotFound from "../features/error/NotFound";


export const appRouter = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            {
                path: '/activities',
                element: <DashBoard />
            },
            {
                path: '/activity/:id',
                element: <ActivityDetailsPage />
            },
            {
                path: '/manage/:id',
                element: <ActivityForm />
            },
            {
                path: '/not-found',
                element: <NotFound />
            }
        ]
    }
]);