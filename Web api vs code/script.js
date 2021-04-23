fetch('https://localhost:44355/api/UserData',{
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
           
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">
              Update
            </button>
          
            <!-- The Modal -->
            <div class="modal" id="myModal">
              <div class="modal-dialog">
                <div class="modal-content">
                
                  <!-- Modal Header -->
                  <div class="modal-header">
                    <h4 class="modal-title">Modal Heading</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                  </div>
                  
                  <!-- Modal body -->
                  <div class="modal-body">
                    <form>
            <label for="mfname">First name:</label><br>
            <input type="text" id="mfname" name="mfname" ><br>
            <label for="mlname">Last name:</label><br>
            <input type="text" id="mlname" name="mlname" ><br>
            <label for="mage">Age:</label><br>
            <input type="text" id="mage" name="mage" ><br>
            <label for="maddress">Address</label><br>
            <input type="text" id="maddress" name="maddress" ><br><br>
            <button type="button" class="btn btn-danger" onclick="update(${TempUser.id})">Submit</button>
          </form> 
                  </div>
                  
                  <!-- Modal footer -->
                  <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                  </div>
                  
                </div>
              </div>
            </div>
            
          
              
            </div>
            <div class="btn-group" role="group" aria-label="Third group">
              <button type="button" class="btn btn-danger" onclick="deleteUser(${TempUser.id})">Delete</button></td>
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
    fetch("https://localhost:44355/api/UserData", {
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
function deleteUser(ids){
    fetch("https://localhost:44355/api/UserData/"+ids.toString(), {
        method : 'DELETE',
        headers: {
            'Content-type': 'application/json'
        }
    }).then(data => console.log("deleted"+" "+data));
}
function update(ids)
{
    
    var TempFname = document.getElementById("mfname");
  var TempLname = document.getElementById("mlname");
  var TempAge = document.getElementById("mage" );
  var TempAddress = document.getElementById("maddress");
  var TempUser = {
    FirstName: TempFname.value,
    LastName: TempLname.value,
    Age: TempAge.value,
    Address: TempAddress.value,
  };
  console.log(TempUser);
  var urlUpdate = "https://localhost:44355/api/UserData/" + ids.toString();
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

  