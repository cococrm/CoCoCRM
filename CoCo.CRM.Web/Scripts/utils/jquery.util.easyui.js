﻿(function ($) {
    $.easyui = (function () {
        return {
            //显示全屏加载进度条
            showLoading: function () {
                var $body = $("body");
                $("<div id=\"div_loading\" class=\"datagrid-mask\"></div>").css({ zIndex: "99998", display: "block" }).appendTo($body);
                $("<div id=\"div_loading_msg\" class=\"datagrid-mask-msg\"></div>").html("处理中，请稍候...").appendTo($body).css({ zIndex: "99999", display: "block", left: "50%", fontSize: "12px" });
            },
            //移除全屏加载进度条
            removeLoading: function () {
                $("#div_loading").remove();
                $("#div_loading_msg").remove();
            },
            //添加IframeTabs
            addIframeToTabs: function (tabsId, title, url, icon, closable) {
                ///	<summary>
                ///	为tabs添加iframe选项卡
                ///	</summary>
                ///	<param name="tabsId" type="String">
                ///	选项卡Id
                ///	</param>
                ///	<param name="title" type="String">
                ///	标题，可以重复
                ///	</param>
                ///	<param name="url" type="String">
                ///	网址,必须唯一
                ///	</param>
                ///	<param name="icon" type="String">
                ///	图标class
                ///	</param>
                ///	<param name="closable" type="Bool">
                ///	是否允许关闭
                ///	</param>
                if (!title && !url)
                    return;
                var tabs = $('#' + tabsId);
                var index;
                var iframe = null;
                if (!exists())
                    createTab();
                selectTab();

                //判断选项卡是否存在,根据url进行判断
                function exists() {
                    var allTabs = tabs.tabs("tabs");
                    for (index = 0; index < allTabs.length; index++) {
                        iframe = allTabs[index].find('iframe');
                        if (iframe.length == 0)
                            continue;
                        if ($.getUrlPath(iframe[0].src) === url)
                            return true;
                    }
                    return false;
                }

                //创建选项卡
                function createTab() {
                    $.easyui.showLoading();
                    addTab();
                    removeLoading();

                    //添加选项卡
                    function addTab() {
                        var content = '<div class="easyui-layout" data-options="fit:true"><iframe scrolling="no" frameborder="0"  src="' + url + '" style="width:100%;height:100%;"></iframe><div>';
                        tabs.tabs('add', {
                            title: title,
                            closable: closable,
                            content: content,
                            iconCls: icon,
                            selected: 0
                        });
                    }

                    //关闭进度条
                    function removeLoading() {
                        var tab = tabs.tabs("getTab", index);
                        iframe = tab.find('iframe');
                        $(iframe).bind({
                            load: function () {
                                $.easyui.removeLoading();
                            },
                            error: function () {
                                $.easyui.removeLoading();
                            }
                        });
                    }
                }

                //选中选项卡
                function selectTab() {
                    tabs.tabs('select', index);
                }
            },
            refreshTabs: function (tabsId) {
                ///	<summary>
                ///	刷新选项卡
                ///	</summary>
                ///	<param name="tabsId" type="String">
                ///	选项卡Id
                ///	</param>
                var tabs = $('#' + tabsId);
                var tab = tabs.tabs('getSelected');
                var iframe = tab.find('iframe');
                if (iframe.length == 0)
                    return;
                iframe[0].contentWindow.location.href = iframe[0].contentWindow.location.href;
            },
            showMenu: function (menuId, e) {
                ///	<summary>
                ///	显示上下文菜单
                ///	</summary>
                ///	<param name="menuId" type="String">
                ///	上下文菜单Id
                ///	</param>
                ///	<param name="e" type="Event">
                ///	事件
                ///	</param>
                e.preventDefault();
                var menu = menuId;
                if (!$.isObject(menu))
                    menu = $('#' + menuId);
                menu.menu('show', {
                    left: e.pageX,
                    top: e.pageY
                });
                return menu;
            }
        };
    })();
})(jQuery);