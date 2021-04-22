

// function showingRefreshedList() {
//     axios.get("https://localhost:44357/api/user")
    
//     .then((response) => {
//         // .then((data) => {
//         //   console.log(data)
//         let data = response.data;
//             let tb = document.getElementById("userTable");
//             data.forEach((user) => {
//                 let tr = document.createElement('tr');
//                 for (let detail of Object.values(user)) {
//                   let td = document.createElement("td");
//                      td.appendChild(document.createTextNode(detail))
//                     tr.appendChild(td)
//                 }
//                 tb.appendChild(tr);
               
//             });
//             if (data.length > 0) {
//                 document.getElementById("userDiv").style.display='block';
//             }
        
//       });
// }

function PostUser() {
    axios.post("https://localhost:44357/api/user", {
        firstname: "aditya",
        lastname: "sharma",
        age: "22",
        address: "la",
      })
      .then((res) => {
        console.log(res);
      });
}

function showingRefreshedList() {
    fetch("https://localhost:44357/api/user")
      .then(function (response) {
        // first then()if(response.ok)
        {
          return response.text();
        }

        throw new Error("Something went wrong.");
      })
      .then(function (text) {
        // second then()console.log('Request successful', text);
      })
      .catch(function (error) {
        // catchconsole.log('Request failed', error);
      });
}
// function showingRefreshedList() {
//     fetch("https://localhost:44357/api/user")
//         .then((response) => response.json())
//         .then((json) => {
//           console.log(response)
       
//             let tb = document.getElementById("userTable");
//             json.forEach((user) => {
//                 let tr = document.createElement('tr');
//                 for (let detail of Object.values(user)) {
//                   let td = document.createElement("td");
//                      td.appendChild(document.createTextNode(detail))
//                     tr.appendChild(td)
//                 }
//                 tb.appendChild(tr);
               
//             });
//             if (json.length > 0) {
//                 document.getElementById("userDiv").style.display='block';
//             }
        
//       });
// }




// var xhttp = new XMLHttpRequest();
// xhttp.open("POST", "demo_post2.asp", true);
// xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
// xhttp.send("firstname=Henry&lastname=Ford");