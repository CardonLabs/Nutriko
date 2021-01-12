
export interface Foods {
    [key: number]: Array<FoodItem>
}

export interface FoodItem {
    id: number,
    version: Date,
    description: string,
    dataType: string,
    foodCategory: string,
    foodNutrients: Array<FoodNutrient>,
    nutrientConversionFactors: { [key: string]: { value: number } }
}

export interface FoodNutrient {
    id: string,
    name: string,
    unitName: string,
    amount: number,
    number: number
}


