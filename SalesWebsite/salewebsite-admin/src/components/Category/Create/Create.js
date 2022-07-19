import { useEffect } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import { LOGIN } from '~/constants/pages';
import CategoryForm from '../categoryForm';

function CreateCategory() {
    let navigate = useNavigate()
    useLocation();
    useEffect(() => {
      if(localStorage.getItem("admin")==null) {
        navigate(LOGIN)
      }
    }, [])
    return (  
        <div className='ml-5'>
        <div className='primaryColor text-title intro-x'>
          Create New Category
        </div>
  
        <div className='row'>
          <CategoryForm />
  
        </div>
  
      </div>
    )
}

export default CreateCategory;