
var totalpass;
var totalfail;
var count1 = 0, count2 = 0, count3 = 0;
var totalstudents;
var totalpasspercent;
var pass = ["0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0"];
var fail = ["0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0"];
var sum = new Array();
var average = new Array();
var m1 = new Array();
var m2 = new Array();
var m3 = new Array();
var m4 = new Array();
var N = ["0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0"];
var Grades = ["0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0"];
var Sections = new Array();
var passpercent = ["0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0"];
var x = 0;


function myFunction() {
    x = document.getElementById("grades").value;
    document.getElementById("data2").value = x;

    y = document.getElementById("sections").value;
    document.getElementById("data3").value = y;
}




function readmarks() {


    Grades[x] = document.getElementById("grades").value;
    Sections[x] = document.getElementById("sections").value;

    m1[x] = parseInt(document.getElementById('mark1').value, 10);
    m2[x] = parseInt(document.getElementById('mark2').value, 10);
    m3[x] = parseInt(document.getElementById('mark3').value, 10);
    m4[x] = parseInt(document.getElementById('mark4').value, 10);

    validateForm();

    //alert("submitted");
    x++;

}


function validateForm() {
    var x = document.myForm.mark1.value;
    var y = document.myForm.mark2.value;
    var z = document.myForm.mark3.value;
    var u = document.myForm.mark4.value;

    if (x == "" || y == "" || z == "" || u == "") {
        alert("Please enter all the fields")
    }
    else if (x < 1 || x > 100) {
        alert("Enter valid mark for english");
        return false;
    }
    else if (y < 1 || y > 100) {
        alert("Enter valid mark for maths");
        return false;
    }
    else if (z < 1 || z > 100) {
        alert("Enter valid mark for science");
        return false;
    }
    else if (u < 1 || u > 100) {
        alert("Enter valid mark for social");
        return false;
    }

    else {

        alert("Details submitted successfully");
        averagecalc();
        return true;
    }

}


function averagecalc() {
    sum[x] = m1[x] + m2[x] + m3[x] + m4[x];
    document.getElementById("mark5").value = sum[x];
    average[x] = sum[x] / 4;
    document.getElementById("mark6").value = average[x];


    if (average[x] >= 60) {
        pass[Grades[x]]++;
        N[Grades[x]]++;
        count1++;
        count3++;


    }
    else {
        fail[Grades[x]]++;
        N[Grades[x]]++;
        count2++;
        count3++;


    }

    //cleartext();
    passpercent[Grades[x]] = ((pass[Grades[x]] / N[Grades[x]]) * 100).toFixed(2);

    totalpass = count1;
    totalfail = count2;
    totalstudents = count3;
    totalpasspercent = ((count1 / count3) * 100).toFixed(2);
}


function display_array() {
    var myTable = "<h1>Final Results</h1>";
    myTable += "<table border='5'><tr><td style='width: 100px; color: red;'>Grades</td>";
    myTable += "<td style='width: 100px; color: red; text-align: right;'>No of students</td>";
    myTable += "<td style='width: 100px; color: red; text-align: right;'>Pass</td>";
    myTable += "<td style='width: 100px; color: red; text-align: right;'>Fail</td>";
    myTable += "<td style='width: 100px; color: red; text-align: right;'>Average</td></tr>";




    for (var i = 1; i <= 12; i++) {

        myTable += "<tr><td style='width: 100px;'>Grade" + i + "</td>";
        myTable += "<td style='width: 100px; text-align: right;'>" + N[i] + "</td>";
        myTable += "<td style='width: 100px; text-align: right;'>" + pass[i] + "</td>";
        myTable += "<td style='width: 100px; text-align: right;'>" + fail[i] + "</td>";
        myTable += "<td style='width: 100px; text-align: right;'>" + passpercent[i] + "</td></tr>";

    }

    myTable += "</table>";
    myTable += "<h3>Total passed students:" + totalpass + "</h3>";
    myTable += "<h3>Total failed students:" + totalfail + "</h3>";
    myTable += "<h3>Total students are:" + totalstudents + "</h3>";
    myTable += "<h3>Total Pass percentage:" + totalpasspercent + "</h3>";

    document.getElementById("Result").innerHTML = myTable;
}





function cleartext() {
    document.getElementById('data1').value = " ";
    document.getElementById('mark1').value = " ";
    document.getElementById('mark2').value = " ";
    document.getElementById('mark3').value = " ";
    document.getElementById('mark4').value = " ";
    document.getElementById('mark5').value = " ";
    document.getElementById('mark6').value = " ";
}

