import { useLocation } from 'react-router-dom';
import CategoryForm from '../categoryForm';

function CreateCategory() {

    useLocation();

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