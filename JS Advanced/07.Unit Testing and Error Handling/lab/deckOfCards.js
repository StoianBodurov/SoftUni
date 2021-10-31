function printCards(cards) {
  const deck = [];

  for (let el of cards) {
    const face = el.slice(0, -1);
    const suite = el.slice(-1);

    try {
      deck.push(solve(face, suite));
    } catch (err) {
      console.log("Invalid card: " + el);
      return;
    }
  }
  console.log(deck.join(" "));

  function solve(face, suit) {
    const cardFace = [
      "2",
      "3",
      "4",
      "5",
      "6",
      "7",
      "8",
      "9",
      "10",
      "J",
      "Q",
      "K",
      "A",
    ];
    const cardSuits = {
      S: "\u2660",
      H: "\u2665",
      D: "\u2666",
      C: "\u2663",
    };
    const card = {
      objFace: "",
      objSuit: "",

      toString: function () {
        return `${this.objFace}${this.objSuit}`;
      },
    };

    if (cardSuits.hasOwnProperty(suit) && cardFace.includes(face)) {
      card.objFace = face;
      card.objSuit = cardSuits[suit];
    } else {
      throw new Error("Invalid suit or face value");
    }

    return card;
  }
}

printCards(["AS", "10D", "KH", "2C"]);
printCards(["5S", "3D", "QD", "1C"]);
