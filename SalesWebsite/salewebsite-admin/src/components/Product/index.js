import { useEffect, useState } from "react";
import { Button } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import { CREATE_PRODUCT } from "~/constants/pages";
import { ASCENDING, DEFAULT_CATEGORY_SORT_COLUMN_NAME, DEFAULT_PAGE_LIMIT, DEFAULT_PRODUCT_SORT_COLUMN_NAME } from "~/constants/paging";
import { getCategoriesRequest } from "~/services/categoriesService";
import { getProductRequest } from "~/services/productService";
import ProductTable from "./List/productTable";

function ListProducts() {

    let navigate = useNavigate();

    const [products, setProducts] = useState('');
    const [isDeleted, setDeleted] = useState(false);

    const [query, setQuery] = useState({
        page: 1,
        limit: DEFAULT_PAGE_LIMIT,
        sortOrder: ASCENDING,
        sortColumn: DEFAULT_PRODUCT_SORT_COLUMN_NAME
    });

    const fetchDataCallBackAsync = async() => {
        let result = await getProductRequest(query);
        setProducts(result.data);
        setDeleted(!isDeleted)
    }

    useEffect(() => {
        console.log('product mounted');
        const fetchDataAsync = async() => {
            let result = await getProductRequest(query);
            setProducts(result.data);
        };
        fetchDataAsync();

    }, [query, isDeleted])

    return (
        <div>
            <Button
                variant="outline-primary" 
                onClick={() => navigate(CREATE_PRODUCT)}
            >Add</Button>  
            <br/>
            <ProductTable 
                products = {products}
                fetchData = {fetchDataCallBackAsync}
            />
        </div>
    )
}

export default ListProducts;