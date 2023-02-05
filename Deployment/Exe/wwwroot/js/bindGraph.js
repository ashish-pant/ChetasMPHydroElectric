var ArrdataSet = [];
var xAxisPoints = [];
$(document).on('click', '.clsDamGraph', function () {
    var siteId = $(this).data('siteid');
    var siteName = $(this).data('sitename');
    var obj = {};
    var siteId = $(this).attr('data-siteid');
    localStorage.setItem("latestsiteId", siteId);
    localStorage.setItem("latestsiteName", siteName);
    //var siteName = $(this).data('data-sitename');
    obj.siteId = siteId;
    if (siteId > 0) {
        $.ajax({
            url: '/Login/CreateGraphs',
            data: { graphmodel: obj },
            type: 'POST',
            async: false,
            success: function (res, textStatus, xhr) {
                //debugger;
                ArrdataSet = [];
                xAxisPoints = [];
                $.each(res, function (index, value) {
                    ArrdataSet.push(value.lastValue);
                    xAxisPoints.push(value.dateandtime);
                });
                $('#container12').html("");
                Highcharts.chart('container12', {
                    chart: {
                        type: 'area'
                    },
                    xAxis: {
                        categories: xAxisPoints
                    },
                    plotOptions: {
                        series: {
                            fillOpacity: 0.1
                        }
                    },
                    tooltip: {
                        formatter: function () {
                            return '<b>' + "RLTvalue" + ':</b> ' + this.y + '<br/>' +
                                this.x;
                        }
                    },
                    series: [{
                        data: ArrdataSet
                    }]
                });
                $('.highcharts-title').html(siteName);
                $('.highcharts-axis-title').html("Pond Level");
                $('.highcharts-legend-item').find('text').html("Date and Time");
            },
            error: function (xhr, textStatus, errorThrown) {
                alert('Error in Database');
            }
        });
    }
});
$(document).ready(function (k, v) {
    $("#datetime1").datetimepicker();
    $("#datetime2").datetimepicker();
    var obj = {};
    localStorage.setItem("latestsiteId", 1);
    localStorage.setItem('latestsiteName', "Barna Dam")
    obj.siteId = 1;
    if (obj.siteId > 0) {
        $.ajax({
            url: '/Login/CreateGraphs',
            data: { graphmodel: obj },
            type: 'POST',
            async: false,
            success: function (res, textStatus, xhr) {
                //debugger;
                $.each(res, function (index, value) {
                    ArrdataSet.push(value.lastValue);
                    xAxisPoints.push(value.dateandtime);
                });
                Highcharts.chart('container12', {
                    chart: {
                        type: 'area'
                    },
                    xAxis: {
                        categories: xAxisPoints
                    },
                    plotOptions: {
                        series: {
                            fillOpacity: 0.1
                        }
                    },
                    tooltip: {
                        formatter: function () {
                            return '<b>' + "RLTvalue" + ':</b> ' + this.y + '<br/>' +
                                this.x;
                        }
                    },
                    series: [{
                        data: ArrdataSet
                    }],
                   
                });
                $('.highcharts-title').html("Barna Dam");
                $('.highcharts-axis-title').html("RLT Data");
                $('.highcharts-legend-item').find('text').html("Date and Time");
            },
            error: function (xhr, textStatus, errorThrown) {
                alert('Error in Database');
            }
        });
    }
});
setInterval(function () {
    location.reload();
    var obj = {};
    var latestsiteId = localStorage.getItem("latestsiteId");
    var latestsiteName = localStorage.getItem("latestsiteName");
    obj.siteId = latestsiteId;
    obj.startdate = $('#datetime1').val();
    obj.enddate = $('#datetime2').val();
    if (latestsiteId > 0) {
        $.ajax({
            url: '/Login/CreateGraphs',
            data: { graphmodel: obj },
            type: 'POST',
            async: false,
            success: function (res, textStatus, xhr) {
                //debugger;
                ArrdataSet = [];
                xAxisPoints = [];
                $.each(res, function (index, value) {
                    ArrdataSet.push(value.lastValue);
                    xAxisPoints.push(value.dateandtime);
                });
                $('#container12').html("");
                Highcharts.chart('container12', {
                    chart: {
                        type: 'area'
                    },
                    xAxis: {
                        categories: xAxisPoints
                    },
                    plotOptions: {
                        series: {
                            fillOpacity: 0.1
                        }
                    },
                    tooltip: {
                        formatter: function () {
                            return '<b>' + "RLTvalue" + ':</b> ' + this.y + '<br/>' +
                                this.x;
                        }
                    },
                    series: [{
                        data: ArrdataSet
                    }]
                });
                $('.highcharts-title').html(latestsiteName);
                $('.highcharts-axis-title').html("RLT Data");
                $('.highcharts-legend-item').find('text').html("Date and Time");
            },
            error: function (xhr, textStatus, errorThrown) {
                alert('Error in Database');
            }
        });
    }
}, 60000);



$(document).click('#btnSubmitBindGraph', function () {
    var obj = {};
    var latestsiteId = localStorage.getItem("latestsiteId");
    var latestsiteName = localStorage.getItem("latestsiteName");

    obj.siteId = latestsiteId;
    obj.startdate = $('#datetime1').val();
    obj.enddate = $('#datetime2').val();
    if (latestsiteId > 0) {
        $.ajax({
            url: '/Login/CreateGraphs',
            data: { graphmodel: obj },
            type: 'POST',
            async: false,
            success: function (res, textStatus, xhr) {
                //debugger;
                ArrdataSet = [];
                xAxisPoints = [];
                $.each(res, function (index, value) {
                    ArrdataSet.push(value.lastValue);
                    xAxisPoints.push(value.dateandtime);
                });
                $('#container12').html("");
                Highcharts.chart('container12', {
                    chart: {
                        type: 'area'
                    },
                    xAxis: {
                        categories: xAxisPoints
                    },
                    plotOptions: {
                        series: {
                            fillOpacity: 0.1
                        }
                    },
                    tooltip: {
                        formatter: function () {
                            return '<b>' + "RLTvalue" + ':</b> ' + this.y + '<br/>' +
                                this.x;
                        }
                    },
                    series: [{
                        data: ArrdataSet
                    }]
                });
                $('.highcharts-title').html(latestsiteName);
                $('.highcharts-axis-title').html("Pond Level");
                $('.highcharts-legend-item').find('text').html("Date and Time");
            },
            error: function (xhr, textStatus, errorThrown) {
                alert('Error in Database');
            }
        });
    }
});


//$(document).on('click', 'a', function (e) {
//    e.preventDefault();
//    var url = $(this).attr('href');
//    window.open(url, '_blank');
//});

function funOpenCCTV(CCTVLink) {
   
    window.open(CCTVLink);


}


//function newTab1() {
//    var form = document.createElement("form");
//    form.method = "POST";
//    form.action = "https://stackoverflow.com/questions/19851782/how-to-open-a-url-in-a-new-tab-using-javascript-or-jquery";
//    form.target = "https://stackoverflow.com/questions/19851782/how-to-open-a-url-in-a-new-tab-using-javascript-or-jquery";
//    document.body.appendChild(form);
//    form.submit();
//}


function logoutfun() {
    window.location.href = window.location.origin;
}