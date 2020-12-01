
/**
 *  Interface for list of collections or documents to store and provide
 * 
 *  - IMCollections: top level items User, Plans, Recipies, etc
 *  - IMRecipe: recipe type document
 */
export interface IMCollections {
    id: string | number;
    tenant?: string;                // This is probably at a higher level not here
    name: string;
    description: string;
}

export interface IMRecipe {
    id: string | number;
    name: string;
    description: string;
    steps: { [key: number]: {id: string; rank: number; name: string; details: string} };
    media: string;
    ingridients: { [key: number]: {id: any; name: string; quantity: number; unit: string} };
    background: {history: string; region: string; cusine: string};
    nutrition: any;
    rating: number;
    popularity: number;
    reviews: { [key: number]: {id: string; author: string; description: string; rating: number} };
}

export interface IMRecipeItem {
    id: string | number;
    name: string;
    nutrition: any;
    rating: number;
    popularity: number;
}

export interface IMPlans {
    id: string | number;
    name: string;
    description: string;
    details: {duration: string, price: number, description: string}
}

export interface IMAccounts {
    id: string | number;
    name: string;
    description: string;
}