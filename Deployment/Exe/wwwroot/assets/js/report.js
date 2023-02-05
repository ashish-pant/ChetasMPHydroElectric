//var report = {
//    reportData: function () {
//        var formData = {
//            'UserName': $('#txtUserName').val(),
//            'Password': $('#txtPassword').val()
//        };
//        $.ajax({
//            url: "/Report/ReportData",
//            type: "Get",
//            success: function (d) {
//                $('#reportWithoutSOD').empty();
//                $.each(res.d, function (data, value) {
//                    $("#locationMaster").append($("<option></option>").val(value.CountryId).html(value.CountryName));
//                });
//            },
//            error: function () {
//                $("#StorageLocations").empty();
//            }
//        });
//    }
//}

function GetAverageWDSSite(selectedlocation, percentageval) {
    debugger;
    $.ajax({
        url: "/Report/ReportDetailsWDSSite?selectedlocation=" + selectedlocation + "&percentageval=" + percentageval,
        type: "Get",
        success: function (data) {
            debugger;
            var row = "";
            //$.each(data.reportDetail, function (index, item) {
            $('.clstablebind').empty();
            $('.clstablebind').html(data);
            $('#averageReport').DataTable();
        },
        error: function () {
            $("#StorageLocations").empty();
        }
    });
}

function GetAverageWDSSOP(selectedlocation, percentageval) {
    debugger;
    $.ajax({
        url: "/Report/AverageReportDetailsWDSSop?selectedlocation=" + selectedlocation + "&percentageval=" + percentageval,
        type: "Get",
        success: function (data) {
            debugger;
            var row = "";
            //$.each(data.reportDetail, function (index, item) {
            $('.clstablebind').empty();
            $('.clstablebind').html(data);
            $('#averageReport').DataTable();
        },
        error: function () {
            $("#StorageLocations").empty();
        }
    });
}

function GetAverageWTPData(selectedlocation, percentageval) {
    debugger;
    $.ajax({
        url: "/Report/AverageWTPData?selectedlocation=" + selectedlocation + "&percentageval=" + percentageval,
        type: "Get",
        success: function (data) {
            debugger;
            var row = "";
            //$.each(data.reportDetail, function (index, item) {
            $('.clstablebind').empty();
            $('.clstablebind').html(data);
            //    $('#reportWithoutSODbody').empty();
            //    //$('#reportWithoutSOD').empty();
            //    row += "<tr><td>" + item.siteName + "</td><td>" + item.zoneName + "</td><td>" + item.headerPressure + "</td>" +
            //        "<td>" + item.inletFlow + "</td>" +
            //        "<td>" + item.inletTotalizerFlow + "</td>" +
            //        "<td>" + item.ugtLevel + "</td>" +
            //        "<td>" + item.outletFlow + "</td>" +
            //        "<td>" + item.outletTotaizerFlow + "</td>" +
            //        "<td>" + item.sedhiCanal + "</td>" +
            //        "<td>" + item.turbidity + "</td>" +
            //        "<td>" + item.start + "</td>" + "<td>" + item.end + "</td>" + "<td>" + item.lastUpdate + "</td>" +
            //        "</tr>";
            //});
            //$("#reportWithoutSODbody").html(row);
            $('#averageReport').DataTable();
        },
        error: function () {
            $("#StorageLocations").empty();
        }
    });
}


function GetAverageWTPSOP(selectedlocation, percentageval) {
    debugger;
    $.ajax({
        url: "/Report/AverageWTPSopData?selectedlocation=" + selectedlocation + "&percentageval=" + percentageval,
        type: "Get",
        success: function (data) {
            debugger;
            var row = "";
            $('.clstablebind').empty();
            $('.clstablebind').html(data);
            $('#reportWithoutSOD').DataTable();
        },
        error: function () {
            $("#StorageLocations").empty();
        }
    });
}



$('#locationMaster').on('change', function () {
    var selectedlocation = $(this).val();
    var isAvg = $('#locationMaster option:selected').data("isavg");
    if (isAvg == 1) {
        $('#percentageId').hide();
        $('#getReportsId').hide();
        $('#loader').addClass("hide-loader");
        $('#loader').addClass("show-loader");
        GetAverageWDSSite(selectedlocation, "");
        $('#loader').removeClass("show-loader");
        $('#loader').addClass("hide-loader");
    }
    else if (isAvg == 2) {
        $('#percentageId').show();
        $('#getReportsId').show();
    }
    else if (isAvg == 3) {
        $('#percentageId').hide();
        $('#getReportsId').hide();
        $('#loader').addClass("hide-loader");
        $('#loader').addClass("show-loader");
        GetAverageWTPData(selectedlocation, "");
        $('#loader').removeClass("show-loader");
        $('#loader').addClass("hide-loader");
    }
    else {
        $('#percentageId').show();
        $('#getReportsId').show();
    }
});


function getReports() {
    var selectedlocation = $('#locationMaster').val();
    var isAvg = $('#locationMaster option:selected').data("isavg");
    var percentageval = $('#percentageId').val();
    if (isAvg == 1) {
        $('#loader').addClass("hide-loader");
        $('#loader').addClass("show-loader");
        GetAverageWDSSite(selectedlocation, percentageval);
        $('#loader').removeClass("show-loader");
        $('#loader').addClass("hide-loader");
    }
    else if (isAvg == 2) {
        $('#loader').addClass("hide-loader");
        $('#loader').addClass("show-loader");
        GetAverageWDSSOP(selectedlocation, percentageval);
        $('#loader').removeClass("show-loader");
        $('#loader').addClass("hide-loader");
    }
    else if (isAvg == 3) {
        $('#loader').addClass("hide-loader");
        $('#loader').addClass("show-loader");
        GetAverageWTPData(selectedlocation, percentageval);
        $('#loader').removeClass("show-loader");
        $('#loader').addClass("hide-loader");
    }
    else {
        $('#loader').addClass("hide-loader");
        $('#loader').addClass("show-loader");
        GetAverageWTPSOP(selectedlocation, percentageval);
        $('#loader').removeClass("show-loader");
        $('#loader').addClass("hide-loader");
    }





}
