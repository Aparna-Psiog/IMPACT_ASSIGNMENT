var vehicle = [
    { product: 'Car',

     name: 'Innova'

     },

    { product: 'Bike',

    name: 'Yamaha'
 }
  ];
  
  for (var i = 0; i < vehicle.length; i++) {

    (function(i) {

      this.print = function() {
        console.log('#' + i + ' ' + this.product + ': ' + this.name);
      }
      this.print();
    }).call(vehicle[i], i);

    
    (function(i) {

        this.print = function() {
          console.log('#' + i + ' ' + this.product + ': ' + this.name);
        }
        this.print();
      }).apply[vehicle[i], i];
  }