//$(function () {
//    var oTable = new TableInit();
//    oTable.Init();
//    oTable.queryParams();
//    //2.初始化Button的点击事件
//     //var queryParams = new queryParams();
//     //queryParams.Init();
//});
//var TableInit = function () {
//    var oTableInit = new Object();
//    //初始化Table
//    oTableInit.Init = function () {
//        $('#table-javascript').bootstrapTable({
//            url: 'sys/Module/GetData',     //请求后台的URL（*）
//            method: 'post',           //请求方式（*）
//            toolbar: '#toolbar',        //工具按钮用哪个容器
//            striped: true,           //是否显示行间隔色
//            cache: false,            //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
//            pagination: true,          //是否显示分页（*）
//            sortable: false,           //是否启用排序
//            sortOrder: "asc",          //排序方式
//            queryParams: oTableInit.queryParams,//传递参数（*）
//            sidePagination: "server",      //分页方式：client客户端分页，server服务端分页（*）
//            pageNumber: 1,            //初始化加载第一页，默认第一页
//            pageSize: 10,            //每页的记录行数（*）
//            pageList: [10, 25, 50, 100],    //可供选择的每页的行数（*）
//            strictSearch: true,
//            clickToSelect: true,        //是否启用点击选中行
//            height: tableHeight(),            //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
//            uniqueId: "ID",           //每一行的唯一标识，一般为主键列
//            cardView: false,          //是否显示详细视图
//            detailView: false,          //是否显示父子表
//            columns: [{
//                field: 'ID',
//                title: '序号',
//                sortable: true,
//            }, {
//                field: 'Name',
//                title: '交易编号'
//            }, {
//                field: 'Price',
//                title: '订单号'
//            }, {
//                field: 'person',
//                title: '交易时间',
//                formatter: 'infoFormatter'
//            }],
//            onClickRow: function (row, $element) {
//                //$element是当前tr的jquery对象
//                $element.css("background-color", "green");
//            },//单击row事件
//            locale: "zh-CN"//中文支持
//        });
//        oTableInit.queryParams = function (params)
//        {
//            return {
//                pageSize: params.pageSize,
//                pageIndex: params.pageNumber
//                //UserName: $("#txtName").val(),
//                //Birthday: $("#txtBirthday").val(),
//                //Gender: $("#Gender").val(),
//                //Address: $("#txtAddress").val(),
//               // name: params.sortName
//            }
//        }
//        //$("#addRecord").click(function () {
//        //    alert("name:" + $("#name").val() + " age:" + $("#age").val());
//        //});
//    };
//}

//    function tableHeight() {
//        return $(window).height() - 50;
//    }
//    /**
//     * 列的格式化函数 在数据从服务端返回装载前进行处理
//     * @param  {[type]} value [description]
//     * @param  {[type]} row   [description]
//     * @param  {[type]} index [description]
//     * @return {[type]}       [description]
//     */
//    function infoFormatter(value, row, index) {
//        return "id:" + row.id + " name:" + row.name + " age:" + row.person;
//    }
  
//                $("#checkall").on("ifChecked", function (event) {
//                    debugger;
//                    $('.icheck_box').iCheck('check');
//                });
//$("#checkall").on("ifUnchecked", function (event) {
//    debugger;
//    $(".icheck_box").iCheck("uncheck");
//});
    $("#checkall").on("click", function () {
        //第一种方法 全选全不选
        var flag = this.checked;
        //if(this.checked){
        //    $("input[name='check1']:checkbox").attr('checked', true);
        //} else {
        //    $("input[name='check1']:checkbox").attr('checked',false);
        //}
        //第二种方法 全选全不选
        //  $("[name='check1']:checkbox").attr("checked", this.checked);//checked为true时为默认显示的状态
        $("[name='check1']:checkbox").each(function () {
            this.checked = flag;
        });
        //$("[name='check1']:checkbox").each(function () {
        //    alter(this.checked);
        //});
    });
    //$("#checkrev").click(function(){
    //    //实现反选功能
    //    $('[name=check1]:checkbox').each(function(){
    //        this.checked=!this.checked;
    //    });
    //});
 

