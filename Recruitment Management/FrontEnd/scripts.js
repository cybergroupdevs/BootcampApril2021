
function Get(){
    fetch("https://localhost:44388/api/Portal",{
    mode: 'cors',
    cache: 'no-cache',
    credentials: 'same-origin',
    headers: {
      'Content-Type': 'application/json'
    },
    redirect: 'follow', 
    referrerPolicy: 'no-referrer'
}).then(resp => resp.json())
.then(data=>{
    let li = "";
            data.forEach(temp => {
                li += `<tr>
                    <th scope="row">${temp.cname}</th>
                    <td>
                        <h6>${temp.designation}</h6>
                        <p>${temp.drole}</p>
                    </td>
                    <td>${temp.availabile}</td>
                    <td>
                        <button type="button" class="btn btn-success" data-toggle="modal" data-target="#MUpdate" id="${temp.id} "onclick="Update(${temp.id},'${temp.cname}',${temp.availabile})">Update</button>
                        <button type="button" class="btn btn-danger" onclick="Delete(${temp.id})">Delete</button>
                </td>
                </tr>`;
            });
        document.getElementById("insert").innerHTML = li;
}).catch(function(error) {
    alert('Looks like there was a problem: \n', error);
})
}


function AddPost(){
    var name = document.getElementById("Cname").value;
    var Twork = document.getElementById("Designation").value;
    var role = document.getElementById("Roledesc").value;
    var ava = document.getElementById("Availability").value;
    var temp = {
        "cname": name,
        "designation": Twork,
        "drole": role,
        "availabile": ava
    };
    try{
    fetch("https://localhost:44388/api/Portal", {
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
        body: JSON.stringify(temp)
        }).then(res => {
            if(res.status==200){
                alert("Added successfully");
            }
            else if(res.status==401){
                alert("Unauthorized  user");
            }
            else{
                alert("Error occur check all field");
            }
            var frm = document.getElementById("form-update");
            frm.reset();
            Get();
            //window.location.reload();
        });
    }
    catch(Exception){
        alert("Error: Sign in for posting new jobs!!");
    }
}


function Update(id,name,ava){
    var u_name = document.getElementById("CompanyName_");
    var u_ava = document.getElementById("Availability_");
    var ubutton = document.getElementById("update-post");
    ubutton.value = id;
    u_name.value = name;
    u_ava.value = ava;
}


var ubutton = document.getElementById("update-post");
ubutton.addEventListener("click", function(){
    var id = ubutton.value;
    var u_name = document.getElementById("CompanyName_");
    var u_des = document.getElementById("designation_");
    var u_role = document.getElementById("Roledesc_");
    var u_ava = document.getElementById("Availability_");
        var TempUser={
            "cname": u_name.value,
            "designation": u_des.value,
            "drole": u_role.value,
            "availabile": u_ava.value
        }
   // console.log(typeof(id));
   try{
        fetch("https://localhost:44388/api/Portal"+"/"+id, {
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
                //window.location.reload();
            }
              else if(result.status==401){
                  alert("Not an Authorize user");
                  //window.location.reload();
            }
              else{
                  alert("Some error has occur on server");
                 // window.location.reload();
            }
              var frm = document.getElementById("update-application");
              frm.reset();
            }
            ).then(res=>{
                Get();
            });
    }catch(Exception)
    {alert("Error: Sign in to Access Update");}
}, false);


function Delete(id){
    try{
    fetch("https://localhost:44388/api/Portal"+"/"+id.toString(), {
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
        }
        else if(result.status==401){
            alert("Not an Authorize user");
        }
        else{
           alert("Error occured at  user");
        }
        Get();
    }
    );}
    catch(Exception){
        alert("Error: Sign in to Access Delete");
    }
 }


function SignIn(){
    var uname = document.getElementById("SigninUsername").value;
    var pass = document.getElementById("SiginPassword1").value;
    var Temp ={
        "UserName": uname,
        "Password": pass
    };
    fetch('https://localhost:44388/api/Login', {
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
        var frm = document.getElementById("signin-form");
        frm.reset();
        document.getElementById("signinchange").innerHTML = `<div><p>Your are Login!!</p>
        <button type="button">Logout</button></div>`
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
    fetch('https://localhost:44388/api/Singup', {
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
        var frm = document.getElementById("signup-form");
        frm.reset();
    });
}
