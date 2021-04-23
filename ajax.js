fetch('https://localhost:44337/api/studentdata',{
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
               // console.log(user);
            li += `<tr>
            <td>${TempUser.id} </td>
            <td>${TempUser.firstName} </td>
            <td>${TempUser.lastName} </td>
            <td>${TempUser.address} </td>
            <td>${TempUser.city}</td>
          <td>  <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
               
            <div  class="btn-group me-2" role="group" aria-label="Second group">
              <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal" >Update</button>
              
            </div>
            <div class="btn-group" role="group" aria-label="Third group">
              <button type="button" class="btn btn-danger"  onclick="deleteUser(${TempUser.id})">Delete</button></td>
            </tr>`;
    });
    document.getElementById("userTable").innerHTML = li;
    
 
  // do something with data
  console.log(data);
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
    fetch("https://localhost:44337/api/studentdata", {
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



function deleteUser(id){
  console.log(id.toString());
  var urlDelete = "https://localhost:44337/api/studentdata/" + id.toString();
  console.log(urlDelete);
  fetch(urlDelete,{
    method: "DELETE",
    mode: "cors",
    cache: 'no-cache', 
      credentials: 'same-origin',
      headers:{
        "Content-Type": "application/json",
      },
      redirect: "follow",
      referredPolicy: "no-referrer",
  })
  .then((result)=>{
    console.log(result);
  })
  }


// function FetchData(){
//     fetch("https://localhost:44335/api/User").
//     then(response => response.json())
//      .then(json => { 
//     let li = `<tr><th>Id</th><th>FirstName</th><th>LastName</th><th>Address</th><th>City</th></tr>`;
//     json.forEach(user => {
//     //console.log(user);
//     li += `<tr>
//      <td>${user.id} </td>
//      <td>${user.firstName} </td>
//      <td>${user.lastName} </td>
//      <td>${user.address}</td> 
//      <td>${user.city} </td>
//      </tr>`;
//      });
//     document.getElementById("users").innerHTML = li;
//     });
//     }

    // function PostData(){​​​​​​​​
    //     fetch(url, {​​​​​​​​
    //     method:"POST",
    //     headers: {​​​​​​​​
    //     'Content-Type':'application/x-www-form-urlencoded'
    //         }​​​​​​​​,
    //     body:JSON.stringify({​​​​​​​​
    //     FirstName:fname.value,
    //     LastName:lname.value,
    //     Address:aname.value,
    //     City:cname.value,
    //         }​​​​​​​​)
    //     }​​​​​​​​)
    //     .then(response=>response.json())
    //     .then(result=> {​​​​​​​​
    //     console.log(result);}​​​​​​​​
    //         );
    //     }​​​​​​​​