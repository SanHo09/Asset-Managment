const Endpoints = {
    categories: '/api/category',
    categoryId: (id) => `/api/category/${id}`,

    products: '/api/product',
    productId: (id) => `api/product/${id}`,

    customers: '/api/customer',
    login: '/api/customer/login'
};

export default Endpoints;