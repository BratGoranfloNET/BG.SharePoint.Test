function getcolors()
{
    var sel = document.getElementById("test-color"); 
    var methodurl = _spPageContextInfo.webServerRelativeUrl + '/' + _spPageContextInfo.layoutsUrl + '/BG.SharePoint.Test/services/TestService.svc/GetColorsPOST'

    var xhr = new XMLHttpRequest();
    xhr.open('POST', methodurl);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.onload = function () {
        if (xhr.status === 200) {
            
            var colors = JSON.parse(xhr.response).GetColorsPOSTResult;
            var index;
            for (index = 0; index < colors.length; ++index) {
                var color = colors[index].Title;
                var el = document.createElement("option");
                el.text = color;
                el.value = color;
                sel.add(el);
            }
        }
    };
    xhr.send(JSON.stringify({
        
    })); 
}

document.addEventListener('DOMContentLoaded', function () {
    getcolors();
}, false);

function testcall() {

    var elem = document.getElementById("test-input");    
    var input = elem.value;   
   
    var methodurl = _spPageContextInfo.webServerRelativeUrl + '/' + _spPageContextInfo.layoutsUrl + '/BG.SharePoint.Test/services/TestService.svc/MultiplicationPOST'

    var xhr = new XMLHttpRequest();
    xhr.open('POST', methodurl);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.onload = function () {
        if (xhr.status === 200) {
            var info = JSON.parse(xhr.responseText);
            console.log(info);

            alert('OK !');
        }
    };
    xhr.send(JSON.stringify({
        inputNumber: input
    })); 

}


function showDialog() {

    var e = document.getElementById('modal-dialog');
    var options = {
        title: "Новая запись",
        width: 700,
        height: 300,
        html: e
    };

    SP.UI.ModalDialog.showModalDialog(options);
};



function createListItem() {

    var validation = true;

    var title = "";
    var firstNumber = "";
    var lastNumber = "";
    var color = "";

    var inpNaim = document.getElementById("naim");
    var inpFirstnumber = document.getElementById("firstnumber");
    var inpLastnumber  = document.getElementById("lastnumber");
    var inpColor  = document.getElementById("test-color");
    color = inpColor.value;

    if (!inpNaim.checkValidity()) {
        document.getElementById("naim-message").innerHTML = inpNaim.validationMessage;
        validation = false;
    }
    else {
        title = inpNaim.value;
    }

    if (!inpFirstnumber.checkValidity()) {
        document.getElementById("firstnumber-message").innerHTML = inpFirstnumber.validationMessage;
        validation = false;
    }
    else {
        firstNumber = inpFirstnumber.value;
    }

    if (!inpLastnumber.checkValidity()) {
        
        document.getElementById("lastnumber-message").innerHTML = inpLirstnumber.validationMessage;
        validation = false;
    }
    else {
        
        lastNumber = inpLirstnumber.value;

        if (lastNumber < firstNumber)
        {
            document.getElementById("lastnumber-message").innerHTML = "Номер меньше первого!";
            validation = false;
        }
    }

   

    if (validation) {
    var methodurl = _spPageContextInfo.webServerRelativeUrl + '/' + _spPageContextInfo.layoutsUrl + '/BG.SharePoint.Test/services/TestService.svc/CreateDataListItemPOST'

        var xhr = new XMLHttpRequest();
        xhr.open('POST', methodurl);
        xhr.setRequestHeader('Content-Type', 'application/json');
        xhr.onload = function () {
            if (xhr.status === 200) {
                var info = JSON.parse(xhr.responseText);
                console.log(info);
                alert('Элемент создан!');
            }
        };
        xhr.send(JSON.stringify({
            title: title,
            firstNumber: firstNumber,
            lastNumber: lastNumber,
            color: color
        }));

    }
}

function createNewColor() {

    var inpColor = document.getElementById("newcolor");
    var color = inpColor.value;

    var methodurl = _spPageContextInfo.webServerRelativeUrl + '/' + _spPageContextInfo.layoutsUrl + '/BG.SharePoint.Test/services/TestService.svc/CreateColorListItemPOST'

    var xhr = new XMLHttpRequest();
    xhr.open('POST', methodurl);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.onload = function () {
        if (xhr.status === 200) {
            var info = JSON.parse(xhr.responseText);

            var colorsel = document.getElementById("test-color"); 
            var el = document.createElement("option");
            el.text = color;
            el.value = color;
            colorsel.add(el);

            console.log(info);            
        }
    };
    xhr.send(JSON.stringify({
        title: title,
        firstNumber: firstNumber,
        lastNumber: lastNumber,
        color: color
    }));

}