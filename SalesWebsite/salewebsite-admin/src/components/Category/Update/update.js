import { useState, useEffect } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { LOGIN } from "~/constants/pages";
import CategoryForm from '../categoryForm';

function UpdateCategory() {
    let navigate = useNavigate();
    const[categories, setCategories] = useState({});

    // get value from index and pass to form
    const {state} = useLocation();
    const {existCategory} = state;
    
    useEffect(() => {
        if(localStorage.getItem("admin")==null) {
            navigate(LOGIN)
        }
        if(existCategory) {
            setCategories({
                id: existCategory.id,
                name: existCategory.name,
                description: existCategory.description
            });
        }
    }, [existCategory])

    return (
        <div className='ml-5'>
            <div className='primaryColor text-title intro-x'>
                Update Category
            </div>
    
            <div className='row'>
                <CategoryForm 
                    initalCategoryForm={categories}
                />
            </div>
  
        </div>
    );
}

export default UpdateCategory;