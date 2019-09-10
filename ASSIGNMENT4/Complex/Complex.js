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


console.log(window.Location);//Prints the Location since it is a global variable accessible by window object
window.print_location();//window object can access print_location function since it is global

console.log("------------------------------------------------------------------");
car_obj1.Free_service();
car_obj2.Free_service();
car_obj3.Free_service();
console.log("------------------------------------------------------------------");

car_showroom.prototype.discount_price=500;



const dp=car_showroom.prototype.discounted_price=(function(){
    car_obj1.price=car_obj1.price-car_obj1.discount_price;
    console.log("The discounted price of"+carname+car_obj1.price);
})();



