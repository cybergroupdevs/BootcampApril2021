var u = localStorage.getItem("u");
const url = 'https://localhost:44368/api/blog/' + u;
// console.log(url)
async function getBlog() {
    var auth_header = new Headers();
    auth_header.append("Authorization", "Bearer " + localStorage.getItem("user-token"));
    const response = await fetch(url, {
        method: 'GET', // *GET, POST, PUT, DELETE, etc.
        mode: 'cors', // no-cors, *cors, same-origin
        cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
        credentials: 'same-origin', // include, *same-origin, omit
        headers: auth_header
    });
    const data = await response.json();

    let card = '<div class="col-md-4 mb-4 bg-light"><div class="card box-shadow bg-dark text-white"><div class="card-body"><p class="card-text"></p></div></div></div>';
    console.log(data)

    for (let i = 0; i < data.length; i++) {

        console.log(data[i])
        $('.append-here').append(card);
        let cards = $('.card-text');
        cards.eq(i).html(("<h3>" + "<p id='blog_head'>" + data[i]["head"] + "</p>" + "</h3>" + "<br>" + "<textarea id='blog_body' class='md-textarea form-control' rows='12'>" + data[i]["body"] + "</textarea>" + "<br>" + "<hr>" + "-" + "<p id='blog_username'>" + data[i]["username"] + "</p>" + "<br>" + "<br>" + `<button class='bg-danger' onclick='del(${data[i]['blogId']})'>` + "Delete" + "</button>" + `<button class='bg-warning' onclick='update(${data[i]['blogId']})'>` + "Update" + "</button>"));
    }
}
getBlog();
function del(i) {
    var auth_header = new Headers();
    auth_header.append("Authorization", "Bearer " + localStorage.getItem("user-token"));
    fetch('https://localhost:44368/api/blog/' + i, {
        method: 'DELETE',
        headers: auth_header,
    }).then(response => {
        return response.json()
    }).then(data =>
        // this is the data we get after putting our data,
        console.log(data + "deleted!!!")
    );
    console.log(i);
}

function update(id) {
    console.log(id)
    var blog_head = document.getElementById("blog_head").innerHTML;
    var blog_body = document.getElementById("blog_body").value;
    var blog_username = document.getElementById("blog_username").innerHTML;
    const blog = {
        "blogId": id,
        "head": blog_head,
        "body": blog_body,
        "username": blog_username
    }
    fetch('https://localhost:44368/api/blog/' + id, {
        method: 'PUT',
        mode: 'cors',
        cache: 'no-cache',
        credentials: 'same-origin',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(blog)
    }).then(response => response.json())
}

document.getElementById("user").innerHTML = u

