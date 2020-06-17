import React from "react";
import { Form, Button, Col } from "react-bootstrap";

export const TaskDetailPresenter = (props) => {
  return (
    <React.Fragment>
      <h1>Task name: {props.task.name}</h1>
      <p>Description: {props.task.description}</p>
      <p>Comments:</p>
      <Form.Group as={Col} controlId="exampleForm.ControlTextarea1">
        <Form.Label>Add comment</Form.Label>
        <Form.Control as="textarea" rows="5" name="description" />
      </Form.Group>
    </React.Fragment>
  );
};
