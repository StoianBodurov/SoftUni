function solve(data) {
  const colection = [];

  const commands = {
    add: function add(str) {
      colection.push(str);
    },

    remove: function remove(str) {
      while (colection.includes(str)) {
        colection.splice(colection.indexOf(str), 1);
      }
    },

    print: function print() {
      console.log(colection.join(","));
    },
  };

  for (let el of data) {
    const [command, value] = el.split(" ");
    commands[command](value);
  }
}

solve(["add hello", "add again", "remove hello", "add again", "print"]);
