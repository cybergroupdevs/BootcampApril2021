function addUser() {
  var TempRname = document.getElementById("rName");
    var TemprAddress = document.getElementById("rAddress");
    var TemprPhone = document.getElementById("rPhone");
    var TemprType = document.getElementById("rType");

  var myHeaders = new Headers();
  myHeaders.append(
    "Authorization",
    "Bearer " + localStorage.getItem("token").toString()
  );
  myHeaders.append("Content-Type", "application/json");

  var raw = JSON.stringify({
    RName: TempRname.value,
    RAddress: TemprAddress.value,
    RPhone: TemprPhone.value,
    RType: TemprType.value,
  });

  var requestOptions = {
    method: "POST",
    headers: myHeaders,
    body: raw,
    redirect: "follow",
  };

  fetch("https://localhost:44306/api/Restro", requestOptions)
    .then((response) => response.text())
      .then((result) => {
          console.log(result);
          location.reload();
      })
    .catch((error) => console.log("error", error));
}

// function addUser() {
//   var TempRname = document.getElementById("rName");
//   var TemprAddress = document.getElementById("rAddress");
//   var TemprPhone = document.getElementById("rPhone");
//   var TemprType = document.getElementById("rType");
//   var userRequest = {
//     RName: TempRname.value,
//     RAddress: TemprAddress.value,
//     RPhone: TemprPhone.value,
//     RType: TemprType.value,
//   };
//   console.log(userRequest);
//   fetch("https://localhost:44306/api/Restro", {
//     method: "POST",
//     mode: "cors", // no-cors, *cors, same-origin
//     cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
//     credentials: "same-origin", // include, *same-origin, omit
//     headers: {
//       "Content-Type": "application/json",
//       //   "Authorization":
//       //     "Bearer " + JSON.parse(localStorage.getItem("token"))["token"],
//       Authorization: "Bearer " + localStorage.getItem("token").toString(),

//       // 'Content-Type': 'application/x-www-form-urlencoded',
//     },
//     redirect: "follow", // manual, *follow, error
//     referrerPolicy: "no-referrer",
//     body: JSON.stringify(userRequest),
//   })
//     //.then(response => response.json())
//     .then((result) => {
//       console.log(result.status);
//     });
// }

function deleteUser(id) {
  console.log(id.toString());
  var urlDelete = "https://localhost:44306/api/Restro/" + id.toString();
  console.log(urlDelete);
  fetch(urlDelete, {
    method: "DELETE",
    mode: "cors", // no-cors, *cors, same-origin
    cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
    credentials: "same-origin", // include, *same-origin, omit
    headers: {
      "Content-Type": "ap9plication/json",
      Authorization: "Bearer " + localStorage.getItem("token").toString(),
      // 'Content-Type': 'application/x-www-form-urlencoded',
    },
    redirect: "follow", // manual, *follow, error
    referrerPolicy: "no-referrer",
  })
    //.then(response => response.json())
    .then((result) => {
        console.log(result);
        location.reload();
    });
}

function updateUser(id) {

    var ubtn = document.getElementById("updateData");
    ubtn.value = "Update";

    var TempRname = document.getElementById("mrName");
    var TemprAddress = document.getElementById("mrAddress");
    var TemprPhone = document.getElementById("mrPhone");
    var TemprType = document.getElementById("mrType");

    ubtn.addEventListener("click", function () {
      var TempUser = {
        rName: TempRname.value,
        rAddress: TemprAddress.value,
        rPhone: TemprPhone.value,
        rType: TemprType.value,
      };

      console.log(TempUser);
      var urlUpdate = "https://localhost:44306/api/Restro/" + id.toString();
      console.log(urlUpdate);
      fetch(urlUpdate, {
        method: "PUT",
        mode: "cors", // no-cors, *cors, same-origin
        cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
        credentials: "same-origin", // include, *same-origin, omit
        headers: {
          "Content-Type": "application/json",
          Authorization: "Bearer " + localStorage.getItem("token").toString(),
          // 'Content-Type': 'application/x-www-form-urlencoded',
        },
        redirect: "follow", // manual, *follow, error
        referrerPolicy: "no-referrer",
        body: JSON.stringify(TempUser),
      })
        //.then(response => response.json())
        .then((result) => {
          console.log(result);
        })
        .then((result) => {
            console.log(result);
            alert("updated data");
            location.reload();
        });
    }, false);
}

function getUser() {
  console.log("Testing");
  fetch("https://localhost:44306/api/Restro", {
    mode: "cors", // no-cors, *cors, same-origin
    cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
    credentials: "same-origin", // include, *same-origin, omit
    headers: {
      "Content-Type": "application/json",
      Authorization: "Bearer " + localStorage.getItem("token").toString(),

      // 'Content-Type': 'application/x-www-form-urlencoded',
    },
    redirect: "follow", // manual, *follow, error
    referrerPolicy: "no-referrer",
  })
    .then((res) => res.json())
    .then((data) => {
      let li = "";
      data.forEach((TempOwner) => {
        console.log(TempOwner);
        li += `<tr>
            
            <td>${TempOwner.rName} </td>
            <td>${TempOwner.rAddress} </td>
            <td>${TempOwner.rPhone}</td> 
            <td>${TempOwner.rType} </td>
          <td>  <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
                    <div class="btn-group me-2" role="group" aria-label="Second group">
                <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#MyModal" onclick="updateUser(${TempOwner.id})">
                  Update
                </button>
              </div>

            <div class="btn-group text-center" role="group" aria-label="Third group">
              <button type="button" class="btn btn-danger text-center" onclick="deleteUser(${TempOwner.id})">Delete</button></td>
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

function logoutuser() {  
    this.token = null;
    this.isAuthenticated = false;
   
    this.clearAuthData();  
    clearTimeout(this.tokenTimer);
    Redirect();
  }  
function clearAuthData() {  
    localStorage.removeItem("token");  
    localStorage.removeItem("expiration");  
}
  
function Redirect() {
  console.log("inside redirect");
  window.open("http://127.0.0.1:5500/index.html", "_blank");
}

         