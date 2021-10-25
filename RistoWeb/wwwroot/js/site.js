window.onload = Init();

////window.addEventListener('load', () => {
    
////    console.log(linkId);
////    linkId.forEach(element => {
////        console.log(element)
////    });
////});

function Init() {
    var linkId = document.getElementsByTagName('a');
    console.log(linkId);
}

/* Function used whith APIController.cs (RemoveReservation(Guid resId))
 * to remove an existent reservation */

function removeReservation() {
    var id = $("#DDLreservation").val();
    if (id != 0) {
        $.ajax({
            method: "GET",
            url: "/api/API/RemoveReservation?resId=" + id,
            data: null,
            success: function () {
                alert("Reservation succesfull cancelled");
                location.reload(true);
                return;
            },
            error: function (error) {
                console.log("error");
                console.log(error);
            },
        });
    }
    else {
        alert("You have to choose a reservation");
        return;
    }
};

/* Function used for handle the reservation and avoid the both selection
 * of "check input" used to choose Lunch or Dinner,
 * (in Reservation.cshtml). */

function checkCheck() {
    var lunch = $('#inpLunch');
    var dinner = $('#inpDinner');
    if (lunch.is(":checked") && dinner.is(":checked")) {
        alert("You have to choose Lunch or Dinner, not both");
        lunch.prop('checked', false);
        dinner.prop('checked', false);
    }
}