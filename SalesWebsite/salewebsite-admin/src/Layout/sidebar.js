import { Container } from "react-bootstrap";
import { Link } from "react-router-dom";

function Sidebar() {
    return (
        <Container fluid className="sidebar" >
            <div className="sidebar-title">
                ADMIN SIDE
            </div>
            <hr />
            <ul >
                <li>
                
                    <Link to='/'>
                        <i class="fa fa-table" aria-hidden="true"></i>
                        <span>Category</span>
                    </Link>
                </li>
                <li>
                    <Link to='/product'>
                        <i class="fa fa-cart-plus" aria-hidden="true"></i>
                        <span>Product</span>
                    </Link>
                </li>
                <li>
                    <Link to='/customer'>
                        <i class="fa fa-user-o" aria-hidden="true"></i>
                        <span>Customer</span>
                    </Link>
                </li>
            </ul>
        </Container>
    )
}

export default Sidebar;