$(document).ready(function() {
    $("#com").click(function () {
        var commentText = $("textarea").val();
        var articleID = $("#articleID").text();
        $.post("/Article/AddComment",
            { id: articleID, text: commentText},
            function(data, status) {
                $("#comments").append(data);
            });
       $("textarea").val("");
    });
});