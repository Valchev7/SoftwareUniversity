function solve(arr, number) {
    return arr.filter((element, index) => index % number == 0);
}

solve(['5', 
'20', 
'31', 
'4', 
'20'], 
2
)