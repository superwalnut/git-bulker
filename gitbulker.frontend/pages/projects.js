import Layout from '../components/Layout';
import ProjectList from '../components/projects/ProjectList';
import ProjectModal from '../components/projects/ProjectModal';
import { Container, Row, Col, Button, Modal } from 'react-bootstrap';

const Projects = props => {
  var isVisible = false;

  return (
    <Layout>
        <h1>Projects</h1>
        <Container>
          <Row>
            <Col sm={10} className="p-0">You can create a project by specifying the root folder and git-bulker will discover git repositories in all the children directories.</Col>
            <Col sm={2} className="p-0 text-right"><ProjectModal showModal={isVisible}/></Col>
          </Row>
        </Container>
        <hr />

        <Container>
        <ProjectList projects={props.projects}/>
        </Container>

        
    </Layout>
  );
}


Projects.getInitialProps = async function() {
    const res = await fetch('http://localhost:5051/api/project/list');
    const data = await res.json();
  
    return {
      projects: data
    };
  };

export default Projects;