function solve(arr) {
    let newArr = [];
    let biggestNum = arr[0];
    for (let index = 0; index < arr.length; index++) {
        let currNum = arr[index];
        if (currNum >= biggestNum) {
            newArr.push(currNum);
            biggestNum = currNum;
        }        
    }
    return newArr;
}

console.log(solve([1, 
    3, 
    8, 
    4, 
    10, 
    12, 
    3, 
    2, 
    24]
    ))