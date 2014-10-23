var baseUrl;
var subDomain;

$(document).ready(function () {
    baseUrl = jQuery('#base-url').val();
    subDomain = jQuery('#sub-domain').val();
    var maNhanVien = $('#ma-nhan-vien').val();
    
    $.ajax({
        type: "GET",
        url: baseUrl + "/Report/GetThongTinNhanVien",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        data: { ip_MaNhanVien: maNhanVien },
        beforeSend: function (xhr) {
            //jQuery('.loading-ma-nhan-vien').html('Loading...');
        },
        success: function (json) {
            console.log(json);
            $('#lblHoTen').text(json.HO_TEN);
            $('#lblGioiTinh').text(json.GIOI_TINH);
            $('#lblNgaySinh').text(json.NGAY_SINH);
            $('#lblNoiSinh').text(json.NOI_SINH);
            $('#lblNguyenQuan').text(json.NGUYEN_QUAN);
            $('#lblHoKhau').text(json.DK_HO_KHAU);
            $('#lblDcThuongTru').text(json.DIA_CHI);
            $('#lblCMTND').text(json.CMTND);
            $('#lblNgayCap').text(json.NGAY_CAP);
            $('#lblNoiCap').val(json.NOI_CAP);
            $('#lblMaSoThue').text(json.MA_SO_THUE);
            $('#lblDTDD').text(json.DTDD);
            $('#lblDTNhaRieng').text(json.DT_NHA_RIENG);
            $('#lblEmailCoQuan').text(json.EMAIL_CO_QUAN);
            $('#lblEmailCaNhan').text(json.EMAIL_CA_NHAN);
            $('#lblTrangThaiLaoDong').text(json.TRANG_THAI_LAO_DONG);
            //jQuery('.loading-ma-nhan-vien').html('');
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(textStatus + ": " + errorThrown);
        }
    });

    $('#tblChucVuNhanVien').bootstrapTable({
        method: 'GET',
        url: baseUrl + 'Report/GetThongTinNhanVien?ip_MaNhanVien=' + maNhanVien,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        height: 400,
        hover: true,
        search: true,
        showColumns: true,
        showRefresh: true,
        minimumCountColumns: 2,
        clickToSelect: true,
        columns: [
            { field: 'LIST_CHUC_VU.TU_NGAY', title: 'Từ ngày', align: 'right', valign: 'middle', sortable: true, },
            { field: 'LIST_CHUC_VU.DEN_NGAY', title: 'Đến ngày', align: 'left', valign: 'middle', sortable: true, },
            { field: 'LIST_CHUC_VU.MA_CHUC_VU', title: 'Mã chức vụ', align: 'center', valign: 'middle', sortable: true },
            { field: 'LIST_CHUC_VU.TEN_CHUC_VU', title: 'Tên chức vụ', align: 'center', valign: 'middle', sortable: true },
            { field: 'LIST_CHUC_VU.TRANG_THAI_CHUC_VU', title: 'Trạng thái chức vụ', align: 'center', valign: 'middle', sortable: true },
            { field: 'LIST_CHUC_VU.TY_LE_THAM_GIA', title: 'Tỷ lệ tham gia', align: 'center', valign: 'middle', sortable: true },
            { field: 'LIST_CHUC_VU.MA_DON_VI', title: 'Mã đơn vị', align: 'center', valign: 'middle', sortable: true },
            { field: 'LIST_CHUC_VU.TEN_DON_VI', title: 'Tên đơn vị', align: 'center', valign: 'middle', sortable: true },
            { field: 'LIST_CHUC_VU.CAP_DON_VI', title: 'Cấp đơn vị', align: 'center', valign: 'middle', sortable: true },
            { field: 'LIST_CHUC_VU.MA_QUYET_DINH', title: 'Mã quyết định', align: 'center', valign: 'middle', sortable: true },
            { field: 'LIST_CHUC_VU.NGAY_CO_HIEU_LUC', title: 'Ngày có hiệu lực', align: 'center', valign: 'middle', sortable: true },
            { field: 'LIST_CHUC_VU.NGAY_HET_HIEU_LUC', title: 'Ngày hết hiệu lực', align: 'center', valign: 'middle', sortable: true },
        ]
    });

    $('#tblChucVuNhanVien').bootstrapTable('refresh', {
        url: baseUrl + 'Report/GetThongTinNhanVien?ip_MaNhanVien=' + maNhanVien,
    });
});