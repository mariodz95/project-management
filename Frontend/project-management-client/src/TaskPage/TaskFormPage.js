import React from "react";
import { Form, Button, Col, Table } from "react-bootstrap";
import { Link } from "react-router-dom";
import * as yup from "yup";
import { Formik } from "formik";
import Container from "react-bootstrap/Container";
import { getAll } from "../actions/userActions";
import PropTypes from "prop-types";
import { connect } from "react-redux";
import Select from "react-select";
import { createTask } from "../actions/taskActions";

const schema = yup.object({
  name: yup
    .string()
    .max(30, "Must be 15 characters or less")
    .required("Name is required field"),
  description: yup.string().required("Description is required field"),
  estimated: yup.number(),
});

class TaskFormPage extends React.Component {
  constructor(props) {
    super(props);
  }
  state = {
    selectedOption: null,
    dropdownUsers: [],
    task: {
      name: "",
      description: "",
      priority: "",
      estimated: "",
      assignedOn: null,
      createdBy: null,
      projectName: null,
    },
  };

  componentDidMount() {
    //TODO change this
    this.props.getAll("D3C01634-1671-4B36-96A9-6AA8BBB77027");
  }

  handleChange = (selectedOption) => {
    this.setState({ selectedOption });
  };

  render() {
    const { selectedOption } = this.state;
    var userList = [];
    if (this.props.users.allUsers !== undefined) {
      this.props.users.allUsers.forEach(function (element) {
        userList.push({ label: element.firstName, value: element.firstName });
      });
    }
    return (
      <React.Fragment>
        <Container className="container">
          <Formik
            initialValues={{
              name: "",
              description: "",
              priority: "",
              estimated: "",
              assign: "",
            }}
            validationSchema={schema}
            onSubmit={(values, { setSubmitting }) => {
              var project = JSON.parse(localStorage.getItem("Project"));

              this.setState({
                task: {
                  ...this.state.task,
                  name: values.name,
                  description: values.description,
                  priority: values.priority,
                  estimated: values.estimated,
                  assignedOn: this.state.selectedOption.value,
                  createdBy: this.props.user.username,
                  projectName: project.name,
                },
              });
              this.props.createTask(this.state.task);
              setSubmitting(false);
            }}
            validateOnBlur={false}
          >
            {({
              handleSubmit,
              handleChange,
              resetForm,
              handleBlur,
              touched,
              errors,
            }) => (
              <Form noValidate onSubmit={handleSubmit}>
                <Form.Row>
                  <Form.Group as={Col} controlId="formGridName">
                    <Form.Label>Task</Form.Label>
                    <Form.Control
                      type="text"
                      placeholder="Task name"
                      name="name"
                      onChange={handleChange}
                      onBlur={handleBlur}
                    />
                    {touched.name && errors.name ? (
                      <div className="errorMesssage">{errors.name}</div>
                    ) : null}
                  </Form.Group>
                </Form.Row>

                <Form.Row>
                  <Form.Group as={Col} controlId="formGridCity">
                    <Form.Label>Priority</Form.Label>
                    <Form.Control
                      type="text"
                      placeholder="Priority"
                      name="priority"
                      onChange={handleChange}
                      onBlur={handleBlur}
                    />
                  </Form.Group>

                  <Form.Group as={Col} controlId="formGridState">
                    <Form.Label>Estimated</Form.Label>
                    <Form.Control
                      type="text"
                      placeholder="Estimated"
                      name="estimated"
                      onChange={handleChange}
                      onBlur={handleBlur}
                    />
                    {touched.estimated && errors.estimated ? (
                      <div className="errorMesssage">{errors.estimated}</div>
                    ) : null}
                  </Form.Group>

                  <Form.Group as={Col} controlId="formGridState">
                    <Form.Label>Assign Task on</Form.Label>

                    <Select
                      value={selectedOption}
                      onChange={this.handleChange}
                      options={userList}
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
                      onChange={handleChange}
                      onBlur={handleBlur}
                    />
                    {touched.description && errors.description ? (
                      <div className="errorMesssage">{errors.description}</div>
                    ) : null}
                  </Form.Group>
                </Form.Row>
                <br />
                <Form.Row>
                  <>
                    <Link to="/projects" className="btn btn-link">
                      Cancel
                    </Link>
                    <Button
                      className="button"
                      variant="danger"
                      type="reset"
                      value="Reset"
                      onClick={resetForm}
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
            )}
          </Formik>
        </Container>
      </React.Fragment>
    );
  }
}

TaskFormPage.propTypes = {
  createTask: PropTypes.func.isRequired,
  getAll: PropTypes.func.isRequired,
};

const mapStateToProps = (state) => ({
  user: state.authentication.user,
  users: state.users,
});

const connectedTaskFormPage = connect(mapStateToProps, {
  createTask,
  getAll,
})(TaskFormPage);
export { connectedTaskFormPage as TaskFormPage };
