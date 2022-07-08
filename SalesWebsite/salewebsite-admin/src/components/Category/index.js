import axios from "axios"
import { useState, useEffect } from "react"
import { UrlBackEnd } from "~/constants/oidc-config"
import Endpoints from "~/constants/endpoints"
import CategoryTable from "./categoryTable"
import { Button } from "react-bootstrap"
import { useNavigate } from "react-router-dom"
import { CREATE_CATEGORY } from "~/constants/pages"
import { DEFAULT_PAGE_LIMIT,
        ASCENDING,
        DEFAULT_CATEGORY_SORT_COLUMN_NAME,
} from "~/constants/paging"
import { getCategoriesRequest } from "~/services/categoriesService"

const ListCategory = () => {

    let navigate = useNavigate();

    const [query, setQuery] = useState({
        page: 1,
        limit: DEFAULT_PAGE_LIMIT,
        sortOrder: ASCENDING,
        sortColumn: DEFAULT_CATEGORY_SORT_COLUMN_NAME
      });

    const [categories, setCategories] = useState(undefined)
    const [update, setUpdate] = useState('')
    
    async function fetchDataCallBackAsync() {
        let result = await getCategoriesRequest(query);
        setCategories(result.data)
    }

    useEffect(() => {
        fetchDataCallBackAsync();
    }, [query, categories])

    return (
        <div className="container">
            <Button 
                variant="outline-primary" 
                onClick={() => navigate(CREATE_CATEGORY)}
            >Add</Button>       
            <CategoryTable 
                categories = {categories}
                fetchData = {fetchDataCallBackAsync}
            />
        </div>
    )
}

export default ListCategory; 