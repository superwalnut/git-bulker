import Layout from '../components/Layout';
import ProjectList from '../components/projects/ProjectList';
import { Container } from 'react-bootstrap';

const Tags = () => (
    <Layout>
        <h1>Tags</h1>
        <p>You can create a tag and associate repositories, then you can perform bulk git actions on them.</p>
        <hr />

        <Container>
        <ProjectList/>
        </Container>
    </Layout>
);

export default Tags;