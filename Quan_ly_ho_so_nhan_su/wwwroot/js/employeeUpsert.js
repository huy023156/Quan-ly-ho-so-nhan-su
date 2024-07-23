$(document).ready(function () {
	$('#QuocGiaId').change(function () {
		var quocGiaId = $(this).val();
		if (quocGiaId) {
			$.ajax({
				url: '/User/api/GetTinhThanhListByQuocGiaId/' + quocGiaId,
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
					$('#XaPhuongId').empty().append($('<option>', {
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
			$('#XaPhuongId').empty().append($('<option>', {
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
				url: '/User/api/GetQuanHuyenListByTinhThanhId/' + tinhThanhId,
				type: "GET",
				success: function (response) {
					$('#QuanHuyenId').empty().append($('<option>', {
						value: '',
						text: '--Select Quận Huyện--',
						disabled: true,
						selected: true
					})).prop('disabled', false);
					$('#XaPhuongId').empty().append($('<option>', {
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
			$('#XaPhuongId').empty().append($('<option>', {
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
				url: '/User/api/GetXaPhuongListByQuanHuyenId/' + quanHuyenId,
				type: "GET",
				success: function (response) {
					console.log(response); // Debug dữ liệu phản hồi
					$('#XaPhuongId').empty().append($('<option>', {
						value: '',
						text: '--Select Xã Phường--',
						disabled: true,
						selected: true
					})).prop('disabled', false);
					console.log($('#XaPhuongId').prop('disabled')); // Debug trạng thái disabled
					$.each(response.data, function (index, item) {
						$('#XaPhuongId').append($('<option>', {
							value: item.id,
							text: item.name
						}));
					});
				},
				error: function (xhr, status, error) {
					console.error("Error: " + status + " - " + error); // Debug lỗi
				}
			});
		} else {
			$('#XaPhuongId').empty().append($('<option>', {
				value: '',
				text: '--Select Xã Phường--',
				disabled: true,
				selected: true
			})).prop('disabled', true);
			console.log($('#XaPhuongId').prop('disabled')); // Debug trạng thái disabled
		}
	});

	$('#NganHangId').change(function () {
		var nganHangId = $(this).val();
		if (nganHangId) {
			$.ajax({
				url: '/User/api/GetChiNhanhListByNganHangId/' + nganHangId,
				type: "GET",
				success: function (response) {
					console.log(response); //
					$('#cnnh').empty().append($('<option>', {
						value: '',
						text: '--Select Chi Nhánh Ngân Hàng--',
						disabled: true,
						selected: true
					})).prop('disabled', false);
					$.each(response.data, function (index, item) {
						$('#cnnh').append($('<option>', {
							value: item.id,
							text: item.name
						}));
					});
				},
				error: function (xhr, status, error) {
					console.error("Error: " + status + " - " + error); // Debug lỗi
				}
			});
		} else {
			$('#cnnh').empty().append($('<option>', {
				value: '',
				text: '--Select Chi Nhánh Ngân Hàng--',
				disabled: true,
				selected: true
			})).prop('disabled', true);
		}
	});

	$('#pb').change(function () {
		var nganHangId = $(this).val();
		if (nganHangId) {
			$.ajax({
				url: '/User/api/GetChucDanhListByPhongBanId/' + nganHangId,
				type: "GET",
				success: function (response) {
					console.log(response); //
					$('#cc').empty().append($('<option>', {
						value: '',
						text: '--Select Phòng Ban--',
						disabled: true,
						selected: true
					})).prop('disabled', false);
					$.each(response.data, function (index, item) {
						$('#cc').append($('<option>', {
							value: item.id,
							text: item.name
						}));
					});
				},
				error: function (xhr, status, error) {
					console.error("Error: " + status + " - " + error); // Debug lỗi
				}
			});
		} else {
			$('#cc').empty().append($('<option>', {
				value: '',
				text: '--Select Phòng Ban--',
				disabled: true,
				selected: true
			})).prop('disabled', true);
		}
	});
});