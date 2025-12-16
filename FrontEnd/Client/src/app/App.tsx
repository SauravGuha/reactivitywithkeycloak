import { Container, CssBaseline } from "@mui/material"
import Navbar from "./layout/Navbar"
import { useEffect, useState } from "react"
import { getAllActivities } from "../library/reactivityapi";
import type { Activity } from "../types/activityType";


function App() {

  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    getAllActivities()
      .then(response => setActivities(response));
  }, []);

  return (
    <>
      <CssBaseline />
      <Navbar />
      <Container maxWidth='xl' sx={{ marginTop: 10 }}>
        {activities.map(a => <>{a.category}</>)}
      </Container>
    </>
  )
}

export default App
