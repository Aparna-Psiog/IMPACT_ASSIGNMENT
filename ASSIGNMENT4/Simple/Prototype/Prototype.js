function car(name,price,color)
{
    this.name=name;
    this.price=price;
    this.color=color;

    this.describe=function(){
        console.log(this.name);
        console.log(this.price);
        console.log(this.color);
    }
}

car.prototype.noofwheels=function(){
    console.log(this.name +" "+"has four wheels");
}

const car_obj1=new car("Dzire",900000,"Grey");
const car_obj2=new car("Benz",1000000,"Black");
const car_obj3=new car("Audi",2000000,"Blue");

car_obj1.describe();
car_obj2.describe();
car_obj3.describe();

car_obj1.noofwheels();
car_obj2.noofwheels();
car_obj3.noofwheels();

car.prototype={
    type:"petrol",
    warranty:"5 years",
}

console.log(car_obj1.type);//gives undefined because the updated values are not known for car_obj1,car_obj2,car_obj3
console.log(car_obj1.name);//This is accessible beacuse the old properties still exists
const car_obj4=new car();//A new object created for car
console.log(car_obj4.type);//This will give the updated value