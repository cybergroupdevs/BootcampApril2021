// function fetchIno() {
//   fetch("https://localhost:44305/api/User")
//     .then((response) => response.json())
//     .then((json) => {
//       let li = `<tr><th>Id</th><th>FirstName</th><th>LastName</th><th>Age</th><th>Address</th></tr>`;
//       json.forEach((user) => {
//         //console.log(user);
//         li += `<tr>
//               <td>${user.id} </td>
//               <td>${user.firstName} </td>
//               <td>${user.lastName} </td>
//               <td>${user.age} </td>
//               <td>${user.address}</td>
//               </tr>`;
//       });
//       document.getElementById("users").innerHTML = li;
//     });
// }

// async function addUser() {
//   var firstName = document.getElementById("firstNameInput").value;
//   var lastName = document.getElementById("lastNameInput").value;
//   var age = document.getElementById("ageInput").value;
//   var address = document.getElementById("addressInput").value;
//   console.log(firstName);
//   var jsonBody = {
//     FirstName: firstName,
//     LastName: lastName,
//     Age: age,
//     Address: address,
//   };
//   console.log(jsonBody);
//   try {
//     let response = await fetch("https://localhost:44305/api/User", {
//       method: "POST",
//       body: jsonBody,
//       headers: {
//         "Content-Type": "application/json",
//       },
//     });
//     let result = await response.json();
//     return result;
//   } catch (err) {}
// }
fetch("https://localhost:44305/api/User", {
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
            <td>${TempUser.id} </td>
            <td><input type="text" id="firstNameData${TempUser.id}" name="fname" value="${TempUser.firstName}"/> </td>
            <td><input type="text" id="lastNameData${TempUser.id}" name="fname" value="${TempUser.lastName}"/> </td>
            <td><input type="text" id="ageData${TempUser.id}" name="fname" value="${TempUser.age}"/></td> 
            <td><input type="text" id="addressData${TempUser.id}" name="fname" value="${TempUser.address}"/> </td>
          <td>  <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
               
            <div  class="btn-group me-2" role="group" aria-label="Second group">
              <button type="button" class="btn btn-success" onclick="updateUser(${TempUser.id})" data-toggle="modal" data-target="#myModal" >Update</button>
              
            </div>
            <div class="btn-group" role="group" aria-label="Third group">
              <button type="button" onclick="deleteUser(${TempUser.id})" class="btn btn-danger" >Delete</button></td>
            </tr>`;
    });
    document.getElementById("userTable").innerHTML = li;

    // do something with data
    console.log(data);
  })
  .catch(function (error) {
    console.log("Looks like there was a problem: \n", error);
  });

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
  fetch("https://localhost:44305/api/User", {
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
  var urlDelete = "https://localhost:44305/api/User/" + id.toString();
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
  var urlUpdate = "https://localhost:44305/api/User/" + id.toString();
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
