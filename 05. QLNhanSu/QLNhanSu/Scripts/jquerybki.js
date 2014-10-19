var baseUrl;
var subDomain;

$(document).ready(function () {
    baseUrl = jQuery('#base-url').val();
    subDomain = jQuery('#sub-domain').val();

    $('.treetable').treetable({ expandable: true });
    $('.treetable').treetable("expandAll", function () { });

    $('#modalDonViDetails').on('shown.bs.modal', function () {
        $(this).find('.modal-dialog').css({
            width: 'auto',
            height: 'auto',
            'max-height': '100%'
        });
    });

    $('.btnViewDetails').click(function () {
        jQuery('#tblDonViDetails > tbody').html('');
        var btn = $(this);
        var maDonVi = btn.attr('data-don-vi');
        var result = "";

        $('#tblDonViDetails').bootstrapTable({
            method: 'GET',
            url: baseUrl + 'Report/GetNhanVienByPhongBan?ipMaDonVi=' + maDonVi,
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
                { field: 'MA_NHAN_VIEN', title: 'Mã nhân viên', align: 'left', valign: 'middle', sortable: true },
                { field: 'HO_DEM', title: 'Họ đệm', align: 'right', valign: 'middle', sortable: true, },
                { field: 'TEN', title: 'Tên', align: 'left', valign: 'middle', sortable: true, },
                { field: 'TRANG_THAI_LD_HIEN_TAI', title: 'Trạng thái lao động', align: 'center', valign: 'middle', sortable: true },
                { field: 'TEN_CHUC_VU', title: 'Tên chức vụ', align: 'center', valign: 'middle', sortable: true },
                { field: 'NGACH', title: 'Ngạch', align: 'center', valign: 'middle', sortable: true },
                { field: 'LOAI_CHUC_VU', title: 'Loại chức vụ', align: 'center', valign: 'middle', sortable: true },
                { field: 'TRANG_THAI_CHUC_VU', title: 'Trạng thái chức vụ', align: 'center', valign: 'middle', sortable: true },
                { field: 'NGAY_BAT_DAU_CHUC_VU', title: 'Ngày bắt đầu CV', align: 'center', valign: 'middle', sortable: true },
                { field: 'NGAY_KET_THUC_CHUC_VU', title: 'Ngày kết thúc CV', align: 'center', valign: 'middle', sortable: true },
                { field: 'TY_LE_THAM_GIA', title: 'Tỷ lệ tham gia', align: 'center', valign: 'middle', sortable: true },
                { field: 'MA_QUYET_DINH', title: 'Mã quyết định', align: 'center', valign: 'middle', sortable: true },
                { field: 'LOAI_QUYET_DINH', title: 'Loại quyết định', align: 'center', valign: 'middle', sortable: true },
                { field: 'NGAY_BAT_DAU_QUYET_DINH', title: 'Ngày bất đầu', align: 'center', valign: 'middle', sortable: true },
                { field: 'NGAY_KET_THUC_QUYET_DINH', title: 'Ngày kết thúc', align: 'center', valign: 'middle', sortable: true },
                { field: 'MA_QUYET_DINH_MIEN_NHIEM', title: 'Mã quyết định miễn nhiệm', align: 'center', valign: 'middle', sortable: true }
            ]
        });

        $('#tblDonViDetails').bootstrapTable('refresh', {
            url: baseUrl + 'Report/GetNhanVienByPhongBan?ipMaDonVi=' + maDonVi,
        });
        
        $('#custem-toolbar-tblDonViDetails').html("<p class='title-table'>" + maDonVi + "</p>");
    });
});