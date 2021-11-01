function solve(data, criteria) {
  const employees = JSON.parse(data);
  const [propps, value] = criteria.split("-");
  let count = 0;

  function filterEmployes(employ, propps, value) {
    if (employ[propps] == value) {
      console.log(
        `${count}. ${employ.first_name} ${employ.last_name} - ${employ.email}`
      );
      count++;
    }
  }
  for (let employ of employees) {
    filterEmployes(employ, propps, value);
  }
}

let data = `[{
    "id": "1",
    "first_name": "Ardine",
    "last_name": "Bassam",
    "email": "abassam0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Jost",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  },  
{
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }]`;

let criteria = "Female";

solve(data, criteria);
