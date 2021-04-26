var url = "https://localhost:44385/api/Airline";


function Onfetch()
{
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
            <td>${TempUser.flightCharges}</td>
            <td>  <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">

            <div  class="btn-group me-2" role="group" aria-label="Second group">
              <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal" id="${data}" onclick=Update(${TempUser.fid},'${TempUser.flightName}','${TempUser.flightSource}','${TempUser.flightdestination}','${TempUser.flightSeats}','${TempUser.flightDeparture}','${TempUser.flightArrival}','${TempUser.flightCharges}')>Update</button>

            </div>
            <div class="btn-group" role="group" aria-label="Third group">
              <button type="button" class="btn btn-danger" onclick=Delete(${TempUser.fid})>Delete</button></td>
            </tr>`;
        });
        document.getElementById("userTable").innerHTML = li;
    })
  }



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


function Update(fid,fname,fsource,fdest,fseats,fdepar,farriv,fcharges){
    var TempFname=document.getElementById("Modalfname");
    var TempSource=document.getElementById("Modalsource");
    var TempDest=document.getElementById("Modaldest");
    var TempSeats=document.getElementById("Modalseats");
    var TempDepar=document.getElementById("Modaldepar");
    var TempArrival=document.getElementById("Modalarrival");
    var TempCharges=document.getElementById("Modalcharges");

    TempFname.value = fname;
    TempSource.value = fsource;
    TempDest.value = fdest;
    TempSeats.value = fseats;
    TempDepar.value = fdepar;
    TempArrival.value = farriv;
    TempCharges.value = fcharges; 

    var ubutton = document.getElementById("updateButton");
    ubutton.addEventListener("click", function(){
        var TempUser={
          "flightName": TempFname.value,
          "flightSource": TempSource.value,
          "flightdestination": TempDest.value,
          "flightSeats": TempSeats.value,
          "flightDeparture": TempDepar.value,
          "flightArrival": TempArrival.value,
          "flightCharges": TempCharges.value
        }
        //console.log(TempUser);
        fetch(url+"/"+fid.toString(), {
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

function SignUp(){
  var uname = document.getElementById("SignupUsername").value;
  var pass = document.getElementById("SigupPassword1").value;
  var email = document.getElementById("SigupEmail").value;
  var Temp = {
      "UserName": uname,
      "Password": pass,
      "Email": email
  };
  fetch('https://localhost:44385/api/Signup', {
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
  }).then(res => {
      if(res.status==200){
          alert("SignUp Successfully Signin to Continue");
      }
      else{
          alert("User with this username or email already exist");
          
      }
      var frm = document.getElementById("frm2");
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

// function Posting(){
//   var input1 = document.getElementById("uname");
//   var input2 = document.getElementById("pass");
//   var TempUser = {
//       "UserName": input1.value,
//       "password_": input2.value
//   }
//   fetch('https://localhost:44353/api/UserAuth', {
//       method: "POST",
//       mode: 'cors', 
//       cache: 'no-cache', 
//       credentials: 'same-origin',
//       headers: {
//         'Content-Type': 'application/json'
//       },
//       redirect: 'follow', 
//       referrerPolicy: 'no-referrer',
//       body: JSON.stringify(TempUser)
//       })
//       .then(response => response.text())
//       .then((response) => {
//           var token = response;
//           console.log(typeof(token));
//           window.localStorage.setItem("token", token);
//       });
// }