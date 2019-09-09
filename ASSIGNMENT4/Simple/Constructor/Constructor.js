function vehicle(color,brand,price)
{
    this.color=color;
    this.brand=brand;
    this.price=price;

    this.displaydetails=function(y){
        console.log(y + " "+"is"+" "+ "of color" + this.color + " "+"brand" + this.brand +" "+ "and price" + this.price);
    }

    this.getprice=function(x){
        this.price=this.price+x;
       console.log(`The new increased price is ${this.price}`);
      
    } 
}


let AudiA4=new vehicle('White','Audi',1000000);
let innova=new vehicle('Black','Toyota',787342);
AudiA4.displaydetails("AudiA4");
innova.displaydetails("innova");
AudiA4.getprice(100);
innova.getprice(200);
AudiA4.displaydetails("AudiA4");
innova.displaydetails("innova");

console.log(AudiA4 instanceof vehicle);
console.log(innova instanceof vehicle);
console.log(typeof AudiA4);
console.log(typeof innova);
