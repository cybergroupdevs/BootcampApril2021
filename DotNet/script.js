// function GetData(){
fetch("https://localhost:44366/api/User").
    then(response => response.json())
        .then(json => {        
            let li = ``;
            json.forEach(user => {
               // console.log(user);
            li += `<tr>
            <td>${user.id} </td>
            <td>${user.firstName} </td>
            <td>${user.lastName} </td>
            <td>${user.age}</td> 
            <td>${user.address} </td>
            <td>
            <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
            <div class="btn-group mr-2" role="group" aria-label="Second group">
              <button type="button" class="btn btn-success"data-toggle="modal" data-target="#myModal" id='${user}'onclick=update(${user.id},'${user.firstName}','${user.lastName}','${user.age}');>Update</button>
            </div>
            <div class="btn-group" role="group" aria-label="Third group">
              <button type="button" class="btn btn-danger"onclick=deleteUser('${user.id}');>Delete</button>
            </div>
          </div>
  </td>
            </tr>`;
    });
    document.getElementById("users").innerHTML = li;
});
function addUser(){
    var First=document.getElementById("fname");
    var Last=document.getElementById("lname");
    var Aged=document.getElementById("age");
    var Addres=document.getElementById("address");
    var TempUser={
        "FirstName":First.value,
        "LastName":Last.value,
        "Age":Aged.value,
        "Address":Addres.value
    }
    console.log(TempUser);
    fetch("https://localhost:44366/api/User", {
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
    alert("Added Successfully");}
    );
}
function deleteUser(id){
    
    fetch("https://localhost:44366/api/User"+"/"+id.toString(), {
     method: "DELETE",
     mode: 'cors', 
     cache: 'no-cache', 
     credentials: 'same-origin',
     headers: {
       'Content-Type': 'application/json'
     },
     redirect: 'follow', 
     referrerPolicy: 'no-referrer'
     })
     .then(result => {
        alert("Deleted Successfully");
     }
     );
     //Get();
 }
function update(id,mf,ml,ag,add)
{ 
   var Fname = document.getElementById("Modalfname");
var Lname = document.getElementById("Modallname");
var Age = document.getElementById("Modalage");
var Address = document.getElementById("Modaladdress");
Fname.value=mf;
Lname.value=ml;
Age.value=ag;
Address.value=add;

var up=document.getElementById("Updatebut");
up.addEventListener("click",function(){
var Temp = {
  "FirstName": Fname.value,
  "LastName": Lname.value,
  "Age": Age.value,
  "Address": Address.value,
}
console.log(Temp);
  fetch("https://localhost:44366/api/User/"+id.toString(), {
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
    body: JSON.stringify(Temp),
  })
    //.then(response => response.json())
    .then((result) => {
      alert("updated data");
    });
},false);
}