function getUserData(){
fetch('https://localhost:44393/api/user',{
    mode: 'cors', // no-cors, *cors, same-origin
    cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
    credentials: 'same-origin', // include, *same-origin, omit
    headers: {
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
                console.log(TempUser.address);
            li += `<tr>
            <td>${TempUser.id} </td>
            <td>${TempUser.firstName} </td>
            <td>${TempUser.lastName} </td>
            <td>${TempUser.age}</td> 
            <td>${TempUser.address} </td>
          <td>  <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
               
          <div class="btn-group mr-2" role="group" aria-label="Second group">
          <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal" onclick=UpdateUser(${TempUser.id})>Update</button>
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
    var TempFname=document.getElementById("fname");
    var TempLname=document.getElementById("lname");
    var TempAge=document.getElementById("age");
    var TempAddress=document.getElementById("address");
    var TempUser={
        "FirstName":TempFname.value,
        "LastName":TempLname.value,
        "Age":TempAge.value,
        "Address":TempAddress.value
    }
    console.log(TempUser);
    fetch("https://localhost:44393/api/user", {
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
    alert("User Added Successfully!");
    getUserData();
}

function deleteUser(id) {
 // console.log(id.toString());
  var url = "https://localhost:44393/api/user/" + id.toString();
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
      console.log(resutl);
    })
      
  alert("User ID " + id + " Deleted Successfully!");
  getUserData();
}

// function UpdateUser(id1){
//  // console.log(id1);
  
//   var TempFname=document.getElementById("Mfname");
//     var TempLname=document.getElementById("Mlname");
//     var TempAge=document.getElementById("Mage");
//     var TempAddress=document.getElementById("Maddress");
//     var TempUser={
//         "FirstName":TempFname.value,
//         "LastName":TempLname.value,
//         "Age":TempAge.value,
//         "Address":TempAddress.value
//     }
//     console.log(TempUser);
  
// }

// function update(ids)
// {
//     console.log(ids);
//     var TempFname = document.getElementById("Mfname");
//   var TempLname = document.getElementById("Mlname");
//   var TempAge = document.getElementById("Mage" );
//   var TempAddress = document.getElementById("Maddress");
//   var TempUser = {
//     FirstName: TempFname.value,
//     LastName: TempLname.value,
//     Age: TempAge.value,
//     Address: TempAddress.value,
//   }
//   console.log(TempUser);
//   var urlUpdate = "https://localhost:44393/api/user/" + ids.toString();
//   console.log(urlUpdate);
//   fetch(urlUpdate, {
//     method: "PUT",
//     mode: "cors", // no-cors, *cors, same-origin
//     cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
//     credentials: "same-origin", // include, *same-origin, omit
//     headers: {
//         "Content-Type": "application/json",
//       // 'Content-Type': 'application/x-www-form-urlencoded',
//     },
//     redirect: "follow", // manual, *follow, error
//     referrerPolicy: "no-referrer",
//     body: JSON.stringify(TempUser),
//   })
//     //.then(response => response.json())
//     .then((result) => {
//       console.log(result);
//     })
// }​