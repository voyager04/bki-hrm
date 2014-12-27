var baseUrl;
var subDomain;

$(document).ready(function () {
    baseUrl = jQuery('#base-url').val();
    subDomain = jQuery('#sub-domain').val();
    
    var userName = $('#v_UserName').val();
    var maNhanvien = $('#v_MaNhanVien').val();
    var idUserGroup = $('#v_IdUserGroup').val();

    $('#txtUserName').val(userName);
    $('#ID_USER_GROUP').val(idUserGroup);

    var nhanVien = [];
    $.ajax({
        type: "GET",
        url: baseUrl + "/User/GetAllNhanVien",
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
            SetValue2TextBox(nhanVien, maNhanvien);
            jQuery('.loading-ma-nhan-vien').html('');
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(textStatus + ": " + errorThrown);
        }
    });
});

function SetValue2TextBox(nhanVien, maNhanvien) {
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

        }
    });

    var selectNhanVien = $selectNhanVien[0].selectize;
    selectNhanVien.setValue([maNhanvien]);
    //selectNhanVien.disable();
}