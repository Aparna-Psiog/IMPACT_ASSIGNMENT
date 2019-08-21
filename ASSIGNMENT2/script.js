
       var totalpass=0;
       var totalfail=0;
       var pass=0;
       var fail=0;
       var sum,average;
       var i=1;
       var j=1;
       var N=5;
       var G=2;

       while(i<=G)
       {
           while(j<=N)
           {
               readmarks();
               averagecalc();
               cleartext();
               j=j+1;
           }
   

           i=i+1;
       }

 function readmarks()
{

    var m1 = parseInt(document.getElementById('mark1').value,10);
    var m2 = parseInt(document.getElementById('mark2').value,10);
    var m3 = parseInt(document.getElementById('mark3').value,10);
    var m4 = parseInt(document.getElementById('mark4').value,10);


        sum= m1+m2+m3+m4;
        document.getElementById("mark5").value=sum;
    
}

function averagecalc()
{
    average=sum/4;
    document.getElementById("mark6").value=average;

    if(average>60)
    {
     pass+=pass+1;
     totalpass+=pass;
    }
    else{
        fail+=fail+1;
        totalfail+=fail;
    }
            
    document.getElementById("data4").value=pass;

    document.getElementById("data5").value=fail;

    document.getElementById("data6").value=totalpass;

    document.getElementById("data7").value=totalfail;
}
   

   

    //document.write("passstudents are:"+pass);
    //document.write("failstudents are:"+fail);
    //document.write("totalpassstudents are:"+totalpass);
    //document.write("total fail studnets are:"+totalfail);






function cleartext(){
    document.getElementById('data1').value=" ";
    document.getElementById('data2').value=" ";
    document.getElementById('data3').value=" ";
    document.getElementById('mark1').value=" ";
    document.getElementById('mark2').value=" ";
    document.getElementById('mark3').value=" ";
    document.getElementById('mark4').value=" ";
    document.getElementById('mark5').value=" ";
    document.getElementById('mark6').value=" ";

}
