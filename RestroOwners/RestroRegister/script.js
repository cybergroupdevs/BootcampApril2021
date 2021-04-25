

function PostUser() {
    var TempEmail = document.getElementById("inputEmail");
    var TempPassword = document.getElementById("inputPassword");
    var TempUsername = document.getElementById("validationDefaultUsername");

    var TempOwner = {
      "OUserName": TempUsername.value,
      "OPassword": TempPassword.value,
      "OEmail": TempEmail.value,
    };
    console.log(TempOwner);
    
      fetch("https://localhost:44306/api/RestroOwner", {
        method: "POST",
        mode: "cors", // no-cors, *cors, same-origin
        cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
        credentials: "same-origin", // include, *same-origin, omit
        headers: {
          "Content-Type": "application/json",
          // 'Content-Type': 'application/x-www-form-urlencoded',
        },
        redirect: "follow", // manual, *follow, error
        referrerPolicy: "no-referrer",
        body: JSON.stringify(TempOwner),
      })
      .then((res) => {
        console.log(res);
      });
}

 function showingRefreshedList() {
   axios
     .get("https://localhost:44306/api/RestroOwner", {
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
     .then((res) => {
       console.log(res.data);
     });
}
 
function OwnerLogin(){
        var TempEmail = document.getElementById("inputEmail");
    var TempPassword = document.getElementById("inputPassword");
    var TempUsername = document.getElementById("validationDefaultUsername");

    var TempOwner = {
      "OUserName": TempUsername.value,
      "OPassword": TempPassword.value,
      "OEmail": TempEmail.value,
    };
    console.log(TempOwner);
    
    fetch("https://localhost:44306/api/RestroOwner/login", {
        method: "POST",
        mode: "cors", // no-cors, *cors, same-origin
        cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
        credentials: "same-origin", // include, *same-origin, omit
        headers: {
            "Content-Type": "application/json",
            // 'Content-Type': 'application/x-www-form-urlencoded',
        },
        redirect: "follow", // manual, *follow, error
        referrerPolicy: "no-referrer",
        body: JSON.stringify(TempOwner),
    })
        .then((res) => {
            console.log(res);
            return res.json()
        })
        .then(data => {
            console.log(data.token);
            localStorage.setItem("token", data.token)
            getUser();
        });
    
    
}

// function logout() {  
//     this.token = null;
//     this.isAuthenticated = false;
//     this.auth
//     this.clearAuthData();  
//     clearTimeout(this.tokenTimer);  
//   }  
// function clearAuthData() {  
//     localStorage.removeItem("token");  
//     localStorage.removeItem("expiration");  
//   }  

  function addUser() {
    var TempFname = document.getElementById("fname");
    var TempLname = document.getElementById("lname");
    var TempAge = document.getElementById("age");
    var TempAddress = document.getElementById("address");
    var TempUser = {
      FirstName: TempFname.value,
      LastName: TempLname.value,
      Age: TempAge.value,
      Address: TempAddress.value,
    };
    console.log(TempUser);
    fetch("https://localhost:44357/api/user", {
      method: "POST",
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
 
  function deleteUser(id) {
    console.log(id.toString());
    var urlDelete = "https://localhost:44357/api/User/" + id.toString();
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
    var TempFname = document.getElementById("firstNameData" + id.toString());
    var TempLname = document.getElementById("lastNameData" + id.toString());
    var TempAge = document.getElementById("ageData" + id.toString());
    var TempAddress = document.getElementById("addressData" + id.toString());
    var TempUser = {
      FirstName: TempFname.value,
      LastName: TempLname.value,
      Age: TempAge.value,
      Address: TempAddress.value,
    };
    console.log(TempUser);
    var urlUpdate = "https://localhost:44357/api/User/" + id.toString();
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

function getUser() {
    fetch("https://localhost:44357/api/user", {
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
        .then((res) => res.json())
        .then((data) => {
            let li = "";
            data.forEach((TempUser) => {
                // console.log(user);
                li += `<tr>
            
            <td>${TempUser.firstName} </td>
            <td>${TempUser.lastName} </td>
            <td>${TempUser.age}</td> 
            <td>${TempUser.address} </td>
          <td>  <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
               
            <div  class="btn-group me-2" role="group" aria-label="Second group">
              <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal" onclick="updateUser(${TempUser.id})" >Update</button>
              
            </div>
            <div class="btn-group" role="group" aria-label="Third group">
              <button type="button" class="btn btn-danger" onclick="deleteUser(${TempUser.id} )">Delete</button></td>
            </tr>`;
            });
            document.getElementById("userTable").innerHTML = li;

            // do something with data
            console.log(data);
        })
        .catch(function (error) {
            console.log("Looks like there was a problem: \n", error);
        });
}