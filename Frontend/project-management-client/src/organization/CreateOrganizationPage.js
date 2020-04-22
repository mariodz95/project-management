import React from "react";
import { Form, Button, Col } from "react-bootstrap";
import * as yup from "yup";
import { Formik } from "formik";
import { organizationService } from "../services/organizationService";
import { connect } from "react-redux";

const schema = yup.object({
  name: yup.string().required(),
  email: yup.string().required(),
  address: yup.string().required(),
  city: yup.string().required(),
  state: yup.string().required(),
  zip: yup.string().required(),
});

class CreateOrganizationPage extends React.Component {
  constructor(props) {
    super(props);
  }
  render() {
    return (
      <React.Fragment>
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
          onSubmit={(values, { setSubmitting }) => {
            organizationService.createOrganization(values, this.props.user.id);
            setSubmitting(false);
          }}
        >
          {({
            handleSubmit,
            handleChange,
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
                    isInvalid={!!errors.name}
                  />
                </Form.Group>

                <Form.Group as={Col} controlId="formGridEmail">
                  <Form.Label>Company Email</Form.Label>
                  <Form.Control
                    type="email"
                    placeholder="Enter company email"
                    name="email"
                    onChange={handleChange}
                    isInvalid={!!errors.email}
                  />
                </Form.Group>
              </Form.Row>

              <Form.Group controlId="formGridAddress1">
                <Form.Label>Address</Form.Label>
                <Form.Control
                  type="text"
                  placeholder="1234 Main St"
                  name="address"
                  onChange={handleChange}
                  isInvalid={!!errors.address}
                />
              </Form.Group>

              <Form.Row>
                <Form.Group as={Col} controlId="formGridCity">
                  <Form.Label>City</Form.Label>
                  <Form.Control
                    type="text"
                    placeholder="City"
                    name="city"
                    onChange={handleChange}
                    isInvalid={!!errors.city}
                  />
                </Form.Group>

                <Form.Group as={Col} controlId="formGridState">
                  <Form.Label>State</Form.Label>
                  <Form.Control
                    type="text"
                    placeholder="State"
                    name="state"
                    onChange={handleChange}
                    isInvalid={!!errors.state}
                  />
                </Form.Group>

                <Form.Group as={Col} controlId="formGridZip">
                  <Form.Label>Zip</Form.Label>
                  <Form.Control
                    type="text"
                    placeholder="Zip"
                    name="zip"
                    onChange={handleChange}
                    isInvalid={!!errors.zip}
                  />
                </Form.Group>
              </Form.Row>
              <Form.Row>
                <Form.Label column lg={2}>
                  Normal Text
                </Form.Label>
                <Col>
                  <Form.Control
                    type="text"
                    placeholder="Description"
                    onChange={handleChange}
                    name="description"
                  />
                </Col>
              </Form.Row>
              <br />
              <Button variant="primary" type="submit">
                Submit
              </Button>
            </Form>
          )}
        </Formik>
      </React.Fragment>
    );
  }
}

const mapStateToProps = (state) => ({
  user: state.authentication.user,
});

// export { CreateOrganizationPage };

const connectedHomePage = connect(mapStateToProps, {})(CreateOrganizationPage);
export { connectedHomePage as CreateOrganizationPage };
