const url = 'https://localhost:44375/api/blog';
async function getDataFromCinemasAPI() {
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

  let cardContentForFilling = '<div class="col-md-4 mb-4"><div class="card box-shadow"><div class="card-body"><p class="card-text"></p></div></div></div>';

  for (let i = 0; i < data.length; i++) {
    $('.append-here').append(cardContentForFilling);
    console.log(data[i])
    let cards = $('.card-text');
    cards.eq(i).html(("<h3 style='color:#310b0b;'>"+data[i]["head"]+"</h3>"+"<br>"+data[i]["body"]+"<br>"+"<hr>"+"-"+"<i>"+data[i]["username"]+"</i>"));
  }
}
getDataFromCinemasAPI();