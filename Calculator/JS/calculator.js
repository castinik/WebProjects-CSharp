var calc = 0;
var flagOperator = 0;
var oprCounter = 0;
var nmbCounter = 0;
var flgPoint = 0;

//_history_
var boxHistory = document.getElementById("history");


var getFigureResult = () => {
    let content = document.getElementById("result");
    let inner = content.innerHTML;
    switch (flagOperator) {
        case 1:
            content.innerHTML = inner + '÷';
            break;
        case 2:
            content.innerHTML = inner + '×';
            break;
        case 3:
            content.innerHTML = inner + '-';
            break;
        case 4:
            content.innerHTML = inner + '+';
            break;
    }
    return parseFloat(inner);
}

var updHistory = () => {
    let newP = document.createElement('p');
    let cells = document.getElementsByTagName('button');
    resultForHistory = document.getElementById("result");
    newP.style.margin = '0px';
    newP.style.fontWeight = "1000";
    newP.innerHTML = resultForHistory.innerHTML + ' = ' + String(calc).slice(0, 12);
    boxHistory.append(newP);
}

function appendNumber() {
    if (nmbCounter == 0) {
        document.getElementById("result").innerHTML = '';
    }
    let number = this.innerHTML;
    let result = document.getElementById("result");
    if (result.innerHTML.length < 12) {
        result.append(number);
    }
    nmbCounter += 1;
}


// 'set' result element
document.getElementById("result").innerHTML = '0';

// take all the button elements
var buttons = document.getElementsByTagName("button");

// event creation for each button
//_SYSTEM_BUTTONS_
// '='
buttons[14].onclick = function () {
    let tempNew = document.getElementById("result").innerHTML;
    let newCalc = parseFloat(tempNew.slice(String(calc).length + 1, tempNew.length));
    switch (flagOperator) {
        case 1:
            calc /= newCalc;
            break;
        case 2:
            calc *= newCalc;
            break;
        case 3:
            calc -= newCalc;
            break;
        case 4:
            calc += newCalc;
            break;
    }
    updHistory();
    document.getElementById("result").innerHTML = String(calc).slice(0, 12);
    calc = 0;
}
// 'C'
buttons[12].onclick = function () {
    calc = 0;
    flag = 0;
    oprCounter = 0;
    nmbCounter = 0;
    document.getElementById("result").innerHTML = '0';
}
// 'CA'
buttons[16].onclick = function () {
    calc = 0;
    flag = 0;
    oprCounter = 0;
    nmbCounter = 0;
    document.getElementById("result").innerHTML = '0';
    document.getElementById("history").innerHTML = '';
}
// '.'
buttons[17].onclick = function () {
    let cntResult = document.getElementById("result");
    //alert(cntResult);
    cntResult.innerHTML += '.';
    //alert(cntResult);
}

//_SIGNS_
// '/' 
buttons[3].onclick = function () {
    flagOperator = 1;
    let n = getFigureResult();
    calc = n;
    n = 0;
    oprCounter += 1;
}
// '×'
buttons[7].onclick = function () {
    flagOperator = 2;
    let n = getFigureResult();
    calc = n;
    n = 0;
    oprCounter += 1;
}
// '-'
buttons[11].onclick = function () {
    flagOperator = 3;
    let n = getFigureResult();
    calc = n;
    n = 0;
    oprCounter += 1;
}
// '+'
buttons[15].onclick = function () {
    flagOperator = 4;
    let n = getFigureResult();
    calc += n;
    n = 0;
    oprCounter += 1;
}

//_NUMBERS_
// 7
buttons[0].onclick = appendNumber;
// 8
buttons[1].onclick = appendNumber;
// 9
buttons[2].onclick = appendNumber;
// 4
buttons[4].onclick = appendNumber;
// 5 
buttons[5].onclick = appendNumber;
// 6
buttons[6].onclick = appendNumber;
// 1
buttons[8].onclick = appendNumber;
// 2
buttons[9].onclick = appendNumber;
// 3
buttons[10].onclick = appendNumber;
// 0
buttons[13].onclick = appendNumber;