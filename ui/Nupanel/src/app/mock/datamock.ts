import { IMCollections, IMPlans, IMRecipeItem } from 'src/app/mock/idata-models';
import { IMRecipe } from 'src/app/models/recipes'

export const NUCOLLECTIONS: IMCollections[] = [
    //{id: 100, name: 'TBD', description: 'Manage user accounts'},
    {id: 101, name: 'Plans', description: 'Manage plan offerings for service'},
    {id: 102, name: 'Recipes', description: 'Recips hub for adding or removing recipes'}
    //{id: 103, name: 'TBD', description: 'Define meals'}

]

export const NUPLANS: IMPlans[] = [
    {id: 1000, name: 'plan1', description: 'asdfsafsadfas sf asd fsa dfs', details: 
        {duration: '1 week', price: 250, description: 'aas'}},
    {id: 1001, name: 'plan1', description: 'asdfsafsadfas sf asd fsa dfs', details: 
        {duration: '1 week', price: 350, description: 'aas'}},
    {id: 1002, name: 'plan1', description: 'asdfsafsadfas sf asd fsa dfs', details: 
        {duration: '1 week', price: 450, description: 'aas'}},
    {id: 1003, name: 'plan1', description: 'asdfsafsadfas sf asd fsa dfs', details: 
        {duration: '1 week', price: 550, description: 'aas'}}
]

export const RECIPES: IMRecipe[] = [
    { id: 10000, name: 'Chicken Under a Brick', description: 'It isn\'t easy to cook chicken so that its skin is crisp and its interior juicy. Grilling, roasting and sauteing all have their problems. But there is an effective and easy method for getting it right, using two ovenproof skillets.', 
        media: '', rating: 3, popularity: 3, 
        background: { history: '', region: 'southern', cusine: 'italian' },
        ingridients: [
            {id: '', name: 'chicken', quantity: 1, weight: 4, unit: 'Lb'},
            {id: '', name: 'rosemary', quantity: 120, weight: 10, unit: 'g'},
            {id: '', name: 'salt and pepper', quantity: 20, weight: 10, unit: 'g'},
            {id: '', name: 'garlic', quantity: 30, weight: 20, unit: 'g'},
            {id: '', name: 'extra virgin olive oil', quantity: 1, weight: 15, unit: 'ml'},
            {id: '', name: 'lemon', quantity: 1, weight: 20, unit: 'g'}
        ],
        nutrition: {calories: 840, carbs: 45},
        steps: [
            {id: '', rank: 1, name: '', details: 'whole hicken, trimmed of excess fat, rinsed, dried and split, backbone removed).'},
            {id: '', rank: 2, name: '', details: 'fresh minced rosemary or 1 teaspoon dried rosemary'},
            {id: '', rank: 3, name: '', details: 'Salt and freshly ground black pepper to taste'},
            {id: '', rank: 4, name: '', details: 'peeled and coarsely chopped garlic'},
            {id: '', rank: 5, name: '', details: 'sprigs fresh rosemary, optional'},
            {id: '', rank: 6, name: '', details: 'lemon, cut into quarters'}
        ],
        directions: [
            {id: '', rank: 1, name: '', details: 'Place the chicken on a cutting board, skin side down, and using your hands, press down hard to make it as flat as possible. Mix together the rosemary leaves, salt, pepper, garlic and 1 tablespoon of the olive oil, and rub this all over the chicken. Tuck some of the mixture under the skin as well. If time permits, cover and marinate in the refrigerator for up to a day (even 20 minutes of marinating boosts the flavor).'},
            {id: '', rank: 2, name: '', details: 'When you are ready to cook, preheat the oven to 500 degrees. Preheat an ovenproof 12-inch skillet (preferably nonstick) over medium-high heat for about 3 minutes. Press rosemary sprigs, if using, into the skin side of the chicken. Put remaining olive oil in the pan and wait about 30 seconds for it to heat up.'},
            {id: '', rank: 3, name: '', details: 'Place the chicken in the skillet, skin side down, along with any remaining pieces of rosemary and garlic; weight it with another skillet or with one or two bricks or rocks, wrapped in aluminum foil. The idea is to flatten the chicken by applying weight evenly over its surface.'},
            {id: '', rank: 4, name: '', details: 'Cook over medium-high to high heat for 5 minutes, then transfer to the oven. Roast for 15 minutes more. Remove from the oven and remove the weights; turn the chicken over (it will now be skin side up) and roast 10 minutes more, or until done (large chickens may take an additional 5 minutes or so). Serve hot or at room temperature, with lemon wedges.'}
        ]
    },
    { id: 10000, name: 'Chicken Under a Brick', description: 'It isn\'t easy to cook chicken so that its skin is crisp and its interior juicy. Grilling, roasting and sauteing all have their problems. But there is an effective and easy method for getting it right, using two ovenproof skillets.', 
        media: '', rating: 3, popularity: 3, 
        background: { history: '', region: '', cusine: '' },
        ingridients: [
            {id: '', name: 'chicken', quantity: 1, weight: 4, unit: 'Lb'},
            {id: '', name: 'rosemary', quantity: 120, weight: 10, unit: 'g'},
            {id: '', name: 'salt and pepper', quantity: 20, weight: 10, unit: 'g'},
            {id: '', name: 'garlic', quantity: 30, weight: 20, unit: 'g'},
            {id: '', name: 'extra virgin olive oil', quantity: 1, weight: 15, unit: 'ml'},
            {id: '', name: 'lemon', quantity: 1, weight: 20, unit: 'g'}
        ],
        nutrition: {calories: 840, carbs: 45},
        steps: [
            {id: '', rank: 1, name: '', details: 'whole hicken, trimmed of excess fat, rinsed, dried and split, backbone removed).'},
            {id: '', rank: 2, name: '', details: 'fresh minced rosemary or 1 teaspoon dried rosemary'},
            {id: '', rank: 3, name: '', details: 'Salt and freshly ground black pepper to taste'},
            {id: '', rank: 4, name: '', details: 'peeled and coarsely chopped garlic'},
            {id: '', rank: 5, name: '', details: 'sprigs fresh rosemary, optional'},
            {id: '', rank: 6, name: '', details: 'lemon, cut into quarters'}
        ],
        directions: [
            {id: '', rank: 1, name: '', details: 'Place the chicken on a cutting board, skin side down, and using your hands, press down hard to make it as flat as possible. Mix together the rosemary leaves, salt, pepper, garlic and 1 tablespoon of the olive oil, and rub this all over the chicken. Tuck some of the mixture under the skin as well. If time permits, cover and marinate in the refrigerator for up to a day (even 20 minutes of marinating boosts the flavor).'},
            {id: '', rank: 2, name: '', details: 'When you are ready to cook, preheat the oven to 500 degrees. Preheat an ovenproof 12-inch skillet (preferably nonstick) over medium-high heat for about 3 minutes. Press rosemary sprigs, if using, into the skin side of the chicken. Put remaining olive oil in the pan and wait about 30 seconds for it to heat up.            '},
            {id: '', rank: 3, name: '', details: 'Place the chicken in the skillet, skin side down, along with any remaining pieces of rosemary and garlic; weight it with another skillet or with one or two bricks or rocks, wrapped in aluminum foil. The idea is to flatten the chicken by applying weight evenly over its surface.'},
            {id: '', rank: 4, name: '', details: 'Cook over medium-high to high heat for 5 minutes, then transfer to the oven. Roast for 15 minutes more. Remove from the oven and remove the weights; turn the chicken over (it will now be skin side up) and roast 10 minutes more, or until done (large chickens may take an additional 5 minutes or so). Serve hot or at room temperature, with lemon wedges.'}
        ]
    },
    { id: 10000, name: 'Chicken Under a Brick', description: 'It isn\'t easy to cook chicken so that its skin is crisp and its interior juicy. Grilling, roasting and sauteing all have their problems. But there is an effective and easy method for getting it right, using two ovenproof skillets.', 
        media: '', rating: 3, popularity: 3, 
        background: { history: '', region: '', cusine: '' },
        ingridients: [
            {id: '', name: 'chicken', quantity: 1, weight: 4, unit: 'Lb'},
            {id: '', name: 'rosemary', quantity: 120, weight: 10, unit: 'g'},
            {id: '', name: 'salt and pepper', quantity: 20, weight: 10, unit: 'g'},
            {id: '', name: 'garlic', quantity: 30, weight: 20, unit: 'g'},
            {id: '', name: 'extra virgin olive oil', quantity: 1, weight: 15, unit: 'ml'},
            {id: '', name: 'lemon', quantity: 1, weight: 20, unit: 'g'}
        ],
        nutrition: {calories: 840, carbs: 45},
        steps: [
            {id: '', rank: 1, name: '', details: 'whole hicken, trimmed of excess fat, rinsed, dried and split, backbone removed).'},
            {id: '', rank: 2, name: '', details: 'fresh minced rosemary or 1 teaspoon dried rosemary'},
            {id: '', rank: 3, name: '', details: 'Salt and freshly ground black pepper to taste'},
            {id: '', rank: 4, name: '', details: 'peeled and coarsely chopped garlic'},
            {id: '', rank: 5, name: '', details: 'sprigs fresh rosemary, optional'},
            {id: '', rank: 6, name: '', details: 'lemon, cut into quarters'}
        ],
        directions: [
            {id: '', rank: 1, name: '', details: 'Place the chicken on a cutting board, skin side down, and using your hands, press down hard to make it as flat as possible. Mix together the rosemary leaves, salt, pepper, garlic and 1 tablespoon of the olive oil, and rub this all over the chicken. Tuck some of the mixture under the skin as well. If time permits, cover and marinate in the refrigerator for up to a day (even 20 minutes of marinating boosts the flavor).'},
            {id: '', rank: 2, name: '', details: 'When you are ready to cook, preheat the oven to 500 degrees. Preheat an ovenproof 12-inch skillet (preferably nonstick) over medium-high heat for about 3 minutes. Press rosemary sprigs, if using, into the skin side of the chicken. Put remaining olive oil in the pan and wait about 30 seconds for it to heat up.            '},
            {id: '', rank: 3, name: '', details: 'Place the chicken in the skillet, skin side down, along with any remaining pieces of rosemary and garlic; weight it with another skillet or with one or two bricks or rocks, wrapped in aluminum foil. The idea is to flatten the chicken by applying weight evenly over its surface.'},
            {id: '', rank: 4, name: '', details: 'Cook over medium-high to high heat for 5 minutes, then transfer to the oven. Roast for 15 minutes more. Remove from the oven and remove the weights; turn the chicken over (it will now be skin side up) and roast 10 minutes more, or until done (large chickens may take an additional 5 minutes or so). Serve hot or at room temperature, with lemon wedges.'}
        ]
    },
    { id: 10000, name: 'Chicken Under a Brick', description: 'It isn\'t easy to cook chicken so that its skin is crisp and its interior juicy. Grilling, roasting and sauteing all have their problems. But there is an effective and easy method for getting it right, using two ovenproof skillets.', 
        media: '', rating: 3, popularity: 3, 
        background: { history: '', region: '', cusine: '' },
        ingridients: [
            {id: '', name: 'chicken', quantity: 1, weight: 4, unit: 'Lb'},
            {id: '', name: 'rosemary', quantity: 120, weight: 10, unit: 'g'},
            {id: '', name: 'salt and pepper', quantity: 20, weight: 10, unit: 'g'},
            {id: '', name: 'garlic', quantity: 30, weight: 20, unit: 'g'},
            {id: '', name: 'extra virgin olive oil', quantity: 1, weight: 15, unit: 'ml'},
            {id: '', name: 'lemon', quantity: 1, weight: 20, unit: 'g'}
        ],
        nutrition: {calories: 840, carbs: 45},
        steps: [
            {id: '', rank: 1, name: '', details: 'whole hicken, trimmed of excess fat, rinsed, dried and split, backbone removed).'},
            {id: '', rank: 2, name: '', details: 'fresh minced rosemary or 1 teaspoon dried rosemary'},
            {id: '', rank: 3, name: '', details: 'Salt and freshly ground black pepper to taste'},
            {id: '', rank: 4, name: '', details: 'peeled and coarsely chopped garlic'},
            {id: '', rank: 5, name: '', details: 'sprigs fresh rosemary, optional'},
            {id: '', rank: 6, name: '', details: 'lemon, cut into quarters'}
        ],
        directions: [
            {id: '', rank: 1, name: '', details: 'Place the chicken on a cutting board, skin side down, and using your hands, press down hard to make it as flat as possible. Mix together the rosemary leaves, salt, pepper, garlic and 1 tablespoon of the olive oil, and rub this all over the chicken. Tuck some of the mixture under the skin as well. If time permits, cover and marinate in the refrigerator for up to a day (even 20 minutes of marinating boosts the flavor).'},
            {id: '', rank: 2, name: '', details: 'When you are ready to cook, preheat the oven to 500 degrees. Preheat an ovenproof 12-inch skillet (preferably nonstick) over medium-high heat for about 3 minutes. Press rosemary sprigs, if using, into the skin side of the chicken. Put remaining olive oil in the pan and wait about 30 seconds for it to heat up.            '},
            {id: '', rank: 3, name: '', details: 'Place the chicken in the skillet, skin side down, along with any remaining pieces of rosemary and garlic; weight it with another skillet or with one or two bricks or rocks, wrapped in aluminum foil. The idea is to flatten the chicken by applying weight evenly over its surface.'},
            {id: '', rank: 4, name: '', details: 'Cook over medium-high to high heat for 5 minutes, then transfer to the oven. Roast for 15 minutes more. Remove from the oven and remove the weights; turn the chicken over (it will now be skin side up) and roast 10 minutes more, or until done (large chickens may take an additional 5 minutes or so). Serve hot or at room temperature, with lemon wedges.'}
        ]
    },
    { id: 10000, name: 'Chicken Under a Brick', description: 'It isn\'t easy to cook chicken so that its skin is crisp and its interior juicy. Grilling, roasting and sauteing all have their problems. But there is an effective and easy method for getting it right, using two ovenproof skillets.', 
        media: '', rating: 3, popularity: 3, 
        background: { history: '', region: '', cusine: '' },
        ingridients: [
            {id: '', name: 'chicken', quantity: 1, weight: 4, unit: 'Lb'},
            {id: '', name: 'rosemary', quantity: 120, weight: 10, unit: 'g'},
            {id: '', name: 'salt and pepper', quantity: 20, weight: 10, unit: 'g'},
            {id: '', name: 'garlic', quantity: 30, weight: 20, unit: 'g'},
            {id: '', name: 'extra virgin olive oil', quantity: 1, weight: 15, unit: 'ml'},
            {id: '', name: 'lemon', quantity: 1, weight: 20, unit: 'g'}
        ],
        nutrition: {calories: 840, carbs: 45},
        steps: [
            {id: '', rank: 1, name: '', details: 'whole hicken, trimmed of excess fat, rinsed, dried and split, backbone removed).'},
            {id: '', rank: 2, name: '', details: 'fresh minced rosemary or 1 teaspoon dried rosemary'},
            {id: '', rank: 3, name: '', details: 'Salt and freshly ground black pepper to taste'},
            {id: '', rank: 4, name: '', details: 'peeled and coarsely chopped garlic'},
            {id: '', rank: 5, name: '', details: 'sprigs fresh rosemary, optional'},
            {id: '', rank: 6, name: '', details: 'lemon, cut into quarters'}
        ],
        directions: [
            {id: '', rank: 1, name: '', details: 'Place the chicken on a cutting board, skin side down, and using your hands, press down hard to make it as flat as possible. Mix together the rosemary leaves, salt, pepper, garlic and 1 tablespoon of the olive oil, and rub this all over the chicken. Tuck some of the mixture under the skin as well. If time permits, cover and marinate in the refrigerator for up to a day (even 20 minutes of marinating boosts the flavor).'},
            {id: '', rank: 2, name: '', details: 'When you are ready to cook, preheat the oven to 500 degrees. Preheat an ovenproof 12-inch skillet (preferably nonstick) over medium-high heat for about 3 minutes. Press rosemary sprigs, if using, into the skin side of the chicken. Put remaining olive oil in the pan and wait about 30 seconds for it to heat up.            '},
            {id: '', rank: 3, name: '', details: 'Place the chicken in the skillet, skin side down, along with any remaining pieces of rosemary and garlic; weight it with another skillet or with one or two bricks or rocks, wrapped in aluminum foil. The idea is to flatten the chicken by applying weight evenly over its surface.'},
            {id: '', rank: 4, name: '', details: 'Cook over medium-high to high heat for 5 minutes, then transfer to the oven. Roast for 15 minutes more. Remove from the oven and remove the weights; turn the chicken over (it will now be skin side up) and roast 10 minutes more, or until done (large chickens may take an additional 5 minutes or so). Serve hot or at room temperature, with lemon wedges.'}
        ]
    },
    { id: 10000, name: 'Chicken Under a Brick', description: 'It isn\'t easy to cook chicken so that its skin is crisp and its interior juicy. Grilling, roasting and sauteing all have their problems. But there is an effective and easy method for getting it right, using two ovenproof skillets.', 
        media: '', rating: 3, popularity: 3, 
        background: { history: '', region: '', cusine: '' },
        ingridients: [
            {id: '', name: 'chicken', quantity: 1, weight: 4, unit: 'Lb'},
            {id: '', name: 'rosemary', quantity: 120, weight: 10, unit: 'g'},
            {id: '', name: 'salt and pepper', quantity: 20, weight: 10, unit: 'g'},
            {id: '', name: 'garlic', quantity: 30, weight: 20, unit: 'g'},
            {id: '', name: 'extra virgin olive oil', quantity: 1, weight: 15, unit: 'ml'},
            {id: '', name: 'lemon', quantity: 1, weight: 20, unit: 'g'}
        ],
        nutrition: {calories: 840, carbs: 45},
        steps: [
            {id: '', rank: 1, name: '', details: 'whole hicken, trimmed of excess fat, rinsed, dried and split, backbone removed).'},
            {id: '', rank: 2, name: '', details: 'fresh minced rosemary or 1 teaspoon dried rosemary'},
            {id: '', rank: 3, name: '', details: 'Salt and freshly ground black pepper to taste'},
            {id: '', rank: 4, name: '', details: 'peeled and coarsely chopped garlic'},
            {id: '', rank: 5, name: '', details: 'sprigs fresh rosemary, optional'},
            {id: '', rank: 6, name: '', details: 'lemon, cut into quarters'}
        ],
        directions: [
            {id: '', rank: 1, name: '', details: 'Place the chicken on a cutting board, skin side down, and using your hands, press down hard to make it as flat as possible. Mix together the rosemary leaves, salt, pepper, garlic and 1 tablespoon of the olive oil, and rub this all over the chicken. Tuck some of the mixture under the skin as well. If time permits, cover and marinate in the refrigerator for up to a day (even 20 minutes of marinating boosts the flavor).'},
            {id: '', rank: 2, name: '', details: 'When you are ready to cook, preheat the oven to 500 degrees. Preheat an ovenproof 12-inch skillet (preferably nonstick) over medium-high heat for about 3 minutes. Press rosemary sprigs, if using, into the skin side of the chicken. Put remaining olive oil in the pan and wait about 30 seconds for it to heat up.            '},
            {id: '', rank: 3, name: '', details: 'Place the chicken in the skillet, skin side down, along with any remaining pieces of rosemary and garlic; weight it with another skillet or with one or two bricks or rocks, wrapped in aluminum foil. The idea is to flatten the chicken by applying weight evenly over its surface.'},
            {id: '', rank: 4, name: '', details: 'Cook over medium-high to high heat for 5 minutes, then transfer to the oven. Roast for 15 minutes more. Remove from the oven and remove the weights; turn the chicken over (it will now be skin side up) and roast 10 minutes more, or until done (large chickens may take an additional 5 minutes or so). Serve hot or at room temperature, with lemon wedges.'}
        ]
    },
    { id: 10000, name: 'Chicken Under a Brick', description: 'It isn\'t easy to cook chicken so that its skin is crisp and its interior juicy. Grilling, roasting and sauteing all have their problems. But there is an effective and easy method for getting it right, using two ovenproof skillets.', 
        media: '', rating: 3, popularity: 3, 
        background: { history: '', region: '', cusine: '' },
        ingridients: [
            {id: '', name: 'chicken', quantity: 1, weight: 4, unit: 'Lb'},
            {id: '', name: 'rosemary', quantity: 120, weight: 10, unit: 'g'},
            {id: '', name: 'salt and pepper', quantity: 20, weight: 10, unit: 'g'},
            {id: '', name: 'garlic', quantity: 30, weight: 20, unit: 'g'},
            {id: '', name: 'extra virgin olive oil', quantity: 1, weight: 15, unit: 'ml'},
            {id: '', name: 'lemon', quantity: 1, weight: 20, unit: 'g'}
        ],
        nutrition: {calories: 840, carbs: 45},
        steps: [
            {id: '', rank: 1, name: '', details: 'whole hicken, trimmed of excess fat, rinsed, dried and split, backbone removed).'},
            {id: '', rank: 2, name: '', details: 'fresh minced rosemary or 1 teaspoon dried rosemary'},
            {id: '', rank: 3, name: '', details: 'Salt and freshly ground black pepper to taste'},
            {id: '', rank: 4, name: '', details: 'peeled and coarsely chopped garlic'},
            {id: '', rank: 5, name: '', details: 'sprigs fresh rosemary, optional'},
            {id: '', rank: 6, name: '', details: 'lemon, cut into quarters'}
        ],
        directions: [
            {id: '', rank: 1, name: '', details: 'Place the chicken on a cutting board, skin side down, and using your hands, press down hard to make it as flat as possible. Mix together the rosemary leaves, salt, pepper, garlic and 1 tablespoon of the olive oil, and rub this all over the chicken. Tuck some of the mixture under the skin as well. If time permits, cover and marinate in the refrigerator for up to a day (even 20 minutes of marinating boosts the flavor).'},
            {id: '', rank: 2, name: '', details: 'When you are ready to cook, preheat the oven to 500 degrees. Preheat an ovenproof 12-inch skillet (preferably nonstick) over medium-high heat for about 3 minutes. Press rosemary sprigs, if using, into the skin side of the chicken. Put remaining olive oil in the pan and wait about 30 seconds for it to heat up.            '},
            {id: '', rank: 3, name: '', details: 'Place the chicken in the skillet, skin side down, along with any remaining pieces of rosemary and garlic; weight it with another skillet or with one or two bricks or rocks, wrapped in aluminum foil. The idea is to flatten the chicken by applying weight evenly over its surface.'},
            {id: '', rank: 4, name: '', details: 'Cook over medium-high to high heat for 5 minutes, then transfer to the oven. Roast for 15 minutes more. Remove from the oven and remove the weights; turn the chicken over (it will now be skin side up) and roast 10 minutes more, or until done (large chickens may take an additional 5 minutes or so). Serve hot or at room temperature, with lemon wedges.'}
        ]
    },
    { id: 10000, name: 'Chicken Under a Brick', description: 'It isn\'t easy to cook chicken so that its skin is crisp and its interior juicy. Grilling, roasting and sauteing all have their problems. But there is an effective and easy method for getting it right, using two ovenproof skillets.', 
        media: '', rating: 3, popularity: 3, 
        background: { history: '', region: '', cusine: '' },
        ingridients: [
            {id: '', name: 'chicken', quantity: 1, weight: 4, unit: 'Lb'},
            {id: '', name: 'rosemary', quantity: 120, weight: 10, unit: 'g'},
            {id: '', name: 'salt and pepper', quantity: 20, weight: 10, unit: 'g'},
            {id: '', name: 'garlic', quantity: 30, weight: 20, unit: 'g'},
            {id: '', name: 'extra virgin olive oil', quantity: 1, weight: 15, unit: 'ml'},
            {id: '', name: 'lemon', quantity: 1, weight: 20, unit: 'g'}
        ],
        nutrition: {calories: 840, carbs: 45},
        steps: [
            {id: '', rank: 1, name: '', details: 'whole hicken, trimmed of excess fat, rinsed, dried and split, backbone removed).'},
            {id: '', rank: 2, name: '', details: 'fresh minced rosemary or 1 teaspoon dried rosemary'},
            {id: '', rank: 3, name: '', details: 'Salt and freshly ground black pepper to taste'},
            {id: '', rank: 4, name: '', details: 'peeled and coarsely chopped garlic'},
            {id: '', rank: 5, name: '', details: 'sprigs fresh rosemary, optional'},
            {id: '', rank: 6, name: '', details: 'lemon, cut into quarters'}
        ],
        directions: [
            {id: '', rank: 1, name: '', details: 'Place the chicken on a cutting board, skin side down, and using your hands, press down hard to make it as flat as possible. Mix together the rosemary leaves, salt, pepper, garlic and 1 tablespoon of the olive oil, and rub this all over the chicken. Tuck some of the mixture under the skin as well. If time permits, cover and marinate in the refrigerator for up to a day (even 20 minutes of marinating boosts the flavor).'},
            {id: '', rank: 2, name: '', details: 'When you are ready to cook, preheat the oven to 500 degrees. Preheat an ovenproof 12-inch skillet (preferably nonstick) over medium-high heat for about 3 minutes. Press rosemary sprigs, if using, into the skin side of the chicken. Put remaining olive oil in the pan and wait about 30 seconds for it to heat up.            '},
            {id: '', rank: 3, name: '', details: 'Place the chicken in the skillet, skin side down, along with any remaining pieces of rosemary and garlic; weight it with another skillet or with one or two bricks or rocks, wrapped in aluminum foil. The idea is to flatten the chicken by applying weight evenly over its surface.'},
            {id: '', rank: 4, name: '', details: 'Cook over medium-high to high heat for 5 minutes, then transfer to the oven. Roast for 15 minutes more. Remove from the oven and remove the weights; turn the chicken over (it will now be skin side up) and roast 10 minutes more, or until done (large chickens may take an additional 5 minutes or so). Serve hot or at room temperature, with lemon wedges.'}
        ]
    },
    { id: 10000, name: 'Chicken Under a Brick', description: 'It isn\'t easy to cook chicken so that its skin is crisp and its interior juicy. Grilling, roasting and sauteing all have their problems. But there is an effective and easy method for getting it right, using two ovenproof skillets.', 
        media: '', rating: 3, popularity: 3, 
        background: { history: '', region: '', cusine: '' },
        ingridients: [
            {id: '', name: 'chicken', quantity: 1, weight: 4, unit: 'Lb'},
            {id: '', name: 'rosemary', quantity: 120, weight: 10, unit: 'g'},
            {id: '', name: 'salt and pepper', quantity: 20, weight: 10, unit: 'g'},
            {id: '', name: 'garlic', quantity: 30, weight: 20, unit: 'g'},
            {id: '', name: 'extra virgin olive oil', quantity: 1, weight: 15, unit: 'ml'},
            {id: '', name: 'lemon', quantity: 1, weight: 20, unit: 'g'}
        ],
        nutrition: {calories: 840, carbs: 45},
        steps: [
            {id: '', rank: 1, name: '', details: 'whole hicken, trimmed of excess fat, rinsed, dried and split, backbone removed).'},
            {id: '', rank: 2, name: '', details: 'fresh minced rosemary or 1 teaspoon dried rosemary'},
            {id: '', rank: 3, name: '', details: 'Salt and freshly ground black pepper to taste'},
            {id: '', rank: 4, name: '', details: 'peeled and coarsely chopped garlic'},
            {id: '', rank: 5, name: '', details: 'sprigs fresh rosemary, optional'},
            {id: '', rank: 6, name: '', details: 'lemon, cut into quarters'}
        ],
        directions: [
            {id: '', rank: 1, name: '', details: 'Place the chicken on a cutting board, skin side down, and using your hands, press down hard to make it as flat as possible. Mix together the rosemary leaves, salt, pepper, garlic and 1 tablespoon of the olive oil, and rub this all over the chicken. Tuck some of the mixture under the skin as well. If time permits, cover and marinate in the refrigerator for up to a day (even 20 minutes of marinating boosts the flavor).'},
            {id: '', rank: 2, name: '', details: 'When you are ready to cook, preheat the oven to 500 degrees. Preheat an ovenproof 12-inch skillet (preferably nonstick) over medium-high heat for about 3 minutes. Press rosemary sprigs, if using, into the skin side of the chicken. Put remaining olive oil in the pan and wait about 30 seconds for it to heat up.            '},
            {id: '', rank: 3, name: '', details: 'Place the chicken in the skillet, skin side down, along with any remaining pieces of rosemary and garlic; weight it with another skillet or with one or two bricks or rocks, wrapped in aluminum foil. The idea is to flatten the chicken by applying weight evenly over its surface.'},
            {id: '', rank: 4, name: '', details: 'Cook over medium-high to high heat for 5 minutes, then transfer to the oven. Roast for 15 minutes more. Remove from the oven and remove the weights; turn the chicken over (it will now be skin side up) and roast 10 minutes more, or until done (large chickens may take an additional 5 minutes or so). Serve hot or at room temperature, with lemon wedges.'}
        ]
    },
    { id: 10000, name: 'Chicken Under a Brick', description: 'It isn\'t easy to cook chicken so that its skin is crisp and its interior juicy. Grilling, roasting and sauteing all have their problems. But there is an effective and easy method for getting it right, using two ovenproof skillets.', 
        media: '', rating: 3, popularity: 3, 
        background: { history: '', region: '', cusine: '' },
        ingridients: [
            {id: '', name: 'chicken', quantity: 1, weight: 4, unit: 'Lb'},
            {id: '', name: 'rosemary', quantity: 120, weight: 10, unit: 'g'},
            {id: '', name: 'salt and pepper', quantity: 20, weight: 10, unit: 'g'},
            {id: '', name: 'garlic', quantity: 30, weight: 20, unit: 'g'},
            {id: '', name: 'extra virgin olive oil', quantity: 1, weight: 15, unit: 'ml'},
            {id: '', name: 'lemon', quantity: 1, weight: 20, unit: 'g'}
        ],
        nutrition: {calories: 840, carbs: 45},
        steps: [
            {id: '', rank: 1, name: '', details: 'whole hicken, trimmed of excess fat, rinsed, dried and split, backbone removed).'},
            {id: '', rank: 2, name: '', details: 'fresh minced rosemary or 1 teaspoon dried rosemary'},
            {id: '', rank: 3, name: '', details: 'Salt and freshly ground black pepper to taste'},
            {id: '', rank: 4, name: '', details: 'peeled and coarsely chopped garlic'},
            {id: '', rank: 5, name: '', details: 'sprigs fresh rosemary, optional'},
            {id: '', rank: 6, name: '', details: 'lemon, cut into quarters'}
        ],
        directions: [
            {id: '', rank: 1, name: '', details: 'Place the chicken on a cutting board, skin side down, and using your hands, press down hard to make it as flat as possible. Mix together the rosemary leaves, salt, pepper, garlic and 1 tablespoon of the olive oil, and rub this all over the chicken. Tuck some of the mixture under the skin as well. If time permits, cover and marinate in the refrigerator for up to a day (even 20 minutes of marinating boosts the flavor).'},
            {id: '', rank: 2, name: '', details: 'When you are ready to cook, preheat the oven to 500 degrees. Preheat an ovenproof 12-inch skillet (preferably nonstick) over medium-high heat for about 3 minutes. Press rosemary sprigs, if using, into the skin side of the chicken. Put remaining olive oil in the pan and wait about 30 seconds for it to heat up.            '},
            {id: '', rank: 3, name: '', details: 'Place the chicken in the skillet, skin side down, along with any remaining pieces of rosemary and garlic; weight it with another skillet or with one or two bricks or rocks, wrapped in aluminum foil. The idea is to flatten the chicken by applying weight evenly over its surface.'},
            {id: '', rank: 4, name: '', details: 'Cook over medium-high to high heat for 5 minutes, then transfer to the oven. Roast for 15 minutes more. Remove from the oven and remove the weights; turn the chicken over (it will now be skin side up) and roast 10 minutes more, or until done (large chickens may take an additional 5 minutes or so). Serve hot or at room temperature, with lemon wedges.'}
        ]
    },
    { id: 10000, name: 'Chicken Under a Brick', description: 'It isn\'t easy to cook chicken so that its skin is crisp and its interior juicy. Grilling, roasting and sauteing all have their problems. But there is an effective and easy method for getting it right, using two ovenproof skillets.', 
        media: '', rating: 3, popularity: 3, 
        background: { history: '', region: '', cusine: '' },
        ingridients: [
            {id: '', name: 'chicken', quantity: 1, weight: 4, unit: 'Lb'},
            {id: '', name: 'rosemary', quantity: 120, weight: 10, unit: 'g'},
            {id: '', name: 'salt and pepper', quantity: 20, weight: 10, unit: 'g'},
            {id: '', name: 'garlic', quantity: 30, weight: 20, unit: 'g'},
            {id: '', name: 'extra virgin olive oil', quantity: 1, weight: 15, unit: 'ml'},
            {id: '', name: 'lemon', quantity: 1, weight: 20, unit: 'g'}
        ],
        nutrition: {calories: 840, carbs: 45},
        steps: [
            {id: '', rank: 1, name: '', details: 'whole hicken, trimmed of excess fat, rinsed, dried and split, backbone removed).'},
            {id: '', rank: 2, name: '', details: 'fresh minced rosemary or 1 teaspoon dried rosemary'},
            {id: '', rank: 3, name: '', details: 'Salt and freshly ground black pepper to taste'},
            {id: '', rank: 4, name: '', details: 'peeled and coarsely chopped garlic'},
            {id: '', rank: 5, name: '', details: 'sprigs fresh rosemary, optional'},
            {id: '', rank: 6, name: '', details: 'lemon, cut into quarters'}
        ],
        directions: [
            {id: '', rank: 1, name: '', details: 'Place the chicken on a cutting board, skin side down, and using your hands, press down hard to make it as flat as possible. Mix together the rosemary leaves, salt, pepper, garlic and 1 tablespoon of the olive oil, and rub this all over the chicken. Tuck some of the mixture under the skin as well. If time permits, cover and marinate in the refrigerator for up to a day (even 20 minutes of marinating boosts the flavor).'},
            {id: '', rank: 2, name: '', details: 'When you are ready to cook, preheat the oven to 500 degrees. Preheat an ovenproof 12-inch skillet (preferably nonstick) over medium-high heat for about 3 minutes. Press rosemary sprigs, if using, into the skin side of the chicken. Put remaining olive oil in the pan and wait about 30 seconds for it to heat up.            '},
            {id: '', rank: 3, name: '', details: 'Place the chicken in the skillet, skin side down, along with any remaining pieces of rosemary and garlic; weight it with another skillet or with one or two bricks or rocks, wrapped in aluminum foil. The idea is to flatten the chicken by applying weight evenly over its surface.'},
            {id: '', rank: 4, name: '', details: 'Cook over medium-high to high heat for 5 minutes, then transfer to the oven. Roast for 15 minutes more. Remove from the oven and remove the weights; turn the chicken over (it will now be skin side up) and roast 10 minutes more, or until done (large chickens may take an additional 5 minutes or so). Serve hot or at room temperature, with lemon wedges.'}
        ]
    },
    { id: 10000, name: 'Chicken Under a Brick', description: 'It isn\'t easy to cook chicken so that its skin is crisp and its interior juicy. Grilling, roasting and sauteing all have their problems. But there is an effective and easy method for getting it right, using two ovenproof skillets.', 
        media: '', rating: 3, popularity: 3, 
        background: { history: '', region: '', cusine: '' },
        ingridients: [
            {id: '', name: 'chicken', quantity: 1, weight: 4, unit: 'Lb'},
            {id: '', name: 'rosemary', quantity: 120, weight: 10, unit: 'g'},
            {id: '', name: 'salt and pepper', quantity: 20, weight: 10, unit: 'g'},
            {id: '', name: 'garlic', quantity: 30, weight: 20, unit: 'g'},
            {id: '', name: 'extra virgin olive oil', quantity: 1, weight: 15, unit: 'ml'},
            {id: '', name: 'lemon', quantity: 1, weight: 20, unit: 'g'}
        ],
        nutrition: {calories: 840, carbs: 45},
        steps: [
            {id: '', rank: 1, name: '', details: 'whole hicken, trimmed of excess fat, rinsed, dried and split, backbone removed).'},
            {id: '', rank: 2, name: '', details: 'fresh minced rosemary or 1 teaspoon dried rosemary'},
            {id: '', rank: 3, name: '', details: 'Salt and freshly ground black pepper to taste'},
            {id: '', rank: 4, name: '', details: 'peeled and coarsely chopped garlic'},
            {id: '', rank: 5, name: '', details: 'sprigs fresh rosemary, optional'},
            {id: '', rank: 6, name: '', details: 'lemon, cut into quarters'}
        ],
        directions: [
            {id: '', rank: 1, name: '', details: 'Place the chicken on a cutting board, skin side down, and using your hands, press down hard to make it as flat as possible. Mix together the rosemary leaves, salt, pepper, garlic and 1 tablespoon of the olive oil, and rub this all over the chicken. Tuck some of the mixture under the skin as well. If time permits, cover and marinate in the refrigerator for up to a day (even 20 minutes of marinating boosts the flavor).'},
            {id: '', rank: 2, name: '', details: 'When you are ready to cook, preheat the oven to 500 degrees. Preheat an ovenproof 12-inch skillet (preferably nonstick) over medium-high heat for about 3 minutes. Press rosemary sprigs, if using, into the skin side of the chicken. Put remaining olive oil in the pan and wait about 30 seconds for it to heat up.            '},
            {id: '', rank: 3, name: '', details: 'Place the chicken in the skillet, skin side down, along with any remaining pieces of rosemary and garlic; weight it with another skillet or with one or two bricks or rocks, wrapped in aluminum foil. The idea is to flatten the chicken by applying weight evenly over its surface.'},
            {id: '', rank: 4, name: '', details: 'Cook over medium-high to high heat for 5 minutes, then transfer to the oven. Roast for 15 minutes more. Remove from the oven and remove the weights; turn the chicken over (it will now be skin side up) and roast 10 minutes more, or until done (large chickens may take an additional 5 minutes or so). Serve hot or at room temperature, with lemon wedges.'}
        ]
    },
    { id: 10000, name: 'Lamb oven roasted', description: 'It isn\'t easy to cook chicken so that its skin is crisp and its interior juicy. Grilling, roasting and sauteing all have their problems. But there is an effective and easy method for getting it right, using two ovenproof skillets.', 
        media: '', rating: 3, popularity: 3, 
        background: { history: '', region: '', cusine: '' },
        ingridients: [
            {id: '', name: 'chicken', quantity: 1, weight: 4, unit: 'Lb'},
            {id: '', name: 'rosemary', quantity: 120, weight: 10, unit: 'g'},
            {id: '', name: 'salt and pepper', quantity: 20, weight: 10, unit: 'g'},
            {id: '', name: 'garlic', quantity: 30, weight: 20, unit: 'g'},
            {id: '', name: 'extra virgin olive oil', quantity: 1, weight: 15, unit: 'ml'},
            {id: '', name: 'lemon', quantity: 1, weight: 20, unit: 'g'}
        ],
        nutrition: {calories: 840, carbs: 45},
        steps: [
            {id: '', rank: 1, name: '', details: 'whole hicken, trimmed of excess fat, rinsed, dried and split, backbone removed).'},
            {id: '', rank: 2, name: '', details: 'fresh minced rosemary or 1 teaspoon dried rosemary'},
            {id: '', rank: 3, name: '', details: 'Salt and freshly ground black pepper to taste'},
            {id: '', rank: 4, name: '', details: 'peeled and coarsely chopped garlic'},
            {id: '', rank: 5, name: '', details: 'sprigs fresh rosemary, optional'},
            {id: '', rank: 6, name: '', details: 'lemon, cut into quarters'}
        ],
        directions: [
            {id: '', rank: 1, name: '', details: 'Place the chicken on a cutting board, skin side down, and using your hands, press down hard to make it as flat as possible. Mix together the rosemary leaves, salt, pepper, garlic and 1 tablespoon of the olive oil, and rub this all over the chicken. Tuck some of the mixture under the skin as well. If time permits, cover and marinate in the refrigerator for up to a day (even 20 minutes of marinating boosts the flavor).'},
            {id: '', rank: 2, name: '', details: 'When you are ready to cook, preheat the oven to 500 degrees. Preheat an ovenproof 12-inch skillet (preferably nonstick) over medium-high heat for about 3 minutes. Press rosemary sprigs, if using, into the skin side of the chicken. Put remaining olive oil in the pan and wait about 30 seconds for it to heat up.            '},
            {id: '', rank: 3, name: '', details: 'Place the chicken in the skillet, skin side down, along with any remaining pieces of rosemary and garlic; weight it with another skillet or with one or two bricks or rocks, wrapped in aluminum foil. The idea is to flatten the chicken by applying weight evenly over its surface.'},
            {id: '', rank: 4, name: '', details: 'Cook over medium-high to high heat for 5 minutes, then transfer to the oven. Roast for 15 minutes more. Remove from the oven and remove the weights; turn the chicken over (it will now be skin side up) and roast 10 minutes more, or until done (large chickens may take an additional 5 minutes or so). Serve hot or at room temperature, with lemon wedges.'}
        ]
    },
    { id: 10000, name: 'Parrillada', description: 'It isn\'t easy to cook chicken so that its skin is crisp and its interior juicy. Grilling, roasting and sauteing all have their problems. But there is an effective and easy method for getting it right, using two ovenproof skillets.', 
        media: '', rating: 3, popularity: 3, 
        background: { history: '', region: '', cusine: '' },
        ingridients: [
            {id: '', name: 'chicken', quantity: 1, weight: 4, unit: 'Lb'},
            {id: '', name: 'rosemary', quantity: 120, weight: 10, unit: 'g'},
            {id: '', name: 'salt and pepper', quantity: 20, weight: 10, unit: 'g'},
            {id: '', name: 'garlic', quantity: 30, weight: 20, unit: 'g'},
            {id: '', name: 'extra virgin olive oil', quantity: 1, weight: 15, unit: 'ml'},
            {id: '', name: 'lemon', quantity: 1, weight: 20, unit: 'g'}
        ],
        nutrition: {calories: 840, carbs: 45},
        steps: [
            {id: '', rank: 1, name: '', details: 'whole hicken, trimmed of excess fat, rinsed, dried and split, backbone removed).'},
            {id: '', rank: 2, name: '', details: 'fresh minced rosemary or 1 teaspoon dried rosemary'},
            {id: '', rank: 3, name: '', details: 'Salt and freshly ground black pepper to taste'},
            {id: '', rank: 4, name: '', details: 'peeled and coarsely chopped garlic'},
            {id: '', rank: 5, name: '', details: 'sprigs fresh rosemary, optional'},
            {id: '', rank: 6, name: '', details: 'lemon, cut into quarters'}
        ],
        directions: [
            {id: '', rank: 1, name: '', details: 'Place the chicken on a cutting board, skin side down, and using your hands, press down hard to make it as flat as possible. Mix together the rosemary leaves, salt, pepper, garlic and 1 tablespoon of the olive oil, and rub this all over the chicken. Tuck some of the mixture under the skin as well. If time permits, cover and marinate in the refrigerator for up to a day (even 20 minutes of marinating boosts the flavor).'},
            {id: '', rank: 2, name: '', details: 'When you are ready to cook, preheat the oven to 500 degrees. Preheat an ovenproof 12-inch skillet (preferably nonstick) over medium-high heat for about 3 minutes. Press rosemary sprigs, if using, into the skin side of the chicken. Put remaining olive oil in the pan and wait about 30 seconds for it to heat up.            '},
            {id: '', rank: 3, name: '', details: 'Place the chicken in the skillet, skin side down, along with any remaining pieces of rosemary and garlic; weight it with another skillet or with one or two bricks or rocks, wrapped in aluminum foil. The idea is to flatten the chicken by applying weight evenly over its surface.'},
            {id: '', rank: 4, name: '', details: 'Cook over medium-high to high heat for 5 minutes, then transfer to the oven. Roast for 15 minutes more. Remove from the oven and remove the weights; turn the chicken over (it will now be skin side up) and roast 10 minutes more, or until done (large chickens may take an additional 5 minutes or so). Serve hot or at room temperature, with lemon wedges.'}
        ]
    },
    { id: 10000, name: 'Pizza', description: 'It isn\'t easy to cook chicken so that its skin is crisp and its interior juicy. Grilling, roasting and sauteing all have their problems. But there is an effective and easy method for getting it right, using two ovenproof skillets.', 
        media: '', rating: 3, popularity: 3, 
        background: { history: '', region: '', cusine: '' },
        ingridients: [
            {id: '', name: 'chicken', quantity: 1, weight: 4, unit: 'Lb'},
            {id: '', name: 'rosemary', quantity: 120, weight: 10, unit: 'g'},
            {id: '', name: 'salt and pepper', quantity: 20, weight: 10, unit: 'g'},
            {id: '', name: 'garlic', quantity: 30, weight: 20, unit: 'g'},
            {id: '', name: 'extra virgin olive oil', quantity: 1, weight: 15, unit: 'ml'},
            {id: '', name: 'lemon', quantity: 1, weight: 20, unit: 'g'}
        ],
        nutrition: {calories: 840, carbs: 45},
        steps: [
            {id: '', rank: 1, name: '', details: 'whole hicken, trimmed of excess fat, rinsed, dried and split, backbone removed).'},
            {id: '', rank: 2, name: '', details: 'fresh minced rosemary or 1 teaspoon dried rosemary'},
            {id: '', rank: 3, name: '', details: 'Salt and freshly ground black pepper to taste'},
            {id: '', rank: 4, name: '', details: 'peeled and coarsely chopped garlic'},
            {id: '', rank: 5, name: '', details: 'sprigs fresh rosemary, optional'},
            {id: '', rank: 6, name: '', details: 'lemon, cut into quarters'}
        ],
        directions: [
            {id: '', rank: 1, name: '', details: 'Place the chicken on a cutting board, skin side down, and using your hands, press down hard to make it as flat as possible. Mix together the rosemary leaves, salt, pepper, garlic and 1 tablespoon of the olive oil, and rub this all over the chicken. Tuck some of the mixture under the skin as well. If time permits, cover and marinate in the refrigerator for up to a day (even 20 minutes of marinating boosts the flavor).'},
            {id: '', rank: 2, name: '', details: 'When you are ready to cook, preheat the oven to 500 degrees. Preheat an ovenproof 12-inch skillet (preferably nonstick) over medium-high heat for about 3 minutes. Press rosemary sprigs, if using, into the skin side of the chicken. Put remaining olive oil in the pan and wait about 30 seconds for it to heat up.            '},
            {id: '', rank: 3, name: '', details: 'Place the chicken in the skillet, skin side down, along with any remaining pieces of rosemary and garlic; weight it with another skillet or with one or two bricks or rocks, wrapped in aluminum foil. The idea is to flatten the chicken by applying weight evenly over its surface.'},
            {id: '', rank: 4, name: '', details: 'Cook over medium-high to high heat for 5 minutes, then transfer to the oven. Roast for 15 minutes more. Remove from the oven and remove the weights; turn the chicken over (it will now be skin side up) and roast 10 minutes more, or until done (large chickens may take an additional 5 minutes or so). Serve hot or at room temperature, with lemon wedges.'}
        ]
    }
]

export const RECIPEITEM: IMRecipeItem[] = [
    { id: '', name: '', nutrition: '', rating: 4, popularity: 4 },
    { id: '', name: '', nutrition: '', rating: 4, popularity: 4 },
    { id: '', name: '', nutrition: '', rating: 4, popularity: 4 },
    { id: '', name: '', nutrition: '', rating: 4, popularity: 4 },
    { id: '', name: '', nutrition: '', rating: 4, popularity: 4 },
    { id: '', name: '', nutrition: '', rating: 4, popularity: 4 },
    { id: '', name: '', nutrition: '', rating: 4, popularity: 4 }
]
