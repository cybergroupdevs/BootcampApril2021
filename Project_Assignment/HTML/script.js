function FetchData(){
    fetch("https://localhost:44378/api/User",{
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
    ).
    then(res => res.json())
     .then(data => { 
    let li = `<tr><th>FirstName  </th><th>LastName  </th><th>Age  </th><th>Address  </th></tr>`;
    data.forEach(user => {
    li += `<tr>
     <td>${user.firstName} </td>
     <td>${user.lastName} </td>
     <td>${user.age}</td>
     <td>${user.address}</td>
     <td> <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#Modal2" onclick="edit(${user.id})">
     Edit
   </button></td>
     <td> <button type="button" class="btn btn-danger" onclick="deleteUser(${user.id})">
     Delete
   </button></td>
     </tr>`;
     });
    document.getElementById("users").innerHTML = li;
    });
    }
    
    function AddUser(){
        var fname=document.getElementById("fname");
        var lname=document.getElementById("lname");
        var age=document.getElementById("age");
        var address=document.getElementById("add");
        var User={
            "FirstName":fname.value,
            "LastName":lname.value,
            "Age":age.value,
            "Address":address.value
        }
        console.log(User);
fetch("https://localhost:44378/api/User", {
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
body: JSON.stringify(User)
})
//.then(response => response.json())
.then(result => {
    fetch("https://localhost:44378/api/User",{
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
    ).
    then(res => res.json())
     .then(data => { 
    let li = `<tr><th>FirstName  </th><th>LastName  </th><th>Age  </th><th>Address  </th></tr>`;
    data.forEach(user => {
    li += `<tr>
     <td>${user.firstName} </td>
     <td>${user.lastName} </td>
     <td>${user.age}</td>
     <td>${user.address}</td>
     <td> <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#Modal2" onclick="edit(${user.id})">
     Edit
   </button></td>
     <td> <button type="button" class="btn btn-danger" onclick="deleteUser(${user.id})">
     Delete
   </button></td>
     </tr>`;
     });
    document.getElementById("users").innerHTML = li;
    });
}
);
}
function deleteUser(id){
    console.log(id);
    fetch("https://localhost:44378/api/User/"+id.toString(), {
        method: "DELETE",
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
        //.then(response => response.json())
        .then(result => {
            fetch("https://localhost:44378/api/User",{
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
    ).
    then(res => res.json())
     .then(data => { 
    let li = `<tr><th>FirstName  </th><th>LastName  </th><th>Age  </th><th>Address  </th></tr>`;
    data.forEach(user => {
    li += `<tr>
     <td>${user.firstName} </td>
     <td>${user.lastName} </td>
     <td>${user.age}</td>
     <td>${user.address}</td>
     <td> <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#Modal2" onclick="edit(${user.id})">
     Edit
   </button></td>
     <td> <button type="button" class="btn btn-danger" onclick="deleteUser(${user.id})">
     Delete
   </button></td>
     </tr>`;
     });
    document.getElementById("users").innerHTML = li;
    });}
        );
}
 function edit(id){
    fetch("https://localhost:44378/api/User/"+id.toString(),{
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
    ).then(res=> res.json())
    .then(data =>{
        data.forEach(user =>
            {
                document.getElementById("hide").innerHTML=user.id;
                document.getElementById("fname2").value=user.firstName;
                document.getElementById("lname2").value=user.lastName;
                document.getElementById("age2").value=user.age;
                document.getElementById("add2").value=user.address;
            });
    });
 }
 function updateUser(){
     var fname=document.getElementById("fname2");
     var lname=document.getElementById("lname2");
     var age=document.getElementById("age2");
     var add=document.getElementById("add2");
     var id=document.getElementById("hide").innerHTML;
     var user={
        FirstName: fname.value,
        LastName: lname.value,
        Age: age.value,
        Address: add.value
     }
     fetch("https://localhost:44378/api/User/"+id.toString(), {
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
        body: JSON.stringify(user),
      })
        //.then(response => response.json())
        .then((result) => {
            fetch("https://localhost:44378/api/User",{
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
            ).
            then(res => res.json())
             .then(data => { 
            let li = `<tr><th>FirstName  </th><th>LastName  </th><th>Age  </th><th>Address  </th></tr>`;
            data.forEach(user => {
            li += `<tr>
             <td>${user.firstName} </td>
             <td>${user.lastName} </td>
             <td>${user.age}</td>
             <td>${user.address}</td>
             <td> <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#Modal2" onclick="edit(${user.id})">
             Edit
           </button></td>
             <td> <button type="button" class="btn btn-danger" onclick="deleteUser(${user.id})">
             Delete
           </button></td>
             </tr>`;
             });
            document.getElementById("users").innerHTML = li;
            });
        });
 }