import { Container, CssBaseline } from "@mui/material"
import Navbar from "./layout/Navbar"
import { useState } from "react"
import { LoadingContext } from "../hooks/appContextHooks";
import { Outlet } from "react-router-dom";


function App() {

  const [isLoading, setIsLoading] = useState(false);

  return (
    <>
      <LoadingContext.Provider value={{ isLoading, setLoader: (value: boolean) => setIsLoading(value) }}>
        <CssBaseline />
        <Navbar />
        <Container maxWidth={false} sx={{ marginTop: 9, background: 'aliceblue' }}>
          <Outlet />
        </Container>
      </LoadingContext.Provider>
    </>
  )
}

export default App
