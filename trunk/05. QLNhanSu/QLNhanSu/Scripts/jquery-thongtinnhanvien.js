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
            LoadInforEmployee(maNhanVien);
            LoadInfoNhanVien(maNhanVien);
        }
    });
    
    window.fbAsyncInit = function () {
        FB.init({
            appId: '972954086052159', // App ID
            status: true, // check login status
            cookie: true, // enable cookies to allow the server to access the session
            xfbml: true  // parse XFBML
        });
        LoadInfoNhanVien($('#ma-nhan-vien').val());

        FB.Event.subscribe('auth.authResponseChange', function (response) {
            if (response.status === 'connected') {
                //document.getElementById("message").innerHTML += "<br>Connected to Facebook";
                //SUCCESS

            }
            else if (response.status === 'not_authorized') {
                //document.getElementById("message").innerHTML += "<br>Failed to Connect";

                //FAILED
            } else {
                //document.getElementById("message").innerHTML += "<br>Logged Out";

                //UNKNOWN ERROR
            }
        });
    };

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

function LoadInfoNhanVien(maNv) {
    $.ajax({
        type: 'GET',
        url: baseUrl + "/User/GetUserByMaNv",
        contentType: "application/json; chartset=utf-8",
        dataType: "json",
        async: false,
        data: { maNhanVien: maNv },
        beforeSend: function () {

        },
        success: function (json) {
            if (json != null) {
                if (json.MSBN == null || json.MSBN == "") {
                    $('#nameFb').html("");
                    $('#avatarFb').attr('src', "");
                    $('#btnAssignFb').css('display', '');
                } else {
                    FB.api(
                        "/" + json.MSBN + "/picture?type=normal", function (response) {
                            if (response && !response.error) {
                                var urlAvatar = response.data.url;
                                $('#avatarFb').attr('src', urlAvatar);
                            }
                        }
                    );
                    $('#nameFb').html(json.CMND);
                    $('#btnAssignFb').css('display', 'none');
                }
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            $('#nameFb').html("");
            $('#avatarFb').attr('src', "");
        }
    });
}

function Login() {

    FB.login(function (response) {
        if (response.authResponse) {
            getUserInfo(response.authResponse.accessToken);
        } else {
            console.log('User cancelled login or did not fully authorize.');
        }
    }, { scope: 'email,user_photos,user_videos' });

}

function getUserInfo(accessToken) {
    FB.api('/me', { "access_token": accessToken } , function (response) {        
        $.ajax({
            type: 'GET',
            url: baseUrl + "/User/UpdateIdFb",
            contentType: "application/json; chartset=utf-8",
            dataType: "json",
            async: false,
            data: { ip_MaNhanVien: $('#ma-nhan-vien').val(), ip_IdFb: response.id, ip_NameFb: response.name },
            beforeSend: function () {

            },
            success: function (jsonIdFb) {
                console.log(response);
                $('#nameFb').html(response.name);
                getPhoto();
                $('#btnAssignFb').css('display', 'none');
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(textStatus + ": " + errorThrown);
            }
        });
    });
}
function getPhoto() {
    FB.api('/me/picture?type=normal', function (response) {
        $('#avatarFb').attr('src', response.data.url);
    });

}
function Logout() {
    FB.logout(function () { document.location.reload(); });
}

// Load the SDK Asynchronously
(function (d) {
    var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement('script'); js.id = id; js.async = true;
    js.src = "//connect.facebook.net/vi_VN/all.js";
    ref.parentNode.insertBefore(js, ref);
}(document));