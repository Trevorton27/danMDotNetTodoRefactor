import React, { useState, useRef, useEffect } from 'react';
import { Container } from 'react-bootstrap';
import Header from './Components/Header';
import InputForm from './Components/InputForm';
import ToDoList from './Components/ToDoList';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';

function App() {
  const inputTextRef = useRef();
  const [todos, setTodos] = useState([]);

  async function getToDos() {
    const response = await axios.get('/api/todos');
    const newToDos = response.data;
    setTodos(newToDos);
  }

  useEffect(() => {
    getToDos();
  }, []);

  async function handleAddToDo(event) {
    event.preventDefault();

    const enteredToDoInput = inputTextRef.current.value;
    const response = await axios.post('/api/todos', { text: enteredToDoInput });
    const postedTodo = response.data;
    console.log('postedTodo: ', postedTodo);
    setTodos([...todos, postedTodo]);

    getToDos();
    inputTextRef.current.value = '';
  }

  async function handleCheckboxClick(todoID, checkedValue) {
    todos.find((todo) => todo.id === todoID);
    await axios.put(`/api/todos/${todoID}`, { isComplete: checkedValue });
    getToDos();
  }

  async function handleDeleteToDo(todoID) {
    todos.find((todo) => todo.id === todoID);
    await axios.delete(`/api/todos/${todoID}`);
    getToDos();
  }

  return (
    <Container className='App'>
      <Header />
      <InputForm inputTextRef={inputTextRef} handleAddToDo={handleAddToDo} />
      <ToDoList
        todos={todos}
        handleCheckboxClick={handleCheckboxClick}
        handleDeleteToDo={handleDeleteToDo}
      />
    </Container>
  );
}

export default App;
