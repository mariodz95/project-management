import React from "react";
import { Form, Container, Col, Row, Button } from "react-bootstrap";

export const TaskDetailPresenter = (props) => {
  return (
    console.log("props", props.allComments.comments),
    (
      <React.Fragment>
        <Container fluid="md">
          <Row>
            <h1>Task name: {props.task.name}</h1>
          </Row>
          <Row>
            <Col>
              <p>
                <b>Description:</b> {props.task.description}
              </p>
            </Col>
          </Row>
          <Row>
            <Col>
              <p>
                <b>Assigned On:</b> {props.task.assignedOn}
              </p>
            </Col>
            <Col>
              <p>
                <b>Created by:</b> {props.task.createdBy}
              </p>
            </Col>
          </Row>
          <Row>
            <Col>
              <p>
                <b>Date created:</b> {props.task.dateCreated}
              </p>
            </Col>
            <Col>
              <p>
                <b>Date updated:</b> {props.task.dateUpdated}
              </p>
            </Col>
          </Row>
          <Row>
            <Col>
              <p>
                <b>Estimated:</b> {props.task.estimated}
              </p>
            </Col>
            <Col>
              <p>
                <b>Priority:</b> {props.task.priority}
              </p>
            </Col>
          </Row>
          {props.allComments.comments !== undefined
            ? props.allComments.comments.map((item) => (
                <p>Comment: {item.text}</p>
              ))
            : "No comments"}
          {/* <Form noValidate onSubmit={props.handleSubmit}> */}
          <Form.Group as={Col} controlId="exampleForm.ControlTextarea1">
            <Form.Label>Add comment</Form.Label>
            <Form.Control
              as="textarea"
              rows="5"
              name="description"
              onChange={() => props.handleChange()}
              ref={props.textInput}
            />
          </Form.Group>
          <Button
            className="button"
            variant="success"
            type="submit"
            size="lg"
            value="Submit"
            onClick={props.submit}
          >
            Submit
          </Button>{" "}
          {/* </Form> */}
        </Container>
      </React.Fragment>
    )
  );
};
