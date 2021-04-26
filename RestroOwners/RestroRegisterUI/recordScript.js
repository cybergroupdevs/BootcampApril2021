function addUser() {
  var TempRname = document.getElementById("rName");
  var TemprAddress = document.getElementById("rAddress");
  var TemprPhone = document.getElementById("rPhone");
  var TemprType = document.getElementById("rType");
  var TempUser = {
    "RName": TempRname.value,
    "RAddress": TemprAddress.value,
    "RPhone": TemprPhone.value,
    "RType": TemprType.value,
  };
  console.log(TempUser);
  fetch("https://localhost:44306/api/Restro", {
    method: "POST",
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
    });
}

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
      "Content-Type": "application/json",
      Authorization: "Bearer " + localStorage.getItem("token").toString(),
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
  var TempRname = document.getElementById("rName");
  var TemprAddress = document.getElementById("rAddress");
  var TemprPhone = document.getElementById("rPhone");
  var TemprType = document.getElementById("rType");
  var TempUser = {
    "rName": TempRname.value,
    "rAddress": TemprAddress.value,
    "rPhone": TemprPhone.value,
    "rType": TemprType.value,
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
    });
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
               
            <div  class="btn-group me-2" role="group" aria-label="Second group">
              <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal" onclick="updateUser(${TempOwner.id})" >Update</button>
              
            </div>
            <div class="btn-group" role="group" aria-label="Third group">
              <button type="button" class="btn btn-danger" onclick="deleteUser(${TempOwner.id})">Delete</button></td>
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
