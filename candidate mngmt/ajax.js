function fetchUser(){

    fetch('http://localhost:44301/api/student', {
      mode: 'cors', // no-cors, *cors, same-origin
      cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
      credentials: 'same-origin', // include, *same-origin, omit
      headers: {
        'Content-Type': 'application/json',
        // 'Content-Type': 'application/x-www-form-urlencoded',
      },
      redirect: 'follow', // manual, *follow, error
      referrerPolicy: 'no-referrer',
    }
    )

.then(res => res.json())
.then(data => {
    let li = "";
    data.forEach(TempUser => {
       //console.log(user);
      li += `<tr>
            <td>${TempUser.id} </td>
            <td>${TempUser.firstName}</td>
            <td>${TempUser.lastName} </td>
            <td>${TempUser.address}</td> 
            <td>${TempUser.city}</td>
          <td>  <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
 
            <div  class="btn-group me-2" role="group" aria-label="Second group">
              <button type="button" class="btn btn-success" onclick="updateUser(${TempUser.id})" data-toggle="modal" data-target="#myModal" >Update</button>
              </div>
              <div class="btn-group" role="group" aria-label="Third group">
                <button type="button" onclick="deleteUser(${TempUser.id})" class="btn btn-danger" >Delete</button></td>
              </tr>`;
      });
      document.getElementById("userTable").innerHTML = li;
      console.log("worked");
   
      // do something with data
      console.log(data);
    })
    .catch(function (error) {
      console.log("Looks like there was a problem: \n", error);
    });
  }
    function addUser() {
        var TempFname = document.getElementById("fname");
        var TempLname = document.getElementById("lname");
        var TempAddress = document.getElementById("address");
        var TempCity = document.getElementById("city");
        var TempUser = {
          "FirstName": TempFname.value,
          "LastName": TempLname.value,
          "Address": TempAddress.value,
          "City": TempCity.value,
        }
        console.log(TempUser);
        fetch("http://localhost:44301/api/student", {
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
          body: JSON.stringify(TempUser)
          
        })
          //.then(response => response.json())
          .then((result) => {
            console.log(result);}
            
          );
      }
    
      function deleteUser(id) {
        console.log(id);
        var urlDelete = "http://localhost:44301/api/student" + id.toString();
        // console.log(urlDelete);
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
            console.log(result);}
          );
      }

      function updateUser(id) {
        var TempFname = document.getElementById("firstNameData" + id.toString());
        var TempLname = document.getElementById("lastNameData" + id.toString());
        var TempAddress = document.getElementById("addressData" + id.toString());
        var TempCity = document.getElementById("cityData" + id.toString());
        var TempUser = {
          "FirstName": TempFname.value,
          "LastName": TempLname.value,
          "Address": TempAddress.value,
          "City": TempCity.value,
        };
        console.log(TempUser);
        var urlUpdate = "http://localhost:44301/api/student" + id.toString();
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