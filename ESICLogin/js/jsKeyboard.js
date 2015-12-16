var jsKeyboard = {
    settings: {
        buttonClass: "button", // default button class
        onclick: "jsKeyboard.write();", // default onclick event for button
        keyClass: "key", // default key class used to define style of text of the button
        text: {
            close: "close"
        }
    },
    "keyboard": [], // different keyboards can be set to this variable in order to switch between keyboards easily.
    init: function (elem, keyboard) {
        jsKeyboard.keyboard["default"] = jsKeyboard.defaultKeyboard;
        jsKeyboard.keyboardLayout = elem;

        if (keyboard != null && keyboard != undefined)
            jsKeyboard.generateKeyboard(keyboard);
        else
            jsKeyboard.generateKeyboard("default");

        jsKeyboard.addKeyDownEvent();

        jsKeyboard.show();
        $("[id$=TextBox2]").not('[type="reset"]').not('[type="submit"]').on('focus, click', function (e) {
            jsKeyboard.currentElement = $(this);
            jsKeyboard.currentElementCursorPosition = $(this).getCursorPosition();
            console.log('keyboard is now focused on ' + jsKeyboard.currentElement.attr('name') + ' at pos(' + jsKeyboard.currentElementCursorPosition + ')');
        });
    },
    focus: function (t) {
        jsKeyboard.currentElement = $(t);
        jsKeyboard.show();
    },
    keyboardLayout: "", // it shows the html element where keyboard is generated
    currentKeyboard: "default", // it shows the which keyboard is used. If it's not set default keyboard is used.
    currentElement: null,
    generateKeyboard: function (keyboard) {
        var bClass = "";
        var kClass = "";
        var onclick = "";
        var text = "";

        var s = "";


        s += "<div id=\"keyboard1\">";
        s += "<div id=\"keyboardHeader\">";
        // s += "<div onclick=\"jsKeyboard.hide();\"><span>" + jsKeyboard.settings.text.close + "</span><span class=\"closex\"> X</span></div>"
        s += "</div>";

        /*number*/
        s += "<div id=\"keyboardNumber\">";
        $.each(jsKeyboard.keyboard[keyboard].number, function (i, key) {
            generate(key);
        });
        s += "</div>";






        function generate(key) {
            bClass = key.buttonClass == undefined ? jsKeyboard.settings.buttonClass : key.buttonClass;
            kClass = key.keyClass == undefined ? jsKeyboard.settings.keyClass : key.keyClass;
            onclick = key.onclick == undefined ? jsKeyboard.settings.onclick.replace("()", "(" + key.value + ")") : key.onclick;

            text = (key.isChar != undefined || key.isChar == false) ? key.value : String.fromCharCode(key.value);

            s += "<div class=\"" + bClass + "\" onclick=\"" + onclick + "\"><div class=\"" + kClass + "\">" + text + "</div></div>";

            bClass = ""; kClass = ""; onclick = ""; text = "";
        }

        $("#" + jsKeyboard.keyboardLayout).html(s);
    },
    addKeyDownEvent: function () {
        $("#keyboardCapitalLetter > div.button, #keyboardSmallLetter > div.button, #keyboardNumber > div.button, #keyboardSymbols > div.button").
            bind('mousedown', (function () { $(this).addClass("buttonDown"); })).
            bind('mouseup', (function () { $(this).removeClass("buttonDown"); })).
            bind('mouseout', (function () { $(this).removeClass("buttonDown"); }));

        //key focus down on actual keyboard key presses
        //todo:....

    },
    changeToSmallLetter: function () {
        $("#keyboardCapitalLetter,#keyboardNumber,#keyboardSymbols").css("display", "none");
        $("#keyboardSmallLetter").css("display", "block");
    },
    changeToCapitalLetter: function () {
        $("#keyboardCapitalLetter").css("display", "block");
        $("#keyboardSmallLetter,#keyboardNumber,#keyboardSymbols").css("display", "none");
    },
    changeToNumber: function () {
        $("#keyboardNumber").css("display", "block");
        $("#keyboardSymbols,#keyboardCapitalLetter,#keyboardSmallLetter").css("display", "none");
    },
    changeToSymbols: function () {
        $("#keyboardCapitalLetter,#keyboardNumber,#keyboardSmallLetter").css("display", "none");
        $("#keyboardSymbols").css("display", "block");
    },
    updateCursor: function () {
        //input cursor focus and position during typing
        jsKeyboard.currentElement.setCursorPosition(jsKeyboard.currentElementCursorPosition);
    },
    write: function (m) {
        var a = jsKeyboard.currentElement.val(),
            b = String.fromCharCode(m),
            pos = jsKeyboard.currentElementCursorPosition,
            output = [a.slice(0, pos), b, a.slice(pos)].join('');
        jsKeyboard.currentElement.val(output);
        jsKeyboard.currentElementCursorPosition++; //+1 cursor
        jsKeyboard.updateCursor();
    },
    del: function () {
        var a = jsKeyboard.currentElement.val(),
            pos = jsKeyboard.currentElementCursorPosition,
            output = [a.slice(0, pos - 1), a.slice(pos)].join('');
        jsKeyboard.currentElement.val(output);
        if (jsKeyboard.currentElement.val() == "") {
            jsKeyboard.currentElementCursorPosition;
        }
        else {
            jsKeyboard.currentElementCursorPosition--; //-1 cursor
        }  
        jsKeyboard.updateCursor();
    },
    enter: function () {
        var t = jsKeyboard.currentElement.val();
        jsKeyboard.currentElement.val(t + "\n");
    },
    space: function () {
        var a = jsKeyboard.currentElement.val(),
            b = " ",
            pos = jsKeyboard.currentElementCursorPosition,
            output = [a.slice(0, pos), b, a.slice(pos)].join('');
        jsKeyboard.currentElement.val(output);
        jsKeyboard.currentElementCursorPosition++; //+1 cursor
        jsKeyboard.updateCursor();
    },
    writeSpecial: function (m) {
        var a = jsKeyboard.currentElement.val(),
            b = String.fromCharCode(m),
            pos = jsKeyboard.currentElementCursorPosition,
            output = [a.slice(0, pos), b, a.slice(pos)].join('');
        jsKeyboard.currentElement.val(output);
        jsKeyboard.currentElementCursorPosition++; //+1 cursor
        jsKeyboard.updateCursor();
    },
    show: function () {
        $("#keyboard").animate({ "bottom": "0" }, "slow", function () { });
    },
    hide: function () {
        $("#keyboard").animate({ "bottom": "-350px" }, "slow", function () { });
    },
    defaultKeyboard: {

        number: [
        // 1st row
                {value: 49 }, { value: 50 }, { value: 51 }, { value: 52 }, { value: 53 }, { value: 54 },
                { value: 55 }, { value: 56 }, { value: 57 },
                { value: "Del", isChar: "false", onclick: "jsKeyboard.del()", buttonClass: "button button_del", keyClass: "key key_del" },
                { value: 48 },
                { value: "Del", isChar: "false", onclick: "jsKeyboard.del()", buttonClass: "button button_del", keyClass: "key key_del" },
        //  { value: "abc", isChar: "false", buttonClass: "button button_smallletter", onclick: "jsKeyboard.changeToSmallLetter();", keyClass: "key key_smallletter" },
        // 2nd row
        //{ value: 45, buttonClass: "button button_dash" },{ value: 47 },{ value: 58 },{ value: 59 },
        //{ value: 40 },{ value: 41 },{ value: 36 },{ value: 38 },{ value: 64 },
        //{ value: "Enter", isChar: "false", buttonClass: "button button_enter", onclick: "jsKeyboard.enter();", keyClass: "key key_enter" },
        //3rd row
        // { value: "ABC", isChar: "false", buttonClass: "button button_capitalletterleft", onclick: "jsKeyboard.changeToCapitalLetter()", keyClass: "key key_capitalletterleft" },
        //{ value: "", isChar: "false", buttonClass: "button button_capitalletterleft", onclick: "", keyClass: "key" },
        //{ value: 63 },{ value: 33 },{ value: 34 },{ value: 124 },{ value: 92 },{ value: 42 },{ value: 61 },{ value: 43 },
        // { value: "ABC", isChar: "false", buttonClass: "button button_capitalletterright", onclick: "jsKeyboard.changeToCapitalLetter();", keyClass: "key key_capitalletterright" },
        //{ value: "", isChar: "false", buttonClass: "button", onclick: "", keyClass: "key" },
        //{ value: "", isChar: "false", buttonClass: "button", onclick: "", keyClass: "key" },

        // 4th row
        // { value: "ABC", isChar: "false", buttonClass: "button button_numberleft", onclick: "jsKeyboard.changeToCapitalLetter();", keyClass: "key key_capitalletterleft" },
        //{ value: "Space", isChar: "false", buttonClass: "button button_space", onclick: "jsKeyboard.space();", keyClass: "key key_space" },
        //{ value: "#%+", isChar: "false", buttonClass: "button button_symbolsright", onclick: "jsKeyboard.changeToSymbols();", keyClass: "key key_symbols" }
            ]


    }
}


// GET CURSOR POSITION
jQuery.fn.getCursorPosition = function(){
    if(this.lengh == 0) return -1;
    return $(this).getSelectionStart();
}

jQuery.fn.getSelectionStart = function(){
    if(this.lengh == 0) return -1;
    input = this[0];

    var pos = input.value.length;

    if (input.createTextRange) {
        var r = document.selection.createRange().duplicate();
        r.moveEnd('character', input.value.length);
        if (r.text == '')
        pos = input.value.length;
        pos = input.value.lastIndexOf(r.text);
    } else if(typeof(input.selectionStart)!="undefined")
    pos = input.selectionStart;

    return pos;
}

//SET CURSOR POSITION
jQuery.fn.setCursorPosition = function(pos) {
  this.each(function(index, elem) {
    if (elem.setSelectionRange) {
      elem.setSelectionRange(pos, pos);
    } else if (elem.createTextRange) {
      var range = elem.createTextRange();
      range.collapse(true);
      range.moveEnd('character', pos);
      range.moveStart('character', pos);
      range.select();
    }
  });
  return this;
};
