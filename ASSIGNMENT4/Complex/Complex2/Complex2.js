//Nested Inheritance Example

function vehicle()
{
    this.type="Land vehicle";
    this.type_of_vehicle=function(){
        console.log("All Vehicles are :"+" "+this.type);
        console.log("---------------------------------------------------------------------------")
    }
}

function car(carname,color,price,seats,year){
    this.noofwheels=2;
    this.type_of_tank="Petrol";
    this.discount=500;

    this.display_details=function(){
        console.log(`Description :`)
        console.log(`Number of wheels is ${this.noofwheels}`);
        console.log(`Type of tank is ${this.type_of_tank}`);
        console.log(`Discount for all the cars is ${this.discount}`);
     };
     this.cal_price=function(price_value,Discount_value){
        price_value=price_value-Discount_value;
        console.log("The price of the car"+" "+this.carname+" "+"is"+" "+price_value);
        return price_value;
    };
}

function Sports_car(carname,color,price,seats,year){
    this.carname=carname;
    this.color=color;
    this.price=price;
    this.seats=seats;
    this.year=year;
    
    this.seating_capacity=function(){
        console.log("---------------------------------------------------------------------------");
        console.log("Description of Sports car:");
        console.log(this.carname+" "+"has capacity for"+" "+this.seats+" "+"seats"+" "+"of color"+" "+this.color+" "+"which costs Rs"+" "+this.price);
        console.log(`Racing Cars have warranty upto ${this.year}`);
    }
    this.ride=function(speed,mileage){
       console.log(`Speed: ${speed}`);
       console.log(`Mileage: ${mileage}`);
     
    }

}

function Racing_car(carname,color,price,seats,year){
    this.carname=carname;
    this.color=color;
    this.price=price;
    this.seats=seats;
    this.year=year;
    
    this.warranty=function(){
        console.log(`The warranty of the carname ${carname} is 5 years`);
    }

    this.describe_car=function(){
        console.log("---------------------------------------------------------------------------");
        console.log(`Description of Racing car:`);
        console.log(`Car name : ${carname}`);
        console.log(`Color : ${color}`);
        console.log(`Price :${price}`);
        console.log(`Number of seats : ${seats}`);
        console.log(`Year :${year}`);
       
    }
  

}

function Luxurious_car(carname,color,pricevalue,seats,year){
    this.carname=carname;
    this.color=color;
    this.pricevalue=pricevalue;
    this.seats=seats;
    this.year=year;

    this.displaydetails=function(){
        console.log(`Description of Luxurious car:`);
        console.log(`The car name is ${this.carname}`);
        console.log(`Color is ${this.color}`);
        console.log(`price_value ${this.pricevalue}`);
        console.log(`Seats are:${this.seats}`);
        console.log(`Year is ${this.year}`);

     };
     
}

//showing nested inheritance using prototype
car.prototype=new vehicle();
Sports_car.prototype=new car();
Racing_car.prototype=new Sports_car();
Luxurious_car.prototype=new car();

var car1=new car();
console.log(car1.type);//prints a property of vehicle
car1.type_of_vehicle();//prints method of vehicle
car1.display_details();


var race1=new Racing_car("BMW","Blue",550000,2,2018);//creating object of racing car 
race1.seating_capacity();//calling method of Sports_car object
race1.ride("100kmph","70kpl");
race1.cal_price(900000,500);//calling method of car object
console.log("---------------------------------------------------------------------------")


//Call() and apply()

function Audi()
{
    this.name="AudiA4";
    Luxurious_car.call(this,"AudiA5","Green",950000,7,2017);
}

var a1=new Audi();
a1.displaydetails();



function Chevrolet()
    {
    this.color="white";
    Racing_car.apply(this,["Chevrolet",this.color,700000,6,2010]);
    }


    var chev=new Chevrolet();
    chev.describe_car();
    chev.warranty();
    console.log("---------------------------------------------------------------------------");
  
   console.log("Other services:")
    var carpayment=(function()   //Main Module
    {
        var prinicipal=10000;
        var fixed_price=500000;
        var tax=2000;
        var delivery_charge=500;
        var tot_year=2;

        var payment_calculation=function(){
            var payment;
            payment=(prinicipal+fixed_price+tax);
            return payment;
            
        }

        full_amount=payment_calculation()+delivery_charge;

        let service_first=(function(){   //submodule
            let service_given;
            if(tot_year==2)
            {
                service_given="The service will be given in a year for"+" "+2+"times"+" "+"and"+" "+4+"times for"+" "+tot_year+"years";
            }
            return service_given;
        })();

        console.log(service_first);
        return full_amount;
    }());
    console.log(`The total car payment:`);
    console.log(carpayment);
    console.log("---------------------------------------------------------------------------")
    
    



   



