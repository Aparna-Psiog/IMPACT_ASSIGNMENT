
       var totalpass=["0","0","0","0","0","0","0","0","0","0","0","0","0"];
       var totalfail=["0","0","0","0","0","0","0","0","0","0","0","0","0"];
       var totalstudents=["0","0","0","0","0","0","0","0","0","0","0","0","0"];
       var pass=["0","0","0","0","0","0","0","0","0","0","0","0","0"];
       var fail=["0","0","0","0","0","0","0","0","0","0","0","0","0"];
       var sum=new Array();
       var average=new Array();
       var m1=new Array();
       var m2=new Array();
       var m3=new Array();
       var m4=new Array();
       var N=["0","0","0","0","0","0","0","0","0","0","0","0","0"];
       var Grades=["0","0","0","0","0","0","0","0","0","0","0","0","0"];
       var Sections=new Array();
       var passpercent=["0","0","0","0","0","0","0","0","0","0","0","0","0"];
       var x= 0;


       function myFunction() 
       {
           x = document.getElementById("ddlFruits").value;
           document.getElementById("data10").value= x;
       }
       
function cleartext(){
    document.getElementById('data1').value=" ";
    document.getElementById('mark1').value=" ";
    document.getElementById('mark2').value=" ";
    document.getElementById('mark3').value=" ";
    document.getElementById('mark4').value=" ";
    document.getElementById('mark5').value=" ";
    document.getElementById('mark6').value=" ";
}

function Add() {
    var ddl = document.getElementById("ddlFruits");
    var option = document.createElement("OPTION");
    option.innerHTML = document.getElementById("txtText").value;
    option.value = document.getElementById("txtValue").value;
    ddl.options.add(option);
}
function Add1() {
    var ddl1 = document.getElementById("sections");
    var option = document.createElement("OPTION");
    option.innerHTML = document.getElementById("txtText1").value;
    option.value = document.getElementById("txtValue1").value;
    ddl1.options.add(option);
}

function readmarks()
{

 
    Grades[x] = document.getElementById("ddlFruits").value;
    Sections[x] = document.getElementById("sections").value;

    m1[x] = parseInt(document.getElementById('mark1').value,10);
    m2[x] = parseInt(document.getElementById('mark2').value,10);
    m3[x] = parseInt(document.getElementById('mark3').value,10);
    m4[x] = parseInt(document.getElementById('mark4').value,10);

    validateForm();
   
        //alert("submitted");
    averagecalc();


    x++;
    
    cleartext();

}
   

function averagecalc()
{
    sum[x]= m1[x]+m2[x]+m3[x]+m4[x];
    document.getElementById("mark5").value=sum[x];
    average[x]=sum[x]/4;
    document.getElementById("mark6").value=average[x];

    if(average[x]>=60)
    {
     pass[Grades[x]]++;
     N[Grades[x]]++;
    
    // totalpass=pass[Grades[x]];
     
    }
    else { 
        fail[Grades[x]]++;
        N[Grades[x]]++;
        //totalfail=fail[Grades[x]]++;
       
    }
    passpercent[Grades[x]]=((pass[Grades[x]]/N[Grades[x]])*100).toFixed(2);

    

}


function display_array()
{
    var myTable="<h1>Final Results</h1>";
    myTable+= "<table border='5'><tr><td style='width: 100px; color: red;'>Grades</td>";
    myTable+= "<td style='width: 100px; color: red; text-align: right;'>No of students</td>";
    myTable+="<td style='width: 100px; color: red; text-align: right;'>Pass</td>";
    myTable+="<td style='width: 100px; color: red; text-align: right;'>Fail</td>";
    myTable+="<td style='width: 100px; color: red; text-align: right;'>Average</td></tr>";
   

   
  
    for (var i=1; i<=12; i++) {
        
        myTable+="<tr><td style='width: 100px;'>Grade" + i + "</td>";
        //myArray[i] = myArray[i].toFixed(3);
        myTable+="<td style='width: 100px; text-align: right;'>" + N[i] + "</td>";
        myTable+="<td style='width: 100px; text-align: right;'>" + pass[i] + "</td>";
        myTable+="<td style='width: 100px; text-align: right;'>" + fail[i] + "</td>";
        myTable+="<td style='width: 100px; text-align: right;'>" + passpercent[i] + "</td></tr>";
        
      } 

    
   myTable+="</table>";

 document.getElementById("Result").innerHTML=myTable;
}


function validateForm()
{
var x=document.myForm.mark1.value;
var y=document.myForm.mark2.value;
var z=document.myForm.mark3.value;
var u=document.myForm.mark4.value;

if(x=="" || y==""||z==""||u=="")
{
    alert("Please enter all the fields")
}
else if (x<0 || x >100)
  {
  alert("Enter valid mark for english");
  return false;
  }
  else if (y<0 || y >100)
  {
  alert("Enter valid mark for maths");
  return false;
  }
  else if (z<0 || z >100)
  {
  alert("Enter valid mark for science");
  return false;
  }
  else if (u<0 || u >100)
  {
  alert("Enter valid mark for social");
  return false;
  }

else {
    alert("Details submitted successfully");
    return true;
}

}



