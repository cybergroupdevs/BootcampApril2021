function myFunction() {//function for hamburger
    var x = document.getElementById("myLinks");
    if (x.style.display === "block") {
      x.style.display = "none";
    } else {
      x.style.display = "block";
    }
  }


  //.Backend linking
  const Baseurl="https://localhost:44364";
function LoginUser()
{
    // alert(form1.email.value);
    // alert(form1.password.value);

    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");
    
    var raw = JSON.stringify({
      "EmailId":form1.email.value,
      "Password": form1.password.value
    });
    // "firstName": form1.fname.value,
    var requestOptions = {
      method: 'POST',
      headers: myHeaders,
      body: raw,
      redirect: 'follow'
    };
    
    fetch(Baseurl+"/api/Login", requestOptions)
      .then(response => response.json())
      .then(result => {
        if(result.token=='')
        {
            alert("Wrong EmailId And Password!")
        }  
        else
        {
            localStorage.setItem("student-management-token",result.token);
            location.replace("./Appoin.html")

        }
        })
      .catch(error => alert("Some Error Occured!"));
}
function LogOut()
{
    localStorage.removeItem("student-management-token");
    location.replace("./Login.html");
}
function CheckLogin()
{
  //
    if(localStorage.getItem("student-management-token")==null)
    {
        location.replace("./Appoin.html");

    }
}
function FetchData()
{
    var myHeaders = new Headers();
    myHeaders.append("Authorization", "Bearer "+localStorage.getItem("student-management-token"));
    var requestOptions = {
        headers: myHeaders,
        method: 'GET',
        redirect: 'follow'
      };
      
      fetch(Baseurl+"/api/UserDB", requestOptions)
        .then(response => response.json())
        .then(result => {
          var StrGet="";
          
          result.forEach((user)=>{
            // console.log(user.address)
            StrGet += `<tr>
                <td>${user.id}</td>
                 <td>${user.name} </td>
                 <td>${user.emailId} </td>
              
                 <td>${user.date}</td> 
                 <td>${user.time}</td>
                
                 <td>
                 <button type="button" onclick="SelectUserForEdit('${user.id}')">Edit</button>
                 </td>
                 <td>
                 <button type="button" onclick="DeleteUser('${user.id}')">Delete</button>
                 </td>
                 </tr>`;
            // create list and bind
            // similarly do for rest functions
             document.getElementById("student-table-body").innerHTML=StrGet;
          });

        })
        .catch(error => console.log('error', error));
}
function HomeInit()
{
     CheckLogin();
    FetchData();
}
function DeleteUser(email)
{
  var IsDelete=confirm("Are You Sure That You Want To Delete ?");
  if(IsDelete==true)
  {
    var myHeaders = new Headers();
myHeaders.append("Authorization", "Bearer "+localStorage.getItem("student-management-token"));

var requestOptions = {
  method: 'DELETE',
  headers: myHeaders,
  redirect: 'follow'
};

fetch(Baseurl+"/api/UserDB/"+email, requestOptions)
  .then(response => response.text())
  .then(result => {alert("Successfully Deleted User.")
  FetchData();
}
  )
  .catch(error => console.log('error', error));
  }
  else
  {
    return;
  }


}
function CreateUser()
{
    if(form1.email.value=='')
     {
       alert("Please Enter An Email!");
       return;
     }

    var myHeaders = new Headers();
    myHeaders.append("Authorization", "Bearer "+localStorage.getItem("student-management-token"));
    myHeaders.append("Content-Type", "application/json");

    var raw = JSON.stringify({
    "ID": form1.id.value,
    "Name": form1.name.value,
    "EmailID": form1.email.value,

     "Date": form1.date.value,
    "Time": form1.time.value,
    // "skills":form1.skills.value ,
    // "email": form1.email.value,
    // "password": form1.password.value,
    });

    var requestOptions = {
    method: 'POST',
    headers: myHeaders,
    body: raw,
    redirect: 'follow'
    };

    fetch(Baseurl+"/api/UserDB", requestOptions)//passing data from form to server side
    .then(response => response.json())
    .then(result => {
      console.log(result);
      if(result.email=='')
      {
       alert("Some Error Occured!")
      }
      else
      {
        alert("Inserted Successfully");
        FetchData();
      }
        

    })
    .catch(error => 
        console.log(error)
        );
}

function SelectUserForEdit(id){
    var newHeaders=new Headers();
    newHeaders.append("Authorization", "Bearer "+localStorage.getItem("student-management-token"));
    newHeaders.append("Content-Type", "application/json");
    fetch("https://localhost:44364/api/UserDB/"+id.toString(),{
        mode: 'cors', // no-cors, *cors, same-origin
        cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
        credentials: 'same-origin', // include, *same-origin, omit
        headers: newHeaders,
        redirect: 'follow', // manual, *follow, error
        referrerPolicy: 'no-referrer'
    }
    ).then(res=> res.json())
    .then(data =>{
        data.forEach(result =>
            {
                form1.id.value=result.id;
                   form1.name.value=result.name;
                     form1.email.value=result.emailId;
                     form1.date.value=result.date;
                     form1.time.value=result.time;
            });
        });

}
// function SelectUserForEdit(id)
// {
// //code for feting info by using id
// var myHeaders = new Headers();
// myHeaders.append("Authorization", "Bearer "+localStorage.getItem("student-management-token"));

// var requestOptions = {
//   method: 'GET',
//   headers: myHeaders,
//   redirect: 'follow'
// };

// fetch(Baseurl+"/api/UserDB/"+ id.toString(), requestOptions)
//   .then(response => response.json())
//   .then(result => {console.log(result)
//     form1.id.value=result.id;
//     form1.name.value=result.name;
//     form1.email.value=result.emailId;
//     form1.date.value=result.date;
//     form1.time.value=result.time;
//     // form1.skills.value=result.skills;
//     // form1.email.value=result.email;
//     // form1.password.value=result.password;
//   })
//   .catch(error => console.log('error', error));

// }

function Update(){
    
  var id=form1.id.value;
 if(id=='')
 {
     alert("Please Select A Record To Update!");
    return;
  }

  var myHeaders = new Headers();
   myHeaders.append("Authorization", "Bearer "+localStorage.getItem("student-management-token"));
   myHeaders.append("Content-Type", "application/json");
  
 // var raw = "{\r\n        \"firstName\": \"Ishansha\",\r\n        \"lastName\": \"Sharma\",\r\n        \"gender\": 1,\r\n        \"age\": 26,\r\n        \"city\": \"chandigarh\",\r\n        \"skills\": \"DSA , .NET Framework , React\",\r\n        \"email\": \"ishan98.es@gmail.com\",\r\n        \"password\": \"Ishan123\",\r\n        \r\n    }";
 var raw = JSON.stringify({
     "ID": form1.id.value,
     "Name": form1.name.value,
     "EmaiID": form1.email.value,

     "Date": form1.date.value,
     "Time": form1.time.value,
     // "skills":form1.skills.value ,
    // "email": form1.email.value,
    // "password": form1.password.value,
    });
  
   var requestOptions = {
     method: 'PUT',
     headers: myHeaders,
   body: raw,
    redirect: 'follow'
   };
   // Baseurl+"/api/Student/"+email
   fetch(Baseurl+"/api/UserDB/"+id, requestOptions)
     .then(response => response.json())
    .then(result => {
       console.log(result);
       if(result.id==null)
       {
         alert("Id Not Found!")
       }
       else
      {
         alert("Edited Successfully!");
         FetchData();
      }
     // console.log(result);
     
   })
     .catch(error => alert("An Error Occured!"));
}
