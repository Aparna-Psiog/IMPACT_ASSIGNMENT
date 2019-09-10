let carname = "Alto";

var brand="Maruti";

var price="500000";

function describe_data(){
    console.log(`The  price of the brand ${this.brand} is ${this.price}`);
}

const vehicle ={
    carname:"Innova",

    color:"blue",

    display_data:function(){
        console.log(`Car name is`+this.carname+`which is of color`+this.color);//prints the local variable of vehicle object
        console.log(`Car name is `+carname +`which belongs to brand`+brand+`of price`+price);//prints the global variables
    }
}

window.describe_data();

console.log(window.brand);//prints the brand since the global variable is accessible by window object

console.log(window.carname);//does not print because of the let keyword


vehicle.display_data();