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
          <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal" onclick=UpdateUser(${TempUser.id})>Update</button>
        </div>
            <div class="btn-group" role="group" aria-label="Third group">
            <button type="button" onclick="deleteUser(${TempUser.id})" class="btn btn-danger" >Delete</button>
            </div></td>
            </tr>`;
            
          // <td>  <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
          //     <div class="btn-group" role="group" aria-label="Third group">
          //     <button style="margin-left:3.5rem" type="button" onclick="deleteUser(${TempUser.id})" class="btn btn-danger" >Delete</button>
          //     </div></td>
          //     </tr>`;
    });
    document.getElementById("userTable").innerHTML = li;
    
 
  // do something with data
  console.log(data);
})
.catch(function(error) {
  console.log('Looks like there was a problem: \n', error);
});

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
    console.log(result);}
    );
    alert("User Added Successfully!! Kindly refresh the page.");
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
         console.log(result);
       })
         
     alert("User ID " + id + " Deleted Successfully!! Kindly refresh the page.");
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

function Updateuser(id) {
  var TempAccNumN = document.getElementById("MaccountNum" + id.toString());
  var TempAccNameN = document.getElementById("MaccHname" + id.toString());
  var TempAgeN = document.getElementById("MageN" + id.toString());
  var TempAddressN = document.getElementById("MaddressN" + id.toString());
  var TempIfscN = document.getElementById("MifscN" + id.toString());
  var TempAmountN = document.getElementById("MamountN" + id.toString());
  var TempUser = {
        "AccountNumber":TempAccNumN.value,
        "AccountHolderName":TempAccNameN.value,
        "Age":TempAgeN.value,
        "Address":TempAddressN.value,
        "IfscCode":TempIfscN.value,
        "Amount":TempAmountN.value
  };
  console.log(TempUser);
  var urlUpdate = "https://localhost:44346/api/Bms/" + id.toString();
  console.log(urlUpdate);
  fetch(urlUpdate, {
    method: "PUT",
    mode: "cors", // no-cors, *cors, same-origin
    cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
    credentials: "same-origin", // include, *same-origin, omit
    headers: {
      "Content-Type": "application/json",
      // 'Content-Type': 'application/x-www-form-urlencoded',
    },
    redirect: "follow", // manual, *follow, error
    referrerPolicy: "no-referrer",
    body: JSON.stringify(TempUser),
  })
    //.then(response => response.json())
    .then((result) => {
      console.log(result);
    });
    alert("User ID " + id + " Updated Successfully!! Kindly refresh the page.");
}