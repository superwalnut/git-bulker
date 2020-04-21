import Layout from '../components/Layout';
import Slide from '../components/index/Slide';
import { Container, Row, Col, Button } from 'react-bootstrap';

const Index = () => (
    <Layout>
        <div className="page-header">
            <h1 className="mt-3 mb-5 text-primary">Overview of multi-repositories</h1>
            <Container>
                <Row>
                    <Col md={{ span: 8, offset: 2 }}><Slide /></Col>
                </Row>
                <Row className="mt-3 text-center">
                    <Col>
                        <Button href="/projects" className="btn-lg">Start</Button>
                    </Col>
                </Row>
            </Container>            
        </div>        
    </Layout>
);

export default Index;