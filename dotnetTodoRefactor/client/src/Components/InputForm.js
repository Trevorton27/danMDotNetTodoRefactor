import React from 'react';
import { Form, InputGroup, Button } from 'react-bootstrap';

function InputForm(props){
    return(
        <Form className="w-50 m-auto" onSubmit={props.handleAddToDo}>
            <InputGroup >
                <Form.Control type="text" ref={props.inputTextRef} className="me-3" placeholder="Enter To Do Item" required/>
                <Button type="submit">Add To Do</Button>
            </InputGroup>
        </Form>
    );
};

export default InputForm;