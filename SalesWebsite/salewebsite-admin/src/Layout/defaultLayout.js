
import { Col, Row } from 'react-bootstrap';
import Sidebar from '~/Layout/sidebar'
import NavbarLayout from './navbar';


function DefaultLayout({children}) {
    return ( 
       <div>
            <NavbarLayout />
            <Row>
            <Col md={2} xs={2}>
              <Sidebar />
            </Col>
            
            <Col md={10} xs={10}>
                
                <div className='content'>
                    {children}
                </div>
              </Col>
          </Row>
       </div>
    );
}

export default DefaultLayout;