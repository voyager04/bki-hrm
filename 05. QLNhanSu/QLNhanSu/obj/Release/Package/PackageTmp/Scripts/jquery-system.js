var baseUrl;
var subDomain;
var idUser = "";
$(document).ready(function () {
    baseUrl = jQuery('#base-url').val();
    subDomain = jQuery('#sub-domain').val();

    LoadTblDmPhanQuyenNhomNguoiDung();

    $('#btnEditAuthorize').click(function () {
        LoadUserGroup();
    });

    $('#btnSave').click(function () {
        $('#message').text("");
        var valUserGroup = $('#cbbUserGroup').val();
        $.ajax({
            type: 'GET',
            url: baseUrl + "/System/RemoveAuthorizeByUserGroup",
            contentType: "application/json; chartset=utf-8",
            dataType: "json",
            data: { idUserGroup: valUserGroup },
            beforeSend: function () {

            },
            success: function (jsonRemove) {
                if (jsonRemove == "Success") {
                    var authorizes = $('.ckbAuthorize:checked');
                    $.each(authorizes, function (index, item) {
                        var valAuthorize = $(item).val();
                        $.ajax({
                            type: 'GET',
                            url: baseUrl + "/System/InsertAuthorizeByUserGroup",
                            contentType: "application/json; chartset=utf-8",
                            dataType: "json",
                            data: { idAuthorize: valAuthorize, idUserGroup: valUserGroup },
                            beforeSend: function () {

                            },
                            success: function (jsonInsert) {
                                if (jsonInsert == "Success") {
                                    $('#message').text("Thay đổi quyền người dùng thành công");
                                }
                            },
                            error: function (xhr, textStatus, errorThrown) {
                                console.log(textStatus + ": " + errorThrown);
                            }
                        });
                    });
                }
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(textStatus + ": " + errorThrown);
            }
        });
    });
});

function LoadTblDmPhanQuyenNhomNguoiDung() {
    $('#tblDmPhanQuyenNhomNguoiDung').bootstrapTable({
        method: 'GET',
        url: baseUrl + '/System/GetAllAuthorize',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
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
            { field: 'UESR_GROUP', title: 'Nhóm người dùng', align: 'left', valign: 'middle', sortable: true },
            { field: 'CHUC_NANG_CON', title: 'Tên quyền', align: 'left', valign: 'left', sortable: true },
            { field: 'CHUC_NANG_CHA', title: 'Quyền cha', align: 'left', valign: 'middle', sortable: true }
        ]
    });
}

function LoadUserGroup() {
    $.ajax({
        type: 'GET',
        url: baseUrl + "/System/FindUserGroupIsAdmin",
        contentType: "application/json; chartset=utf-8",
        dataType: "json",
        beforeSend: function () {

        },
        success: function (json) {
            var result = "";
            $('#cbbUserGroup').html("");
            $.each(json, function (index, item) {
                result += "<option value='" + item.ID + "'>";
                result += item.USER_GROUP_NAME;
                result += "</option>";
            });
            $('#cbbUserGroup').html(result);
            idUser = $('#cbbUserGroup').val();
            LoadAuthorize();
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(textStatus + ": " + errorThrown);
        }
    });
}

function LoadAuthorize() {
    $.ajax({
        type: 'GET',
        url: baseUrl + "/System/FinAuthorizeIsAdmin",
        contentType: "application/json; chartset=utf-8",
        dataType: "json",
        beforeSend: function () {

        },
        success: function (json) {
            var result = "";
            $('#listAythorize').html("");
            $.each(json, function (index, item) {
                result += "<div class='checkbox'>";
                result += "<label>";
                result += "<input type='checkbox' class='ckbAuthorize' value='" + item.ID_CONTROLLER + "'>";
                result += item.CHUC_NANG_CON;
                result += "</label>";
                result += "</div>";
            });
            $('#listAythorize').html(result);
            CheckAuthorize();
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(textStatus + ": " + errorThrown);
        }
    });
}

function CheckAuthorize() {
    $.ajax({
        type: 'GET',
        url: baseUrl + "/System/FindAuthorizeByUserGroup",
        contentType: "application/json; chartset=utf-8",
        dataType: "json",
        async: false,
        data: { idUserGroup: idUser },
        beforeSend: function () {

        },
        success: function (json) {
            $.each(json, function (index, item) {
                var id = item.ID_CONTROLLER;
                $('input.ckbAuthorize').each(function (position, element) {
                    var valChk = $(element).attr("value");
                    if (valChk == id) {
                        //console.log($(element).attr("value"));
                        $(element).attr('checked', 'checked');
                    }
                });
            });
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(textStatus + ": " + errorThrown);
        }
    });
}