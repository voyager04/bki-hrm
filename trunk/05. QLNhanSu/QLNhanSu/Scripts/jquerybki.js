var baseUrl;
var subDomain;

$(document).ready(function () {
    baseUrl = jQuery('#base-url').val();
    subDomain = jQuery('#sub-domain').val();
    
    $('.treetable').treetable({ expandable: true });
    $('.treetable').treetable("expandAll", function () {});
    
    
    $('#modalDonViDetails').on('shown.bs.modal', function () {
        $(this).find('.modal-dialog').css({
            width: 'auto',
            height: 'auto',
            'max-height': '80%'
        });
    });

    $('.btnViewDetails').click(function() {
        var btn = $(this);
        var maDonVi = btn.attr('data-don-vi');
        var result = "";
        $.ajax({
            type: "GET",
            url: baseUrl + "Report/GetNhanVienByPhongBan",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: { ipMaDonVi: maDonVi },
            success: function (json) {
                jQuery.each(json, function(index, item) {
                    result += "<tr>";
                    result += "<td>" + item.MA_NHAN_VIEN + "</td>";
                    result += "<td>" + item.HO_DEM + "</td>";
                    result += "<td>" + item.TEN + "</td>";
                    result += "<td>" + item.TRANG_THAI_LD_HIEN_TAI + "</td>";
                    result += "<td>" + item.TEN_CHUC_VU + "</td>";
                    result += "<td>" + item.NGACH + "</td>";
                    result += "<td>" + item.LOAI_CHUC_VU + "</td>";
                    result += "<td>" + item.TRANG_THAI_CHUC_VU + "</td>";
                    result += "<td>" + item.NGAY_BAT_DAU_CHUC_VU + "</td>";
                    result += "<td>" + item.NGAY_KET_THUC_CHUC_VU + "</td>";
                    result += "<td>" + item.TY_LE_THAM_GIA + "</td>";
                    result += "<td>" + item.MA_QUYET_DINH + "</td>";
                    result += "<td>" + item.LOAI_QUYET_DINH + "</td>";
                    result += "<td>" + item.NGAY_BAT_DAU_QUYET_DINH + "</td>";
                    result += "<td>" + item.NGAY_KET_THUC_QUYET_DINH + "</td>";
                    result += "<td>" + item.MA_QUYET_DINH_MIEN_NHIEM + "</td>";
                    result += "</tr>";
                });
                jQuery('#tblDonViDetails > tbody').append(result);
                $('#tblDonViDetails').dataTable().columnFilter();
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(textStatus + ": " + errorThrown);
            }
        });
    });
});