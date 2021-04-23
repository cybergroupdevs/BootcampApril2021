var url = "https://localhost:44353/api/studentsdata";


fetch(url,{
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
            var data = "update"+TempUser.id.toString();
            li += `<tr id="${TempUser.id}">
            <td>${TempUser.firstName} </td>
            <td>${TempUser.lastName} </td>
            <td>${TempUser.address}</td> 
            <td>${TempUser.city} </td>
            <td>  <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
               
            <div  class="btn-group me-2" role="group" aria-label="Second group">
              <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal" id="${data}" onclick=Update(${TempUser.id})>Update</button>
              
            </div>
            <div class="btn-group" role="group" aria-label="Third group">
              <button type="button" class="btn btn-danger" onclick=Delete(${TempUser.id})>Delete</button></td>
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
    console.log(TempUser);
    fetch(url, {
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
       alert("User added");}
    );
    //Get();
}


function Update(id){
    var TempFname=document.getElementById("Modalfname");
    var TempLname=document.getElementById("Modallname");
    var TempAddress=document.getElementById("Modaladdress");
    var TempCity=document.getElementById("Modalcity");

    var ubutton = document.getElementById("updateButton");
    ubutton.addEventListener("click", function(){
        var TempUser={
            "FirstName":TempFname.value,
            "LastName":TempLname.value,
            "Address":TempAddress.value,
            "City":TempCity.value
        }
        //console.log(TempUser);
        fetch(url+"/"+id.toString(), {
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
                alert("Updated Data");}
            );
    }, false);
}



function Delete(id){
    
   fetch(url+"/"+id.toString(), {
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
        alert("Deleted successfully");
    }
    );
    //Get();
}

