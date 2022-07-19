export const LOGIN = '/login'
export const HOME = '/home/*'

export const CATEGORIES = '/';
export const CREATE_CATEGORY = '/createCategory';
export const UPDATE_CATEGORY = '/updateCategory/:id';
export const UPDATE_CATEGORY_ID = (id) => `updateCategory/${id}`

export const PRODUCT = '/product';
export const CREATE_PRODUCT = '/createProduct';
export const UPDATE_PRODUCT = '/updateProduct/:id';
export const UPDATE_PRODUCT_ID = (id) => `/updateProduct/${id}`

export const CUSTOMER = '/Customer'
export const CREATE_CUSTOMER = '/createCustomer';
export const UPDATE_CUSTOMER = '/updateCustomer/:id';
export const UPDATE_CUSTOMER_ID = (id) => `/updateCustomer/${id}`