$(document).ready(function () {
    $('#QuocGiaId').change(function () {
        var quocGiaId = $(this).val();
        if (quocGiaId) {
            $.ajax({
                url: '/api/GetTinhThanhListByQuocGiaId/' + quocGiaId,
                type: "GET",
                success: function (response) {
                    $('#QuanHuyen_TinhThanhId').empty().append($('<option>', {
                        value: '',
                        text: '--Select Tỉnh Thành--',
                        disabled: true,
                        selected: true
                    })).prop('disabled', false);
                    $.each(response.data, function (index, item) {
                        $('#QuanHuyen_TinhThanhId').append($('<option>', {
                            value: item.id,
                            text: item.name
                        }));
                    });
                }
            });
        } else {
            $('#QuanHuyen_TinhThanhId').empty().append($('<option>', {
                value: '',
                text: '--Select Tỉnh Thành--',
                disabled: true,
                selected: true
            })).prop('disabled', true);
        }
    });
});