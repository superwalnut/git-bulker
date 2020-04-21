import Layout from '../../components/Layout';
import RepositoryList from '../../components/project/RepositoryList';
import { Container, DropdownButton, Dropdown, ButtonGroup, Row, Col } from 'react-bootstrap';

const Project = props => (
    <Layout>
        <h1>Repositories</h1>
        <Container>
          <Row>
            <Col sm={10} className="p-0">You can perform bulk actions against selected repositories and have an overview of all repositories.</Col>
            <Col sm={2} className="p-0 text-right">
            <DropdownButton as={ButtonGroup} title="Sort By">
              <Dropdown.Item eventKey="1">Current Head</Dropdown.Item>
              <Dropdown.Item eventKey="2">Folder</Dropdown.Item>
              <Dropdown.Item eventKey="2">Has Changes</Dropdown.Item>
              <Dropdown.Item eventKey="2">Recently Updated</Dropdown.Item>
            </DropdownButton>

            </Col>
          </Row>
        </Container>
        <hr />

        <RepositoryList repositories={props.repositories}/>
    </Layout>
);

Project.getInitialProps = async function(context) {
  const { id } = context.query;

  const res = await fetch(`http://localhost:5051/api/gitrepo/${id}`);
  const data = await res.json();

  console.log(`Show data fetched. Count: ${data.length}`);
  //console.log(data);

  return {
    repositories: data
  };
};

export default Project;