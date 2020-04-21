import React from 'react';
import { Button, Container, Modal } from 'react-bootstrap';
import ProjectForm from './ProjectForm';
import Router from 'next/router';

class ProjectModal extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            show: props.showModal
        };
        
        this.handleClose = this.handleClose.bind(this);
        this.handleShow = this.handleShow.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    
    handleClose (){
        this.setState({ show: false });
    };
    
    handleShow (){
        this.setState({ show: true });
    };

    handleSubmit (){
        this.setState({ show: false });
        Router.push('/projects');
    };

    render() {
        return(
            <Container>
                <Button variant="primary" onClick={this.handleShow}>Create Project</Button>

                <Modal show={this.state.show} onHide={this.handleClose}>
                    <Modal.Header closeButton>
                        <Modal.Title>Create Project</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <ProjectForm submitCallback = {this.handleSubmit}/>
                    </Modal.Body>
                </Modal>
            </Container>
        );
    }
}

  
export default ProjectModal;