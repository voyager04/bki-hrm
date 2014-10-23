var baseUrl;
var subDomain;

$(document).ready(function () {
    baseUrl = jQuery('#base-url').val();
    subDomain = jQuery('#sub-domain').val();
    var maNhanVien = $('#ma-nhan-vien').val();
    
    LoadInforEmployee(maNhanVien);

    var nhanVien = [];
    $.ajax({
        type: "GET",
        url: baseUrl + "/HeThong/GetAllNhanVien",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        data: {},
        beforeSend: function (xhr) {
            jQuery('.loading-ma-nhan-vien').html('Loading...');
        },
        success: function (json) {
            jQuery.each(json, function (index, item) {
                nhanVien.push({
                    id: item.ID,
                    maNhanVien: item.MA_NHAN_VIEN,
                    hoTen: item.HO_DEM + ' ' + item.TEN,
                    chucVu: item.MA_CHUC_VU,
                    donVi: item.MA_DON_VI
                });
            });
            jQuery('.loading-ma-nhan-vien').html('');
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(textStatus + ": " + errorThrown);
        }
    });

    var $selectNhanVien = $('#txtMaNhanVien').selectize({
        maxItems: 1,
        maxOptions: 100,
        valueField: 'maNhanVien',
        labelField: 'hoTen',
        searchField: 'hoTen',
        options: nhanVien,
        create: false,
        render: {
            option: function (item, escape) {
                var result = "";
                result += "<div>";
                result += "<span class='glyphicon glyphicon-user'></span> " + escape(item.hoTen);
                result += "<p><span>" + item.maNhanVien + " - " + item.chucVu + " - " + item.donVi + "</span></p>";
                result += "</div>";
                return result;
            }
        },
        onChange: function (value, item) {
            maNhanVien = value;
            LoadInforEmployee(maNhanVien);
        }
    });
});

function LoadInforEmployee(maNhanVien) {
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
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(textStatus + ": " + errorThrown);
        }
    });

    $('#tblChucVuNhanVien').bootstrapTable({
        method: 'GET',
        url: baseUrl + 'Report/GetChucVuNhanVien?ip_MaNhanVien=' + maNhanVien,
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
            { field: 'TU_NGAY', title: 'Từ ngày', align: 'right', valign: 'middle', sortable: true, },
            { field: 'DEN_NGAY', title: 'Đến ngày', align: 'left', valign: 'middle', sortable: true, },
            { field: 'MA_CHUC_VU', title: 'Mã chức vụ', align: 'center', valign: 'middle', sortable: true },
            { field: 'TEN_CHUC_VU', title: 'Tên chức vụ', align: 'center', valign: 'middle', sortable: true },
            { field: 'TRANG_THAI_CHUC_VU', title: 'Trạng thái chức vụ', align: 'center', valign: 'middle', sortable: true },
            { field: 'TY_LE_THAM_GIA', title: 'Tỷ lệ tham gia', align: 'center', valign: 'middle', sortable: true },
            { field: 'MA_DON_VI', title: 'Mã đơn vị', align: 'center', valign: 'middle', sortable: true },
            { field: 'TEN_DON_VI', title: 'Tên đơn vị', align: 'center', valign: 'middle', sortable: true },
            { field: 'CAP_DON_VI', title: 'Cấp đơn vị', align: 'center', valign: 'middle', sortable: true },
            { field: 'MA_QUYET_DINH', title: 'Mã quyết định', align: 'center', valign: 'middle', sortable: true },
            { field: 'NGAY_CO_HIEU_LUC', title: 'Ngày có hiệu lực', align: 'center', valign: 'middle', sortable: true },
            { field: 'NGAY_HET_HIEU_LUC', title: 'Ngày hết hiệu lực', align: 'center', valign: 'middle', sortable: true },
        ]
    });

    $('#tblChucVuNhanVien').bootstrapTable('refresh', {
        url: baseUrl + 'Report/GetChucVuNhanVien?ip_MaNhanVien=' + maNhanVien,
    });
}