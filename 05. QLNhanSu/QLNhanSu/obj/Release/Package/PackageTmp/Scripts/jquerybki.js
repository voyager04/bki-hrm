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

    $.ajaxSetup({ cache: true });
    $.getScript('//connect.facebook.net/en_UK/all.js', function () {
        FB.init({
            appId: '972954086052159', // App ID
            status: true, // check login status
            cookie: true, // enable cookies to allow the server to access the session
            xfbml: true  // parse XFBML
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
                clickToSelect: true,
                columns: [
                    { field: 'MA_NV', title: 'Mã nhân viên', align: 'left', visible: false },
                    { field: 'HO_TEN', title: 'Họ tên', align: 'left', width: 200, valign : 'middle' },
                    { field: 'SDT', title: 'Di động', align: 'left', width: 150, valign: 'middle' },
                    { field: 'DIA_CHI', title: 'Địa bàn', align: 'left', width: 150, valign: 'middle' },
                    { field: 'EMAIL_CQ', title: 'Email', align: 'left', width: 150, valign: 'middle' },
                    { field: 'NGACH', title: 'Ngạch', align: 'center', width: 150, valign: 'middle' },
                    { field: 'MA_DON_VI', title: 'Mã đơn vị', align: 'center', width: 150, valign: 'middle' },
                    { field: 'AVATAR', title: 'Avatar', align: 'left', formatter: fbAvatarFormatter, width: 68, valign: 'middle' },
                    { field: 'TEN_FB', title: 'Facebook', align: 'left', formatter: fbNameFormatter, width: 200, valign: 'middle' }
                ]
            });

            $('#tblDonViDetails').bootstrapTable('refresh', {
                url: baseUrl + 'Report/GetNhanVienByPhongBan?ipMaDonVi=' + maDonVi,
            });

            $('#custem-toolbar-tblDonViDetails').html("<p class='title-table'>" + maDonVi + "</p>");
        });
    });

    $('#btn-search-nhan-vien').click(function() {
        jQuery('#tblDonViDetails > tbody').html('');
        var btn = $(this);
        var maDonVi = btn.attr('data-don-vi');
        var result = "";

        $('#tblDonViDetails').bootstrapTable({
            method: 'GET',
            url: baseUrl + 'Report/GetNhanVienByPhongBan',
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
            clickToSelect: true,
            columns: [
                { field: 'MA_NV', title: 'Mã nhân viên', align: 'left', visible: false },
                { field: 'HO_TEN', title: 'Họ tên', align: 'left', width: 200, valign: 'middle' },
                { field: 'SDT', title: 'Di động', align: 'left', width: 150, valign: 'middle' },
                { field: 'DIA_CHI', title: 'Địa bàn', align: 'left', width: 150, valign: 'middle' },
                { field: 'EMAIL_CQ', title: 'Email', align: 'left', width: 150, valign: 'middle' },
                { field: 'NGACH', title: 'Ngạch', align: 'center', width: 150, valign: 'middle' },
                { field: 'MA_DON_VI', title: 'Mã đơn vị', align: 'center', width: 150, valign: 'middle' },
                { field: 'AVATAR', title: 'Avatar', align: 'left', formatter: fbAvatarFormatter, width: 68, valign: 'middle' },
                { field: 'TEN_FB', title: 'Facebook', align: 'left', formatter: fbNameFormatter, width: 200, valign: 'middle' }
            ]
        });

        $('#tblDonViDetails').bootstrapTable('refresh', {
            url: baseUrl + 'Report/GetNhanVienByPhongBan',
        });

        $('#custem-toolbar-tblDonViDetails').html("<p class='title-table'>Tìm kiếm nhân viên</p>");
    });
});

function fbAvatarFormatter(value, row, index) {
    $.ajax({
        type: 'GET',
        url: baseUrl + "/User/GetUserByMaNv",
        contentType: "application/json; chartset=utf-8",
        dataType: "json",
        async: false,
        data: { maNhanVien: row.MA_NV },
        beforeSend: function () {

        },
        success: function (json) {
            if (json != null) {
                FB.api(
                    "/" + json.MSBN + "/picture", function (response) {
                        if (response && !response.error) {
                            var urlAvatar = response.data.url;
                            $('.avatar-fb-' + index).attr('src', urlAvatar);
                        }
                    }
                );
                
                FB.api(
                    "/" + json.MSBN, function (response) {
                        if (response && !response.error) {
                            $('.name-fb-' + index).html(response.name);
                        }
                    }
                );
            };
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(textStatus + ": " + errorThrown);
        }
    });
    return "<img class='avatar-fb-" + index + "' src='' />";
}

function fbNameFormatter(value, row, index) {
    $.ajax({
        type: 'GET',
        url: baseUrl + "/User/GetUserByMaNv",
        contentType: "application/json; chartset=utf-8",
        dataType: "json",
        async: false,
        data: { maNhanVien: row.MA_NV },
        beforeSend: function () {

        },
        success: function (json) {
            if (json != null) {
                FB.api(
                    "/" + json.MSBN, function (response) {
                        if (response && !response.error) {
                            $('.name-fb-' + index).html(response.name);
                        }
                    }
                );
            };
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(textStatus + ": " + errorThrown);
        }
    });
    return "<span class='name-fb-" + index + "'></span>";
}

// Load the SDK Asynchronously
(function (d) {
    var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement('script'); js.id = id; js.async = true;
    js.src = "//connect.facebook.net/vi_VN/all.js";
    ref.parentNode.insertBefore(js, ref);
}(document));