(function ($) {
    $.easyui.treegrid = (function () {
        return {
            //添加并编辑
            addRow: function (gridId) {
                var grid = $("#" + gridId);
                var row = { ID: $.newGuid('-'), MenuName: "", MenuCode: "", ParentId: $.newEmptyGuid() };
                grid.treegrid('append', { parent: '', data: [row] });
                grid.treegrid('select', row.ID);
                $.easyui.treegrid.edit(gridId);
            },
            //编辑行
            edit: function (gridId) {
                var grid = $("#" + gridId);
                var row = grid.treegrid('getSelected');
                if (!row) {
                    $.easyui.warn("请选择待编辑的记录！");
                    return;
                }
                grid.treegrid('beginEdit', row.ID);
            },
            //取消编辑
            cancel: function (gridId) {
                var grid = $("#" + gridId);
                var row = grid.treegrid('getSelected');
                if (!row) {
                    return;
                }
                grid.treegrid('cancelEdit', row.ID);
            },
            //删除节点
            remove: function (gridId) {
                var grid = $("#" + gridId);
                var row = grid.treegrid('getSelected');
                if (!row) {
                    $.easyui.warn("请选择待删除的记录！");
                    return;
                }
                grid.treegrid('remove', row.ID);
            },
            //刷新
            refresh: function (gridId) {
                var grid = $("#" + gridId);
                grid.treegrid('reload');
            }
        };
    })();
})(jQuery);