import { Routes, Route, Link} from 'react-router-dom'
import CustomerTable from './components/Customer/List/customerTable';
import ListProducts from './components/Product';
import ListCategory from './components/Category';
import CreateCategory from './components/Category/Create/create';
import UpdateCategory from './components/Category/Update/update';
import  * as PAGE from './constants/pages';
import { NotificationManager, NotificationContainer } from 'react-notifications';
import 'react-notifications/lib/notifications.css';
import CreateProduct from './components/Product/Create/create';
import UpdateProduct from './components/Product/Update/update';
import CreateCustomer from './components/Customer/Create/create';
import UpdateCustomer from './components/Customer/Update/update';
import ListCustomer from './components/Customer';
import NavbarLayout from './Layout/navbar';
import { Col, Container, Row } from 'react-bootstrap';
import Sidebar from './Layout/sidebar';
import '../src/styles/Dashboard.css'
function App() {

  return (
   <div>
    
    <NotificationContainer/>
    <Container fluid>
      <Row className='layout'>

        <Col md={2} xs={2}>
          <Sidebar />
        </Col>

        <Col md={10} xs={10}>
            <NavbarLayout />
            <div className='content'>
              <Routes>
                {/*Show pages */}
                <Route path= {PAGE.CATEGORIES} element={<ListCategory />} />
                <Route path={PAGE.PRODUCT} element={<ListProducts />} />
                <Route path={PAGE.CUSTOMER} element={<ListCustomer/>} />
                {/* Manage */}
                <Route path={PAGE.CREATE_CATEGORY} element={<CreateCategory />} />
                <Route path={PAGE.UPDATE_CATEGORY} element={<UpdateCategory />} />

                <Route path={PAGE.CREATE_PRODUCT} element={<CreateProduct />} />
                <Route path={PAGE.UPDATE_PRODUCT} element={<UpdateProduct />} />

                <Route path={PAGE.CREATE_CUSTOMER} element={<CreateCustomer />} />
                <Route path={PAGE.UPDATE_CUSTOMER} element={<UpdateCustomer />} />
              
              </Routes>
            </div>
          </Col>
        </Row>
    </Container>
   </div>
  );
}

export default App;
