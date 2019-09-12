function validation(mail)
{
    const regex=new RegExp(/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/);
    if(regex.test(mail))
    {
        console.log(mail);
        console.log("Valid email address");
    }
    else{
        console.log(mail);
        console.log("Invalid email address");
    }
    
}

function phone_valid(phone_number)
{
    const regex1=new RegExp(/^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/)
    if(regex1.test(phone_number))
    {
        console.log(phone_number);
        console.log("Valid phone number");

    }
    else{
        console.log(phone_number);
        console.log("Invalid phone number");
    }
}
validation("me-info@example.com");
validation("me-info@example.comgjh");
phone_valid("032-243-8991");
phone_valid("04442-243-8991");
