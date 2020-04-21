import Router from 'react';
import { Form, Row, Col, Button, Modal } from 'react-bootstrap';
import { useForm } from 'react-hook-form';

const ProjectForm = props => {
    const { register, handleSubmit, errors } = useForm();
    const onSubmit = data => { 
        fetch('http://localhost:5051/api/project', {
          method: 'post',
          headers: {
            'Accept': 'application/json, text/plain, */*',
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(data)
        }).then((res) => {
            if(res.status === 200 || res.status == 202){   
                props.submitCallback();
            } else {
                serverErr = res.text();
            }
        })
    };
    
    return (
        <Form onSubmit={handleSubmit(onSubmit)}>
            <Form.Group as={Row}>
                <Form.Label column sm={2}>Name</Form.Label>
                <Col sm={10}>
                    <input className="form-control" name="name" placeholder="Project Name" ref={register({ required: true })}/>
                    {errors.name && <span>Project name is required</span>}
                </Col>
            </Form.Group>
            <Form.Group as={Row}>
                <Form.Label column sm={2}>Path</Form.Label>
                <Col sm={10}>
                    <input className="form-control" name="root" placeholder="Project Path" ref={register({ required: true })}/>
                    {errors.root && <span>Project path is required</span>}
                </Col>
            </Form.Group>
            <fieldset>
                <Form.Group as={Row}>
                <Form.Label as="legend" column sm={2}>
                    Branching Stragety
                </Form.Label>
                <Col sm={10}>
                    <Form.Check type="radio" label="GitHub Flow" name="branchingStrategy" id="branchingStrategyGithub" value="GitHub Flow" ref={register}/>
                    <Form.Check type="radio" label="GitFlow" name="branchingStrategy" id="branchingStrategyGit" value="GitFlow" ref={register}/>
                    <Form.Check type="radio" label="Forking Workflow" name="branchingStrategy" id="branchingStrategyFork" value="Forking Workflow" ref={register}/>
                </Col>
                </Form.Group>
            </fieldset>
            <Modal.Footer>       
                <Button variant="primary" type="submit">Save Project</Button>
            </Modal.Footer>         
        </Form>
    );
}

export default ProjectForm;