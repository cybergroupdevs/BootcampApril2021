// Handle click event on Update button
// fetch("https://localhost:44330/api/user")
//   .then((response) => response.json())
//   .then((data) => {
//     console.log(data)
//   });


$(document).ready(function () {
    userList();
});

function userList() {
    $.ajax({
        url: 'https://localhost:44330/api/user/',
        type: 'GET',
        dataType: 'json',
        success: function (users) {
            userListSuccess(users);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

function userListSuccess(users) {
    $.each(users, function (index, user) {
        userAddRow(user);
    });
}

function userAddRow(user) {
    if ($("#userTable tbody").length == 0) {
        $("#userTable").append("<tbody></tbody>");
    }
    $("#userTable tbody").append(
        userBuildTableRow(user));
}

function userBuildTableRow(user) {
    console.log(user)
    var ret =
        "<tr>" +
        "<td>" + user.id + "</td>" +
        "<td>" + user.firstName + "</td>" +
        "<td>" + user.lastName + "</td>" +
        "<td>" + user.age + "</td>" +
        "<td>" + user.address + "</td>" +
        "<td>" +
        "<button type='button' " +
        "onclick='userGet(this);' " +
        "class='btn btn-default' " +
        "data-id='" + user.id + "'>" +
        "<span class='bg-warning' >"+"EDIT"+"</span>"
        + "</button>" +
        "</td>" +

        "<td>" +
        "<button type='button' " +
        "onclick='userDelete(this);' " +
        "class='btn btn-default' " +
        "data-id='" + user.id + "'>" +
        "<span class='bg-danger' >" +"DEL"+"</span>"+
        "</button>" +
        "</td>" +
        "</tr>";
    return ret;
}

function userGet(ctl) {
    var id = ctl.getAttribute('data-id');

    // Store product id in hidden field
    $("#userid").val(id);

    // Call Web API to get a list of Products
    $.ajax({
        url: "https://localhost:44330/api/user/" + id,
        type: 'GET',
        dataType: 'json',
        success: function (user) {
            console.log("We'r inside EDIT");
            userToFields(user,id);

            // Change Update Button Text
            $("#updateButton").text("Update my Data");
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

function userToFields(user,id) {
    console.log(id+"passed id")
    $("#id").val(user.id);
    $("#fname").val(user.firstName);
    $("#lname").val(user.lastName);
    $("#age").val(user.age);
    $("#address").val(user.address);

}

var User = {
    FirstName: "",
    LastName: "",
    Age: "",
    Address: ""
}

function updateClick() {
    User = new Object();
    // User.id=$("#id").val();
    User.FirstName = $("#fname").val();
    User.LastName = $("#lname").val();
    User.Age = $("#age").val();
    User.Address = $("#address").val();
    if ($("#updateButton").text().trim() == "Add") {
        console.log("passing user to post")
        userAdd(User);
    }
    else {
        userUpdate(User);
    }
}


function userAdd(user) {
    console.log(user)
    $.ajax({
        url: "https://localhost:44330/api/user/",
        type: 'POST',
        contentType:
            "application/json;charset=utf-8",
        data: JSON.stringify(user),
        success: function (user) {
            console.log("we'r inside POST");
            userAddSuccess(user);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

function userAddSuccess(user) {
    userAddRow(user);
    formClear();
}

function formClear() {
    $("#fname").val("");
    $("#lname").val("");
    $("#age").val("");
    $("#address").val("");
}
function addClick() {
    formClear();
}

function userUpdate(user) {
    console.log(user)
    $.ajax({
        url: "https://localhost:44330/api/user/"+user.id,
        type: 'PUT',
        contentType:
            "application/json;charset=utf-8",
        data: JSON.stringify(user),
        success: function (user) {
            userUpdateSuccess(user);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

function userUpdateSuccess(user) {
    userUpdateInTable(user);
}

function userUpdateInTable(user) {
    // Find Product in <table>
    var row = $("#userTable button[data-id='" + user.id + "']").parents("tr")[0];

    // Add changed product to table
    $(row).after(userBuildTableRow(user));

    // Remove original product
    $(row).remove();
    formClear();  // Clear form fields

    // Change Update Button Text
    $("#updateButton").text("Add");
}

function userDelete(ctl) {
    var id = ctl.getAttribute('data-id');
    console.log(id);
            
    $.ajax({
        url: "https://localhost:44330/api/user/" + id,
        type: 'DELETE',
        success: function (ctl) {
            console.log(ctl);
            $(ctl).parents("tr").remove();
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}
function handleException(request, message, error) {
    var msg = "";
    msg += "Code: " + request.status + "\n";
    msg += "Text: " + request.statusText + "\n";
    if (request.responseJSON != null) {
        msg += "Message" + request.responseJSON.Message + "\n";
    }
    alert(msg);
}

