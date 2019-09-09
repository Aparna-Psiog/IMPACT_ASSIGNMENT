//Creating Object and modifying object properties

const car={
    color : 'Red',
    brand    :  'Maruti',
    price: 1000,
    
    displaydata : function(){
      console.log(`The car color is ${this.color} and costs $ ${this.price}`);  
    }
  };

car.displaydata();

car.price=2000;

car.displaydata();

//Adding and deleting properties on an object

car['noofwheels']='four';

console.log(`The number of wheels are ${car.noofwheels}`);

delete car.noofwheels;

console.log(car.noofwheels);



//Calling methods by property name
const bike={
  color:'black',

  show: function showitem()
  {
    console.log(`The item is ${this.color}`);
  }
};

bike.show();

console.log(Object.keys(car));
console.log(Object.values(car));

console.log(Object.keys(bike));
console.log(Object.values(bike));
