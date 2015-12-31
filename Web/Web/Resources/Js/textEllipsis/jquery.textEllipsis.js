/**
 * jquery plugin: Text Ellipsis
 * requires: jQuery v1.4+
 * @author: Nicolas.Z
 * data: 2011-3-14
 */
(function($){

    $.fn.textEllipsis = function(options){
        options = $.extend({
        
            // 省略符号，代替溢出的文本
            ellipsis: "...",
            
            // 鼠标在元素上悬停时是否显示完整的文本
            tooltip: true,
            
            // 元素显示文本的行数
            line: 1
			
        }, options || {});
        
        return this.each(function(){
            var elem = $(this), text = $.trim(elem.text()), len = text.length;
			
			// 复制元素，使对其字符省略操作时不影响重绘，从而影响性能
            var _elem = elem.clone().appendTo(elem.parent()), _text = text, _w, _h, _lh, h;
            
			// 强制换行，获取宽度
			// 因为对于长英文单词或连续的英文字符会影响计算和布局
            _w = _elem.css({
                display: "block",
                height: "auto",
                "word-wrap": "break-word"
            }).width();
            
			// 强制不换行，获取行高
			// 由于"line-height"属性值会受到font-size、属性值单位等的影响，line-height是这些相关属性计算后的值
			// 所以元素单行的高度也就等于计算后的line-height属性值
            _lh = _elem.css({
                "word-wrap": "normal",
                "white-space": "nowrap"
            }).height();
            
			// 重设回强制换行
            _h = _elem.css({
                width: _w,
                "word-wrap": "break-word",
                "white-space": "normal"
            }).height();
			
			// 隐藏，开始准备操作元素内容
			_elem.hide();
			
			_h = Math.round(_h / _lh) * _lh;
			h = _lh * options.line;
			
			if (_h > h) {
                f();
            }
            
            _elem.show().css({
                height: h,
                overflow: "hidden"
            });
            
            if (options.tooltip) {
                _elem.attr("title", _text);
            }
            
            elem.replaceWith(_elem);
            
            function f(){
                text = text.substring(0, --len);
                _h = Math.round(_elem.text(text + options.ellipsis).height() / _lh) * _lh;
                
                if (_h > h) {
                    arguments.callee();
                }
            }
        });
    };
})(jQuery);
