
function logincheck(){
    var TempName=document.getElementById("user");
    var TempPass=document.getElementById("pass");
    
    var TempBook={
    "UserName":TempName.value,
    "Password":TempPass.value
    }
    console.log(TempBook);
    fetch("https://localhost:44376/api/USERS",{
    method:"POST",
    mode:'cors', // no-cors, *cors, same-origin
    cache:'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
    credentials:'same-origin', // include, *same-origin, omit
    headers:{
    'Content-Type':'application/json'
    // 'Content-Type': 'application/x-www-form-urlencoded',
    },
    redirect:'follow', // manual, *follow, error
    referrerPolicy:'no-referrer',
    body:JSON.stringify(TempBook)
  })
    //.then(response => response.json())
    .then(response=>response.text())
          .then((response) =>{
    var token=response;
    window.localStorage.setItem("token", token);
    openpage();
           });
    
            }
            function openpage(){
              window.open("./info.html","_blank");
            }
    
    
