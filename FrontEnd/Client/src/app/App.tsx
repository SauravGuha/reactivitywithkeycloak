import { Container, CssBaseline } from "@mui/material"
import Navbar from "./layout/Navbar"


function App() {

  return (
    <>
      <CssBaseline />
      <Navbar />
      <Container sx={{marginTop:1}}>
        hello
      </Container>
    </>
  )
}

export default App
