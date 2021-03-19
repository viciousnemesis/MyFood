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