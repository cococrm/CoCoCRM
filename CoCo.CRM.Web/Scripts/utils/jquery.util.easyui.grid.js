(function ($) {
    $.easyui.treegrid = (function () {
        return {
            //编辑行
            edit: function (gridId) {
                var grid = $("#" + gridId);
                var row = grid.treegrid('getSelected');
                if (row) {
                    grid.treegrid('beginEdit', row.ID);
                }
            },
            //取消编辑
            cancel: function (gridId) {
                var grid = $("#" + gridId);
                var row = grid.treegrid('getSelected');
                if (row) {
                    grid.treegrid('cancelEdit', row.ID);
                }
            }
        };
    })();
})(jQuery);