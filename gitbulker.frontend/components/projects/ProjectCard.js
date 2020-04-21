import { Card } from 'react-bootstrap';
import Link from 'next/link';
import Moment from 'moment';

const ProjectCard = ({project}) => (
    <Card className="border-primary">
        <Card.Header>{Moment(project.created).format('d MMM YYYY')} ({Moment(project.created).startOf('day').fromNow()})</Card.Header>
        <Card.Body>
            <Card.Title><Link href="/project/[id]" as={`/project/${project.id}`}><a><i className="far fa-folder-open"></i> {project.name}</a></Link></Card.Title>
            <Card.Text>
                <i className="fas fa-sitemap"></i> {project.root}
            </Card.Text>
            <Card.Text>
                <i className="fas fa-code-branch"></i> Branching: <strong>{project.branchingStrategy}</strong>
            </Card.Text>
            <Link href="/project/[id]" as={`/project/${project.id}`}><a className="btn btn-primary">Go to Project</a></Link>
        </Card.Body>
    </Card>
);

export default ProjectCard;