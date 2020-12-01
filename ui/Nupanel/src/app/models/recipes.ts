/**
 * List all recipes
 * Get recipe
 * Get recipes by user
 * Get recipes by plan
 */

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

export interface IMRecipeItem {
    id: string | number;
    name: string;
    nutrition: any;
    rating: number;
    popularity: number;
}