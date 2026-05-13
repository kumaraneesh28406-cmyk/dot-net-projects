
var dataTable;
$(document).ready(function () {
    loadDataTable();
})
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/api/book/GetAll",
            "type": "Get",
            "dataType": "json"
        },
        "columns": [
            { "data": "title", "width": "15%" },
            { "data": "description", "width": "15%" },
            { "data": "author", "width": "15%" },
            { "data": "isbn", "width": "15%" },
            { "data": "price", "width": "15%" },
            {
                "data": "id", "render": function (data) {
                    return `
                <div class ="text-center">
<a href="/Booklist/Upsert?id=${data}"class="btn btn-info">
<i class="fas fa-edit"></i>
</a>
<a class="btn btn-danger"
onclick = Delete("api/book?id=${data}")>
<i class="fas fa-trash"></i>
</a>

                </div>`;
                }
            }
        ]
    })
}



function delete(url) {
    // triggering sweetalert for confirmation
    swal({
        title: "are you sure you want to delete this data?",
        icon: "warning",  // this ensures the warning icon shows up
        text: "this action cannot be undone!",
        buttons: true,
        dangermode: true
    }).then((willdelete) => {  // make sure to use .then() instead of .than()
        if (willdelete) {
            $.ajax({
                url: url,
                type: "delete",
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);  // show success message
                        datatable.ajax.reload();  // reload datatable after successful deletion
                    } else {
                        toastr.error(data.message);  // show error message if deletion failed
                    }
                },
                error: function (err) {
                    toastr.error("error while deleting data.");
                }
            });
        }
    });
}
