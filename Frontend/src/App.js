import React, { useEffect, useState } from "react";
import { Button, Container, Table } from "reactstrap";

import { imagesLoader } from "./ImagesLoader";
import { deleteCards } from "./services/deleteCards"

function App() {

  const [cards, setCards] = useState([])

  useEffect(() => {
    let interval = setInterval(() => {
      setCards(imagesLoader());
      setTimeout(() => window.location.reload(), 1500)
    }, 1000)
    setCards(imagesLoader());

    return () => clearInterval(interval,);
  }, [])

  return (
    <>
      <Container className="d-grid justify-content-center align-items-center">
        <Button onClick={deleteCards} color="danger" className="my-4">Deletar Cartas</Button>
        <Table dark bordered style={{ textAlign: 'center', width: 20 }}>
          <tbody>
            {cards}
          </tbody>
        </Table>
      </Container>
    </>
  );
}

export default App;
