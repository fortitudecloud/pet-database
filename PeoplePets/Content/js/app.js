// app.js 
// Author: Lionel Hickey
// 12-09-2016

function compileList(genderNames) {
    var templateMarkup = $("#name-list-template").html();
    var template = Handlebars.compile(templateMarkup);
    return template(genderNames);
}

$(document).ready(function () {

    // Hit the custom web service for retrieving cats by gender
    $('button').click(function () {

        $.get('/people/cats_by_gender', function (data) {

            // Render the list as markup

            var htmlList = "";

            data.forEach(function (e, i, a) {
                htmlList += compileList(e);
            });


            setTimeout(function () {
                // Show the result list
                var namesElement = $('.names');
                namesElement.find('.results .list').append(htmlList);
                namesElement.css('visibility', 'visible');
                namesElement.addClass('animated fadeInLeft');

                // Show a not implemented notification (ideally this would be rendered after a 501)
                $('li').click(function () {
                    var notify = $('#notifications');                    

                    notify.css('visibility', 'visible');
                    notify.addClass('fadeInDown');
                    setTimeout(function () {
                        notify.addClass('fadeOutUp');
                        notify.removeClass('fadeInDown');
                        setTimeout(function () {
                            notify.css('visibility', 'hidden');
                            notify.removeClass('fadeOutUp');
                        }, 800);
                    }, 3000);
                });
            }, 800);           

        });

        // Transition from home to results
        var homeElement = $('.home');
        homeElement.addClass('animated fadeOutUp');

        setTimeout(function () {
            homeElement.css('display', 'none');            
        }, 800);

    });    

});