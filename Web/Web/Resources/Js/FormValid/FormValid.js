//by:xcl @2012.8
var XCLFormValid = function (frm) {
    this.frm = frm;
    this.errMsg = new Array();
    this.errName = new Array();

    this.required = function (inputObj) {
        if (typeof (inputObj) == "undefined" || inputObj.value.trim() == "") {
            return false;
        }
        return true;
    }

    this.eqaul = function (inputObj, formElements) {
        var fstObj = inputObj;
        var sndObj = formElements[inputObj.getAttribute('eqaulName')];

        if (fstObj != null && sndObj != null) {
            if (fstObj.value != sndObj.value) {
                return false;
            }
        }
        return true;
    }

    this.gt = function (inputObj, formElements) {
        var fstObj = inputObj;
        var sndObj = formElements[inputObj.getAttribute('eqaulName')];

        if (fstObj != null && sndObj != null && fstObj.value.trim() != '' && sndObj.value.trim() != '') {
            if (parseFloat(fstObj.value) <= parseFloat(sndObj.value)) {
                return false;
            }
        }
        return true;
    }

    this.compare = function (inputObj, formElements) {
        var fstObj = inputObj;
        var sndObj = formElements[inputObj.getAttribute('objectName')];
        if (fstObj != null && sndObj != null && fstObj.value.trim() != '' && sndObj.value.trim() != '') {
            if (!(eval(parseFloat(fstObj.value) + inputObj.getAttribute('operate') + parseFloat(sndObj.value)))) {
                return false;
            }
        }
        return true;
    }

    this.limit = function (inputObj) {
        var len = inputObj.value.length;
        if (len) {
            var minv = parseFloat(inputObj.getAttribute('min'));
            var maxv = parseFloat(inputObj.getAttribute('max'));
            minv = minv || 0;
            maxv = maxv || Number.MAX_VALUE;
            return minv <= len && len <= maxv;
        }
        return true;
    }

    this.range = function (inputObj) {
        var val = parseFloat(inputObj.value);
        if (inputObj.value) {
            var minv = parseFloat(inputObj.getAttribute('min'));
            var maxv = parseFloat(inputObj.getAttribute('max'));
            minv = minv || 0;
            maxv = maxv || Number.MAX_VALUE;

            return minv <= val && val <= maxv;
        }
        return true;
    }

    this.requireChecked = function (inputObj, formElements) {
        var minv = parseFloat(inputObj.getAttribute('min'));
        var maxv = parseFloat(inputObj.getAttribute('max'));
        var arrayName = null;
        var pos = inputObj.name.indexOf('[');
        if (pos != -1)
            arrayName = inputObj.name.substr(0, pos);
        minv = minv || 1;
        maxv = maxv || Number.MAX_VALUE;

        var checked = 0;
        if (!arrayName) {
            var groups = document.getElementsByName(inputObj.name);
            for (var i = 0; i < groups.length; i++) {
                if (groups[i].checked) checked++;
            }

        } else {
            for (var i = 0; i < formElements.length; i++) {
                var ee = formElements[i];
                if (ee.checked == true && ee.type == 'checkbox'
					&& ee.name.substring(0, arrayName.length) == arrayName) {
                    checked++;
                }

            }
        }
        return minv <= checked && checked <= maxv;
    }

    this.filter = function (inputObj) {
        var value = inputObj.value;
        var allow = inputObj.getAttribute('allow');
        if (value.trim()) {
            return new RegExp("^.+\.(?=EXT)(EXT)$".replace(/EXT/g, allow.split(/\s*,\s*/).join("|")), "gi").test(value);
        }
        return true;
    }

    this.isNo = function (inputObj) {
        var value = inputObj.value;
        var noValue = inputObj.getAttribute('noValue');
        return value != noValue;
    }
    this.isTelephone = function (inputObj) {
        inputObj.value = inputObj.value.trim();
        if (inputObj.value == '') {
            return true;
        } else {
            if (!XCLValid_RegExps.isMobile.test(inputObj.value) && !XCLValid_RegExps.isPhone.test(inputObj.value)) {
                return false;
            }
        }
        return true;
    }
    this.checkReg = function (inputObj, reg, msg) {
        inputObj.value = inputObj.value.trim();

        if (inputObj.value == '') {
            return true;
        } else {
            return reg.test(inputObj.value);
        }
    }

    this.passed = function () {
        if (this.errMsg.length > 0) {
            XCLFormValid.showError(this.errMsg, this.errName, this.frm.name);
            if (this.errName[0].indexOf('[') == -1) {
                frt = document.getElementsByName(this.errName[0])[0];
                if (frt.type == 'text' || frt.type == 'password') {
                    frt.focus();
                }
            }
            var s = [];
            s = this.errName.toString().split(',');
            if (s.length > 0) {
                for (var i = 0; i < s.length; i++) {
                    if (s[i] != '') {
                        var currentObj = document.getElementById('errMsg_' + s[i]);
                        currentObj.className = "XCLFormValid_Error";
                    }
                }
            }

            return false;
        } else {

            return XCLFormValid.succeed();
        }
    }

    this.addErrorMsg = function (name, str) {
        this.errMsg.push(str);
        this.errName.push(name);
    }

    this.addAllName = function (name) {
        XCLFormValid.allName.push(name);
    }
}
XCLFormValid.allName = new Array();
XCLFormValid.showError = function(errMsg) {
	var msg = "";
	for (i = 0; i < errMsg.length; i++) {
		msg += "- " + errMsg[i] + "\n";
	}
	alert(msg);
}
XCLFormValid.succeed = function () {
	return true;
}
function XCLValid_Validator(frm) {
	var formElements = frm.elements;
	var fv = new XCLFormValid(frm);
	XCLFormValid.allName = new Array();
	for (var i=0; i<formElements.length;i++) {
		if (formElements[i].disabled==true) continue;
		var msgs = XCLValid_fvCheck(formElements[i],fv,formElements);
		if (msgs.length>0) {
			for (n in msgs) {
				fv.addErrorMsg(formElements[i].name,msgs[n]);
			}
		}
	}
	return fv.passed();
}
function XCLValid_fvCheck(ee, fv, formElements) {
    var formArr = ["INPUT", "SELECT", "TEXTAREA", "BUTTON"]; //判断是否为表单元素
    var isFormEle = 0;
    for (var i = 0; i < formArr.length; i++) {
        if (ee.nodeName == formArr[i]) {
            isFormEle = 1;
            break;
        }
    }
    if (isFormEle == 0) {
        return [];
    }
	var validType = ee.getAttribute('valid');
	var errorMsg = ee.getAttribute('errmsg');
	if (!errorMsg) {
		errorMsg = '';
	}
	if (validType==null) return [];
	fv.addAllName(ee.name);
	var vts = validType.split('|');
	var ems = errorMsg.split('|');
	var r = [];
	for (var j=0; j<vts.length; j++) {
		var curValidType = vts[j];
		var curErrorMsg = ems[j];
		var validResult;
		switch (curValidType) {
		case 'isNumber':
		case 'isEmail':
		case 'isPhone':
		case 'isMobile':
		case 'isIdCard':
		case 'isMoney':
		case 'isZip':
		case 'isQQ':
		case 'isInt':
		case 'isEnglish':
		case 'isChinese':
		case 'isUrl':
		case 'isDate':
		case 'isTime':
			validResult = fv.checkReg(ee,XCLValid_RegExps[curValidType],curErrorMsg);
			break;
		case 'regexp':
			validResult = fv.checkReg(ee,new RegExp(ee.getAttribute('regexp'),"g"),curErrorMsg);
			break;
		case 'custom':
			validResult = eval(ee.getAttribute('custom')+'(ee,formElements)');
			break;
		default :
			validResult = eval('fv.'+curValidType+'(ee,formElements)');
			break;
		}
		if (!validResult) r.push(curErrorMsg);
	}
	return r;
}
String.prototype.trim = function() {
	return this.replace(/^\s*|\s*$/g, "");
}
var XCLValid_RegExps = function(){};
XCLValid_RegExps.isNumber = /^[-\+]?\d+(\.\d+)?$/;
XCLValid_RegExps.isEmail = /([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)/;
XCLValid_RegExps.isPhone = /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/;
XCLValid_RegExps.isMobile = /^((\(\d{2,3}\))|(\d{3}\-))?(13|15)\d{9}$/;
XCLValid_RegExps.isIdCard = /(^\d{15}$)|(^\d{17}[0-9Xx]$)/;
XCLValid_RegExps.isMoney = /^\d+(\.\d+)?$/;
XCLValid_RegExps.isZip = /^[1-9]\d{5}$/;
XCLValid_RegExps.isQQ = /^[1-9]\d{4,10}$/;
XCLValid_RegExps.isInt = /^[-\+]?\d+$/;
XCLValid_RegExps.isEnglish = /^[A-Za-z]+$/;
XCLValid_RegExps.isChinese =  /^[\u0391-\uFFE5]+$/;
XCLValid_RegExps.isUrl = /^http[s]?:\/\/[A-Za-z0-9]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/;
XCLValid_RegExps.isDate = /^\d{4}-\d{1,2}-\d{1,2}$/;
XCLValid_RegExps.isTime = /^\d{4}-\d{1,2}-\d{1,2}\s\d{1,2}:\d{1,2}:\d{1,2}$/;


function XCLValid_InitValid(frm) {
    var formElements = frm.elements;
    for (var i = 0; i < formElements.length; i++) {
        var validType = formElements[i].getAttribute('valid');
        if (validType == null) continue;
        formElements[i].onblur = (function (a, b) {
            return function () { XCLValid_ValidInput(a, b) }
        })(formElements[i], frm);
    }
}
function XCLValid_ValidInput(ipt, frm, p) {
    if (p == null) p = 'errMsg_';
    var fv = new XCLFormValid(frm);
    var formElements = frm.elements;
    var msgs = XCLValid_fvCheck(ipt, fv, formElements);
    var currentObj = document.getElementById(p + ipt.name);
    if (msgs.length > 0) {
        currentObj.innerHTML = msgs.join(',');
        currentObj.className = "XCLFormValid_Error";
    } else {
        currentObj.innerHTML = '';
        currentObj.className = "";
    }
}

//表单验证初始化
XCLFormValid.showError = function (errMsg, errName, formName) {
    if (formName == document.forms[0].getAttribute("name")) {
        for (key in XCLFormValid.allName) {
            var obj = document.getElementById('errMsg_' + XCLFormValid.allName[key]);
            obj.innerHTML = '';
            obj.className = '';
        }
        for (key in errMsg) {
            var obj = document.getElementById('errMsg_' + errName[key]);
            obj.innerHTML = errMsg[key];
            obj.className = "XCLFormValid_Error";
        }
    }
}
if (document.forms[0] != undefined && document.forms[0] != null) {
    XCLValid_InitValid(document.forms[0]);
}
function XCLValid_SubmitForm() {
    if (document.forms[0] != undefined && document.forms[0] != null) {
        return XCLValid_Validator(document.forms[0])
    } else {
        return true;
    }
}