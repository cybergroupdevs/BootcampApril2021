
    fetch('https://localhost:44326/api/User',{
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
                <td>${TempUser.firstName} </td>
                <td>${TempUser.lastName} </td>
                <td>${TempUser.age}</td> 
                <td>${TempUser.address} </td>
              <td>  <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
                   
                <div  class="btn-group me-2" role="group" aria-label="Second group">
                  <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal" onclick="updateUser(${TempUser.id})" >Update</button>
                  
                </div>
                <div class="btn-group" role="group" aria-label="Third group">
                  <button type="button" class="btn btn-danger" onclick="deleteUser(${TempUser.id})" >Delete</button></td>
                </tr>`;
        });
        document.getElementById("userTable").innerHTML = li;
        
      // do something with data
      console.log(data);
    })
    .catch(function(error) {
      console.log('Looks like there was a problem: \n', error);
    });
  
    function addUser(){
        var TempFname=document.getElementById("fname");
        var TempLname=document.getElementById("lname");
        var TempAge=document.getElementById("age");
        var TempAddress=document.getElementById("address");
        var TempUser={
            "FirstName":TempFname.value,
            "LastName":TempLname.value,
            "Age":TempAge.value,
            "Address":TempAddress.value
        }
        console.log(TempUser);
        fetch("https://localhost:44326/api/User", {
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
    
      console.log(id)
    
      fetch("https://localhost:44326/api/User/"+id.toString(), {
    
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
    
          console.log(result);}
    
          );
    
    }


