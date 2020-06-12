import React from "react";
import { Form, Button, Col, Table } from "react-bootstrap";
import * as yup from "yup";
import { Formik } from "formik";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import { createProject, updateProject } from "../actions/projectActions";
import { getAll } from "../actions/userActions";
import { Link } from "react-router-dom";
import "../styles/Organization.css";
import Container from "react-bootstrap/Container";

const schema = yup.object({
  name: yup
    .string()
    .max(30, "Must be 15 characters or less")
    .required("Name is required field"),
});

class CreateProjectPage extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      selectedOption: null,
      listOfUsers: [],
      project: {
        name: "",
        description: "",
        users: [],
      },
    };
  }

  componentDidMount() {
    //TODO change this
    this.props.getAll("D3C01634-1671-4B36-96A9-6AA8BBB77027");
    if (this.props.location.state !== undefined) {
      this.addUser(this.props.location.state.item.userProject[0].us);
    } else {
      this.addUser(this.props.user);
    }
  }

  display = () => {
    this.setState({
      displayDropdown: this.state.displayDropdown ? false : true,
    });
  };

  handleChange = (selectedOption) => {
    this.setState({ selectedOption });
    var joined = this.state.listOfUsers.concat(selectedOption.value);
    this.setState({ listOfUsers: joined });
  };

  removeUser = (item) => {
    this.setState({
      listOfUsers: this.state.listOfUsers.filter(function (users) {
        return users !== item;
      }),
    });
  };

  addUser = (item) => {
    var joined = this.state.listOfUsers.concat(item);
    this.setState({ listOfUsers: joined });
  };
  render() {
    return (
      <React.Fragment>
        <Container className="container">
          <Formik
            initialValues={{
              name:
                this.props.location.state !== undefined
                  ? this.props.location.state.item.name
                  : "",
              description:
                this.props.location.state !== undefined
                  ? this.props.location.state.item.description
                  : "",
            }}
            validationSchema={schema}
            onSubmit={(values, { setSubmitting }) => {
              if (this.props.location.state !== undefined) {
                this.props.updateProject(
                  this.props.location.state.item.id,
                  values
                );
                setSubmitting(false);
              } else {
                this.setState({
                  project: {
                    ...this.state.project,
                    name: values.name,
                    description: values.description,
                    users: this.state.listOfUsers,
                  },
                });
                this.props.createProject(
                  this.state.project,
                  this.props.user.id
                );
              }
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
                    <Form.Label>Project Name</Form.Label>
                    <Form.Control
                      type="text"
                      placeholder="Project name"
                      name="name"
                      defaultValue={
                        this.props.location.state !== undefined
                          ? this.props.location.state.item.name
                          : null
                      }
                      onChange={handleChange}
                      onBlur={handleBlur}
                    />
                    {touched.name && errors.name ? (
                      <div className="errorMesssage">{errors.name}</div>
                    ) : null}
                  </Form.Group>
                </Form.Row>
                <Form.Row>
                  <Form.Group as={Col} controlId="exampleForm.ControlTextarea1">
                    <Form.Label>Description</Form.Label>
                    <Form.Control
                      as="textarea"
                      rows="5"
                      name="description"
                      defaultValue={
                        this.props.location.state !== undefined
                          ? this.props.location.state.item.description
                          : null
                      }
                      onChange={handleChange}
                      onBlur={handleBlur}
                    />
                  </Form.Group>
                </Form.Row>
                <br />
                <h2>Users on project</h2>
                <Table striped bordered hover>
                  <thead>
                    <tr>
                      <th>Name</th>
                      <th>Description</th>
                    </tr>
                  </thead>
                  {this.state.listOfUsers !== undefined
                    ? this.state.listOfUsers.map((item) => (
                        <tbody key={item.id}>
                          <tr>
                            <td>{item.id}</td>
                            <td>{item.firstName}</td>
                            <td>
                              {this.props.user.id !== item.id ? (
                                <Button
                                  variant="link"
                                  onClick={() => {
                                    this.removeUser(item);
                                  }}
                                >
                                  Remove
                                </Button>
                              ) : null}
                            </td>
                          </tr>
                        </tbody>
                      ))
                    : null}
                </Table>
                <h2>Available users</h2>
                <Table striped bordered hover>
                  <thead>
                    <tr>
                      <th>Name</th>
                      <th>Description</th>
                      <th></th>
                    </tr>
                  </thead>
                  {this.props.users.allUsers !== undefined
                    ? this.props.users.allUsers
                        .filter((item) => item.id !== this.props.user.id)
                        .map((item) => (
                          <React.Fragment>
                            <tbody key={item.id}>
                              <tr>
                                <td>{item.id}</td>
                                <td>{item.firstName}</td>
                                <td>
                                  {this.state.listOfUsers.some(
                                    (data) => data.id !== item.id
                                  ) ? (
                                    <Button
                                      variant="link"
                                      onClick={() => {
                                        this.addUser(item);
                                      }}
                                    >
                                      Add user
                                    </Button>
                                  ) : null}
                                </td>
                              </tr>
                            </tbody>
                          </React.Fragment>
                        ))
                    : null}
                </Table>
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

CreateProjectPage.propTypes = {
  createProject: PropTypes.func.isRequired,
  updateProject: PropTypes.func.isRequired,
  getAll: PropTypes.func.isRequired,
};

const mapStateToProps = (state) => ({
  user: state.authentication.user,
  edit: state.projects.edit,
  users: state.users,
});

const connecterCreateProjectPage = connect(mapStateToProps, {
  createProject,
  updateProject,
  getAll,
})(CreateProjectPage);
export { connecterCreateProjectPage as CreateProjectPage };
