

function PostUser() {
    var TempEmail = document.getElementById("inputEmail");
    var TempPassword = document.getElementById("inputPassword");
    var TempUsername = document.getElementById("validationDefaultUsername");

    var TempOwner = {
      "OUserName": TempUsername.value,
      "OPassword": TempPassword.value,
      "OEmail": TempEmail.value,
    };
    console.log(TempOwner);
    
      fetch("https://localhost:44306/api/RestroOwner", {
        method: "POST",
        mode: "cors", // no-cors, *cors, same-origin
        cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
        credentials: "same-origin", // include, *same-origin, omit
        headers: {
          "Content-Type": "application/json",
          // 'Content-Type': 'application/x-www-form-urlencoded',
        },
        redirect: "follow", // manual, *follow, error
        referrerPolicy: "no-referrer",
        body: JSON.stringify(TempOwner),
      })
      .then((res) => {
        console.log(res);
      });
}

 function showingRefreshedList() {
   axios
     .get("https://localhost:44306/api/RestroOwner", {
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
     .then((res) => {
       console.log(res.data);
     });
}
 
function OwnerLogin(){
        var TempEmail = document.getElementById("inputEmail");
    var TempPassword = document.getElementById("inputPassword");
    var TempUsername = document.getElementById("validationDefaultUsername");

    var TempOwner = {
      "OUserName": TempUsername.value,
      "OPassword": TempPassword.value,
      "OEmail": TempEmail.value,
    };
    console.log(TempOwner);
    
    fetch("https://localhost:44306/api/RestroOwner/login", {
      method: "POST",
      mode: "cors", // no-cors, *cors, same-origin
      cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
      credentials: "same-origin", // include, *same-origin, omit
      headers: {
        "Content-Type": "application/json",
        // 'Content-Type': 'application/x-www-form-urlencoded',
      },
      redirect: "follow", // manual, *follow, error
      referrerPolicy: "no-referrer",
      body: JSON.stringify(TempOwner),
    })
      
      .then((res) => {
          console.log(res);
          return res.json()
      })
      .then((data) => {
      
        console.log(data.token);
        localStorage.setItem("token", data.token);
        Redirect();
      });
    
    
}

function Redirect() {
  console.log("inside redirect");
  window.open("http://127.0.0.1:5500/records.html", "_blank"); 
}

  

 