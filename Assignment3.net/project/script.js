function myModal(id){
  var modal = document.getElementById("myModal");
  var btn = document.getElementById("myBtn");
  var btn2 = document.getElementById("myBtn2");
  var span = document.getElementsByClassName("close")[0];
  btn.onclick = function() {
    modal.style.display = "block";
  }
  span.onclick = function() {
    modal.style.display = "none";
  }
  window.onclick = function(event) {
    if (event.target == modal) {
      modal.style.display = "none";
    }
  }
  btn2.onclick = updatedUser(id);
}




fetch('https://localhost:44339/api/books',{
    mode: 'cors', // no-cors, *cors, same-origin
    cache: 'no-cache', 
    credentials: 'same-origin', 
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
    console.log(data);
    let li = "";
            data.forEach(TempUser => {
               // console.log(user);
            li += `<tr>
            <td>${TempUser.id}</td>
            <td>${TempUser.name}</td>
            <td>${TempUser.author} </td>
            
          <td>  <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
               
            
            <div class="btn-group" role="group" aria-label="Third group">
              <button type="button" class="btn btn-danger ml-1 mt-1" onclick="deleting(${TempUser.id})" >Delete</button></td>
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
    var TempBname=document.getElementById("name1");
    var TempAuthor=document.getElementById("author1");
   
    var TempUser={
        "Name":TempBname.value,
        "Author":TempAuthor.value
    }
    console.log(TempUser);
    fetch("https://localhost:44339/api/books", {
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
    ).catch(err =>{
        console.log(err);
    })
}

function updatedUser(ids)
{
    
    var TempName = document.getElementById("updated_name");
  var TempAuthor = document.getElementById("updated_author");
  
  var TempUser = {
    Name: TempName.value,
    Author: TempAuthor.value,
    
  };
  console.log(TempUser);
  var urlUpdate = "https://localhost:44339/api/books/" + ids.toString();
  console.log(urlUpdate);
  console.log(TempUser);
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

function Update(fid,fname,fsource){
  var TempFname=document.getElementById("Modalfname");
  var TempSource=document.getElementById("Modalsource");

  TempFname.value = fname;
  TempSource.value = fsource;


  var ubutton = document.getElementById("updateButton");
  ubutton.addEventListener("click", function(){
      var TempUser={
        "Name": TempFname.value,
        "Author": TempSource.value,
        
      }
      //console.log(TempUser);
      fetch("https://localhost:44339/api/books/"+"/"+fid.toString(), {
          method: "PUT",
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



function deleting(id){
    console.log(id.toString());
    var urlDelete = "https://localhost:44339/api/books/" + id.toString();
    console.log(urlDelete);
    fetch(urlDelete,{
      method: "DELETE",
      mode: "cors",
      cache: 'no-cache', 
        credentials: 'same-origin',
        headers:{
          "Content-Type": "application/json",
        },
        redirect: "follow",
        referredPolicy: "no-referrer",
    })
    .then((result)=>{
      console.log(result);
    })
    }


    function Signin()
{
    var uname = document.getElementById("SigninUsername").value;
    var pass = document.getElementById("SiginPassword1").value;
    var Temp ={
        "UserName": uname,
        "Passwords": pass
    };
    fetch('https://localhost:44339/api/login/', {
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

function Signup(){
  var uname = document.getElementById("SignupUsername").value;
  var pass = document.getElementById("SigupPassword1").value;

  var Temp = {
      "UserName": uname,
      "Password": pass,
      
  };
  console.log(Temp);
  fetch('https://localhost:44339/api/signup', {
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

{/* <div  class="btn-group me-2" role="group" aria-label="Second group">
 <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal" id="myBtn" onclick="Update(${TempUser.id},${TempUser.name},${TempUser.author})" >Update</button>
              
            </div> */}