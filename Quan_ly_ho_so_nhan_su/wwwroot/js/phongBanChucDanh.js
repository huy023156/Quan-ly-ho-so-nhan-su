var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    var id = $('#phongBanId').val();
    var url = `/PhongBanChucDanh/GetChucDanhList/${id}`;

    dataTable = $('#tblData').DataTable({
        "ajax": {
            url: url,
            error: function (xhr, error, thrown) {
                console.error(xhr.responseText);
                console.log(this.url);
                alert('Error loading data. Please check console for more details.');
            }
        },
        "columns": [
            {
                data: 'name',
                width: '80%'
            },
            {
                data: 'id',
                "render": function (data, type, row) {
                    return `<div class="w-100 btn-group ms-auto" role="group">
                                <a onClick="Delete('/PhongBanChucDanh/Delete/?phongBanId=${id}&chucDanhId=${data}')" class="btn btn-danger mx-2"><i class="bi bi-trash-fill"></i> Xóa</a>
                            </div>`;
                },
                width: '20%'
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: "Bạn chắc chứ?",
        text: "Chức danh sẽ bị loại bỏ khỏi phòng ban",
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