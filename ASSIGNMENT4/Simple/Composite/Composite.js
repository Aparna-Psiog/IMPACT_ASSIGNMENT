//This can be illustrated for inheritance also

function Car(name,color) {
    this.name = name;
    this.color = color;
}

Car.prototype.display = function () {
    console.log(this.car);
}

function Car_showroom(name) {
    this.name = name;
    this.cars = [];
}

Car_showroom.prototype.add = function (item) {
    this.cars.push(item);
}



Car_showroom.prototype.getCarName = function (index) {
    return this.cars[index].name;
}
Car_showroom.prototype.getCarColor = function(index) {
    return this.cars[index].color;
}

Car_showroom.prototype.describe = function() {
    console.log(this.name);
    for (let i = 0, length = this.cars.length; i < length; i++) {
        console.log("   ", this.getCarName(i) , "of color " , this.getCarColor(i));
        
    }
}

Showroom1 = new Car_showroom('Showroom 1');
Showroom2 = new Car_showroom('Showroom 2');
Showroom3 = new Car_showroom('Showroom 3');

car1 = new Car('Maruti800' , 300000);
car2 = new Car('Benz' , 900000);
car3 = new Car('Audi' , 1000000);

Showroom1.add(car1);
Showroom1.add(car2);

Showroom2.add(car1);
Showroom2.add(car3);

Showroom3.add(car1);
Showroom3.add(car2);
Showroom3.add(car3);

Showroom1.describe();
Showroom2.describe();
Showroom3.describe();