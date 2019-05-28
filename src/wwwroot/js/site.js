$('#btn-comment').click(function() {
    $.ajax({
        type: "POST",
        url: "/api/v1/Comments/SendComment",
        data: { text: $('#comment-text').val(), id: $('#movie-id').val() },
        success: function(result){
            $('#comments').append('<li>'+$('#comment-text').val());
        },
        failure: function(result) {
            alert ('Cannot send that comment. Try again later');
        }
    });
})
