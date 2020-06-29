import React from "react";
import { Form, Button, Col } from "react-bootstrap";
import Container from "react-bootstrap/Container";
import Select from "react-select";
import "./Task.scss";
import { history } from "../helpers/history";

const priority = [
  { value: "Low", label: "Low" },
  { value: "Medium", label: "Medium" },
  { value: "High", label: "High" },
];

export const TaskFormPresenter = (props) => {
  return (
    <React.Fragment>
      <Container className="container">
        <h1>Create new task</h1>
        <Form noValidate onSubmit={props.handleSubmit}>
          <Form.Row>
            <Form.Group as={Col} controlId="formGridName">
              <Form.Label>Task</Form.Label>
              <Form.Control
                size="lg"
                type="text"
                placeholder="Task name"
                name="name"
                onChange={props.handleChange}
                onBlur={props.handleBlur}
              />
              {props.touched.name && props.errors.name ? (
                <div className="errorMesssage">{props.errors.name}</div>
              ) : null}
            </Form.Group>
          </Form.Row>
          <Form.Row>
            <Form.Group as={Col} controlId="formGridState">
              <Form.Label>Priority</Form.Label>
              <Select
                value={props.selectedPriorityOption}
                onChange={props.handleDropdownChange}
                options={props.priority}
              />
            </Form.Group>
            <Form.Group as={Col} controlId="formGridState">
              <Form.Label>Estimated</Form.Label>
              <Form.Control
                size="lg"
                type="text"
                placeholder="Estimated: Example 0.5, 1, 1.5... in hours"
                name="estimated"
                onChange={props.handleChange}
                onBlur={props.handleBlur}
              />
              {props.touched.estimated && props.errors.estimated ? (
                <div className="errorMesssage">{props.errors.estimated}</div>
              ) : null}
            </Form.Group>
            <Form.Group as={Col} controlId="formGridState">
              <Form.Label>Assign Task on</Form.Label>
              <Select
                value={props.selectedOption}
                onChange={props.handleDropdownChange}
                options={props.userList}
              />
            </Form.Group>
          </Form.Row>
          <Form.Row>
            <Form.Group as={Col} controlId="exampleForm.ControlTextarea1">
              <Form.Label>Description</Form.Label>
              <Form.Control
                as="textarea"
                rows="5"
                name="description"
                onChange={props.handleChange}
                onBlur={props.handleBlur}
              />
              {props.touched.description && props.errors.description ? (
                <div className="errorMesssage">{props.errors.description}</div>
              ) : null}
            </Form.Group>
          </Form.Row>
          <br />
          <Form.Row>
            <>
              <Button variant="link" onClick={history.goBack}>
                Go Back
              </Button>
              <Button
                className="button"
                variant="danger"
                type="reset"
                value="Reset"
                onClick={props.resetForm}
                size="lg"
              >
                Clear
              </Button>
              <Button
                className="button"
                variant="success"
                type="submit"
                size="lg"
                value="Submit"
              >
                Submit
              </Button>
            </>
          </Form.Row>
        </Form>
      </Container>
    </React.Fragment>
  );
};
