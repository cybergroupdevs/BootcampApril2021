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

//  function showingRefreshedList() {
//     axios.get("https://localhost:44357/api/user",{
//     mode: "cors", // no-cors, *cors, same-origin
//     cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
//     credentials: "same-origin", // include, *same-origin, omit
//     headers: {
//       "Content-Type": "application/json",
//       // 'Content-Type': 'application/x-www-form-urlencoded',
//     },
//     redirect: "follow", // manual, *follow, error
//     referrerPolicy: "no-referrer",
// })

//     .then((response) => {
//         // .then((data) => {
//         //   console.log(data)
//         let data = response.data;
//             let tb = document.getElementById("userTable");
//             data.forEach((user) => {
//                 let tr = document.createElement('tr');
//                 for (let detail of Object.values(user)) {
//                   let td = document.createElement("td");
//                     td.appendChild(document.createTextNode(detail))
//                     tr.appendChild(td)
//                 }
//                 tb.appendChild(tr);

//             });
//             // if (data.length > 0) {
//             //     document.getElementById("userDiv").style.display='block';
//             // }

//       });
//  //} 

// function PostUser() {
//     axios.post("https://localhost:44357/api/user", {
//         firstname: "aditya",
//         lastname: "sharma",
//         age: "22",
//         address: "la",
//       })
//       .then((res) => {
//         console.log(res);
//       });
// }

// function showingRefreshedList() {
//     fetch("https://localhost:44357/api/user")
//       .then(function (response) {
//         // first then()if(response.ok)
//         {
//           return response.text();
//         }

//         throw new Error("Something went wrong.");
//       })
//       .then(function (text) {
//         // second then()console.log('Request successful', text);
//       })
//       .catch(function (error) {
//         // catchconsole.log('Request failed', error);
//       });
// }
// // function showingRefreshedList() {
// //     fetch("https://localhost:44357/api/user")
// //         .then((response) => response.json())
// //         .then((json) => {
// //           console.log(response)

// //             let tb = document.getElementById("userTable");
// //             json.forEach((user) => {
// //                 let tr = document.createElement('tr');
// //                 for (let detail of Object.values(user)) {
// //                   let td = document.createElement("td");
// //                      td.appendChild(document.createTextNode(detail))
// //                     tr.appendChild(td)
// //                 }
// //                 tb.appendChild(tr);

// //             });
// //             if (json.length > 0) {
// //                 document.getElementById("userDiv").style.display='block';
// //             }

// //       });
// // }

// // var xhttp = new XMLHttpRequest();
// // xhttp.open("POST", "demo_post2.asp", true);
// // xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
// // xhttp.send("firstname=Henry&lastname=Ford");
