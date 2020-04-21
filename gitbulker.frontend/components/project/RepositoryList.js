import Link from 'next/link';
import { Container, Table, Form, Row, Col, Button, DropdownButton, ButtonGroup, Dropdown } from 'react-bootstrap';
import { useForm } from 'react-hook-form';

const RepositoryList = props => {
    const { register, handleSubmit, errors } = useForm();
    const onSubmit = data => { 
        console.log(data);
    };

    function renderTrackedDetail(trackedDetail, aheadBy, behindBy) {
        switch(trackedDetail) {
          case 1:
            return '-';
          case 2:
            return '↑' + aheadBy;
          case 3: 
            return '↓' + behindBy;
        }
    }

    return(
    <Container>
        <p>Found {props.repositories.length} repositories</p>
        <Form onSubmit={handleSubmit(onSubmit)}>
            <Table responsive>
                <thead>
                <tr>
                    <th><Form.Check type="checkbox" ref={register}/></th>
                    <th>Folder</th>
                    <th>Name</th>
                    <th>Current</th>
                    <th>Remote</th>
                    <th>Commits</th>
                    <th>Updated</th>
                    <th>Changes</th>
                    <th>Status</th>
                    <th>develop</th>
                    <th>master</th>
                </tr>
                </thead>
                <tbody>
                    {props.repositories.map((p, i)=> (
                    <tr key={p.path}>
                        <td><Form.Check type="checkbox" name={p.path} ref={register}/></td>
                        <td>{p.parentName ==''? ('/'): (p.parentName)}</td>
                        <td>{p.name}</td>
                        <td>{p.currentHeadFriendlyName}</td>
                        <td>{p.trackedRemoteCanonicalName == null? ('None'): (p.trackedRemoteCanonicalName)}</td>
                        <td>{p.localCommitCount}</td>
                        <td>{p.localLastCommitTime}<br/>{p.localLastCommitter}</td>
                        <td>
                            {p.hasPendingChanges ? (<i className="far fa-edit"></i>) : (<i className="fas fa-check-circle"></i>)}
                            {p.hasPendingChanges ? ' ('+(p.pendingChangesCount)+')' : ''}
                        </td>
                        <td>{ renderTrackedDetail(p.trackedDetail, p.aheadBy, p.behindBy)}</td>
                        <td>{p.developFriendlyName}</td>
                        <td>{p.masterFriendlyName}</td>
                    </tr>
                    ))}
                </tbody>
            </Table>
            <Container className="alert alert-secondary sticky-bottom">
                <Row>
                    <Col className="mb-2 pl-3">
                        Selected repositories: 
                    </Col>
                </Row>
                <Row>
                    <Col md={1}>
                        <DropdownButton as={ButtonGroup} key="up" drop="up" variant="secondary" title={` Select... `}>
                        <Dropdown.Item eventKey="1">Create Branch</Dropdown.Item>
                        <Dropdown.Item eventKey="2">Switch Branch</Dropdown.Item>
                        <Dropdown.Divider />
                        <Dropdown.Item eventKey="4">Create Tag</Dropdown.Item>
                        </DropdownButton>
                    </Col>
                    <Col md={8}>
                        <Form.Control type="text" name="target" placeholder="Enter a target" ref={register}/>
                    </Col>
                    <Col md={3} className="align-bottom">
                        <Button variant="primary" type="submit">Submit</Button>
                        <Button variant="secondary" className="ml-2">Remove Selections</Button>
                    </Col>
                </Row>                                
            </Container>
        </Form>
    </Container>
    );
};

export default RepositoryList;