localStorage.clear();

const Baseurl="https://localhost:44368";
function LoginUser()
{
    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");
    
    var raw = JSON.stringify({
      "username":form1.username.value,
      "Password": form1.password.value
    });
    localStorage.setItem("u", form1.username.value);

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
            alert("Wrong Credentials!")
        }  
        else
        {
            localStorage.setItem("user-token",result.token);
            location.replace("./blogs.html")

        }
        })
      .catch(error => alert("Some Error Occured!"));
}
