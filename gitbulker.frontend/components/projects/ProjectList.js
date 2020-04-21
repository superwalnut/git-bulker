import Link from 'next/link';
import fetch from 'isomorphic-unfetch';
import { Container } from 'react-bootstrap';
import ProjectCard from './ProjectCard';

const ProjectList = ({projects}) => (
    <Container>
    <ul className="ul-fl">
      {projects.map(p => (
          <li key={p.id}>
              <ProjectCard project={p}></ProjectCard>
          </li>
        ))}
    </ul>
    </Container>
);

export default ProjectList;