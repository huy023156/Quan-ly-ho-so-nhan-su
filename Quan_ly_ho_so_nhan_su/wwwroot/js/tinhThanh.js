var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: 'TinhThanh/GetAll' },
        "columns": [
            { data: 'name', width: '35%' },
            { data: 'quocGia.name', width: '15%' },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group ms-auto" role="group">
                                        <a href="/TinhThanh/Upsert?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i> Edit</a>
                                        <a onClick=Delete('/TinhThanh/Delete/${data}') class="btn btn-danger mx-2"><i class="bi bi-trash-fill"></i> Delete</a>
                                    </div>`;
                }
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: "Bạn chắc chứ?",
        text: "Tỉnh thành sẽ bị xóa vĩnh viễn!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Xóa"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    });
}