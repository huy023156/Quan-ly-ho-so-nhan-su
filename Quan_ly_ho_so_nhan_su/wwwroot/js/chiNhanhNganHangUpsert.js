$(document).ready(function () {
    $('#QuocGiaId').change(function () {
        var quocGiaId = $(this).val();
        if (quocGiaId) {
            $.ajax({
                url: '/diachiapi/GetTinhThanhListByQuocGiaId/' + quocGiaId,
                type: "GET",
                success: function (response) {
                    $('#TinhThanhId').empty().append($('<option>', {
                        value: '',
                        text: '--Select Tỉnh Thành--',
                        disabled: true,
                        selected: true
                    })).prop('disabled', false);
                    $('#QuanHuyenId').empty().append($('<option>', {
                        value: '',
                        text: '--Select Quận Huyện--',
                        disabled: true,
                        selected: true
                    })).prop('disabled', true);
                    $('#ChiNhanhNganHang_XaPhuongId').empty().append($('<option>', {
                        value: '',
                        text: '--Select Xã Phường--',
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
            $('#QuanHuyenId').empty().append($('<option>', {
                value: '',
                text: '--Select Quận Huyện--',
                disabled: true,
                selected: true
            })).prop('disabled', true);
            $('#ChiNhanhNganHang_XaPhuongId').empty().append($('<option>', {
                value: '',
                text: '--Select Xã Phường--',
                disabled: true,
                selected: true
            })).prop('disabled', true);
        }
    });

    $('#TinhThanhId').change(function () {
        var tinhThanhId = $(this).val();
        if (tinhThanhId) {
            $.ajax({
                url: '/diachiapi/GetQuanHuyenListByTinhThanhId/' + tinhThanhId,
                type: "GET",
                success: function (response) {
                    $('#QuanHuyenId').empty().append($('<option>', {
                        value: '',
                        text: '--Select Quận Huyện--',
                        disabled: true,
                        selected: true
                    })).prop('disabled', false);
                    $('#ChiNhanhNganHang_XaPhuongId').empty().append($('<option>', {
                        value: '',
                        text: '--Select Xã Phường--',
                        disabled: true,
                        selected: true
                    })).prop('disabled', true);
                    $.each(response.data, function (index, item) {
                        $('#QuanHuyenId').append($('<option>', {
                            value: item.id,
                            text: item.name
                        }));
                    });
                }
            });
        } else {
            $('#QuanHuyenId').empty().append($('<option>', {
                value: '',
                text: '--Select Quận Huyện--',
                disabled: true,
                selected: true
            })).prop('disabled', true);
            $('#ChiNhanhNganHang_XaPhuongId').empty().append($('<option>', {
                value: '',
                text: '--Select Xã Phường--',
                disabled: true,
                selected: true
            })).prop('disabled', true);
        }
    });

    $('#QuanHuyenId').change(function () {
        var quanHuyenId = $(this).val();
        if (quanHuyenId) {
            $.ajax({
                url: '/diachiapi/GetXaPhuongListByQuanHuyenId/' + quanHuyenId,
                type: "GET",
                success: function (response) {
                    $('#ChiNhanhNganHang_XaPhuongId').empty().append($('<option>', {
                        value: '',
                        text: '--Select Xã Phường--',
                        disabled: true,
                        selected: true
                    })).prop('disabled', false);
                    $.each(response.data, function (index, item) {
                        $('#ChiNhanhNganHang_XaPhuongId').append($('<option>', {
                            value: item.id,
                            text: item.name
                        }));
                    });
                }
            });
        } else {
            $('#ChiNhanhNganHang_XaPhuongId').empty().append($('<option>', {
                value: '',
                text: '--Select Xã Phường--',
                disabled: true,
                selected: true
            })).prop('disabled', true);
        }
    });
});