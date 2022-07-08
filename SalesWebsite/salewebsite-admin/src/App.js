import { Routes, Route, Link} from 'react-router-dom'
import CustomerTable from './components/Customer/customerTable';
import ProductTable from './components/Product/productTable';
import ListCategory from './components/Category';
import CreateCategory from './components/Category/Create/create';
import UpdateCategory from './components/Category/Update/update';
import  * as PAGE from './constants/pages';
import { NotificationManager, NotificationContainer } from 'react-notifications';
import 'react-notifications/lib/notifications.css';
function App() {

  return (
   <div>
    <ul>
      <li>
        <Link to='/'>Category</Link>
      </li>
      <li>
        <Link to='/product'>Product</Link>
      </li>
      <li>
        <Link to='/customer'>Customer</Link>
      </li>
    </ul>
    <NotificationContainer/>
    <Routes>
      {/*Show pages */}
      <Route path= {PAGE.CATEGORIES} element={<ListCategory />} />
      <Route path={PAGE.PRODUCT} element={<ProductTable />} />
      <Route path={PAGE.CUSTOMER} element={<CustomerTable />} />
      {/* Manage */}
      <Route path={PAGE.CREATE_CATEGORY} element={<CreateCategory />} />
      <Route path={PAGE.UPDATE_CATEGORY} element={<UpdateCategory />} />
    </Routes>
   </div>
  );
}

export default App;
