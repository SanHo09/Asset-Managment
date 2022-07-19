import { Routes, Route, Link} from 'react-router-dom'

import  * as PAGE from './constants/pages';
import { NotificationManager, NotificationContainer } from 'react-notifications';
import 'react-notifications/lib/notifications.css';
import NavbarLayout from './Layout/navbar';
import '../src/styles/Dashboard.css'
import Login from './components/Security/Login/Login';
import { Container } from 'react-bootstrap';
import DefaultLayout from './Layout/defaultLayout';
import {publicRoutes} from '~/routers/index'
function App() {

  return (
   <div>
    
    <NotificationContainer/>
    <Container fluid>
        
        <Routes>
          <Route path={PAGE.LOGIN} element={<Login />} />
          {publicRoutes.map((route, index) => {
              const Page = route.component;
              return <Route  
                    key={index} 
                    path={route.path} 
                    element={<DefaultLayout>
                                <Page />
                            </DefaultLayout>} />
          })}
        </Routes>
    </Container>
   </div>
  );
}

export default App;
