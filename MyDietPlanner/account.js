var username = localStorage.getItem("username");
const url = 'https://localhost:44375/api/blog/' + username;
console.log(url)
async function getBlog() {
    var myHeaders = new Headers();
    myHeaders.append("Authorization", "Bearer " + localStorage.getItem("user-token"));
    const response = await fetch(url, {
        method: 'GET', // *GET, POST, PUT, DELETE, etc.
        mode: 'cors', // no-cors, *cors, same-origin
        cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
        credentials: 'same-origin', // include, *same-origin, omit
        headers: myHeaders
    });
    const data = await response.json();

    let card = '<div class="col-md-4 mb-4"><div class="card box-shadow"><div class="card-body"><p class="card-text"></p></div></div></div>';
    console.log(data)

    for (let i = 0; i < data.length; i++) {

        console.log(data[i])
        $('.append-here').append(card);
        let cards = $('.card-text');
        cards.eq(i).html(("<h3>" + data[i]["head"] + "</h3>" + "<br>" + data[i]["body"] + "<br>" + "<hr>" + "-" + data[i]["username"] + "<br>" + "<br>" + `<button class='bg-danger' onclick='del(${data[i]['blogId']})'>` + "Delete" +"</button>"+  `<button class='bg-info' onclick='update(${data[i]['blogId']})'>` + "Update" + "</button>"));
    }
}
getBlog();
function del(i) {
    fetch('https://localhost:44375/api/blog/' + i, {
        method: 'DELETE'
    }).then(response => {
        return response.json()
    }).then(data =>
        // this is the data we get after putting our data,
        console.log(data+"deleted!!!")
    );
    console.log(i);
}
document.getElementById("final").innerHTML=username;