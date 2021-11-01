function solve() {
  const microelements = {
    protein: 0,
    carbohydrate: 0,
    fat: 0,
    flavour: 0,
  };

  const meals = {
    apple: { carbohydrate: 1, flavour: 2 },
    lemonade: { carbohydrate: 10, flavour: 20 },
    burger: { carbohydrate: 5, fat: 7, flavour: 3 },
    eggs: { protein: 5, fat: 1, flavour: 1 },
    turkey: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 },
  };

  function restock(microelement, countiti) {
    microelements[microelement] += countiti;
    return "Success";
  }
  function prepare(recipe, countiti) {
    const temp = [];
    let inprogres = true;
    for (let microel of Object.keys(meals[recipe])) {
      if (meals[recipe][microel] * countiti <= microelements[microel]) {
        const obj = new Object();
        obj[microel] = meals[recipe][microel] * countiti;
        temp.push(obj);
      } else {
        return`Error: not enough ${microel} in stock`;
        inprogres = false;
        break;
      }
    }
    if (inprogres) {
      for (let m of temp) {
        const key = Object.keys(m)[0];
        microelements[key] -= m[key];
      }
      return "Success";
    }
  }
  function report() {
    return `protein=${microelements["protein"]} carbohydrate=${microelements["carbohydrate"]} fat=${microelements["fat"]} flavour=${microelements["flavour"]}`;
  }

  function commands(input) {
    let [command, product, countiti] = input.split(" ");
    countiti = Number(countiti);

    if (command == "restock") {
      return restock(product, countiti);
    } else if (command == "prepare") {
      return prepare(product, countiti);
    } else if (command == "report") {
      return report();
    }
  }

  return commands;
}

let result = solve();

// result("restock flavour 50");

// result("prepare lemonade 4");
// result("restock carbohydrate 10");
// result("restock flavour 10");
// result("prepare apple 1");
// result("restock fat 10");
// result("prepare burger 1");
// result("report");

console.log(result("prepare turkey 1")); //, 'Error: not enough protein in stock'],
console.log(result("restock protein 10")); //, 'Success'],
console.log(result("prepare turkey 1")); //, 'Error: not enough carbohydrate in stock'],
console.log(result("restock carbohydrate 10")); //, 'Success'],
console.log(result("prepare turkey 1")); //, 'Error: not enough fat in stock'],
console.log(result("restock fat 10")); //, 'Success'],
console.log(result("prepare turkey 1")); //, 'Error: not enough flavour in stock'],
console.log(result("restock flavour 10")); //, 'Success'],
console.log(result("prepare turkey 1")); //, 'Success'],
console.log(result('report'))
//'report', 'protein=0 carbohydrate=0 fat=0 flavour=0'
