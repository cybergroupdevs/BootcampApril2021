// Navbar functionality STARTS
$(".navbar-nav>li>a").on("click", function () {
  $(".navbar-collapse").collapse("hide");
});
// Navbar functionality ENDS

// JQuery for Perfect Mobile View START
$(document).ready(function () {
  $(".table-responsive-stack").each(function (i) {
    var id = $(this).attr("id");
    //alert(id);
    $(this)
      .find("th")
      .each(function (i) {
        $("#" + id + " td:nth-child(" + (i + 1) + ")").prepend(
          '<span class="table-responsive-stack-thead">' +
            $(this).text() +
            ":</span> "
        );
        $(".table-responsive-stack-thead").hide();
      });
  });

  $(".table-responsive-stack").each(function () {
    var thCount = $(this).find("th").length;
    var rowGrow = 100 / thCount + "%";
    //console.log(rowGrow);
    $(this).find("th, td").css("flex-basis", rowGrow);
  });

  function flexTable() {
    if ($(window).width() < 768) {
      $(".table-responsive-stack").each(function (i) {
        $(this).find(".table-responsive-stack-thead").show();
        $(this).find("thead").hide();
      });

      // window is less than 768px
    } else {
      $(".table-responsive-stack").each(function (i) {
        $(this).find(".table-responsive-stack-thead").hide();
        $(this).find("thead").show();
      });
    }
    // flextable
  }

  flexTable();

  window.onresize = function (event) {
    flexTable();
  };

  // document ready
});
// JQuery for Perfect Mobile View END
function authorize() {
  var text = document.getElementById("authorisePara");
  if (window.localStorage.getItem("token").toString() != "false") {
    getDoubts();
  } else {
    text.style.display = "block";
  }
}

function getDoubts() {
  fetch("https://localhost:44305/api/User", {
    mode: "cors", // no-cors, *cors, same-origin
    cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
    credentials: "same-origin", // include, *same-origin, omit
    headers: {
      "Content-Type": "application/json",
      Authorization:
        "Bearer " + window.localStorage.getItem("token").toString(),
      // 'Content-Type': 'application/x-www-form-urlencoded',
    },
    redirect: "follow", // manual, *follow, error
    referrerPolicy: "no-referrer",
  })
    .then((res) => res.json())
    .then((data) => {
      let li = "";
      data.forEach((TempUser) => {
        // console.log(user);
        li += `<tr>
            <td data-label="Id">${TempUser.id} </td>
            <td id="nameData${TempUser.id}" data-label="Name">${TempUser.name}</td>
            <td id="dateData${TempUser.id}" data-label="DateTime">${TempUser.dateTime}</td>
            <td id="doubtData${TempUser.id}" data-label="Doubt">${TempUser.doubt}</td> 
            <td id="resolverData${TempUser.id}" data-label="Resolver">${TempUser.resolver}</td>
            <td data-label="Solution"><textarea
            wrap="hard"
            id="solutionData${TempUser.id}"
            name="fname"
            value=""
          >${TempUser.solution}</textarea>
        </td>
          <td data-label="Action">
            <button type="button" class="responsive-content btn btn-success" onclick="updateDoubt(${TempUser.id})" data-toggle="modal" data-target="#myModal" >Update</button>
            <button type="button" onclick="deleteDoubt(${TempUser.id})" class="responsive-content btn btn-danger" >Delete</button>
          </td>
            </tr>`;
      });
      document.getElementById("userTable").innerHTML = li;

      // do something with data
      console.log(data);
    })
    .catch(function (error) {
      console.log("Looks like there was a problem: \n", error);
    });
}

function addDoubt() {
  var TName = document.getElementById("nameInput").value;
  var date = new Date();
  var TDate = date.toISOString().slice(0, 19).replace("T", " ");
  var TDoubt = document.getElementById("doubtInput").value;
  var TResolver = document.getElementById("resolverInput").value;

  var TempUser = {
    Name: TName,
    DateTime: TDate,
    Doubt: TDoubt,
    Resolver: TResolver,
    Solution: "Unresolved",
  };
  console.log(TempUser);
  fetch("https://localhost:44305/api/User", {
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
    body: JSON.stringify(TempUser),
  })
    //.then(response => response.json())
    .then((result) => {
      console.log(result);
    });
  alert("Added your doubt Successfully!!!");
  getDoubts();
}

function deleteDoubt(id) {
  console.log(id.toString());
  var urlDelete = "https://localhost:44305/api/User/" + id.toString();
  console.log(urlDelete);
  fetch(urlDelete, {
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
    .then((result) => {
      console.log(result);
    });
  alert("Deleted Successfully!!!");
  getDoubts();
}

function updateDoubt(id) {
  var TName = document.getElementById("nameData" + id.toString());
  console.log("nameData + id.toString(): " + "nameData" + id.toString());
  var TDate = document.getElementById("dateData" + id.toString());
  var date = new Date();
  var TDate = date.toISOString().slice(0, 19).replace("T", " ");
  var TDoubt = document.getElementById("doubtData" + id.toString());
  var TResolver = document.getElementById("resolverData" + id.toString());
  var TSolution = document.getElementById("solutionData" + id.toString());

  var TempUser = {
    Name: TName.innerText,
    DateTime: TDate,
    Doubt: TDoubt.innerText,
    Resolver: TResolver.innerText,
    Solution: TSolution.value,
  };
  console.log(TempUser);
  var urlUpdate = "https://localhost:44305/api/User/" + id.toString();
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
  alert("Doubt has been updated Successfully!!!");
  getDoubts();
}

function openFB() {
  window.open("https://www.facebook.com/Zyro9922/", "_blank");
}

function openInsta() {
  window.open("http://instagram.com/alihasan9922", "_blank");
}

function openLinkedin() {
  window.open("https://www.linkedin.com/in/Zyro9922", "_blank");
}

function openGithub() {
  window.open("https://github.com/AliCYGRP/", "_blank");
}

function logout() {
  window.localStorage.setItem("token", "false");
  alert("Logout successful");
  window.open("http://127.0.0.1:5500/LoginPage/index.html", "_blank");
}
