function getall() {
    console.log("update click")
    fetch('https://localhost:44394/api/UsersData', {
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
            let li = '<tr><th>Id</th><th>First Name</th><th>LastName</th><th>Age</th><th>Address</th><th>Actions</th>';
            data.forEach(usersRequest => {
                // console.log(user);
                li += `<tr>
            <td>${usersRequest.id} </td>
            <td>${usersRequest.firstName} </td>
            <td>${usersRequest.lastName} </td>
            <td>${usersRequest.age}</td> 
            <td>${usersRequest.address} </td>
          <td>  <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
               
            <div  class="btn-group me-2" role="group" aria-label="Second group">
              <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal" onclick = "updateval(${usersRequest.id},'${usersRequest.firstName}','${usersRequest.lastName}','${usersRequest.age}','${usersRequest.address}')">Update</button>
              
            </div>
            <div class="btn-group" role="group" aria-label="Third group">
              <button type="button" class="btn btn-danger" onclick="deleteval('${usersRequest.id}')">Delete</button></td>
            </tr>`;
            });
            document.getElementById("users").innerHTML = li;


            // do something with data
            console.log(data);
        })
        .catch(function (error) {
            console.log('Looks like there was a problem: \n', error);
        });
}

function addUser() {
    var TempFname = document.getElementById("firstname");
    var TempLname = document.getElementById("lastname");
    var TempAge = document.getElementById("age1");
    var TempAddress = document.getElementById("address1");
    var TempUser = {
        "FirstName": TempFname.value,
        "LastName": TempLname.value,
        "Age": TempAge.value,
        "Address": TempAddress.value
    }
    console.log(TempUser);
    fetch("https://localhost:44394/api/UsersData", {
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
            console.log(result);
        }
        );
    getall();
}

function updateval(id,a, b, c, d) {
    // console.log(id)
    document.getElementById("fName").value = a;
    document.getElementById("lName").value = b;
    document.getElementById("age").value = c;
    document.getElementById("address").value = d;
    document.getElementById("update1").addEventListener("click",function(){

    var TempFname = document.getElementById("fName");
    var TempLname = document.getElementById("lName");
    var TempAge = document.getElementById("age");
    var TempAddress = document.getElementById("address");
   

    var TempUser = {
        "FirstName": TempFname.value,
        "LastName": TempLname.value,
        "Age": TempAge.value,
        "Address": TempAddress.value
    }
     console.log(id);
    fetch("https://localhost:44394/api/UsersData/" +id.toString(), {
        method: "PUT",
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
       // .then(getall())// or res.json()
       .then(res => res.text())
        .then(res => getall())

    })
}
/*function updateUser(id) {


    var TempFname = document.getElementById("fName");
    var TempLname = document.getElementById("lName");
    var TempAge = document.getElementById("age");
    var TempAddress = document.getElementById("address");
    console.log(id);

    var TempUser = {
        "FirstName": TempFname.value,
        "LastName": TempLname.value,
        "Age": TempAge.value,
        "Address": TempAddress.value
    }
     console.log(id);
    fetch("https://localhost:44394/api/UsersData/" +id, {
        method: "PUT",
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
            console.log(result);
        }
        );
    getall();

}*/

function deleteval(id) {
    fetch("https://localhost:44394/api/UsersData/" + id, {
        method: 'DELETE',
        mode: 'cors', // no-cors, *cors, same-origin
        cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
        credentials: 'same-origin', // include, *same-origin, omit
        headers: {
            'Content-Type': 'application/json'
            // 'Content-Type': 'application/x-www-form-urlencoded',
        },
        redirect: 'follow', // manual, *follow, error
        referrerPolicy: 'no-referrer',
    })
        .then(getall())// or res.json()
        .then(res => console.log(res))
   
}