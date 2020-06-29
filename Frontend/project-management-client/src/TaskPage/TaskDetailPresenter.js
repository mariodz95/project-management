import React from "react";
import { Container, Col, Row } from "react-bootstrap";
import { CommentContainer } from "../comment/CommentContainer";

export const TaskDetailPresenter = (props) => {
  return (
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
              <b>Estimated:</b> {props.task.estimated} hours
            </p>
          </Col>
          <Col>
            <p>
              <b>Priority:</b> {props.task.priority}
            </p>
          </Col>
        </Row>
        <CommentContainer task={props.task}></CommentContainer>
      </Container>
    </React.Fragment>
  );
};
