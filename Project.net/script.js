



fetch("https://localhost:44368/api/Emp")
.then(response => response.json())
    .then(json => { 
            
        let li = ``;
        json.forEach(user => {
           // console.log(user);
        li += `<tr>
        <td data-label="Id">${user.empId } </td>
        <td data-label="Firstname">${user.empFname} </td>
        <td data-label="Lastname">${user.empLname} </td>
        <td data-label="Deptno">${user.empDptno}</td> 
        <td data-label="Deptname">${user.empDptname} </td>
        <td>
        <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
        <div class="btn-group mr-2" role="group" aria-label="Second group">
          <button type="button" class="btn btn-success"data-toggle="modal" data-target="#myModal" id='${user}'onclick=update(${user.empId},'${user.empFname}','${user.empLname}','${user.empDptno}','${user.empDptname}');><i class="material-icons">&#xE254;</i></button>
        </div>
        <div class="btn-group" role="group" aria-label="Third group">
          <button type="button" class="btn btn-danger"onclick=deleteUser('${user.empId}');><i class="material-icons">&#xE872;</i></button>
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
var Dptno=document.getElementById("dptnumber");
var Dptname=document.getElementById("dptname");
var TempUser={
    "EmpFname":First.value,
    "EmpLname":Last.value,
    "EmpDptno":Dptno.value,
    "EmpDptname":Dptname.value
}
console.log(TempUser);
fetch("https://localhost:44368/api/Emp", {
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

fetch("https://localhost:44368/api/Emp"+"/"+id.toString(), {
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
function update(id,mf,ml,dptno,dptname)
{ 
var Fname = document.getElementById("Modalfname");
var Lname = document.getElementById("Modallname");
var Dptno = document.getElementById("Modaldptnumber");
var Dptname = document.getElementById("Modaldptname");
Fname.value=mf;
Lname.value=ml;
Dptno.value=dptno;
Dptname.value=dptname;

var up=document.getElementById("Updatebut");
up.addEventListener("click",function(){
var Temp = {
"EmpFname": Fname.value,
"EmpLname": Lname.value,
"EmpDptno": Dptno.value,
"EmpDptname": Dptname.value,
}
console.log(Temp);
fetch("https://localhost:44368/api/Emp"+"/"+id.toString(), {
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

