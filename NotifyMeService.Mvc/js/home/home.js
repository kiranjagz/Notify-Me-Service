/// <reference path="_references.js" />
$(document).ready(function () {
    $.ajax(
        {
            type: "GET",
            url: "/Home/BuildEmailTrail",
            dataType: "json",
            success: function (data) {

                //var i = 1;
                //console.log(data[1]);
                //console.log(data);
                //$('table > tbody').empty();

                var tr;
                if (data.length <= 0) {
                    console.log("No email trail found");
                }

                for (var i = 0; i < data.length; i++) {
                    console.log(data);
                    var date = data[i].SubmittedDateTime.toString();
                    var datetime = new Date(date);
                    console.log(date);
                    console.log(datetime);
                    tr = $('<tr id="fileRow"/>').attr("data-id", data[i].DocumentId);
                    tr.append("<td>" + data[i].Id + "</td>");
                    tr.append("<td>" + data[i].Success + "</td>");
                    tr.append("<td>" + datetime + "</td>");
                    tr.append("<td>" + data[i].Message + "</td>");
                    tr.append("<td>" + data[i].From + "</td>");
                    tr.append("<td>" + data[i].To + "</td>");
                    tr.append("<td>" + data[i].Body + "</td>");
                    $('#tbemail').append(tr);
                    //$("#foldername").text(data[i].FolderName);
                    //console.log(data[i].FolderName);
                }
            },
            error: function (xhr) {
                alert("An error has occurred");
            }
        });
});
