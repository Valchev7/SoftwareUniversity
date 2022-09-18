function fruits(typeOfFruit, weightInGrams, pricePerKg) {
    weightInKg = weightInGrams / 1000;
    let price = weightInKg * pricePerKg;
    console.log(`I need $${price.toFixed(2)}  to buy ${weightInKg.toFixed(2)} kilograms ${typeOfFruit}.`)
}
fruits('apple', 1563, 2.35)3
    