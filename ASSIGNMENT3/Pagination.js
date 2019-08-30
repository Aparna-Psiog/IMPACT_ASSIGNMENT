var current_page = 1;
var records_per_page=5;
var count=Object.keys(record_copy).length;

function go()
{
   
    records_per_page = document.getElementById("myInput1").value;
    validation(records_per_page);
    current_page = 1;
    changePage(current_page);
}
   
function validation(x)
{

    if(x=="")
    {
        alert("Enter some value");
       insertNewRecord(data);
        return false;
    }
   
    else if((x<0)||x>1000)
    {
     alert("Enter valid values");
     insertNewRecord(data);
     return false;
    }
    else{
        
        return true;  
    }
    
}

function prevPage()
{
    deleteall();
    if (current_page > 1) {
        current_page--;
        changePage(current_page);
    }
}

function nextPage()
{
    deleteall();
    if (current_page < numPages()) {
        current_page++;
        changePage(current_page);
    }
}

function changePage(page)
{
    deleteall();
    var btn_next = document.getElementById("btn_next");
    var btn_prev = document.getElementById("btn_prev");
    //var listing_table = document.getElementById("listingTable");
    var page_span = document.getElementById("page");

    // Validate page
    if (page < 1) page = 1;
    if (page > numPages()) page = numPages();

    for (var i = (page-1) * records_per_page; i < (page * records_per_page) && i< records.length; i++) {
        var table = document.getElementById("myTable").getElementsByTagName('tbody')[0];
   
        var newRow = table.insertRow(table.length);
        cell1=newRow.insertCell(0);
        cell1.innerHTML=`<input id="chk" type="checkbox" value="check"/>`
        cell1 = newRow.insertCell(1);
        cell1.innerHTML = record_copy[i].itemName;
        cell2 = newRow.insertCell(2);
        cell2.innerHTML = record_copy[i].description;
        cell3 = newRow.insertCell(3);
        cell3.innerHTML = record_copy[i].price;
        cell4 = newRow.insertCell(4);
        cell4.innerHTML = record_copy[i].category;
        cell4 = newRow.insertCell(5);
        cell4.innerHTML = 
        `<input type='button' class="Edit" value='Edit' onclick='onEdit(this)'>
        <input type='button' class="Read" value='Read' onclick='onRead(this)'>
        <input type='button' class="Delete" value='Delete' onclick='onDelete(this)'>`
        
    
}
    page_span.innerHTML = page;

    if (page == 1) {
        btn_prev.style.visibility = "hidden";
    } else {
        btn_prev.style.visibility = "visible";
    }

    if (page == numPages()) {
        btn_next.style.visibility = "hidden";
    } else {
        btn_next.style.visibility = "visible";
    }
}

function numPages()
{
    return Math.ceil(Object.keys(record_copy).length / records_per_page);
}

function num_pages_after()
{
    return Math.ceil(Object.keys(record_copy).length);
}

window.onload = function() {
    changePage(1);
};