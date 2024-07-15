$(document).ready(function () {
    $('#QuocGiaId').change(function () {
        var quocGiaId = $(this).val();
        if (quocGiaId) {
            $.ajax({
                url: '/api/GetTinhThanhListByQuocGiaId/' + quocGiaId,
                type: "GET",
                success: function (response) {
                    $('#TinhThanhId').empty().append($('<option>', {
                        value: '',
                        text: '--Select Tỉnh Thành--',
                        disabled: true,
                        selected: true
                    })).prop('disabled', false);
                    $('#XaPhuong_QuanHuyenId').empty().append($('<option>', {
                        value: '',
                        text: '--Select Quận Huyện--',
                        disabled: true,
                        selected: true
                    })).prop('disabled', true);
                    $.each(response.data, function (index, item) {
                        $('#TinhThanhId').append($('<option>', {
                            value: item.id,
                            text: item.name
                        }));
                    });
                }
            });
        } else {
            $('#TinhThanhId').empty().append($('<option>', {
                value: '',
                text: '--Select Tỉnh Thành--',
                disabled: true,
                selected: true
            })).prop('disabled', true);
            $('#XaPhuong_QuanHuyenId').empty().append($('<option>', {
                value: '',
                text: '--Select Quận Huyện--',
                disabled: true,
                selected: true
            })).prop('disabled', true);
        }
    });

    $('#TinhThanhId').change(function () {
        var tinhThanhId = $(this).val();
        if (tinhThanhId) {
            $.ajax({
                url: '/api/GetQuanHuyenListByTinhThanhId/' + tinhThanhId,
                type: "GET",
                success: function (response) {
                    $('#XaPhuong_QuanHuyenId').empty().append($('<option>', {
                        value: '',
                        text: '--Select Quận Huyện--',
                        disabled: true,
                        selected: true
                    })).prop('disabled', false);
                    $.each(response.data, function (index, item) {
                        $('#XaPhuong_QuanHuyenId').append($('<option>', {
                            value: item.id,
                            text: item.name
                        }));
                    });
                }
            });
        } else {
            $('#XaPhuong_QuanHuyenId').empty().append($('<option>', {
                value: '',
                text: '--Select Quận Huyện--',
                disabled: true,
                selected: true
            })).prop('disabled', true);
        }
    });
});