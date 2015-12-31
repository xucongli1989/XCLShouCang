var XCLShouCang = {
    XCLJsonMessageName: "",
    RootURL: "",
    PageConfig: {},
    Init: function () {
        var mainThis = this;

        $("input").iCheck({
            checkboxClass: 'icheckbox_square-blue',
            radioClass: 'icheckbox_square-blue',
            increaseArea: '20%'
        });

        $(".XCLToolTip").popover();

        //菜单导航
        var initNav = function () {
            mainThis.NavMenuObjectModel.$XCL_NavAdmin = $(".nav #XCL_NavAdmin");
            mainThis.NavMenuObjectModel.$XCL_NavFavInput = $(".nav #XCL_NavFavInput");
            mainThis.NavMenuObjectModel.$XCL_NavLogin = $(".nav #XCL_NavLogin");
            mainThis.NavMenuObjectModel.$XCL_NavMyFav = $(".nav #XCL_NavMyFav");
            mainThis.NavMenuObjectModel.$XCL_NavReg = $(".nav #XCL_NavReg");
            mainThis.NavMenuObjectModel.$XCL_NavUpdateMyInfo = $("#XCL_NavUpdateMyInfo");
            mainThis.NavMenuObjectModel.$XCL_NavSearch = $("#XCL_NavSearch");
            mainThis.NavMenuObjectModel.$XCL_NavComment = $("#XCL_NavComment");
        };
        initNav();

        //溢出隐藏
        //$(".XCLTextEllipsis").textEllipsis();

        //搜索收藏
        var initFastSearch = function () {
            var $txtWebTypeListSearch = $('#txtWebTypeListSearch');
            $txtWebTypeListSearch.typeahead({
                ajax: {
                    url: XCLShouCang.RootURL + "Common/GetSearchJsonResult",
                    method: "get",
                    triggerLength: 1,
                    preDispatch: function (query) {
                        return { keyWord: query };
                    },
                    loadingClass: "XCLLoading"
                },
                display: "SearchName",
                val: "SearchVal",
                item: '<li class="webTypeListSearchItem"><a href="javascript:void(0);"></a></li>',
                render: function (items) {

                    var that = this;
                    items = $(items).map(function (i, item) {
                        i = $(that.options.item).attr('data-value', item[that.options.val]);
                        var $link = i.find('a');
                        var valData = $.parseJSON(item[that.options.val]);
                        var aHtml = that.highlighter(item[that.options.display], item);
                        if (valData.IsFolder == 1) {
                            aHtml = "<span class='glyphicon glyphicon-folder-open'></span>&nbsp;" + aHtml;
                        } else {
                            $link.attr({ "target": "_blank" });
                        }
                        $link.html(aHtml).attr({ "href": valData.TypeURL });
                        return i[0];
                    });
                    items.first().addClass('active');
                    this.$menu.html(items);

                    return this;
                },
                click: function () { }
            });
            $txtWebTypeListSearch.on("click", function () {
                $(this).select();
            }).on("keydown", function (event) {
                if (event.keyCode == 13) {
                    var selectURL = $(".webTypeListSearchItem").filter('.active').find("a").attr("href");
                    window.open(selectURL, "_blank");
                    return false;
                }
            });
        };
        initFastSearch();

        //QQ登录
        $("#qqLoginBtn").on("click", function () {
            QC.Login.showPopup({
                appId: XCLShouCang.PageConfig.QQAppID,
                redirectURI: XCLShouCang.PageConfig.QQLoginRedirectURL
            });
        });
        
    },
    //导航菜单Li对象
    NavMenuObjectModel: {
        $XCL_NavMyFav: null,
        $XCL_NavFavInput: null,
        $XCL_NavAdmin: null,
        $XCL_NavReg: null,
        $XCL_NavLogin: null,
        $XCL_NavUpdateMyInfo: null,
        $XCL_NavSearch: null,
        $XCL_NavComment:null
    },
    SetNavSelected: function ($currentMenu) {
        if ($currentMenu) {
            $currentMenu.addClass("XCLSelectNav");
        }
    }
};
$(function () {
    XCLShouCang.Init();
});

//首页
XCLShouCang.Home = {
    Init: function () {
        
    }
};




//登录注册
XCLShouCang.Login = {};
XCLShouCang.Login.Register = {
    Init: function () {
        var that = this;
        $("body").keypress(function (event) {
            if (event.keyCode == 13) {
                that.Submit($("#btnRegisterSubmit")[0]);
            }
        });
        XCLShouCang.SetNavSelected(XCLShouCang.NavMenuObjectModel.$XCL_NavReg);
    },
    Submit: function (obj) {
        if (!XCLValid_SubmitForm()) {
            return false;
        }
        $.XCLGoAjax({ obj: obj, isAlertShowMsg: true });
    }
};

XCLShouCang.Login.LogOn = {
    Init: function () {
        var that = this;
        $("body").keypress(function (event) {
            if (event.keyCode == 13) {
                that.Submit($("#btnLogOn")[0]);
            }
        });
        XCLShouCang.SetNavSelected(XCLShouCang.NavMenuObjectModel.$XCL_NavLogin);
    },
    Submit: function (obj) {
        if (!XCLValid_SubmitForm()) {
            return false;
        }
        $.XCLGoAjax({ obj: obj,isRefreshSelf: true });
    }
};

XCLShouCang.Login.QQLoginCallBack = {
    Init: function () {

        if (QC.Login.check()) {
            QC.Login.getMe(function (openId, accessToken) {

                $.post(XCLShouCang.RootURL + "Login/LoginByThird", { ThirdLoginType: "QQ", ThirdLoginToken: openId, NickName: "" }, function (data) {
                    if (data.IsSuccess) {
                        QC.Login.signOut();//退出QQ，使用本地授权
                        location.href = XCLShouCang.PageConfig.WebMainURL;
                    } else {
                        art.dialog.tips("登录失败，请重试！");
                    }
                });

            });
        } else {
            art.dialog.tips("登录失败，请重试！");
        }

    }
};


//类别管理
XCLShouCang.UserAdmin = {};

XCLShouCang.UserAdmin.WebTypeList = {
    Init: function () {
        $.XCLTableList();

        $("select#selParentID").bind("change", function () {
            location.href = XCLShouCang.RootURL + "UserAdmin/WebTypeList?parentWebTypeID=" + this.value;
        });
        $("#tableWebTypeList tr").hover(function () {
            $(this).addClass("warning");
        }, function () {
            $(this).removeClass("warning");
        });

        XCLShouCang.SetNavSelected(XCLShouCang.NavMenuObjectModel.$XCL_NavAdmin);

        $("#divTableTopTools").stickUp();
    },
    Del: function (obj) {
        if ($("input[name='ckWebTypeID']:checked").length <= 0) {
            art.dialog.tips("请选择要删除的数据！");
            return false;
        }
        art.dialog.confirm("【谨慎操作】您确定要删除所选内容吗？", function () {
            $.XCLGoAjax({ obj: obj, url: XCLShouCang.RootURL + "WebTypeAdd/Del", isRefreshSelf: true });
        }, function () { })
    },
    SetShare: function (obj) {
        $.XCLGoAjax({ obj: obj });
    }
};


XCLShouCang.UserAdmin.WebTypeAdd = {
    Init: function () {
        XCLShouCang.SetNavSelected(XCLShouCang.NavMenuObjectModel.$XCL_NavAdmin);
    },
    Submit: function (obj) {
        if (!XCLValid_SubmitForm()) {
            return false;
        }
        $.XCLGoAjax({ obj: obj, isAlertShowMsg: true });        
    }
};


XCLShouCang.UserAdmin.WebTypeInput = {
    Init: function () {
        XCLShouCang.SetNavSelected(XCLShouCang.NavMenuObjectModel.$XCL_NavFavInput);
    },
    Submit: function (obj) {
        if (!XCLValid_SubmitForm()) {
            return false;
        }
        var $hdUploadSuccessPath = $("#hdUploadSuccessPath");
        $hdUploadSuccessPath.val("");
        $.ajaxFileUpload
		(
			{
			    url: XCLShouCang.RootURL + 'Common/UploadFile',
			    secureuri: false,
			    fileElementId: 'UploadData',
			    dataType: 'json',
			    data: { uploadPath: $("#UploadData").attr("uploadPath") },
			    success: function (data) {
			        var data = data[XCLShouCang.XCLJsonMessageName];
			        if (data.IsSuccess && data.Message !== "") {
			            $hdUploadSuccessPath.val(data.Message);
			        } else {
			            $hdUploadSuccessPath.val("");
			        }

			        if ($hdUploadSuccessPath.val() === "") {
			            art.dialog.tips("文件上传失败，请重试！");
			        } else {
			            $.XCLGoAjax({ obj: obj, isAlertShowMsg: true });
			        }
			    },
			    error: function () {
			        art.dialog.tips("文件上传失败，请重试！");
			    }
			}
		)
    }
};

XCLShouCang.UserAdmin.WebTypeShow = {
    Init: function () {
            
    }
};

XCLShouCang.UserAdmin.UserInfoUpdate = {
    Init: function () {
        XCLShouCang.SetNavSelected(XCLShouCang.NavMenuObjectModel.$XCL_NavUpdateMyInfo);
    },
    Submit: function (obj) {
        if (!XCLValid_SubmitForm()) {
            return false;
        }
        $.XCLGoAjax({ obj: obj, isAlertShowMsg: true });
    }
};


XCLShouCang.UserAdmin.MyHome = {
    Init: function () {
        var that = this;
        XCLShouCang.SetNavSelected(XCLShouCang.NavMenuObjectModel.$XCL_NavMyFav);
        that.RenderWebTypeList(-1);
    },
    //收藏列表的表头单击显示与隐藏效果
    SetListStyle: function () {
        var that = this;
        //折叠效果
        var SetXCLExpandFlag = function ($obj, isExpand) {
            if (isExpand) {
                $obj.removeClass("glyphicon glyphicon-plus").addClass("glyphicon glyphicon-minus");
            } else {
                $obj.removeClass("glyphicon glyphicon-minus").addClass("glyphicon glyphicon-plus");
            }
        };
        var $XCLWebTypeHeader = $(".XCLWebTypeHeader"), $XCLWebTypeBody = $(".XCLWebTypeBody");
        if ($XCLWebTypeHeader.length == 1) {
            $XCLWebTypeBody.show();
            $XCLWebTypeHeader.find(".XCLExpandFlag").remove();
        } else if ($XCLWebTypeHeader.length > 1) {
            $XCLWebTypeBody.filter(":eq(0)").show();
            SetXCLExpandFlag($($XCLWebTypeHeader.get(0)).find(".XCLExpandFlag"), true);
            $XCLWebTypeHeader.on("click", function (event) {
                var _this = this;
                $(this).siblings(".XCLWebTypeBody").toggle("fast", function () {
                    SetXCLExpandFlag($(_this).find(".XCLExpandFlag"), $(this).is(":visible"));
                });
                return false;
            });
        }
        //给收藏夹设置事件
        $(".aWebTypeLink[XCL-IsFolder='1'],.aWebTypeLinkListHeader").on("click", function () {
            that.RenderWebTypeList($(this).attr("XCL-WebTypeID"));
            return false;
        });
        //给路径导航设置事件
        $("#divWebTypeListNav a.LayerListLink").on("click", function () {
            that.RenderWebTypeList($(this).attr("XCL-WebTypeID"));
            return false;
        });
    },
    //ajax加载所有收藏list
    RenderWebTypeList: function (parentID) {
        var that = this;
        $MyWebTypeListContainer = $(".XCLCenterDiv .MyWebTypeListContainer");
        art.dialog.tips("正在努力加载中...",99999999);
        $.get(XCLShouCang.RootURL + "UserAdmin/GetMyWebTypeList", { parentID: parentID,v:Math.random() }, function (data) {
            var list = art.dialog.list["Tips"];
            if (null != list) {
                list.close();
            }
            $MyWebTypeListContainer.fadeOut("fast", function () {
                $MyWebTypeListContainer.html(data);
                that.SetListStyle();
                $MyWebTypeListContainer.fadeIn("fast");
            });
        })
    }
};





XCLShouCang.Common = {};
XCLShouCang.Common.Search = {
    Init: function () {
        XCLShouCang.SetNavSelected(XCLShouCang.NavMenuObjectModel.$XCL_NavSearch);
        this.GoSearch();
    },
    GoSearch: function () {
        $("#btnGoogleSearch").on("click", function () {
            $(this).closest("form").submit();
        });
        $("#btnBaiduSearch").on("click", function () {
            $(this).closest("form").submit();
        });
    }
};
XCLShouCang.Common.Comment = {
    Init: function () {
        XCLShouCang.SetNavSelected(XCLShouCang.NavMenuObjectModel.$XCL_NavComment);
    }
};