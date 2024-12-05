const Baseurl="https://localhost:44375";

function LoginUser()

{

    // alert(form1.email.value);

    // alert(form1.password.value);



    var myHeaders = new Headers();

    myHeaders.append("Content-Type", "application/json");

    var raw = JSON.stringify({

      "Username":form1.username.value,

      "Password": form1.password.value

    });

    localStorage.setItem("username", form1.username.value);
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

            alert("Wrong Username And Password!")

        }  

        else

        {

            localStorage.setItem("user-token",result.token);

            location.replace("./Home.html")



        }

        })

      .catch(error => alert("Some Error Occured!"));

}

