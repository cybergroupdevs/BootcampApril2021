const url = 'https://localhost:44368/api/blog';
async function getBlogs() {
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

    for (let i = 0; i < data.length; i++) {
        $('.append-here').append(card);
        let cards = $('.card-text');
        cards.eq(i).html(("<h3>" + data[i]["head"] + "</h3>" + "<br>" + data[i]["body"] + "<br>" + "<hr>" + "-" + data[i]["username"]));
    }
}
getBlogs();
var u = localStorage.getItem("u");
// localStorage.setItem("u", u);

if (u != null) {
    document.getElementById("user").innerHTML = "<a class='btn btn-primary btn-sm' href='./profile.html' role='button'>" + "My Profile" + "</a>"
}
else {
    document.getElementById("user").innerHTML = "<a class='btn btn-primary btn-sm' href='./login.html' role='button'>" + "Please Login!!!" + "</a>"
}
