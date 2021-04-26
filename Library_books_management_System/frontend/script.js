
function loginCheck(){
  var TempId=document.getElementById("FuserId");
  var TempPass=document.getElementById("Fpass");
  
  var TempBook={
      "userId":TempId.value,
      "password":TempPass.value
      
  }
  console.log(TempBook);
  fetch("https://localhost:44321/api/Login", {
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
  body: JSON.stringify(TempBook)
})
//.then(response => response.json())
.then(response => response.text())
      .then((response) => {
        console.log('token');
        window.localStorage.setItem('token', response);
        window.localStorage.getItem('token').toString();
      })
      
}

//////////////GET LIST OF ALL BOOKS FUNCTION /////////////

function getData(){
fetch('https://localhost:44321/api/Book',{
    mode: 'cors', // no-cors, *cors, same-origin
    cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
    credentials: 'same-origin', // include, *same-origin, omit
    headers: {
      //'Authorization': 'Bearer ' + (window.localStorage.getItem("token")),
      'Content-Type': 'application/json'
     
    },
    redirect: 'follow', // manual, *follow, error
    referrerPolicy: 'no-referrer'
}
)
.then(res => res.json())
.then(data => {
    let li = "";
            data.forEach(TempBook => {
              
             li += `<tr>
            <td colspan ="2" > 
            ${TempBook.bookName}
            </td>
            <td align="right"><i class="fa fa-book" aria-hidden="true" data-toggle="modal" data-target="#myModal" onclick=getDataById(${TempBook.bookId})></i>
             &nbsp&nbsp&nbsp
             <i class="fa fa-pencil" aria-hidden="true" data-toggle="modal" data-target="#myModal" onclick=UpdateData(${TempBook.bookId})></i>
             &nbsp&nbsp&nbsp
             <i class="fa fa-trash" aria-hidden="true" onclick="deleteBook(${TempBook.bookId})"></i>
              &nbsp&nbsp&nbsp
            </td></tr>`
    });
    document.getElementById("BookBody").innerHTML = li;
    

  // do something with data
  console.log(data);
})
.catch(function(error) {
  console.log('Looks like there was a problem: \n', error);
});
}

var xname = document.getElementById("Mname");
  var xauthor = document.getElementById("Mauthor");
  var xcost= document.getElementById("Mcost");
  var xissued = document.getElementById("Missued");
  var xavailable = document.getElementById("Mavailable");


/////////GET DATA OF BOOK USIND ID //////////

function getDataById(id1){
  document.getElementById("modalHeading").innerHTML="Book Details";
  // document.getElementById("updateData").value="Add";
   var ubtn=document.getElementById("updateData")
 ubtn.value="Ok!!";
  var url= "https://localhost:44321/api/Book/" + id1.toString();
  fetch(url,{
    mode: 'cors', // no-cors, *cors, same-origin
    cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
    credentials: 'same-origin', // include, *same-origin, omit
    headers: {
      
      'Content-Type': 'application/json',
      //Authorization: `token ${token}`
      // 'Content-Type': 'application/x-www-form-urlencoded',
    },
    redirect: 'follow', // manual, *follow, error
    referrerPolicy: 'no-referrer'
}
)
   .then(res => res.json())
   .then(data => {
      
                xname.value = data.bookName;
                xauthor.value = data.bookAuthor;
                xcost.value = data.bookCost;
                xissued.value = data.bookIssued;
                xavailable.value = data.bookAvailable;
                 })
   .catch(function(error) {
     console.log('Looks like there was a problem: \n', error);
   });
   }

             ///////////UPDATE BOOK DATA ///////////
 
function UpdateData(id1){
  getDataById(id1);
  document.getElementById("modalHeading").innerHTML="Update Book details!!"
  
  var ubtn=document.getElementById("updateData")
       ubtn.value="Update";
  ubtn.addEventListener("click",function(){
    var TempUser={
      "bookName":xname.value,
      "bookAuthor":xauthor.value,
      "bookCost":xcost.value,
      "bookIssued":xissued.value,
      "bookAvailable":xavailable.value

    }
    var url= "https://localhost:44321/api/Book/" + id1.toString();
    fetch(url,{
      method:"PUT",
      mode: 'cors', // no-cors, *cors, same-origin
      cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
      credentials: 'same-origin', // include, *same-origin, omit
      headers: {
       
        'Authorization': 'Bearer ' + (window.localStorage.getItem("token")),
        'Content-Type': 'application/json'
        // 'Content-Type': 'application/x-www-form-urlencoded',
      },
      redirect: 'follow', // manual, *follow, error
      referrerPolicy: 'no-referrer',
      body:JSON.stringify(TempUser)
  }
  )
  .then(result=>{
    alert("updated data");
  });
  },false);
}

              ///////////DELETE BOOK DATA//////////


function deleteBook(id1) {
  // console.log(id.toString());
   var url = "https://localhost:44321/api/Book/" + id1.toString();
   console.log(url);
   fetch(url, {
     method: "DELETE",
     mode: "cors", // no-cors, *cors, same-origin
     cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
     credentials: "same-origin", // include, *same-origin, omit
     headers: {
      'Authorization': 'Bearer ' + (window.localStorage.getItem("token")),
       "Content-Type": "application/json",
       // 'Content-Type': 'application/x-www-form-urlencoded',
     },
     redirect: "follow", // manual, *follow, error
     referrerPolicy: "no-referrer",
   })
     //.then(response => response.json())
     .then(result =>{
      alert( " Deleted Successfully!");
      getData();
     });
       }

                  //////// ADD NEW  BOOK FUNCTION //////


       function addBook(){
         document.getElementById("modalHeading").innerHTML="Add New Book";
        // document.getElementById("updateData").value="Add";
         var ubtn=document.getElementById("updateData")
       ubtn.value="Add";
       
        ubtn.addEventListener("click",function(){
          var TempUser={
            "bookName":xname.value,
            "bookAuthor":xauthor.value,
             "bookCost":xcost.value,
             "bookIssued":xissued.value,
            "bookAvailable":xavailable.value
      
         }
         //console.log(window.localStorage.getItem("token"));
          fetch("https://localhost:44321/api/Book", {
            method: "POST",
            mode: 'cors', // no-cors, *cors, same-origin
            cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
            credentials: 'same-origin', // include, *same-origin, omit
            headers: {
             
                'Authorization': 'Bearer ' + (window.localStorage.getItem("token")),
               'Content-Type': 'application/json'
            },
            redirect: 'follow', // manual, *follow, error
            referrerPolicy: 'no-referrer',
            body: JSON.stringify(TempUser)
        })
        //.then(response => response.json())
        .then(result => {
          alert("User Added Successfully!");
          getData();
            }
            );
            
            
        })
      }

      