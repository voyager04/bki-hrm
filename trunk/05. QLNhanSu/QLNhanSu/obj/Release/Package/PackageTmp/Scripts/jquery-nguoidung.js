var baseUrl;
var subDomain;

$(document).ready(function () {
    baseUrl = jQuery('#base-url').val();
    subDomain = jQuery('#sub-domain').val();
    
    $('#tblDanhMucNhanVien').bootstrapTable({
        method: 'GET',
        url: baseUrl + '/User/GetAllUser',
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
            { field: 'MA_NHAN_VIEN', title: 'Mã nhân viên', align: 'left', valign: 'middle', sortable: true },
            { field: 'USERNAME', title: 'Tên đăng nhập', align: 'left', valign: 'middle', sortable: true },
            { field: 'ID_FB', title: 'Facebook', align: 'left', valign: 'middle', sortable: true },
            { field: 'AVATAR', title: 'Avatar', align: 'center', valign: 'middle', formatter: displayAvatar, sortable: true },
            //{ field: 'HO', title: 'Họ đệm', align: 'right', valign: 'left', sortable: true, },
            //{ field: 'TEN', title: 'Tên', align: 'left', valign: 'left', sortable: true, },
            { field: 'USER_GROUP', title: 'Nhóm người dùng', align: 'left', valign: 'middle', sortable: true },
            { field: 'CONTROL', title: 'Thao tác', align: 'center', valign: 'middle', formatter: operateFormatter, events: operateEvents, clickToSelect: false }
        ]
    });
    
    var nhanVien = [];
    $.ajax({
        type: "GET",
        url: baseUrl + "/User/GetAllNhanVien/",
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

    $('#txtMaNhanVien').selectize({
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
        onChange: function(value, item) {
            
        }
    });
});

function operateFormatter(value, row, index) {
    return [
        '<a class="edit ml10" href="' + baseUrl + '/User/F203_Update/' + row.ID + '" title="Edit">',
            '<i class="glyphicon glyphicon-edit"></i>',
        '</a>&nbsp;&nbsp;',
        '<a class="remove ml10" href="" title="Remove">',
            '<i class="glyphicon glyphicon-remove"></i>',
        '</a>'
    ].join('');
}

function displayAvatar(value, row, index) {
    return '<img src="' + row.AVATAR + '">';
}

window.operateEvents = {
    'click .edit': function (e, value, row, index) {
        //alert('You click edit icon, row: ' + JSON.stringify(row) + value);
        //console.log(value, row, index);
    },
    'click .remove': function (e, value, row, index) {
        if (confirm("Bạn có chắc chắn muốn xóa người dùng?")) {
            $.ajax({
                type: "GET",
                url: baseUrl + "/User/F204_Remove",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                data: { id: row.ID },
                beforeSend: function (xhr) {
                    
                },
                success: function (json) {
                    alert('Xóa thành công');
                },
                error: function (xhr, textStatus, errorThrown) {
                    console.log(textStatus + ": " + errorThrown);
                }
            });
        }
        //alert('You click remove icon, row: ' + JSON.stringify(row));
        //console.log(value, row, index);
    }
};