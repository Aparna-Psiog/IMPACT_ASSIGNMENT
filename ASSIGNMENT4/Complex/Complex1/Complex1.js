var Location="Chennai";

function print_location(){
    console.log("The location of the showroom is in"+" "+Location);
}

class car_showroom{

        constructor(carname,brand,price){

        this.carname=carname;
        this.brand=brand;
        this.price=price;

        this.show_room_name=function(){
            var showroomname="Car_Park";
            console.log("My car showroom name is"+" "+showroomname);
        }

        this.displaydetails=function(){
           console.log(`The car name is ${this.carname}`);
           console.log(`Brand of the car ${this.carname} is ${this.brand}`);
           console.log(`Price of the car ${this.carname} is ${this.price}`);
        }

        this.warranty_period=function(){
            if(this.carname=="AudiA4")
                console.log("The warranty period of the car"+this.carname+" "+"is"+" "+"5 years");
            if(this.carname=="Innova")
                console.log("The warranty period of the car"+this.carname+" "+"is"+" "+"10 years");
            if(this.carname=="Alto")
                console.log("The warranty period of the car"+this.carname+" "+"is"+" "+"7 years");    
        }
    }
};

car_showroom.prototype.Free_service=function()
{
    console.log(this.carname+" "+"has a free service in the sixth month after buying the car");
}

const car_obj1=new car_showroom("Innova","Toyota",900000);
const car_obj2=new car_showroom("AudiA4","Audi",1000000);
const car_obj3=new car_showroom("Alto","Maruti",400000);

console.log(window.Location);//Prints the Location since it is a global variable accessible by window object
window.print_location();//window object can access print_location function since it is global


car_obj1.show_room_name();

console.log(car_obj1.showroomname);//Encapsulation-cannot be accessed because it is a private variable encapsulated inside show_room_name function

console.log("----------------------Showroom1---------------------");
car_obj1.displaydetails();
console.log("----------------------Showroom2---------------------");
car_obj2.displaydetails();
console.log("----------------------Showroom3---------------------");
car_obj3.displaydetails();
console.log("-----------------------------------------------------");


car_obj1.warranty_period();
car_obj2.warranty_period();
car_obj3.warranty_period();



console.log("------------------------------------------------------------------");
car_obj1.Free_service();
car_obj2.Free_service();
car_obj3.Free_service();
console.log("------------------------------------------------------------------");

car_showroom.prototype.discount_price=500;

const dp1=car_showroom.prototype.discounted_price=(function(){
    car_obj1.price=car_obj1.price-car_obj1.discount_price;
    console.log("The discounted price of all cars is"+" "+car_obj1.price);
})();

const dp2=car_showroom.prototype.discounted_price=(function(){
    car_obj2.price=car_obj2.price-car_obj2.discount_price;
    console.log("The discounted price of all cars is"+" "+car_obj2.price);
})();

const dp3=car_showroom.prototype.discounted_price=(function(){
    car_obj3.price=car_obj3.price-car_obj3.discount_price;
    console.log("The discounted price of all cars is"+" "+car_obj3.price);
})();

console.log("------------------------------------------------------------------");


car_showroom.prototype.mode;
car_obj1.mode="Petrol";
car_obj2.mode="Diesel";
car_obj3.mode="Petrol";

car_obj1.color="Red";
car_obj2.color="Blue";
car_obj3.color="Black";

function added_colors(){
    car_obj1.color="Black";
    car_obj2.color="White";
    car_obj3.color="Green";
}

added_colors();
console.log("New colors changed");

car_showroom.prototype.total_profit;

car_showroom.prototype.profit;
car_obj1.profit=200;
car_obj2.profit=500;
car_obj3.profit=400;



(function Profit_calc(){

    
    car_obj1.total_profit = (car_obj1.price * car_obj1.profit);
    console.log("Total profit made by showrrom 1 is " , car_obj1.total_profit);
   
    
    car_obj2.total_profit = (car_obj2.price * car_obj2.profit);
    console.log("Total profit made by shwroom 2 is " ,  car_obj2.total_profit);
   
  })();

  console.log("------------------------------------------------------------------");


  let people_visited = (function () {
    let count=0;

  
    function no_of_people_visted() {
     count += 1;
      console.log(`Number of people visited the showroom are:${count}`);
    }
  
    function displayName() {
      console.log(car_obj1.displaydetails());
      console.log(car_obj2.displaydetails());
      console.log(car_obj2.displaydetails());
    }
  
    function display_visited() {
     no_of_people_visted();
    }
  
    return {
      name: displayName,
      visited: display_visited
    };
  })();


  console.log(people_visited.name());
console.log(people_visited.visited());
console.log(people_visited.visited());
console.log(people_visited.visited());


