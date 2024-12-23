import React from "react";
import { switchCards } from "../services/switchCards";

// XY / column, row
// 00   01   02   03   04   05
// 10
// 20
// 30
// 40

export function imagesLoader() {

    let cards = [];

    for (let i = 0; i < 5; i++) {
        cards.push(
            <React.Fragment key={i}>
                <tr>
                    {rowLoader(i)}
                </tr>
            </React.Fragment>
        )
    }

    return cards;
}

function rowLoader(y) {

    let columns = [0, 1, 2, 3, 4, 5];
    let selectedCard = localStorage.getItem("path");
    
    // pega somente a localização X e Y da carta armazenada para manter a carta marcada
    // quando for feita a verificação no className durante a montagem das cartas
    let cardPosition = selectedCard && selectedCard[selectedCard.length - 2] + "" + selectedCard[selectedCard.length - 1]

    function handleClick(e) {

        // Corta a parte da url que vem junto do src
        let src = e.target.dataset.src;
        e.target.classList.toggle("selected-card");

        console.log(e.target.dataset.src);
        switchCards(src);
    }

    return (
        <>
            {columns.map(x => (
                <td key={`${x}${y}`}>
                    <img className={cardPosition === x + "" + y ? "selected-card" : ""}
                        onClick={handleClick}
                        src={`./img/Card${x}${y}.jpg`}
                        data-src={`/img/Card${x}${y}`}
                        alt="image"
                        onError={(e) => {
                            e.target.src = "./img/nullCard.jpg";
                            e.target.dataset.src = `${x}${y}`
                        }} />
                </td>
            ))}
        </>
    )

}
