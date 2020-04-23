import React from "react";
import { Form, Button, Col } from "react-bootstrap";
import * as yup from "yup";
import { Formik } from "formik";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import { createOrganization } from "../actions/organizationActions";
import { Link } from "react-router-dom";
import "../styles/Organization.css";
import Container from "react-bootstrap/Container";

const schema = yup.object({
  name: yup
    .string()
    .max(30, "Must be 15 characters or less")
    .required("Name is required field"),
  email: yup
    .string()
    .email("Invalid email address")
    .required("Company Email is required field"),
  address: yup
    .string()
    .max(30, "Must be 15 characters or less")
    .required("Address is required field"),
  city: yup
    .string()
    .max(30, "Must be 15 characters or less")
    .required("State is required field"),
  state: yup
    .string()
    .max(30, "Must be 15 characters or less")
    .required("City is required field"),
  zip: yup.number().required("Zip is required field"),
});

class CreateOrganizationPage extends React.Component {
  render() {
    return (
      <React.Fragment>
        <Container className="container">
          <Formik
            initialValues={{
              name: "",
              email: "",
              address: "",
              zip: "",
              city: "",
              state: "",
              owner: "",
              description: "",
            }}
            validationSchema={schema}
            onSubmit={(values, { setSubmitting, resetForm }) => {
              this.props.createOrganization(values, this.props.user.id);
              setSubmitting(false);
              resetForm();
            }}
            validateOnBlur={false}
          >
            {({
              handleSubmit,
              handleChange,
              resetForm,
              handleBlur,
              values,
              touched,
              isValid,
              errors,
            }) => (
              <Form noValidate onSubmit={handleSubmit}>
                <Form.Row>
                  <Form.Group as={Col} controlId="formGridName">
                    <Form.Label>Company Name</Form.Label>
                    <Form.Control
                      type="text"
                      placeholder="Company name"
                      name="name"
                      onChange={handleChange}
                      onBlur={handleBlur}
                    />
                    {touched.name && errors.name ? (
                      <div className="errorMesssage">{errors.name}</div>
                    ) : null}
                  </Form.Group>

                  <Form.Group as={Col} controlId="formGridEmail">
                    <Form.Label>Company Email</Form.Label>
                    <Form.Control
                      type="email"
                      placeholder="Enter company email"
                      name="email"
                      onChange={handleChange}
                      onBlur={handleBlur}
                    />
                    {touched.email && errors.email ? (
                      <div className="errorMesssage">{errors.email}</div>
                    ) : null}
                  </Form.Group>
                </Form.Row>

                <Form.Group controlId="formGridAddress1">
                  <Form.Label>Address</Form.Label>
                  <Form.Control
                    type="text"
                    placeholder="1234 Main St"
                    name="address"
                    onChange={handleChange}
                    onBlur={handleBlur}
                  />
                  {touched.address && errors.address ? (
                    <div className="errorMesssage">{errors.address}</div>
                  ) : null}
                </Form.Group>

                <Form.Row>
                  <Form.Group as={Col} controlId="formGridCity">
                    <Form.Label>City</Form.Label>
                    <Form.Control
                      type="text"
                      placeholder="City"
                      name="city"
                      onChange={handleChange}
                      onBlur={handleBlur}
                    />
                    {touched.city && errors.city ? (
                      <div className="errorMesssage">{errors.city}</div>
                    ) : null}
                  </Form.Group>

                  <Form.Group as={Col} controlId="formGridState">
                    <Form.Label>State</Form.Label>
                    <Form.Control
                      type="text"
                      placeholder="State"
                      name="state"
                      onChange={handleChange}
                      onBlur={handleBlur}
                    />
                    {touched.state && errors.state ? (
                      <div className="errorMesssage">{errors.state}</div>
                    ) : null}
                  </Form.Group>

                  <Form.Group as={Col} controlId="formGridZip">
                    <Form.Label>Zip</Form.Label>
                    <Form.Control
                      type="text"
                      placeholder="Zip"
                      name="zip"
                      onChange={handleChange}
                      onBlur={handleBlur}
                    />
                    {touched.zip && errors.zip ? (
                      <div className="errorMesssage">{errors.zip}</div>
                    ) : null}
                  </Form.Group>
                </Form.Row>
                <Form.Row>
                  <Form.Label column lg={2}>
                    Description
                  </Form.Label>
                  <Form.Control
                    type="text"
                    placeholder="Description"
                    onChange={handleChange}
                    name="description"
                  />
                </Form.Row>
                <br />
                <Form.Row>
                  <>
                    <Link to="/home" className="btn btn-link">
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

CreateOrganizationPage.propTypes = {
  createOrganization: PropTypes.func.isRequired,
};

const mapStateToProps = (state) => ({
  user: state.authentication.user,
});

const connecterCreateOrganizationPage = connect(mapStateToProps, {
  createOrganization,
})(CreateOrganizationPage);
export { connecterCreateOrganizationPage as CreateOrganizationPage };
