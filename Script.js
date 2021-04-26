fetch('https://localhost:44394/api/booking',{
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
            <td>${TempUser.name} </td>
            <td>${TempUser.age} </td>
            <td>${TempUser.bdate} </td>
            <td>${TempUser.flight}</td>
            <td>${TempUser.time}</td>
            <td>${TempUser.address}</td>

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
function addAuthUser(){
    var _name=document.getElementById("name");
    var _pass=document.getElementById("pass");
    var email=document.getElementById("address");
    


    var AuthUser={
        "Name":_name.value,
        "Password":_pass.value,
        "E-Mail":email.value,
        
    }
    console.log(AuthUser);
    fetch("https://localhost:44394/api/login", {
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
    body: JSON.stringify(AuthUser)
})
//.then(response => response.json())
.then(result => {
    console.log(result);}
    );
}




function addUser(){
    var Tempname=document.getElementById("name");
    var Tempage=document.getElementById("age");
    var Tempbdate=document.getElementById("bdate");
    var Tempfname=document.getElementById("flight");
    var Tempfname=document.getElementById("address");

    var Temptime=document.getElementById("time");

    var TempUser={
        "Name":Tempname.value,
        "Age":Tempage.value,
        "Booking Date":Tempbdate.value,
        "Flight Name":Tempfname.value,
        "Time":Temptime.value
    }
    console.log(TempUser);
    fetch("https://localhost:44394/api/booking", {
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
  var urlDelete = "https://localhost:44394/api/booking" + id.toString();
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