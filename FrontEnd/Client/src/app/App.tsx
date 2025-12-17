import { Box, Container, CssBaseline } from "@mui/material"
import Navbar from "./layout/Navbar"
import { useState } from "react"
import { LoadingContext } from "../hooks/appContextHooks";
import { Outlet, useLocation } from "react-router-dom";
import Home from "../features/home/Home";


function App() {

  const [isLoading, setIsLoading] = useState(false);
  const { pathname } = useLocation();

  return (
    <Box sx={{ bgcolor: '#eeeeee', minHeight: '100vh' }}>
      <CssBaseline />
      {pathname == '/'
        ? <Home />
        : <LoadingContext.Provider value={{ isLoading, setLoader: (value: boolean) => setIsLoading(value) }}>
          <Navbar />
          <Container maxWidth={false} sx={{ marginTop: 9 }}>
            <Outlet />
          </Container>
        </LoadingContext.Provider>
      }
    </Box>
  )
}

export default App
