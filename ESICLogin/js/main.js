
     $(function () {
         jsKeyboard.init("virtualKeyboard");

         //first input focus
         var $firstInput = $("[id$=TextBox2]").first().focus();
         jsKeyboard.currentElement = $firstInput;
         jsKeyboard.currentElementCursorPosition = 0;
     });