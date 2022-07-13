const Endpoints = {
    categories: '/api/category',
    categoryId: (id) => `/api/category/${id}`,

    products: '/api/product',
    productId: (id) => `api/product/${id}`,

    customers: '/api/customer'

};

export default Endpoints;