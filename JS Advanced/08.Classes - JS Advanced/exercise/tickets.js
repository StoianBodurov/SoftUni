function solve(ticketData, sortedCriteria) {
    class Ticket {
        constructor(destination, price, status){
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    const tickets = []

    for (let el of ticketData) {
        let [destination, price, status] =el.split('|')
        price = Number(price)
        tickets.push(new Ticket(destination, price, status))
    }
    if (sortedCriteria == 'price'){
        return tickets.sort((a, b) => a[sortedCriteria] - b[sortedCriteria])
    }else {
        return tickets.sort((a, b) => a[sortedCriteria].localeCompare(b[sortedCriteria]))
    }
}

// solve(['Philadelphia|94.20|available',
// 'New York City|95.99|available',
// 'New York City|95.99|sold',
// 'Boston|126.20|departed'],
// 'destination')

// solve(['Philadelphia|94.20|available',
//  'New York City|95.99|available',
//  'New York City|95.99|sold',
//  'Boston|126.20|departed'],
// 'status')

solve(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|available',
        'Philadelphia|132.20|departed',
        'Chicago|140.20|available',
        'Dallas|144.60|sold',
        'New York City|206.20|sold',
        'New York City|240.20|departed',
        'New York City|305.20|departed'],
    'destination')