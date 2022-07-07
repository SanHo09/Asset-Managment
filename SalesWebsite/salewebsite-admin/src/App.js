import { Routes, Route, Link} from 'react-router-dom'
import CustomerTable from './components/Customer/customerTable';
import ProductTable from './components/Product/productTable';
import ListCategory from './components/Category';

function App() {

  return (
   <div>
    <ul>
      <li>
        <Link to='/'>Customer</Link>
      </li>
      <li>
        <Link to='/product'>Product</Link>
      </li>
      <li>
        <Link to='/category'>Category</Link>
      </li>
    </ul>
    <Routes>
      <Route path='/' element={<CustomerTable />} />
      <Route path='/product' element={<ProductTable />} />
      <Route path='/category' element={<ListCategory />} />
    </Routes>
   </div>
  );
}

export default App;
