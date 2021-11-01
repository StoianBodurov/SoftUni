const library = {
  print: function () {
    console.log(`${this.name} is printing a page`);
  },
  scan: function () {
    console.log(`${this.name} is scanning a document`);
  },
  play: function (artist, track) {
    console.log(`${this.name} is playing '${track}' by ${artist}`);
  },
};

const orders = [
  {
    template: { name: 'ACME Printer'},
    parts: ['print']      
  },
  {
    template: { name: 'Initech Scanner'},
    parts: ['scan']      
  },
  {
    template: { name: 'ComTron Copier'},
    parts: ['scan', 'print']      
  },
  {
    template: { name: 'BoomBox Stereo'},
    parts: ['play']      
  }
];


function solve(library, orders) {
  const l = [];

  for (let order of orders) {
      let k = order.template;
      let fun = order.parts;
      const s = {};
      for (let el in k) {
        s[el] = k[el];
        
      }
      for (el of fun) {
        s[el] = library[el];
      }

      l.push(s);
    
  }

  
  return l;
}

const products = solve(library, orders);
console.log(products);

for (let el of products) {
  console.log(el);
}