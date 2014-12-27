var baseUrl;
var subDomain;

$(document).ready(function () {
    baseUrl = jQuery('#base-url').val();
    subDomain = jQuery('#sub-domain').val();
    var maNhanVien = $('#ma-nhan-vien').val();
    
    $('#tblThuNhapCaNhan').bootstrapTable({
        method: 'GET',
        url: baseUrl + 'Report/GetThuNhapCaNhan?ip_MaNhanVien=' + maNhanVien,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        height: 400,
        hover: true,
        pagination: true,
        pageSize: 50,
        pageList: [10, 25, 50, 100, 200],
        search: true,
        showColumns: true,
        showRefresh: true,
        minimumCountColumns: 2,
        clickToSelect: true,
        columns: [
            { field: 'LUONG', title: 'Lương', align: 'right', valign: 'middle', sortable: true, },
            { field: 'NGAY_AP_DUNG', title: 'Ngày', align: 'center', valign: 'middle', sortable: true, },
            { field: 'MA_QUYET_DINH', title: 'Mã quyết định', align: 'left', valign: 'middle', sortable: true },
            { field: 'NGAY_KY', title: 'Ngày ký', align: 'center', valign: 'middle', sortable: true }
            
            //{ field: 'LUONG_HIEN_TAI', title: 'Lương hiện tại', align: 'center', valign: 'middle', sortable: true },
            //{ field: 'MA_KY', title: 'Mã kỳ', align: 'center', valign: 'middle', sortable: true },
            //{ field: 'NGAY_BD_KY', title: 'Ngày bắt đầu kỳ', align: 'center', valign: 'middle', sortable: true },
            //{ field: 'NGAY_KT_KY', title: 'Ngày kết thúc kỳ', align: 'center', valign: 'middle', sortable: true },
            //{ field: 'LOAI_QUYET_DINH', title: 'Loại quyết định', align: 'center', valign: 'middle', sortable: true },
            //{ field: 'NGAY_CO_HIEU_LUC', title: 'Ngày có hiệu lực', align: 'center', valign: 'middle', sortable: true },
            //{ field: 'NOI_DUNG', title: 'Nội dung', align: 'center', valign: 'middle', sortable: true },
            //{ field: 'MA_SO_THUE', title: 'Mã số thuế', align: 'center', valign: 'middle', sortable: true },
        ]
    });

    $('#tblThuNhapCaNhan').bootstrapTable('refresh', {
        url: baseUrl + 'Report/GetThuNhapCaNhan?ip_MaNhanVien=' + maNhanVien,
    });
});