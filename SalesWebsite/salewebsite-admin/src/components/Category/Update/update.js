import { useState, useEffect } from "react";
import { useLocation } from "react-router-dom";
import CategoryForm from '../categoryForm';

function UpdateCategory() {

    const[categories, setCategories] = useState({});

    // get value from index and pass to form
    const {state} = useLocation();
    const {existCategory} = state;
    
    useEffect(() => {
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