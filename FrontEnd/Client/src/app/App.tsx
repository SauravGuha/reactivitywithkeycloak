import { Container, CssBaseline } from "@mui/material"
import Navbar from "./layout/Navbar"
import { useState } from "react"
import { LoadingContext } from "../hooks/appContextHooks";
import { Outlet, useLocation } from "react-router-dom";
import Home from "../features/home/Home";


function App() {

  const [isLoading, setIsLoading] = useState(false);
  const { pathname } = useLocation();

  return (
    <>
      {pathname == '/'
        ? <Home />
        : <LoadingContext.Provider value={{ isLoading, setLoader: (value: boolean) => setIsLoading(value) }}>
          <CssBaseline />
          <Navbar />
          <Container maxWidth={false} sx={{ marginTop: 9, background: 'aliceblue' }}>
            <Outlet />
          </Container>
        </LoadingContext.Provider>
      }
    </>
  )
}

export default App
