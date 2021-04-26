    // function GetData(){
        fetch("https://localhost:44376/api/Teacher_Info").
        then(response => response.json())
            .then(json => {        
                let li = ``;
                json.forEach(user => {
                   // console.log(user);
                li += `<tr>
                <td>${user.teacherId}</td>
                <td>${user.teacherName}</td>
                <td>${user.teacherGender}</td>
                <td>${user.teacherPhone}</td>
                <td>${user.teacherDep}</td>
                <td>${user.teacherAdd}</td>
                 <td>
                <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
                <div class="btn-group me-2" role="group" aria-label="Second group">
                  <button type="button" class="btn btn-warning"data-toggle="modal" data-target="#myModal" id='${user}'onclick=update(${user.teacherId},'${user.teacherName}','${user.teacherGender}','${user.teacherPhone}','${user.teacherDep}','${user.teacherAdd}',);>Edit</button>
                </div>
                <div class="btn-group" role="group" aria-label="Third group">
                  <button type="button" class="btn btn-danger"onclick=deleteUser('${user.teacherId}');>Delete</button>
                </div>
              </div>
        </td>
                </tr>`;
        });
        document.getElementById("users").innerHTML = li;
        });
        function deleteUser(id){
    
            fetch("https://localhost:44376/api/Teacher_Info"+"/"+id.toString(), {
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
            var ID=document.getElementById("TeacherId");
            var name=document.getElementById("Name");
            var dept=document.getElementById("dept");
            var phn=document.getElementById("phn");
            var add=document.getElementById("Addre");
            var gen=document.getElementById("gender");
            var TempUser={
                "TeacherId":ID.value,
               "TeacherName":name.value,
               "TeacherGender":gen.value,
               "TeacherPhone":phn.value,
               "TeacherDep":dept.value,
               "TeacherAdd":add.value
            }
            console.log(TempUser);
            fetch("https://localhost:44376/api/Teacher_Info", {
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
        function update(id,name,gen,phn,dep,add)
        { 
          var tid=document.getElementById("ModalTeacherId")
           var tname = document.getElementById("ModalName");
        var tgen = document.getElementById("Modalgender");
        var tphn = document.getElementById("Modalphn");
        var tdep = document.getElementById("Modaldept");
        var tadd = document.getElementById("ModalAddre");
        tid.value=id,
        tname.value=name;
       tgen.value=gen;
       tphn.value=phn;
       tdep.value=dep;
       tadd.value=add;
        
        var up=document.getElementById("Updatebut");
        up.addEventListener("click",function(){
        var Temp = {
          "TeacherId":tid.value,
         "TeacherName": tname.value,
         "TeacherGender":  tgen.value,
         "TeacherPhone": tphn.value,
         "TeacherDep":tdep.value,
         "TeacherAdd": tadd.value,
        }
        console.log(Temp);
          fetch("https://localhost:44376/api/Teacher_Info/"+id.toString(), {
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