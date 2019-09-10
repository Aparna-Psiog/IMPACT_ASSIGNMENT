const carname='Swift';

function discount_percentage(price,deliverycharge,discount){

    var original_price=price;

    var deliver=deliverycharge;

    var discountvalue=discount;
   

   return function(){

        console.log(`The car name is ${carname}`);
        
        return((original_price+deliver-discountvalue)*100);
    };

}


let dzire= discount_percentage(1000000,100,500);

console.log("The original price of the car is"+" "+dzire());

  