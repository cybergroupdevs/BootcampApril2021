fetch('https://localhost:44317/api/GuardDataBase',{
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
            <td>${TempUser.employeeId} </td>
            <td>${TempUser.name} </td>
            <td>${TempUser.contact}</td> 
            <td>${TempUser.location} </td>
          <td>  <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
               
           
            <div class="btn-group" role="group" aria-label="Third group">
              <button type="button" class="btn btn-primary" onclick="deleteUser(${TempUser.id})"><i class="fas fa-trash-alt"></i></button></td>
            </tr>`;
    });
    document.getElementById("userTable").innerHTML = li;
    
  // do something with data
  console.log(data);
})
.catch(function(error) {
  console.log('Looks like there was a problem: \n', error);
});
function addEntry(){
    var TempId=document.getElementById("empId");
    var TempFname=document.getElementById("fname");
    var TempContact=document.getElementById("contact");
    var TempLoct=document.getElementById("loct");
    var TempUser={
        "EmployeeId":TempId.value,
        "Name":TempFname.value,
        "Contact":TempContact.value,
        "Location":TempLoct.value
    }
    console.log(TempUser);
    fetch("https://localhost:44317/api/GuardDataBase", {
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
}
function update(ids)
{
    
    var TempFname = document.getElementById("gufname");
  var TempLname = document.getElementById("gulname");
  var TempAge = document.getElementById("guage" );
  var TempAddress = document.getElementById("guaddress");
  var TempUser = {
    FirstName: TempFname.value,
    LastName: TempLname.value,
    Age: TempAge.value,
    Address: TempAddress.value,
  };
  console.log(TempUser);
  var urlUpdate = "https://localhost:44317/api/GuardDataBase/" + ids.toString();
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
}
function deleteUser(ids){
    fetch("https://localhost:44317/api/GuardDataBase/"+ids.toString(), {
        method : 'DELETE',
        headers: {
            'Content-type': 'application/json'
        }
    }).then(data => console.log("deleted"+" "+data));
}
// function postInfo(){
//     var Templogin=document.getElementById("login");
//     var Temppass=document.getElementById("passw");
   
//     var TempUser={
//         "Email":Templogin.value,
//         "Passwrd":Temppass.value,
//     }
//     console.log(TempUser);
//     fetch("https://localhost:44317/api/Login", {
//     method: "POST",
//     mode: 'cors', // no-cors, *cors, same-origin
//     cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
//     credentials: 'same-origin', // include, *same-origin, omit
//     headers: {
//       'Content-Type': 'application/json'
//       // 'Content-Type': 'application/x-www-form-urlencoded',
//     },
//     redirect: 'follow', // manual, *follow, error
//     referrerPolicy: 'no-referrer',
//     body: JSON.stringify(TempUser)
// })
// .then(response => response.text())
// .then((response) => {

//     window.localStorage.setItem('token',response);
// })

// }
function LoginUser()
{
var UserName=document.getElementById("login");
var Password=document.getElementById("pass");
var LoginUser =
{

"email":UserName.value,
"passwrd":Password.value,
}
fetch("https://localhost:44317/api/Login/login",
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
openMain();
});
 
}
function openMain()
{
  window.open("http://127.0.0.1:5501/index.html","_blank");
} 
function postInfo()
{
var UserName=document.getElementById("login");
var Password=document.getElementById("pass");


var LoginUser = 
  {
  "UserName":UserName.value,
  "EmailId":"nothing",
  "Password":Password.value,
  }

  fetch("https://localhost:44317/api/Login/signup", 
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
  .then((result) => {
      console.log(result);
      alert("Signup Successful");
  });
  }


