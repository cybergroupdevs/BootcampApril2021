
// function showUsers(){
//     fetch("https://localhost:44324/api/StudentData").
//         then(response => response.json())
//             .then(json => {        
//                 let li = `<tr><th>Id</th><th>FirstName</th><th>LastName</th><th>Address</th><th>City</th><th>Options</th></tr>`;
//                 json.forEach(user => {
//                 li += `<tr>
//                 <td>${user.id} </td>
//                 <td>${user.firstName} </td>
//                 <td>${user.lastName} </td>
//                 <td>${user.address}</td> 
//                 <td>${user.city} </td>
//                 <td><button type="button" class="btn btn-success" onclick="updateWindow(${user.firstName}, ${user.lastName}, ${user.address}, ${user.city})">Update</button>
//                     <button type="button" class="btn btn-danger">Delete</button>
//                 </td>
//                 </tr>`;
//             });
//             // document.getElementById("users").appendChild(li);
//             document.getElementById("users").innerHTML = li;
//     });
// }

fetch('https://localhost:44324/api/StudentData',{
    mode: 'cors', 
    cache: 'no-cache', 
    credentials: 'same-origin', 
    headers: {
      'Content-Type': 'application/json'
    },
    redirect: 'follow', 
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
            <td>${TempUser.firstName} </td>
            <td>${TempUser.lastName} </td>
            <td>${TempUser.address} </td>
            <td>${TempUser.city}</td> 
          <td>  <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
               
            <div  class="btn-group me-2" role="group" aria-label="Second group">
              <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal" onclick="updateUser(${TempUser.id}, '${TempUser.firstName}', '${TempUser.lastName}', '${TempUser.address}', '${TempUser.city}')" >Update</button>
            </div>
            <div class="btn-group" role="group" aria-label="Third group" onclick="DeleteUser(${TempUser.id})">
              <button type="button" class="btn btn-danger" >Delete</button>
              </td>
            </tr>`;
    });
    document.getElementById("userTable").innerHTML = li;
})
.catch(function(error) {
  console.log('Looks like there was a problem: \n', error);
});

function addUser(){
    var TempFname=document.getElementById("fname");
    var TempLname=document.getElementById("lname");
    var TempAddress=document.getElementById("address");
    var TempCity=document.getElementById("city");
    var TempUser={
    "FirstName":TempFname.value,
    "LastName":TempLname.value,
    "Address":TempAddress.value,
    "City":TempCity.value
     }
    // console.log(TempUser);
    fetch("https://localhost:44324/api/StudentData", {
    method: "POST",
    mode: 'cors', 
    cache: 'no-cache', 
    credentials: 'same-origin', 
    headers: {
    'Content-Type': 'application/json'
     },
    redirect: 'follow', 
    referrerPolicy: 'no-referrer',
    body: JSON.stringify(TempUser)
    })
    .then(result => {
        alert('Successfully addedd');
        window.location.reload();
    });
}

function updateUser(id, fname, lname, address, city){

    document.getElementById('Modalfname').value = fname;
    document.getElementById('Modallname').value = lname;
    document.getElementById('Modaladdress').value = address;
    document.getElementById('Modalcity').value = city;

    document.getElementById('update-btn').addEventListener('click', function(){

        var TempFname=document.getElementById("Modalfname");
        var TempLname=document.getElementById("Modallname");
        var TempAddress=document.getElementById("Modaladdress");
        var TempCity=document.getElementById("Modalcity");
        var TempUser={
        "FirstName":TempFname.value,
        "LastName":TempLname.value,
        "Address":TempAddress.value,
        "City":TempCity.value
        }
        // console.log(TempUser);
        fetch("https://localhost:44324/api/StudentData" + "/" + id.toString(), {
        method: "PUT",
        mode: 'cors', 
        cache: 'no-cache', 
        credentials: 'same-origin', 
        headers: {
        'Content-Type': 'application/json'
        },
        redirect: 'follow', 
        referrerPolicy: 'no-referrer',
        body: JSON.stringify(TempUser)
        })
        .then(result => {
            alert('Entry is Updated');
        });
        document.getElementById('modal-close-btn').addEventListener('click', function(){
            window.location.reoload();
        });
    });
}


function DeleteUser(id){
    fetch("https://localhost:44324/api/StudentData" + "/" + id.toString(), {
    method: "DELETE",
    mode: 'cors', 
    cache: 'no-cache', 
    credentials: 'same-origin', 
    headers: {
    'Content-Type': 'application/json'
    },
    redirect: 'follow', 
    referrerPolicy: 'no-referrer',
    })
    .then(result => {
        alert('Entry Deleted!');
        window.location.reload();
    });
}

