(function ($) {
    $.easyui.treegrid = (function () {
        editIndex = undefined;
        return {
            //判断编辑
            endEditing: function (gridId) {
                if (editIndex == undefined) {
                    return true;
                }
                var grid = $("#" + gridId);
                if (grid.treegrid('validateRow', editIndex)) {
                    grid.treegrid('endEdit', editIndex);
                    editIndex = undefined;
                    return true;
                } else {
                    return false;
                }
            },
            //添加并编辑
            addRow: function (gridId) {
                if ($.easyui.treegrid.endEditing(gridId)) {
                    var grid = $("#" + gridId);
                    var row = { ID: $.newGuid('-'), MenuName: "", MenuCode: "", ParentId: $.newEmptyGuid() };
                    grid.treegrid('append', { parent: '', data: [row], isNewRecord: true });
                    grid.treegrid('select', row.ID);
                    $.easyui.treegrid.edit(gridId);
                }
            },
            //编辑行
            edit: function (gridId) {
                var grid = $("#" + gridId);
                var row = grid.treegrid('getSelected');
                if (!row) {
                    $.easyui.warn("请选择待编辑的记录！");
                    return;
                }
                if (editIndex != row.ID) {
                    if ($.easyui.treegrid.endEditing(gridId)) {
                        editIndex = row.ID;
                        grid.treegrid('selectRow', editIndex);
                        grid.treegrid('beginEdit', editIndex);
                        alert(row.isNewRecord);
                    } else {
                        grid.treegrid('selectRow', editIndex);
                    }
                }
            },
            //取消编辑
            cancel: function (gridId) {
                if (editIndex == undefined) { return; }
                var grid = $("#" + gridId);
                grid.treegrid('cancelEdit', editIndex);
                //grid.datagrid('rejectChanges');
                editIndex = undefined;
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