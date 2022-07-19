import { CATEGORIES } from "~/constants/pages"
import CreateProduct from '~/components/Product/Create/create';
import UpdateProduct from '~/components/Product/Update/update';
import CreateCustomer from '~/components/Customer/Create/create';
import UpdateCustomer from '~/components/Customer/Update/update';
import ListCustomer from '~/components/Customer';
import ListProducts from '~/components/Product';
import ListCategory from '~/components/Category';
import CreateCategory from '~/components/Category/Create/create';
import UpdateCategory from '~/components/Category/Update/update';
import  * as PAGE from '~/constants/pages';
const publicRoutes = [
    {path:PAGE.CATEGORIES, component: ListCategory },
    {path:PAGE.PRODUCT, component: ListProducts },
    {path:PAGE.CUSTOMER, component: ListCustomer},
    {path:PAGE.CREATE_CATEGORY, component: CreateCategory },
    {path:PAGE.UPDATE_CATEGORY, component: UpdateCategory },

    {path:PAGE.CREATE_PRODUCT, component: CreateProduct },
    {path:PAGE.UPDATE_PRODUCT, component: UpdateProduct },

    {path:PAGE.CREATE_CUSTOMER, component: CreateCustomer },
    {path:PAGE.UPDATE_CUSTOMER, component: UpdateCustomer }
]
const privateRoutes = [
    
]

export {publicRoutes, privateRoutes}