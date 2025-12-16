import { Container, CssBaseline } from "@mui/material"
import Navbar from "./layout/Navbar"


function App() {

  return (
    <>
      <CssBaseline />
      <Navbar />
      <Container maxWidth='xl' sx={{ marginTop: 3 }}>
        hello
      </Container>
    </>
  )
}

export default App
