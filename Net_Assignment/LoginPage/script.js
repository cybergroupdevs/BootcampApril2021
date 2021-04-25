function signup() {
  var username = document.getElementById("usernameInput").value;
  var password = document.getElementById("passwordInput").value;
  var loginInfo = {
    UserName: username,
    EmailID: "nothing",
    Password: password,
  };
  console.log(loginInfo);
  fetch("https://localhost:44305/api/Login/signup", {
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
    body: JSON.stringify(loginInfo),
  })
    //.then(response => response.json())
    .then((result) => {
      console.log(result);
      alert("SignUp Successfully!!!");
    });
}

function openPage() {
  window.open("http://127.0.0.1:5500/", "_blank");
}

function login() {
  var username = document.getElementById("usernameInput").value;
  var password = document.getElementById("passwordInput").value;
  var loginInfo = {
    UserName: username,
    EmailID: "nothing",
    Password: password,
  };
  console.log(loginInfo);
  fetch("https://localhost:44305/api/Login/login", {
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
    body: JSON.stringify(loginInfo),
  })
    .then((response) => response.text())
    .then((response) => {
      console.log("Bearer " + response);
      window.localStorage.setItem("token", response);
      if (window.localStorage.getItem("token").toString() != "false") {
        alert("Login Successful. Open Link");
        openPage();
      } else {
        alert("This user does not exist");
      }
    });
}

function load() {
  window.localStorage.setItem("token", "false");
}
