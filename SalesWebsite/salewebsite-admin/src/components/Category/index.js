import axios from "axios"
import { useState, useEffect } from "react"
import { UrlBackEnd } from "~/constants/oidc-config"
import Endpoints from "~/constants/endpoints"
import CategoryTable from "./categoryTable"
import { Button } from "react-bootstrap"

const ListCategory = () => {

    const [categories, setCategories] = useState([])
    useEffect(() => {
        axios.get(UrlBackEnd+Endpoints.categories)
        .then(res => setCategories(res.data.items))
    }, [])
    
    console.log('re-render');

    return (
        <div className="container">
           
           <CategoryTable 
                categories = {categories}
            />
        </div>
    )
}

export default ListCategory; 