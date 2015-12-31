//by:xcl @2012-10-24
//请求成功后需要返回的数据:{"msg":"提示信息","isReload":"为1则需要刷新，否则只显示提示信息不刷新页面"}
; (function ($) {
    $.extend({
        XCLGoAjax: function (options) {
            options = $.extend({}, funs.Defaults, options);
            funs.Init(options);
        }
    });
    var funs = {
        Defaults: {
            obj: null, //指定对象
            type: "POST", // post或get
            data: null, //数据
            url: null, //url
            isLockBtn: true, //为true则disabled对象obj
            isRefreshSelf: false, // 为true刷新当前页面页不是父页面
            successFunction: null, //请求成功后执行的函数
            afterSuccessFunction:null,//执行默认的成功函数后要执行的内容
            isAlertShowMsg: false, //true:以alert的方式弹出消息，点确定或关闭执行刷新或其它函数。false:以tips弹出消息
            beforeSendMsg: "", //请求前要提示的信息
            refreshFromCache: true//请求完成后，若要刷新页面，是否从缓存中刷新
        },
        Init: function (options) {
            if(options.url==null){
                options.url=$(options.obj).closest("form").attr("action");
            }

            var oldValue=$(options.obj).text();//按钮的原始文字
            oldValue=(oldValue=="")?"保存":oldValue;

            if (options.data == null) {
                options.data = $(options.obj).closest("form").serialize();
            }
            if (options.beforeSendMsg != "") {//写在$.ajax中时，当网络不好时，可能会卡
                art.dialog.tips(options.beforeSendMsg, 500000);
            }
            if (options.isLockBtn) {
                $(options.obj).text("提交中...").prop({ "disabled":true });
            }
            $.ajax({
                type: options.type,
                data: options.data,
                dataType: "JSON",
                url: options.url,
                error: function () {
                    art.dialog.tips("抱歉，出错啦！请稍后再试！");
                    if (options.isLockBtn) {
                        $(options.obj).text(oldValue).prop({"disabled":false});
                    }
                },
                success: function (data) {

                    var data = data[XCLShouCang.XCLJsonMessageName];

                    if (null != options.successFunction) {
                        options.successFunction(data);
                        if(null!=options.afterSuccessFunction){
                            options.afterSuccessFunction(data);
                        }
                        return;
                    }
                    if (options.isLockBtn) {
                        //延迟2秒，防止点击过快
                        setTimeout(function () {
                            $(options.obj).text(oldValue).prop({"disabled":false});
                        }, 1000);
                    }
                    if (data.Message != "") {
                        if (options.isAlertShowMsg) {
                            var list = art.dialog.list["Tips"];
                            if (null != list) {
                                list.close();
                            }
                            art.dialog({
                                content: data.Message,
                                cancelVal: '知道了',
                                cancel: function () {
                                    funs.Refresh(options, data);
                                }
                            });
                        } else {
                            art.dialog.tips(data.Message);
                            funs.Refresh(options, data);
                        }
                    }
                    if(null!=options.afterSuccessFunction){
                        options.afterSuccessFunction(data);
                    }
                },
                complete:function(){
                    $(options.obj).text(oldValue).prop({"disabled":false});
                }
            });
        },
        Refresh: function (options, data) {
            var time = 700;
            if (options.isAlertShowMsg) {
                time = 0;
            }
            if (data.IsRefresh) {
                setTimeout(function () {
                    if (options.isRefreshSelf) {
                        if (options.refreshFromCache) {
                            location.reload();
                        } else {
                            location.reload(true);
                        }

                    } else {
                        if (options.refreshFromCache) {
                            art.dialog.open.origin.location.reload();
                        } else {
                            art.dialog.open.origin.location.reload(true);
                        }
                    }
                }, time);
            }
        }
    }
})(jQuery);