const display = document.querySelector(".calculator-input");
const keys = document.querySelector(".calculator-keys");

let displayValue = "0";
let operator = null;
let firstValue = null;
let waitingSecondValue = false;


updateDisplay();

function updateDisplay() {
    display.value = displayValue;
}

keys.addEventListener("click", function (e) {
    const element = e.target;
    const value = element.value;
    
    if (!element.matches("button")) return;

    switch (value) {
        case "+":
        case "-":
        case "*":
        case "/":
        case "=":
            handleOperator(value);
            break;

        case ".":
            inputDecimal();
            break;
        case "clear":
            clear();
            break;
        default:
            inputNumber(value);
            break;
    }
    updateDisplay();
});

function handleOperator(nextOperator) {
    const value = parseFloat(displayValue);
    console.log(operator);
    if (operator && waitingSecondValue) {
        operator = nextOperator;
        return;
    }

    if (firstValue === null) {
        firstValue = value;
    } else {
        const result = calculate(firstValue, operator, value);
        displayValue = parseFloat(result.toFixed(6));
        firstValue = result;
    }
    operator = nextOperator;
    waitingSecondValue = true;
    console.log(firstValue, operator, displayValue, waitingSecondValue);

}

function inputNumber(num) {
    if (waitingSecondValue) {
        displayValue = num;
        waitingSecondValue = false;
    } else {
        displayValue = displayValue === "0" ? num : displayValue + num;
    }
    console.log(firstValue, operator, displayValue, waitingSecondValue);

}

function calculate(first, op, second) {
    switch (op) {
        case "+":
            return first + second;
            break;
        case "-":
            return first - second;
            break;
        case "*":
            return first * second;
            break;
        case "/":
            return first / second;
            break;
        default:
            break;
    }
    
}

function clear() {
    displayValue="0";
    operator = null;
    firstValue=null;
    waitingSecondValue=false;

}


function inputDecimal() {
    if (!displayValue.includes(".")) displayValue+= ".";
}



