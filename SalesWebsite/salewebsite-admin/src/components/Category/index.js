import { useState, useEffect } from "react"
import CategoryTable from "./List/categoryTable"
import { Button } from "react-bootstrap"
import { useNavigate } from "react-router-dom"
import { CREATE_CATEGORY } from "~/constants/pages"
import { DEFAULT_PAGE_LIMIT,
        ASCENDING,
        DEFAULT_CATEGORY_SORT_COLUMN_NAME,
} from "~/constants/paging"
import { getCategoriesRequest } from "~/services/categoriesService"

function ListCategories() {

    let navigate = useNavigate();

    const [categories, setCategories] = useState(undefined)
    const [isDelete, setDelete] = useState(false)

    const [query, setQuery] = useState({
        page: 1,
        limit: DEFAULT_PAGE_LIMIT,
        sortOrder: ASCENDING,
        sortColumn: DEFAULT_CATEGORY_SORT_COLUMN_NAME
    });

    async function fetchDataCallBackAsync(isDeleteQuery) {
        let result = await getCategoriesRequest(query);
        setCategories(result.data)
        setDelete(!isDelete);
    }

    useEffect(() => {
        console.log('mounted');
        const fetchData = async() => {
            let result = await getCategoriesRequest(query);
            setCategories(result.data)
            setDelete(false)
        }
        fetchData();

    }, [query, isDelete])

    return (
        <div className="container">
            <Button 
                variant="outline-primary" 
                onClick={() => navigate(CREATE_CATEGORY)}
            >Add</Button>     
            <br />  
            <CategoryTable 
                categories = {categories}
                fetchData = {fetchDataCallBackAsync}
                isDelete = {isDelete}
            />
        </div>
    )
}

export default ListCategories; 