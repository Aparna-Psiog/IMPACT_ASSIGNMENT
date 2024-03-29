var selectedRow = null


function onFormSubmit() {

  if (validate()) {

    var formData = readFormData();

    if (selectedRow == null)

      duplicate_check(formData);

    else

      updateRecord(formData);

    resetForm();
  }

}


var records = [
  {
    itemName: 'Tomato soup',
    description: 'Tomato soup-A starter with pieces of breads',
    price: '100',
    category: 'Starters'
  },

  {
    itemName: 'Bhel puri',
    description: 'A chat with tomato sauce',
    price: '170',
    category: 'Chat'
  },

  {
    itemName: 'French fries',
    description: 'Fried crisps with Sauce',
    price: '120',
    category: 'Starters'
  },

  {
    itemName: 'North Indian Thali',
    description: 'Meal with chapathi,paratta,Panner butter masala',
    price: '300',
    category: 'Maincourse'
  },

  {
    itemName: 'Vanilla Milkshake',
    description: 'A shake with vanilla flavour with icecream',
    price: '290',
    category: 'Desserts'
  },

  {
    itemName: 'South Indian Thali',
    description: 'Meal with rice,Sambhar,rasam,vegetable,aplam',
    price: '300',
    category: 'Maincourse'
  },

  {
    itemName: 'Aloo Paratha',
    description: 'Main course with paratta and aloo masala',
    price: '220',
    category: 'Maincourse'
  },

  {
    itemName: 'Piri piri noodles',
    description: 'A spicy noodles with white and tomato sauce',
    price: '350',
    category: 'Chat'
  },

  {
    itemName: 'Kaaju kismiss',
    description: 'A strawberry and buttercotch flavoured icecream',
    price: '310',
    category: 'Desserts'
  },

  {
    itemName: 'Paneer Tikka',
    description: 'A spicy starter of paneer',
    price: '160',
    category: 'Starters'
  },

  {
    itemName: 'Veggie Burger',
    description: 'A burger with cheese,vegetables and stuffed potatoes',
    price: '220',
    category: 'Maincourse'
  },

  {
    itemName: 'Matar Paneer',
    description: 'Matar Paneer is a vegetarian north Indian dish withpeas,farmer cheese.',
    price: '250',
    category: 'Maincourse'
  },

  {
    itemName: 'Chocolate Mint Bars',
    description: ' thin chocolate-mint Girl Scout cookies or Andes candies. ',
    price: '400',
    category: 'Desserts'
  },

  {
    itemName: 'Aloo Tikki',
    description: 'spicy green peas curry and sweet and sour chutneys',
    price: '150',
    category: 'Chat'
  },

  {
    itemName: 'Lemon-Scented Blueberry Cupcakes',
    description: 'Studded with plump, juicy fresh berries',
    price: '270',
    category: 'Desserts'
  },

  {
    itemName: 'Naan',
    description: 'Naan is a leavened, oven-baked flatbreads',
    price: '300',
    category: 'Maincourse'
  },

  {
    itemName: 'Kakori Kebabs',
    description: 'Juicy, succulent with some chaat masala, fresh mint chutney',
    price: '200',
    category: 'Starters'
  },

  {
    itemName: 'ButterNaan',
    description: 'Naan is a leavened and overbaked with butter',
    price: '300',
    category: 'Maincourse'
  },

  {
    itemName: 'Dahi Puri',
    description: 'Pani puri stuffed with amshed poatatoes with dahi',
    price: '450',
    category: 'Chat'
  },

  {
    itemName: 'Bourbon-Pecan Tart with Chocolate Drizzle',
    description: 'Pecan pie is the bourbon, molasses, and chocolate',
    price: '500',
    category: 'Desserts'
  },

  {
    itemName: 'Flat Breads',
    description: 'rotis,chapathis and parotas made with whaet flour',
    price: '331',
    category: 'Maincourse'
  },


  {
    itemName: 'Raspberry-Rhubarb Pie',
    description: 'Sweet raspberries pies',
    price: '440',
    category: 'Desserts'
  },

  {
    itemName: 'Cheese Balls',
    description: 'No forks or spoons are required for this easy-to-grab party snack.',
    price: '245',
    category: 'Starters'
  },

  {
    itemName: 'Puris',
    description: 'Puris dwith side dsih of any kind of sabjis',
    price: '220',
    category: 'Maincourse'
  },

  {
    itemName: 'Ragda Patties',
    description: 'Aloo tikki covered withwhite chickpeas called "ragdas" ',
    price: '260',
    category: 'Chat'
  },

  {
    itemName: 'Walnut Brownies',
    description: 'Large chocolate chunks with chocolate chips',
    price: '470',
    category: 'Desserts'
  },

  {
    itemName: 'Burrata bruschetta',
    description: 'bruschetta, topped with burrata, broad beans, radish, mint and chilli.',
    price: '430',
    category: 'Starters'
  },

  {
    itemName: 'Idlis',
    description: 'A perfect breakfast with sambhar and type of chutnis',
    price: '200',
    category: 'Maincourse'
  },

  {
    itemName: 'Dahi Vada',
    description: 'Vada dumped in dahi and masala',
    price: '210',
    category: 'Chat'
  },

  {
    itemName: 'Texas Sheet cake',
    description: 'A cake prepared with butter and butter milk',
    price: '380',
    category: 'Desserts'
  },

  {
    itemName: 'Saatdhan Parathas',
    description: 'Parathas that is being prepared with butter masala',
    price: '190',
    category: 'Maincourse'
  },

  {
    itemName: 'Pakora',
    description: 'Deep fried fritters like Dahi vada',
    price: '230',
    category: 'Chat'
  },

  {
    itemName: 'Salt-baked beetroot with feta & pickled onions',
    description: 'Salt crust with beetroots and onion soup',
    price: '290',
    category: 'Starters'
  },
  {
    itemName: 'Plum cakes',
    description: 'A cake with nuts and cherries',
    price: '280',
    category: 'Desserts'
  },
  {
    itemName: 'Andhra meals',
    description: 'A meal of hydreabad Biriyani',
    price: '330',
    category: 'Maincourse'
  }


]

var record_copy = JSON.parse(JSON.stringify(records));

function readFormData() {

  var formData = {};
  formData["itemName"] = document.getElementById("itemName").value;
  formData["description"] = document.getElementById("description").value;
  formData["price"] = document.getElementById("price").value;
  formData["category"] = document.getElementById("category").value;
  return formData;
}

function showpage() {
  current_page = numPages();
  deleteall();
  changePage(current_page);
}

function insertNewRecord(data) {
  var table = document.getElementById("myTable").getElementsByTagName('tbody')[0];
  var sample = {};
  var newRow = table.insertRow(table.length);
  cell1 = newRow.insertCell(0);
  cell1.innerHTML = `<input id="chk" type="checkbox" value="check"/>`
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

  sample["itemName"] = data.itemName;
  sample["description"] = data.description;
  sample["price"] = data.price;
  sample["category"] = data.category;
  records.push(sample);
  record_copy.push(sample);
  showpage();

}

var selectedRow;
var temp;
var index_row;

function onEdit(td) {
  selectedRow = td.parentElement.parentElement;
  temp = selectedRow.rowIndex;
  index_row = ((current_page - 1) * records_per_page) + temp;
  document.getElementById("itemName").value = selectedRow.cells[1].innerHTML;
  document.getElementById("description").value = selectedRow.cells[2].innerHTML;
  document.getElementById("price").value = selectedRow.cells[3].innerHTML;
  document.getElementById("category").value = selectedRow.cells[4].innerHTML;
  div_show();
}

function onRead(td) {
  selectedRow = td.parentElement.parentElement;

  document.getElementById("itemName").value = selectedRow.cells[1].innerHTML;
  document.getElementById("description").value = selectedRow.cells[2].innerHTML;
  document.getElementById("price").value = selectedRow.cells[3].innerHTML;
  document.getElementById("category").value = selectedRow.cells[4].innerHTML;

  read_div_show();
}

function updateRecord(formData) {
  selectedRow.cells[1].innerHTML = formData.itemName;
  selectedRow.cells[2].innerHTML = formData.description;
  selectedRow.cells[3].innerHTML = formData.price;
  selectedRow.cells[4].innerHTML = formData.category;

  //div_show();
  record_copy[index_row - 1].itemName = selectedRow.cells[1].innerHTML;
  record_copy[index_row - 1].description = selectedRow.cells[2].innerHTML;
  record_copy[index_row - 1].price = selectedRow.cells[3].innerHTML;
  record_copy[indexrow - 1].category = selectedRow.cells[4].innerHTML;
}


document.getElementById("undo").disabled = true;
var y;
var deleted_row_index;

function onDelete(td) {
  if (confirm('Are you sure to delete this record ?')) {
    row = td.parentElement.parentElement;
    y = row.rowIndex;
    deleted_row_index = ((current_page - 1) * records_per_page) + y;

    //document.getElementById("myTable").deleteRow(y);
    record_copy.splice(deleted_row_index - 1, 1);

    resetForm();
    deleteall();
    changePage(current_page);

    document.getElementById("undo").disabled = false;

  }

}


function undo() {

  var obj_copy = {};
  obj_copy["itemName"] = records[deleted_row_index - 1].itemName;
  obj_copy["description"] = records[deleted_row_index - 1].description;
  obj_copy["price"] = records[deleted_row_index - 1].price;
  obj_copy["category"] = records[deleted_row_index - 1].category;
  record_copy.splice(deleted_row_index - 1, 0, obj_copy);

  resetForm();
  deleteall();
  changePage(current_page);

  document.getElementById("undo").disabled = true;

}



function deleteselected() {
  var table = document.getElementById("myTable");
  var rowCount = table.rows.length;
  if (confirm('Are you Sure ?')) {
    for (var i = 1; i < rowCount; i++) {
      var row = table.rows[i];
      var chkbox = row.cells[0].childNodes[0];
      if (null != chkbox && true == chkbox.checked) {

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
  for (var i = 0; i < node_list.length; i++) {
    var node = node_list[i];
    if (node.getAttribute('type') == 'checkbox') {
      checkboxes.push(node);
    }
  }
  return checkboxes;
}


function toggle(source) {
  checkboxes = getcheckboxes();
  for (var i = 0, n = checkboxes.length; i < n; i++) {
    checkboxes[i].checked = source.checked;
  }
}

function deleteall() {
  var table = document.getElementById("myTable");
  //or use :  var table = document.all.tableid;
  for (var i = table.rows.length - 1; i > 0; i--) {
    table.deleteRow(i);
  }
}

function resetForm() {
  document.getElementById("itemName").value = "";
  document.getElementById("description").value = "";
  document.getElementById("price").value = "";
  document.getElementById("category").value = "";
  selectedRow = null;

}

function duplicate_check(data) {
  var flag = 0;
  for (var j = 0; j < Object.keys(record_copy).length; j++) {
    if (data.itemName == record_copy[j].itemName) {
      flag = 1;
      break;
    }
  }

  if (flag == 1) {
    alert("Record already exists in the table");
    flag = 0;
  }
  else {
    insertNewRecord(data);
  }
}

function create_div_show() {
 resetForm();
  document.getElementById('abc').style.display = "block";
}


function div_show() {
  document.getElementById('abc').style.display = "block";
}

function div_hide() {
  document.getElementById("itemName").readOnly = false;
  document.getElementById("description").readOnly = false;
  document.getElementById("price").readOnly = false;
  document.getElementById("category").disabled = false;
  document.getElementById("abc").style.display = "none";
}

function read_div_show() {

  document.getElementById("itemName").readOnly = true;
  document.getElementById("description").readOnly = true;
  document.getElementById("price").readOnly = true;
  document.getElementById("category").disabled = true;
  document.getElementById('abc').style.display = "block";
  //document.getElementById("abc").readOnly=true;

}


function validate() {
  isValid = true;

  if ((document.getElementById("itemName").value == "") && (document.getElementById("description").value == "") && (document.getElementById("price").value == "") && (document.getElementById("category").value == "")) {
    isValid = false;
  }
  else if (document.getElementById("itemName").value == "") {
    isValid = false;
    alert("Please enter all the fields");
    div_show();
  }
  else if (document.getElementById("description").value == "") {
    isValid = false;
    alert("Description is required");
    div_show();
  }
  else if (document.getElementById("price").value == "") {
    isValid = false;
    alert("Price is required");
    div_show();
  }
  else if (document.getElementById("category").value == "") {
    isValid = false;
    alert("select a category");
    div_show();
  }
 
  else if (document.getElementById("price").value < 0){
    isValid = false;
    alert("Price should be positive");
    div_show();
  }
  else if(document.getElementById("price").value > 10000)
  {
    isValid = false;
    alert("Enter valid price value");
    div_show();
  }

  else {
    isValid = true;
    if (isNaN(document.getElementById("itemName").value)) {
      isValid = true;
      
    }
    else {
      isValid = false;
      alert("Item name should not be a number");
      div_show();
    }


  }

  return isValid;
}



function searchfunction() {
  records_per_page = num_pages_after();
  deleteall();
  changePage(records_per_page);

  var input, filter, table, tr, td, td1, i, txtValue, txtValue1;
  input = document.getElementById("myInput");
  filter = input.value.toUpperCase();
  table = document.getElementById("myTable");
  tr = table.getElementsByTagName("tr");
  for (i = 0; i < tr.length; i++) {
    td = tr[i].getElementsByTagName("td")[1];
    td1 = tr[i].getElementsByTagName("td")[4];
    if (td) {
      txtValue = td.textContent || td.innerText;
      txtValue1 = td1.textContent || td1.innerText;

      if ((txtValue.toUpperCase().indexOf(filter) > -1) || (txtValue1.toUpperCase().indexOf(filter) > -1)) {
        tr[i].style.display = "";
      }

      else {
        tr[i].style.display = "none";
      }
    }
  }
}














