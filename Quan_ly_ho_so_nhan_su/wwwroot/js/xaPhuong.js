var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: 'XaPhuong/GetAll' },
        "columns": [
            { data: 'name', width: '25%' },
            { data: 'quanHuyen.name', width: '15%' },
            {
                data: 'isApplied',
                "render": function (data) {
                    return data ? 'Đang áp dụng' : 'Không áp dụng';
                },
                width: '10%'
            },
            {
                data: 'id',
                "render": function (data, type, row) {
                    return `<div class="w-100 btn-group ms-auto btn-group-equal" role="group">
                                <a href="/XaPhuong/Upsert?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i> Sửa</a>
                                <a onClick="Delete('/XaPhuong/Delete/${data}')" class="btn btn-danger mx-2"><i class="bi bi-trash-fill"></i> Xóa</a>
                                <a onClick="ToggleApply(${data}, ${row.isApplied})" class="btn btn-${row.isApplied ? 'warning' : 'success'} mx-2">
                                    <i class="bi bi-${row.isApplied ? 'x-circle' : 'check-circle'}"></i> ${row.isApplied ? 'Ngừng áp dụng' : 'Áp dụng'}
                                </a>
                            </div>`;
                },
                width: '40%'
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: "Bạn chắc chứ?",
        text: "Xã phường sẽ bị xóa vĩnh viễn!",
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


function ToggleApply(id, isApplied) {
    Swal.fire({
        title: isApplied ? "Ngừng áp dụng?" : "Áp dụng?",
        text: isApplied ? "Xã phường sẽ ngừng áp dụng." : "Xã phường sẽ được áp dụng.",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: isApplied ? "Ngừng áp dụng" : "Áp dụng"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: '/XaPhuong/ToggleApply',
                type: 'POST',
                data: { id: id },
                success: function (data) {
                    console.log("AJAX success:", data); // Debug log
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                },
                error: function (xhr, status, error) {
                    console.error("AJAX error:", status, error); // Debug log
                    toastr.error("Thay đổi trạng thái không thành công");
                }
            });
        }
    });
}