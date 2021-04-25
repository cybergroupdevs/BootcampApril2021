var url = "https://localhost:44385/api/Airline";



fetch(url,{
    mode: 'cors',
    cache: 'no-cache',
    credentials: 'same-origin',
    headers: {
      'Content-Type': 'application/json'
    },
    redirect: 'follow', 
    referrerPolicy: 'no-referrer'
}
)
.then(res => res.json())
.then(data => {
    let li = "";
            data.forEach(TempUser => {
            var data = "update"+TempUser.fid.toString();
            li += `<tr>
            <td>${TempUser.fid} </td>
            <td>${TempUser.flightName} </td>
            <td>${TempUser.flightSource} </td>
            <td>${TempUser.flightdestination} </td>
            <td>${TempUser.flightSeats}</td>
            <td>${TempUser.flightDeparture}</td>
            <td>${TempUser.flightArrival}</td>
            <td>${TempUser.flightCharges} </td>
            <td>  <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">

            <div  class="btn-group me-2" role="group" aria-label="Second group">
              <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal" id="${data}" onclick=Update(${TempUser.id},'${TempUser.firstName}','${TempUser.lastName}','${TempUser.address}','${TempUser.city}')>Update</button>

            </div>
            <div class="btn-group" role="group" aria-label="Third group">
              <button type="button" class="btn btn-danger" onclick=Delete(${TempUser.fid})>Delete</button></td>
            </tr>`;
        });
        document.getElementById("userTable").innerHTML = li;
    })



function addUser(){
    var TempFname=document.getElementById("fname");
    var TempSrc=document.getElementById("source");
    var TempDest=document.getElementById("dest");
    var TempSeats=document.getElementById("seats");
    var TempDepar=document.getElementById("depar");
    var TempArriv=document.getElementById("arrival");
    var TempCharges=document.getElementById("charges");
    
    
    
    var TempUser={
    "flightName": TempFname.value,
    "flightSource": TempSrc.value,
    "flightdestination": TempDest.value,
    "flightSeats": TempSeats.value,
    "flightDeparture": TempDepar.value,
    "flightArrival": TempArriv.value,
    "flightCharges": TempCharges.value
    }
   
    fetch(url, {
    method: "POST",
    mode: 'cors', 
    cache: 'no-cache', 
    credentials: 'same-origin',
    headers: {
      'Authorization':"Bearer "+ JSON.parse(localStorage.getItem("token"))['token'],
      'Content-Type': 'application/json'
    },
    redirect: 'follow', 
    referrerPolicy: 'no-referrer',
    body: JSON.stringify(TempUser)
    })
    .then(result => {
      if(result.status==200){
        alert("Added successfully");
        window.location.reload();}
        else{
          alert("Not an Authorize user");
        }
      }
    );
    //Get();
}


function Update(id,mfname,mlname,maddress,mcity){
    var TempFname=document.getElementById("Modalfname");
    var TempLname=document.getElementById("Modallname");
    var TempAddress=document.getElementById("Modaladdress");
    var TempCity=document.getElementById("Modalcity");

    TempFname.value = mfname;
    TempLname.value = mlname;
    TempAddress.value = maddress;
    TempCity.value = mcity;

    var ubutton = document.getElementById("updateButton");
    ubutton.addEventListener("click", function(){
        var TempUser={
            "FirstName":TempFname.value,
            "LastName":TempLname.value,
            "Address":TempAddress.value,
            "City":TempCity.value
        }
        //console.log(TempUser);
        fetch(url+"/"+id.toString(), {
            method: "PUT",
            mode: 'cors', 
            cache: 'no-cache', 
            credentials: 'same-origin',
            headers: {
              'Authorization':"Bearer "+ JSON.parse(localStorage.getItem("token"))['token'],
              'Content-Type': 'application/json'
            },
            redirect: 'follow', 
            referrerPolicy: 'no-referrer',
            body: JSON.stringify(TempUser)
            })
            .then(result => {
              if(result.status==200){
                alert("Updated successfully");
                window.location.reload();}
              else{
                  alert("Not an Authorize user");
                  window.location.reload();
                }}
            );
    }, false);
}

function Signin()
{
    var uname = document.getElementById("SigninUsername").value;
    var pass = document.getElementById("SiginPassword1").value;
    var Temp ={
        "UserName": uname,
        "Password": pass
    };
    fetch('https://localhost:44385/api/Login', {
        method: "POST",
        mode: 'cors', 
        cache: 'no-cache', 
        credentials: 'same-origin',
        headers: {
          'Content-Type': 'application/json'
        },
        redirect: 'follow', 
        referrerPolicy: 'no-referrer',
        body: JSON.stringify(Temp)
    }).then(response => response.text())
    .then((response) => {
        var token = response;
        if(token==""){
        alert("Incorrect Username or Password");
        }
        else{
            window.localStorage.setItem("token", token);
            alert("Login successfully");
        }
        var frm = document.getElementById("fm1");
        frm.reset();
    }); 
}

function Delete(id){
    
   fetch(url+"/"+id.toString(), {
    method: "DELETE",
    mode: 'cors', 
    cache: 'no-cache', 
    credentials: 'same-origin',
    headers: {
      'Authorization':"Bearer "+ JSON.parse(localStorage.getItem("token"))['token'],
      'Content-Type': 'application/json'
    },
    redirect: 'follow', 
    referrerPolicy: 'no-referrer'
    })
    .then(result => {
        if(result.status==200){
        alert("Deleted successfully");
        window.location.reload();}
        else{
          alert("Not an Authorize user");
        }
    }
    );
}

function Posting(){
  var input1 = document.getElementById("uname");
  var input2 = document.getElementById("pass");
  var TempUser = {
      "UserName": input1.value,
      "password_": input2.value
  }
  fetch('https://localhost:44353/api/UserAuth', {
      method: "POST",
      mode: 'cors', 
      cache: 'no-cache', 
      credentials: 'same-origin',
      headers: {
        'Content-Type': 'application/json'
      },
      redirect: 'follow', 
      referrerPolicy: 'no-referrer',
      body: JSON.stringify(TempUser)
      })
      .then(response => response.text())
      .then((response) => {
          var token = response;
          console.log(typeof(token));
          window.localStorage.setItem("token", token);
      });
}