import React from 'react';
import { Container } from 'react-bootstrap';

function Header() {
    return(
        <Container>
            <h1>To Do List</h1>
            <h3>Enter Items to Add to the List</h3>
            <h3>Mark an Item as Complete by Checking the Box</h3>
            <h3>Completed Items Can Be Deleted by Clicking the Delete Button</h3>
        </Container>
    );
};

export default Header;