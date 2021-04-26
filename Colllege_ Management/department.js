    // function GetData(){
        fetch("https://localhost:44376/api/Department_Info").
        then(response => response.json())
            .then(json => {        
                let li = ``;
                json.forEach(user => {
                   // console.log(user);
                li += `<tr>
                <td>${user.depName} </td>
                <td>${user.depDesc} </td>
                <td>${user.depDuration} </td>
                 <td>
                <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
                <div class="btn-group mr-2" role="group" aria-label="Second group">
                  <button type="button" class="btn btn-warning"data-toggle="modal" data-target="#myModal" id='${user}'onclick=update('${user.depName}','${user.depDesc}','${user.depDuration}');>Edit</button>
                </div>
                <div class="btn-group" role="group" aria-label="Third group">
                  <button type="button" class="btn btn-danger"onclick=deleteUser('${user.depName}');>Delete</button>
                </div>
              </div>
        </td>
                </tr>`;
        });
        document.getElementById("users").innerHTML = li;
        });
        function addUser(){
            var  Name=document.getElementById("name");
            var Desc=document.getElementById("des");
            var Durat=document.getElementById("dur");
            var TempUser={
                "DepName":Name.value,
                "DepDesc":Desc.value,
                "DepDuration":Durat.value,
            }
            console.log(TempUser);
            fetch("https://localhost:44376/api/Department_Info", {
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
            alert("Added Successfully");}
            );
        }
        function deleteUser(name){
            
          fetch("https://localhost:44376/api/Department_Info"+"/"+name.toString(), {
           method: "DELETE",
           mode: 'cors', 
           cache: 'no-cache', 
           credentials: 'same-origin',
           headers: {
             'Content-Type': 'application/json'
           },
           redirect: 'follow', 
           referrerPolicy: 'no-referrer'
           })
           .then(result => {
              alert("Deleted Successfully");
           }
           );
           //Get();
        }
        function update(name,desc,dur)
        { 
           var Name = document.getElementById("Modalname");
        var DESC = document.getElementById("Modaldesc");
        var DUR = document.getElementById("Modaldur");
        Name.value=name;
        DESC.value=desc;
        DUR.value=dur;

        
        var up=document.getElementById("Updatebut");
        up.addEventListener("click",function(){
        var Temp = {
          "DepName": Name.value,
          "DepDesc": DESC.value,
          "DepDuration":DUR.value,
        }
        console.log(Temp);
          fetch("https://localhost:44376/api/Department_Info/"+name.toString(), {
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
            body: JSON.stringify(Temp),
          })
            //.then(response => response.json())
            .then((result) => {
              alert("updated data");
            });
        },false);
        }