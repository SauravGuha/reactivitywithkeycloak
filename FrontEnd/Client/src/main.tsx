import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { appRouter } from './app/AppRouter.tsx';
import { RouterProvider } from 'react-router-dom';
import "react-toastify/ReactToastify.css"
import { ToastContainer } from "react-toastify";

const queryClient = new QueryClient();

createRoot(document.getElementById('root')!).render(
  <QueryClientProvider client={queryClient}>
    <ToastContainer position='bottom-right' hideProgressBar theme='colored' />
    <RouterProvider router={appRouter} />
    <StrictMode>
    </StrictMode>
  </QueryClientProvider>,
)
