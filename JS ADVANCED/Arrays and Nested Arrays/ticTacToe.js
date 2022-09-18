function play(matrix) {
    let initDashboard = [
        [false, false, false],
        [false, false, false],
        [false, false, false]
    ]
    isFirstPlayer = true;
    for (let coordinates of matrix) {
        let [row, col] = coordinates.split(" ")
        if (initDashboard[row][col]) {
            console.log("This place is already taken. Please choose another!")
            continue;
        }
        let marker = isFirstPlayer ? "X" : "О";
        initDashboard[row][col] = marker;
        for (let index = 0; index < initDashboard.length; index++) {
            if (initDashboard[index][0] === marker && initDashboard[index][1] === marker && initDashboard[index][2] === marker) {
                console.log(`Player ${marker} wins!`)
                return
            } 
            else if (initDashboard[0][index] === marker && initDashboard[1][index] === marker && initDashboard[2][index] === marker) {
                console.log(`Player ${marker} wins!`)
                return
            }
            else if (initDashboard[0][0] === marker && initDashboard[0][1] === marker && initDashboard[0][2] === marker) {
                console.log(`Player ${marker} wins!`)
                return
            }
            else if (initDashboard[0][2] === marker && initDashboard[1][1] === marker && initDashboard[2][0] === marker) {
                console.log(`Player ${marker} wins!`)
                return
            }


        }
        let isFreeSpace = false;
        for (let x = 0; x < initDashboard.length; x++) {
            for (let y = 0; y < initDashboard.length; y++) {
               
                if (!initDashboard[x][y]) {
                    isFreeSpace = true;
                    break;
                }
            }
            if (isFreeSpace) {
                break;
            }
            
        }
        if (!isFreeSpace) {
            console.log("The game ended! Nobody wins :(")
            return;
        } 

        isFirstPlayer = !isFirstPlayer;
    }

}

play(["0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 1",
    "1 2",
    "2 2",
    "2 1",
    "0 0"
])