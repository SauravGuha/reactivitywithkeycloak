import { Container, CssBaseline } from "@mui/material"
import Navbar from "./layout/Navbar"
import { useState } from "react"
import { LoadingContext } from "../hooks/appContext";
import Dashboard from "../features/activity/DashBoard";


function App() {

  const [isLoading, setIsLoading] = useState(false);

  return (
    <>
      <LoadingContext.Provider value={{ isLoading, setLoader: (value: boolean) => setIsLoading(value) }}>
        <CssBaseline />
        <Navbar />
        <Container maxWidth='xl' sx={{ marginTop: 10 }}>
          <Dashboard />
        </Container>
      </LoadingContext.Provider>
    </>
  )
}

export default App
