function car(brand,color,noofwheels,price,tax,deliverycharge)
{
    this.brand=brand;
    this.color=color;
    this.noofwheels=noofwheels;
    this.price=price;
    this.tax=tax;
    this.deliverycharge=deliverycharge;


    this.display_data=function(){
      console.log(`The car is of brand ${this.brand},color ${this.color} and has ${this.noofwheels} wheels `);
    };


    this.calculate_originalprice=function(){
        return ((this.price+this.tax+this.deliverycharge)*10);
    };


    this.display_originalprice=function(){
    var original_price=this.calculate_originalprice();
    console.log(`The original price of the car is`+original_price);
    };
}



var Benz=new car("Mercedes","Red",4,9000000,20,100);
Benz.display_data();
Benz.display_originalprice();

console.log(Benz.price);
console.log(Benz.brand);
console.log(Benz.color);

console.log(Benz.original_price);//the variable original_price cannot be accessed because it is a private variable encapsulated inside display_originalprice
