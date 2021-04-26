    // function GetData(){
        fetch("https://localhost:44376/api/STUD_INFO").
        then(response => response.json())
            .then(json => {        
                let li = ``;
                json.forEach(user => {
                   // console.log(user);
                li += `<tr>
                <td>${user.stdId}</td>
                <td>${user.stdName}</td>
                <td>${user.stdGender}</td>
                <td>${user.stdDOB}</td>
                <td>${user.stdPhone}</td>
                <td>${user.stdDep}</td>
                <td>${user.stdFees}</td>
                 <td>
                <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
                <div class="btn-group me-2" role="group" aria-label="Second group">
                  <button type="button" class="btn btn-warning"data-toggle="modal" data-target="#myModal" id='${user}'onclick=update(${user.stdId},'${user.stdName}','${user.stdGender}','${user.stdDOB}','${user.stdPhone}','${user.stdDep}','${user.stdFees}',);>Edit</button>
                </div>
                <div class="btn-group" role="group" aria-label="Third group">
                  <button type="button" class="btn btn-danger"onclick=deleteUser('${user.stdId}');>Delete</button>
                </div>
              </div>
        </td>
                </tr>`;
        });
        document.getElementById("users").innerHTML = li;
        });
        function deleteUser(id){
    
            fetch("https://localhost:44376/api/STUD_INFO"+"/"+id.toString(), {
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
          function addUser(){
            // var ID=document.getElementById("StudentId");
            var name=document.getElementById("Name");
            var Dates=document.getElementById("DATEOB");
            var dept=document.getElementById("dept");
            var phn=document.getElementById("phn");
            var fees=document.getElementById("fee");
            var gen=document.getElementById("gender");
            var TempUser={
                // "StdId":ID.value,
               "StdName":name.value,
               "StdGender":gen.value,
               "StdDOB":Dates.value,
               "StdPhone":phn.value,
               "StdDep":dept.value,
               "StdFees":fees.value
            }
            console.log(TempUser);
            fetch("https://localhost:44376/api/STUD_INFO", {
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
        function update(id,name,gen,dob,phn,dep,fee)
        { 
          var tid=document.getElementById("ModalStudentId")
           var tname = document.getElementById("ModalName");
        var tgen = document.getElementById("Modalgender");
        var tdb=document.getElementById("Modaldob");
        var tphn = document.getElementById("Modalphn");
        var tdep = document.getElementById("Modaldept");
        var tfee = document.getElementById("Modalfee");
        tid.value=id,
        tname.value=name;
       tgen.value=gen;
       tdb.value=dob;
       tphn.value=phn;
       tdep.value=dep;
       tfee.value=fee;
        
        var up=document.getElementById("Updatebut");
        up.addEventListener("click",function(){
        var Temp = {
          "StdId":tid.value,
         "StdName": tname.value,
         "StdGender":  tgen.value,
         "StdDOB":tdb.value,
         "StdPhone": tphn.value,
         "StdDep":tdep.value,
         "StdFees": tfee.value,
        }
        console.log(Temp);
          fetch("https://localhost:44376/api/STUD_INFO/"+id.toString(), {
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