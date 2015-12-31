//by:xcl @2012.8  qq:80213876
;(function ($) { 
    $.extend({
        XCLTableList:function(options){
            options = $.extend({},funs.Defaults, options);
            funs.Init(options);
            $(options.tableClass).each(function(){

                /******全选相关开始*****/
                //单击全选时
                $(options.checkAllClass).on("ifChanged", function () {
                    var $ckAll=$(this).closest(options.tableClass).find(options.checkAllClass);
                    var $ckItem=$(this).closest(options.tableClass).find(options.checkItemClass);
                    if(this.checked){
                        $ckItem.prop({"checked":true}).parent().addClass("checked");
                    }else{
                        $ckItem.prop({"checked":false}).parent().removeClass("checked");
                    }
                    funs.GetCheckBoxIDs($ckAll,$ckItem);
                });
                //单击列表中的checkbox时
                $(options.checkItemClass).on("ifChanged", function () {
                    var $ckAll=$(this).closest(options.tableClass).find(options.checkAllClass);
                    var $ckItem=$(this).closest(options.tableClass).find(options.checkItemClass);
                    var flag=1;
                    $ckItem.each(function(){
                        if(!this.checked){
                            flag=0;
                            return false;
                        }
                    });
                    if(flag==1){
                        $ckAll.prop({"checked":true}).parent().addClass("checked");
                    }else{
                        $ckAll.prop({"checked":false}).parent().removeClass("checked");
                    }
                    funs.GetCheckBoxIDs($ckAll,$ckItem);
                });
                /******全选相关结束*****/

            });
        }
    });
    var funs={
        Defaults:{
            tableClass:".tableList",//table的class
            checkAllClass:".checkAll",//全选按钮class
            checkItemClass:".checkItem"//选择框的class
        },
        Init:function(options){
            //当子项都为选中时，此时选中全选项
            $(options.tableClass).each(function(){
                    var $ckAll=$(this).closest(options.tableClass).find(options.checkAllClass);
                    var $ckItem=$(this).closest(options.tableClass).find(options.checkItemClass);
                    var isAllChecked = ($ckItem.length > 0 && $ckItem.filter(":checked").length == $ckItem.length);
                    if (isAllChecked) {
                        $ckAll.prop({"checked":true}).parent().addClass("checked");
                    }
                    funs.GetCheckBoxIDs($ckAll, $ckItem);
            });
        },
        //将列表中的checkbox的value的数组形式存到全选的checkbox的value中
        GetCheckBoxIDs:function(ckAll,ckItem){
            var v=[];
            ckItem.each(function(){
                if(this.checked){
                    v.push(this.value);
                }
            });
            ckAll.val(v.toString());
        }
    }
})(jQuery);