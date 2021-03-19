var dataTable;

$(document).ready(function () {
    loadDataTable()

});

function loadDataTable() {

    var collapsedGroups = {};
    dataTable = $('#DT_FoodLog').DataTable({
        //"ajax": {
        //    "url": "/logfood/getall/",
        //    "type": "GET",
        //    "datatype": "json"
        //},
        "aaSortingFixed": [[0, 'asc']],
        "columns": [
            { "data": "meal", "width": "0%" },
            { "data": "food", "width": "80%" },
            { "data": "calories", "width": "20%" }
        ],
        "columnDefs": [
            {
                "targets": [0],
                "visible": false
            }
        ],
        "language": {
            "emptyTable": "No logged foods."
        },
        "width": "100%",
        "paging": false,
        "searching": false,
        "rowGroup": {
            // Uses the 'row group' plugin
            dataSrc: "meal",
            startRender: function (rows, group) {
                var collapsed = !!collapsedGroups[group];

                rows.nodes().each(function (r) {
                    r.style.display = collapsed ? 'none' : '';
                });

                // Add category name to the <tr>. NOTE: Hardcoded colspan
                return $('<tr/>')
                    .append('<td colspan="3">' + group + '</td>')
                    .attr('data-name', group)
                    .toggleClass('collapsed', collapsed);
            }
        }
    });

    $('#DT_FoodLog tbody').on('click', 'tr.group-start', function () {
        var name = $(this).data('name');
        collapsedGroups[name] = !collapsedGroups[name];
        dataTable.draw(false);
    });

}

$(function () {
    $("#datepicker").datepicker({
        defaultDate: new Date(),
        format: 'DD/MM/YYYY',
        onSelect: function () {
            UpdateDayLabel();
        }
    });
});


$("#subtractday").click(function () {
    var date = $('#datepicker').datepicker('getDate', '-1d');
    date.setDate(date.getDate() - 1);
    $('#datepicker').datepicker('setDate', date);
    UpdateDayLabel();
})


$("#addday").click(function () {
    var date = $('#datepicker').datepicker('getDate', '+1d');
    date.setDate(date.getDate() + 1);
    $('#datepicker').datepicker('setDate', date);
    UpdateDayLabel();
})


function UpdateDayLabel() {
    var dateSelected = $("#datepicker").datepicker("getDate").getTime();
    var oneDay = 24 * 60 * 60 * 1000; // hours*minutes*seconds*milliseconds
    var today = new Date();
    today.setHours(0, 0, 0, 0);
    var yesterday = new Date();
    yesterday.setDate(today.getDate() - 1)
    yesterday.setHours(0, 0, 0, 0);
    var tomorrow = new Date();
    tomorrow.setDate(today.getDate() + 1)
    tomorrow.setHours(0, 0, 0, 0);

    var text = ""
    if (dateSelected < yesterday) {
        text = `${Math.round(Math.abs((today.getTime() - dateSelected) / (oneDay)))} days ago`;
    } else if (dateSelected === yesterday.getTime()) {
        text = "Yesterday";
    } else if (dateSelected === today.getTime()) {
        text = "Today";
    } else if (dateSelected === tomorrow.getTime()) {
        text = "Tomorrow";
    } else if (dateSelected > tomorrow) {
        text = `${Math.round(Math.abs((today.getTime() - dateSelected) / (oneDay)))} days from now`;
    }

    $("#daylabel").text(text).css('font-weight', 'bold')
}

function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}