function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {
      const inputText = document.querySelector('textarea').value
      const splited = inputText.slice(1, inputText.length - 2).split('\n')
      const restaurants = {}
      let bestResturant = ''
      let bestAverageSalary = 0
   
      for (let el of splited) {
         let [restaurant, workersLikeText] =  el.slice(1, el.length - 2).split(' - ')
         let workers = workersLikeText.split(', ')
         let averageSalary = 0
         restaurants[restaurant] = {}

         for (let worker of workers) {
            let [name, salary] = worker.split(' ')
            salary = Number(salary)
            averageSalary += salary
      
            restaurants[restaurant]['name'] = name
            restaurants[restaurant]['salary'] = Number(salary)
         }
         averageSalary /= workers.length

         if (averageSalary > bestAverageSalary) {
            bestAverageSalary = averageSalary
            bestResturant = restaurant
         }
      }


      console.log(bestResturant)
      console.log(bestAverageSalary)
      
   }
}