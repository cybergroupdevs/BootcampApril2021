fetch('https://localhost:44325/api/student',{
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
            data.forEach(user => {
                //console.log(user);
            li += `<tr>
            <td>${user.id} </td>
            <td>${user.firstName} </td>
            <td>${user.lastName} </td>
            <td>${user.address}</td> 
            <td>${user.city} </td>
          <td>  <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
               
            <div  class="btn-group me-2" role="group" aria-label="Second group">
            <button type="button" class="btn btn-success" onclick="updateUser(${user.id})" data-toggle="modal" data-target="#myModal" >Update</button>
            <div class="btn-group me-2" role="group" aria-label="Third group">
              <button type="button" class="btn btn-danger"onclick=deleteUser('${user.id}');>Delete</button>
            </tr>`;
    });
    document.getElementById("Table").innerHTML = li;
    
  // do something with data
  
})
.catch(function(error) {
  console.log('Looks like there was a problem: \n', error);
});


 
function addUser(){
    var userfname=document.getElementById("fname");
    var userlname=document.getElementById("lname");
    var useraddress=document.getElementById("address");
    var usercity=document.getElementById("city");
    var abc={
        "FirstName":userfname.value,
        "LastName":userlname.value,
        "Address":useraddress.value,
        "City":usercity.value
    }
    console.log(abc);
    fetch("https://localhost:44325/api/student", {
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
    body: JSON.stringify(abc)
})
//.then(response => response.json())
.then(result => {
    console.log(result);}
    );
}

     
     function deleteUser(id) {
      console.log(id.toString());
      var urlDelete = "https://localhost:44325/api/student/" + id.toString();
      console.log(urlDelete);
      fetch(urlDelete, {
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
        .then((result) => {
          console.log(result);
        });
    }
    function updateUser(id) {
      var fname = document.getElementById("fname" + id.toString());
      var lname = document.getElementById("lname" + id.toString());
      var address = document.getElementById("address" + id.toString());
      var city = document.getElementById("city" + id.toString());
      var user = {
        "Firstname":fname.value,
        "Lastname": lname.value,
        "Address": address.value,
        "City": city.value
      };
      console.log(user);
      var urlUpdate = "https://localhost:44325/api/student/" + id.toString();
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
 