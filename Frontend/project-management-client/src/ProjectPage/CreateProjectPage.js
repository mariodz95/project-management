import React from "react";
import { Form, Button, Col } from "react-bootstrap";
import * as yup from "yup";
import { Formik } from "formik";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import { createProject } from "../actions/projectActions";
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
  render() {
    return (
      <React.Fragment>
        <Container className="container">
          <Formik
            initialValues={{
              name: "",
              description: "",
            }}
            validationSchema={schema}
            onSubmit={(values, { setSubmitting }) => {
              console.log("On submit", values);
              this.props.createProject(values, this.props.user.id);
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
                    <Form.Label>Project Name</Form.Label>
                    <Form.Control
                      type="text"
                      placeholder="Project name"
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
                  <Form.Group as={Col} controlId="exampleForm.ControlTextarea1">
                    <Form.Label>Description</Form.Label>
                    <Form.Control
                      as="textarea"
                      rows="5"
                      name="description"
                      onChange={handleChange}
                      onBlur={handleBlur}
                    />
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

CreateProjectPage.propTypes = {
  createProject: PropTypes.func.isRequired,
};

const mapStateToProps = (state) => (
  console.log("State", state),
  {
    user: state.authentication.user,
  }
);

const connecterCreateProjectPage = connect(mapStateToProps, {
  createProject,
})(CreateProjectPage);
export { connecterCreateProjectPage as CreateProjectPage };
