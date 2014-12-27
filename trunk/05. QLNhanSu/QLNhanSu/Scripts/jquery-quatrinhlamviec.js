var baseUrl;
var subDomain;

$(document).ready(function () {
    baseUrl = jQuery('#base-url').val();
    subDomain = jQuery('#sub-domain').val();
    
    var nhanVien = [];
    var strDieuKien = "";
    var maNhanVien = "";
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
            $('.lien-quan').attr('checked', 'checked');
            $.ajax({
                type: "GET",
                url: baseUrl + "/Report/GetQuaTrinhLamViec",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                data: { ip_MaNhanVien: value, ip_DieuKien: "ACD" },
                beforeSend: function (xhr) {
                    jQuery('.loading-data').html('Loading...');
                },
                success: function (json) {
                    var result = "";
                    jQuery.each(json, function (position, element) {
                        result += "<tr>";
                        result += "<td>" + element.TU_NGAY + "</td>";
                        result += "<td>" + element.DEN_NGAY + "</td>";
                        result += "<td>" + element.LAM_GI + "</td>";
                        result += "<td>" + element.O_DAU + "</td>";
                        result += "<td>" + element.VAI_TRO + "</td>";
                        result += "<td>" + element.TY_LE_THAM_GIA + "</td>";
                        result += "<td>" + element.MA_QUYET_DINH + "</td>";
                        result += "<td>" + element.LOAI_QD + "</td>";
                        result += "</tr>";
                    });
                    $('#tblQuaTrinhLamViecCaNhan > tbody').html(result);
                    jQuery('.loading-data').html('');
                },
                error: function (xhr, textStatus, errorThrown) {
                    console.log(textStatus + ": " + errorThrown);
                }
            });
        }
    });
    
    $('.lien-quan').click(function() {
        var checked = $('.lien-quan:checked');
        strDieuKien = "";
        $.each(checked, function(index, item) {
            strDieuKien += $(item).val();
        });
        $.ajax({
            type: "GET",
            url: baseUrl + "/Report/GetQuaTrinhLamViec",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            data: { ip_MaNhanVien: maNhanVien, ip_DieuKien: strDieuKien },
            beforeSend: function (xhr) {
                jQuery('.loading-data').html('Loading...');
            },
            success: function (json) {
                var result = "";
                jQuery.each(json, function (position, element) {
                    result += "<tr>";
                    result += "<td>" + element.TU_NGAY + "</td>";
                    result += "<td>" + element.DEN_NGAY + "</td>";
                    result += "<td>" + element.LAM_GI + "</td>";
                    result += "<td>" + element.O_DAU + "</td>";
                    result += "<td>" + element.VAI_TRO + "</td>";
                    result += "<td>" + element.TY_LE_THAM_GIA + "</td>";
                    result += "<td>" + element.MA_QUYET_DINH + "</td>";
                    result += "<td>" + element.LOAI_QD + "</td>";
                    result += "</tr>";
                });
                $('#tblQuaTrinhLamViecCaNhan > tbody').html(result);
                jQuery('.loading-data').html('');
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(textStatus + ": " + errorThrown);
            }
        });
    });
});