function coocking(number, operationOne, operationTwo, operationThree, operationFour, operationFive) {
    let inputAsNumber = Number(number);
    let arrOfCommands = [operationOne, operationTwo, operationThree, operationFour, operationFive];
    let chop = function () {
        return inputAsNumber / 2;

    }
    let dice = function () {
        return Math.sqrt(inputAsNumber);
    }
    let spice = function () {
        return inputAsNumber + 1;

    }
    let bake = function () {
        return inputAsNumber * 3;

    }
    let fillet = function () {
        return inputAsNumber * 0.80;
    }
    for (let i = 0; i < arrOfCommands.length; i++) {
        let currentCommand = arrOfCommands[i];
        switch (currentCommand) {
            case 'chop':
                inputAsNumber = chop(inputAsNumber);
                console.log(inputAsNumber);
                break;
            case 'dice':
                inputAsNumber = dice(inputAsNumber);
                console.log(inputAsNumber);
                break;
            case 'spice':
                inputAsNumber = spice(inputAsNumber);
                console.log(inputAsNumber);
                break;
            case 'bake':
                inputAsNumber = bake(inputAsNumber);
                console.log(inputAsNumber);
                break;
            case 'fillet':
                inputAsNumber = fillet(inputAsNumber);
                console.log(inputAsNumber);
                break;
        }
    }
}
coocking('32', 'chop', 'chop', 'chop', 'chop', 'chop')
coocking('9', 'dice', 'spice', 'chop', 'bake', 'fillet')