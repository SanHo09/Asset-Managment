import { useState, useEffect } from "react"
import axios from "axios"

const CategoryTable = () => {

    const [categories, setCategories] = useState([])

    useEffect(() => {
       axios.get(`https://localhost:44321/api/Category`)
        .then(res => setCategories(res.data))
    }, [])

    console.log(categories);

    return (
        <div>
            <ul>
                <h1>Hello</h1>
                {categories.map(category => (
                    <li key={category.id}>{category.name || category.title}</li>
                ))}
            </ul>        
        </div>
    )
}

export default CategoryTable; 