fetch('https://localhost:44346/api/Bms',{
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
            <td>${TempUser.accountNumber} </td>
            <td>${TempUser.accountHolderName} </td>
            <td>${TempUser.age}</td> 
            <td>${TempUser.address} </td>
            <td>${TempUser.ifscCode} </td>
            <td>${TempUser.amount} </td>
          <td>  <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
              <div class="btn-group" role="group" aria-label="Third group">
              <button style="margin-left:3.5rem" type="button" onclick="deleteUser(${TempUser.id})" class="btn btn-danger" >Delete</button>
              </div></td>
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
    var TempAccNum=document.getElementById("accNum");
    var TempAccName=document.getElementById("name");
    var TempAge=document.getElementById("age");
    var TempAddress=document.getElementById("address");
    var TempIfsc=document.getElementById("ifsc");
    var TempAmount=document.getElementById("amount");
    var TempUser={
        "AccountNumber":TempAccNum.value,
        "AccountHolderName":TempAccName.value,
        "Age":TempAge.value,
        "Address":TempAddress.value,
        "IfscCode":TempIfsc.value,
        "Amount":TempAmount.value
    }
    console.log(TempUser);
    fetch("https://localhost:44346/api/Bms", {
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
    alert("User Added Successfully!! Kindly refresh the page.");
}


function deleteUser(id) {
    // console.log(id.toString());
     var url = "https://localhost:44346/api/Bms/" + id.toString();
     console.log(url);
     fetch(url, {
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
       .then(result =>{
         console.log(result);
       })
         
     alert("User ID " + id + " Deleted Successfully!! Kindly refresh the page.");
    }