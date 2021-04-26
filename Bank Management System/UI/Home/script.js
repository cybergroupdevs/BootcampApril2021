function get(){  
  fetch('https://localhost:44346/api/Bms',{
      mode: 'cors', // no-cors, *cors, same-origin
      cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
      credentials: 'same-origin', // include, *same-origin, omit
      headers: {
        'Authorization': 'Bearer ' + (window.localStorage.getItem("token")),
        'Content-Type': 'application/json'
        // 'Content-Type': 'application/x-www-form-urlencoded',
      },
      redirect: 'follow', // manual, *follow, error
      referrerPolicy: 'no-referrer'
  }
  )
  .then(res => res.json())
  .then(data => {
      let li = "";
              data.forEach(TempUser => {
                // console.log(user);
              li += `<tr>
              <td>${TempUser.id} </td>
              <td>${TempUser.accountNumber} </td>
              <td>${TempUser.accountHolderName} </td>
              <td>${TempUser.age}</td> 
              <td>${TempUser.address} </td>
              <td>${TempUser.ifscCode} </td>
              <td>${TempUser.amount} </td>
              <td>  <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
                
            <div class="btn-group mr-2" role="group" aria-label="Second group">
            <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal" onclick="UpdateUser('${TempUser.id}','${TempUser.accountNumber}','${TempUser.accountHolderName}','${TempUser.age}','${TempUser.address}','${TempUser.ifscCode}','${TempUser.amount}')">Update</button>
          </div>
              <div class="btn-group" role="group" aria-label="Third group">
              <button type="button" onclick="deleteUser(${TempUser.id})" class="btn btn-danger" >Delete</button>
              </div></td>
              </tr>`;
              
            
      });
      document.getElementById("userTable").innerHTML = li;
      
  
    // do something with data
    console.log(data);
  })
  .catch(function(error) {
    console.log('Looks like there was a problem: \n', error);
  });
}

function addUser(){
    var TempAccNum=document.getElementById("accNum");
    var TempAccName=document.getElementById("name");
    var TempAge=document.getElementById("age");
    var TempAddress=document.getElementById("address");
    var TempIfsc=document.getElementById("ifsc");
    var TempAmount=document.getElementById("amount");
    var TempUser={
        "AccountNumber":TempAccNum.value,
        "AccountHolderName":TempAccName.value,
        "Age":TempAge.value,
        "Address":TempAddress.value,
        "IfscCode":TempIfsc.value,
        "Amount":TempAmount.value
    }
    console.log(TempUser);
    fetch("https://localhost:44346/api/Bms", {
    method: "POST",
    mode: 'cors', // no-cors, *cors, same-origin
    cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
    credentials: 'same-origin', // include, *same-origin, omit
    headers: {
      'Content-Type': 'application/json'
      // 'Content-Type': 'application/x-www-form-urlencoded',
    },
    redirect: 'follow', // manual, *follow, error
    referrerPolicy: 'no-referrer',
    body: JSON.stringify(TempUser)
})
//.then(response => response.json())
.then(result => {
      alert("User Added Successfully!!");
      get();
      }
    );
    
}


function deleteUser(id) {
    // console.log(id.toString());
     var url = "https://localhost:44346/api/Bms/" + id.toString();
     console.log(url);
     fetch(url, {
       method: "DELETE",
       mode: "cors", // no-cors, *cors, same-origin
       cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
       credentials: "same-origin", // include, *same-origin, omit
       headers: {
         "Content-Type": "application/json",
         // 'Content-Type': 'application/x-www-form-urlencoded',
       },
       redirect: "follow", // manual, *follow, error
       referrerPolicy: "no-referrer",
     })
       //.then(response => response.json())
       .then(result =>{
        alert("User ID " + id + " Deleted Successfully!!");
         get();
       })
    }


    function LoginUser()
{
var UserName=document.getElementById("uname");
var Password=document.getElementById("upass");
var LoginUser =
{
"username":UserName.value,
"pass":Password.value,
}
fetch("https://localhost:44346/api/Login/login",
{
method: "POST",
mode: 'cors', // no-cors, *cors, same-origin
cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
credentials: 'same-origin', // include, *same-origin, omit
headers: {
 
'Content-Type': 'application/json'
// 'Content-Type': 'application/x-www-form-urlencoded',
},
redirect: 'follow', // manual, *follow, error
referrerPolicy: 'no-referrer',
body: JSON.stringify(LoginUser),
 
})
//.then(response => response.json())
.then(response => response.text())
.then((response) => {
window.localStorage.setItem('token', response);
window.localStorage.getItem('token').toString();
openpage();
});
 
}

function openpage(){
  window.open("http://127.0.0.1:5501/index.html","_blank");
}

function UpdateUser(id,TempAccNumM,TempAccNameM,TempAgeM,TempAddressM,TempIfscM,TempAmountM) {
  var TempAccNumN = document.getElementById("MaccountNum");
  var TempAccNameN = document.getElementById("MaccHname");
  var TempAgeN = document.getElementById("MageN");
  var TempAddressN = document.getElementById("MaddressN");
  var TempIfscN = document.getElementById("MifscN");
  var TempAmountN = document.getElementById("MamountN");
  
  TempAccNumN.value = TempAccNumM;
  TempAccNameN.value = TempAccNameM;
  TempAgeN.value = TempAgeM;
  TempAddressN.value = TempAddressM;
  TempIfscN.value = TempIfscM;
  TempAmountN.value = TempAmountM;

  var ubutton = document.getElementById("updateEntry");
  ubutton.value = id;
 
}

document.getElementById("updateEntry").addEventListener("click",function(){

  var id = document.getElementById("updateEntry").value;
  var TempAccNumN = document.getElementById("MaccountNum");
  var TempAccNameN = document.getElementById("MaccHname");
  var TempAgeN = document.getElementById("MageN");
  var TempAddressN = document.getElementById("MaddressN");
  var TempIfscN = document.getElementById("MifscN");
  var TempAmountN = document.getElementById("MamountN");
    var TempUser = {
    "AccountNumber":parseInt(TempAccNumN.value),
    "AccountHolderName":TempAccNameN.value,
    "Age":parseInt(TempAgeN.value),
    "Address":TempAddressN.value,
    "IfscCode":parseInt(TempIfscN.value),
    "Amount": parseInt(TempAmountN.value)
  };

  console.log(JSON.stringify(TempUser));
  var urlUpdate = "https://localhost:44346/api/Bms/" + id;
  try{
  fetch(urlUpdate, {
    method: "PUT",
    mode: "cors", 
    cache: "no-cache", 
    credentials: "same-origin", 
    headers: {
      "Content-Type": "application/json",
    
    },
    redirect: "follow", 
    referrerPolicy: "no-referrer",
    body: JSON.stringify(TempUser),
  })
    
    .then((result) => {
      alert("User updated details successfully!!");
      get();
    });}
    catch{
      alert("Some technical error has occured.");
    }
 },false);