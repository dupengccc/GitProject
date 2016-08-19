$("#checkall").on("click", function () {
    var flag = this.checked;
    $("[name='check1']:checkbox").each(function () {
        this.checked = flag;
    });
});

function VaildataPermission(v)
{
    var permissionlist = v;
    if (permissionlist != "" && permissionlist != undefined)
    {
        var permission = "";
        $.each(permissionlist, function (p, t) {
            permission += t.PERVALUE + ",";
        });
        permission = permission.toLowerCase();
        $(".ibox a[action]").each(function () {
            var action = $(this).attr("action");
            if (permission.indexOf(action.toLowerCase() + ",")<0)
            {
                $(this).remove();
            }

            if (permission.indexOf(action.toLowerCase() + ",") < 0) {
                $(this).remove();
            }
        })

        $(".ibox a[listaction]").each(function () {
            var listaction = $(this).attr("listaction");
            if (permission.indexOf(listaction.toLowerCase() + ",") < 0) {
                $(this).remove();
            }
        })

    }
}