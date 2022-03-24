var dataTable;

$(document).ready(function() {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Ticket/GetAll"
        },
        "columns": [
            { "data": "title of movie", "width": "15%" },
            { "data": "actors", "width": "15%" },
            { "data": "director", "width": "15%" },
            { "data": "genre", "width": "15%" },
            { "data": "description", "width": "15%" },
            { "data": "category", "width": "15%" },
            { "data": "Original Language", "width": "15%" },
            { "data": "Price", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                        <a href="/Admin/Ticket/Upsert?id=${data}"
                        class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>
                        <a onClick=Delete('/Admin/Ticket/Delete/${data}')
                        class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
					</div>
                        `
                },
                "width": "15%"
            }
        ]
    });
}


