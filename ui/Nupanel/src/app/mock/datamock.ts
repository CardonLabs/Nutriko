import { IMCollections, IMPlans } from 'src/app/mock/idata-models'

export const NUCOLLECTIONS: IMCollections[] = [
    {id: 100, name: 'Users', description: 'Manage user accounts'},
    {id: 101, name: 'Plans', description: 'Manage plan offerings for service'},
    {id: 102, name: 'Recipes', description: 'Recips hub for adding or removing recipes'},
    {id: 103, name: 'Meals', description: 'Define meals'}

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
