
var report =
{
    createlogin: function () {
        var formData = {
            'UserName': $('#txtUserName').val(),
            'Password': $('#txtPassword').val()
        };
        $.ajax({
            url: "/Login/UserLogin",
            type: "POST",
            data: formData,
            success: function (d) {
                debugger;
                if (d == "1") {
                    $('.clsErrorMsg').removeClass('clsShow');
                    $('.clsErrorMsg').addClass('clshide');
                    var selectedlocation = "";
                    window.location.href = '/Report/ReportData?selectedlocation' + selectedlocation;
                }
                else {
                    $('.clsErrorMsg').removeClass('clshide');
                    $('.clsErrorMsg').addClass('clsShow');
                }
            },
            error: function () {
                $("#StorageLocations").empty();
            }
        });
    }
}


$("#btnLoginForm").on("click", function (event) {
    $('#loader').addClass("show-loader");
    report.createlogin();
    $('#loader').addClass("hide-loader");
});




