var selectedRow = null
var records=readvalues();
function onFormSubmit() {
 
    if (validate()) {
     
        var formData = readFormData();
        if (selectedRow == null)
      
            insertNewRecord(formData);
        
    else
  
            updateRecord(formData);
    
        resetForm();
    }
}

function div_show() {
    document.getElementById('abc').style.display = "block";
    }

    function div_hide(){
        document.getElementById('abc').style.display = "none";
        }

function readvalues(){
    //var records={};
    var records = [
        { itemName: 'Tomato soup', 
        description: 'Tomato soup-A starter with pieces of breads', 
        price: '100',
        category: 'Starters' },

        { itemName: 'Bhel puri',
         description: 'A chat with tomato sauce', 
         price: '170', 
         category: 'Chat' },

        { itemName: 'French fries',
         description: 'Fried crisps with Sauce',
          price: '120', 
          category: 'Starters' },

        { itemName: 'North Indian Thali', 
        description: 'Meal with chapathi,paratta,Panner butter masala',
        price: '300',
        category: 'Maincourse' },

        { itemName: 'Vanilla Milkshake', 
        description: 'A shake with vanilla flavour with icecream', 
        price: '290',
         category: 'Desserts' },

        { itemName: 'South Indian Thali',
         description: 'Meal with rice,Sambhar,rasam,vegetable,aplam',
          price: '300', 
          category: 'Maincourse' },

        { itemName: 'Pani puri', 
        description: 'A chat with tomato sauce', 
        price: '250',
        category: 'Chat' },
        { itemName: 'Pani puri', 
        description: 'A chat with tomato sauce', 
        price: '250',
        category: 'Chat' },

        { itemName: 'Pani puri', 
        description: 'A chat with tomato sauce', 
        price: '250',
        category: 'Chat' },
        { itemName: 'Pani puri', 
        description: 'A chat with tomato sauce', 
        price: '250',
        category: 'Chat' }

    ]
    //records["fullName"]=["Aparna"];
    //records["empCode"]=["hbjhb"];
    //records["salary"]=["87879"];
    //records["city"]=["chennai"];
    for(var i=0;i<records.length;i++)
    {
        insertNewRecord(records[i]);
    }
   
    return records;
}

function readFormData() {

    var formData = {};
    formData["itemName"] = document.getElementById("itemName").value;
    formData["description"] = document.getElementById("description").value;
    formData["price"] = document.getElementById("price").value;
    formData["category"] = document.getElementById("category").value;
    return formData;
}

function insertNewRecord(data) {
    var table = document.getElementById("myTable").getElementsByTagName('tbody')[0];
    var newRow = table.insertRow(table.length);
    cell1=newRow.insertCell(0);
    cell1.innerHTML=`<input id="chk" type="checkbox" value="check"/>`
    cell1 = newRow.insertCell(1);
    cell1.innerHTML = data.itemName;
    cell2 = newRow.insertCell(2);
    cell2.innerHTML = data.description;
    cell3 = newRow.insertCell(3);
    cell3.innerHTML = data.price;
    cell4 = newRow.insertCell(4);
    cell4.innerHTML = data.category;
    cell4 = newRow.insertCell(5);
    cell4.innerHTML = 
    `<input type='button' class="Edit" value='Edit' onclick='onEdit(this)'>
    <input type='button' class="Read" value='Read' onclick='onRead(this)'>
    <input type='button' class="Delete" value='Delete' onclick='onDelete(this)'>`
}

function resetForm() {
    document.getElementById("itemName").value = "";
    document.getElementById("description").value = "";
    document.getElementById("price").value = "";
    document.getElementById("category").value = "";
    selectedRow = null;
}

function onEdit(td) {
    selectedRow = td.parentElement.parentElement;
    document.getElementById("itemName").value = selectedRow.cells[1].innerHTML;
    document.getElementById("description").value = selectedRow.cells[2].innerHTML;
    document.getElementById("price").value = selectedRow.cells[3].innerHTML;
    document.getElementById("category").value = selectedRow.cells[4].innerHTML;
    div_show();
}
function updateRecord(formData) {
    selectedRow.cells[1].innerHTML = formData.itemName;
    selectedRow.cells[2].innerHTML = formData.description;
    selectedRow.cells[3].innerHTML = formData.price;
    selectedRow.cells[4].innerHTML = formData.category;
}

function onDelete(td) {
    if (confirm('Are you sure to delete this record ?')) {
        row = td.parentElement.parentElement;
        document.getElementById("myTable").deleteRow(row.rowIndex);
        resetForm();
    }
}
function validate() {
    isValid = true;
    if (document.getElementById("itemName").value == "") {
        isValid = false;
        document.getElementById("itemNameValidationError").classList.remove("hide");
    } else {
        isValid = true;
        if (!document.getElementById("itemNameValidationError").classList.contains("hide"))
            document.getElementById("itemNameValidationError").classList.add("hide");
    }
    return isValid;
}



    

function deleteselected() 
{
var table=document.getElementById("myTable");
var rowCount=table.rows.length;
if (confirm('Are you Sure ?')) {
for (var i=1; i<rowCount; i++) {
var row=table.rows[i];
var chkbox=row.cells[0].childNodes[0];
if (null!=chkbox&&true==chkbox.checked) {

table.deleteRow(i);
rowCount--;
i--;
 }
}
}
}

function getcheckboxes() {
    var node_list = document.getElementsByTagName('input');
    var checkboxes = [];
    for (var i = 0; i < node_list.length; i++) 
    {
        var node = node_list[i];
        if (node.getAttribute('type') == 'checkbox') 
    {
            checkboxes.push(node);
        }
    } 
    return checkboxes;
}

function toggle(source) {
    checkboxes = getcheckboxes();
    for(var i=0, n=checkboxes.length;i<n;i++) 
    {
      checkboxes[i].checked = source.checked;
    }
  }
  function searchfunction() {
    // Declare variables 
    var input, filter, table, tr, td,td1, i, txtValue,txtValue1;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("myTable");
    tr = table.getElementsByTagName("tr");
  
    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
      td = tr[i].getElementsByTagName("td")[1];
      td1= tr[i].getElementsByTagName("td")[4];
      if (td) {
        txtValue = td.textContent || td.innerText;
        txtValue1=td1.textContent || td1.innerText;
        if((txtValue.toUpperCase().indexOf(filter) > -1) ||(txtValue1.toUpperCase().indexOf(filter) > -1))
         {
          tr[i].style.display = "";
        }
         else 
         {
          tr[i].style.display = "none";
        }
      } 
    }
  }


