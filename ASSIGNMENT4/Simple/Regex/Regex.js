var vehicle = function(){
    var carname="Swift Dzire";

    var reg=new RegExp(/\d+/);

    return {
        set_name= function(newvalue){
        if(reg.test(newvalue))
        {
            console.log("Invalid car name");

        }

        else{
            carname=newvalue;
        }
    },

    get_name=function()
    {
        return carname;
    }
}
}();

console.log(vehicle.get_name());
vehicle.set_name("Dzire");
console.log(vehicle.get_name());