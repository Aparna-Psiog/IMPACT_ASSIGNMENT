const carname='Swift';

function discount_percentage(price,deliverycharge,discount){
    var original_price=price;
    var deliver=deliverycharge;
    var discountvalue=discount;
   

    function calculate(){
        console.log(`The car name is ${carname}`);
        console.log((original_price+deliver-discountvalue)*100);
    }
return calculate();
}


let dzire= discount_percentage(100000,100,500);
