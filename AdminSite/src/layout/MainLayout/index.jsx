import { Outlet } from "react-router-dom";
import { Col, Row, Container } from "react-bootstrap";
import Topbar from "../../components/Topbar";
import Sidebar from "../../components/Sidebar";

function MainLayout(props) {
    return (
        <Container fluid>
            <Row>
                <Col xs={3}>
                    <Sidebar />
                </Col>
                <Col className="p-0">
                    <Topbar />
                    <Outlet />
                </Col> 
            </Row>
        </Container>
    );
}

export default MainLayout;
