var car=(function() //Main Module
{
    var carname="Audi";
    var price=500000;
    var discount=2000;
    var discountpercent;
    console.log(carname);

    var discounted_price=function(){
        return price-discount;
    }

    discountpercent=discounted_price()/100;

    let find_warrantyperiod=(function(){ //SubModule
        let warranty;

        if(carname=="Audi")
        {
            warranty=5;
        }
        return warranty;
    })();

    console.log("The warranty period for Audi is"+" "+find_warrantyperiod+" "+"years");
    return discountpercent;

}());

console.log(car);