function Car(carname,brand,color)
{
    this.carname=carname;
    this.brand=brand;
    this.color=color;
}

Car.prototype.describecar=function()
{
    console.log(`The car name is ${this.carname} with brand ${this.brand} of color ${this.color}`);
}

const Benz=new Car("benz","Mercedes","Black");
Benz.describecar();


//Using Object.create

const BenzC=Object.create(Benz);

console.log(BenzC);//Nothing is displayed

BenzC.describecar();

var v=Object.getPrototypeOf(Benz);

console.log(v);//returns the Benz object details

console.log(BenzC.__proto__===Benz);//returns true because Audi is linked to Car



