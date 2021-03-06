/**
 * List all recipes
 * Get recipe
 * Get recipes by user
 * Get recipes by plan
 */

 import { FoodItem, FoodNutrient } from 'src/app/models/foods';

 //recipe full
export interface IMRecipe {
    id: string | number;
    name: string;
    description: string;
    steps: { [key: number]: {id: string; rank: number; name: string; details: string} };
    directions: { [key: number]: {id: string; rank: number; name: string; details: string} };
    media: string;
    ingridients: { [key: number]: {id: any; name: string; quantity: number; weight: number; unit: string} };
    background: {history: string; region: string; cusine: string};
    nutrition: {calories: number, carbs: number};
    rating: number;
    popularity: number;
    // Doing for later ** reviews: { [key: number]: {id: string; author: string; description: string; rating: number} };
}

export interface Recipe {
    id: string | number;
    name: string;
    description: string;
    steps: Array<RecipeStep>;
    directions: Array<RecipeDirection>;
    media: string;
    ingridients: Array<RecipeIngridient>;
    foods: Array<FoodItem> | null;
    background: {history: string; region: string; cusine: string};
    nutrition: {calories: number, carbs: number};
    rating: number;
    popularity: number;
    // Doing for later ** reviews: { [key: number]: {id: string; author: string; description: string; rating: number} };
}

export interface RecipeBasic {
    id: string | number;
    name: string;
    description: string;
    media: string;
    background: {history: string; region: string; cusine: string};
    nutrition: {calories: number, carbs: number};
    rating: number;
    popularity: number;
}

export interface RecipeStep {
    id: string,
    rank: number,
    name: string,
    details: string
}

export interface RecipeDirection {
    id: string,
    rank: number,
    name: string,
    details: string
}

export interface RecipeIngridient {
    id: string,
    name: string,
    quantity: string,
    weight: number,
    unit: string
}

export interface IMRecipeItem {
    id: string | number;
    name: string;
    nutrition: any;
    rating: number;
    popularity: number;
}