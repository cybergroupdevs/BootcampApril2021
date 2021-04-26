    // function GetData(){
fetch("https://localhost:44376/api/USER_INFO").
then(response => response.json())
    .then(json => {        
        let li = ``;
        json.forEach(user => {
           // console.log(user);
        li += `<tr>
        <td>${user.userId} </td>
        <td>${user.userName} </td>
        <td>${user.password} </td>
         <td>
        <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
        <div class="btn-group mr-2" role="group" aria-label="Second group">
          <button type="button" class="btn btn-warning"data-toggle="modal" data-target="#myModal" id='${user}'onclick=update(${user.userId},'${user.userName}','${user.password}');>Edit</button>
        </div>
        <div class="btn-group" role="group" aria-label="Third group">
          <button type="button" class="btn btn-danger"onclick=deleteUser('${user.userId}');>Delete</button>
        </div>
      </div>
</td>
        </tr>`;
});
document.getElementById("users").innerHTML = li;
});
function addUser(){
    var First=document.getElementById("Username");
    var pass=document.getElementById("pass");
    var TempUser={
        "UserName":First.value,
        "Password":pass.value,
    }
    console.log(TempUser);
    fetch("https://localhost:44376/api/USER_INFO", {
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
    
  fetch("https://localhost:44376/api/USER_INFO"+"/"+id.toString(), {
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
function update(id,uname,pass)
{ 
   var Uname = document.getElementById("ModalUname");
var PASS = document.getElementById("Modalpass");

Uname.value=uname;
PASS.value=pass

var up=document.getElementById("Updatebut");
up.addEventListener("click",function(){
var Temp = {
  "UserName": Uname.value,
  "password": PASS.value
}
console.log(Temp);
  fetch("https://localhost:44376/api/USER_INFO/"+id.toString(), {
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