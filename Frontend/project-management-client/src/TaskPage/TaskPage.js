import React from "react";
import { Table, Form, Button, FormControl, Row, Col } from "react-bootstrap";
import { Link } from "react-router-dom";

class TaskPage extends React.Component {
  constructor(props) {
    super(props);
  }
  render() {
    return (
      <React.Fragment>
        <Row xs={4} md={4} lg={6}>
          <Col>
            <Link to="/taskfrom" className="btn btn-link">
              Create New Task
            </Link>{" "}
          </Col>
          <Col>
            <Form inline>
              <FormControl
                type="text"
                placeholder="Search"
                className="mr-sm-2"
                onChange={(e) => {
                  this.handleChange(e);
                }}
              />
              <Button variant="outline-info" onClick={this.onSearchClick}>
                Search
              </Button>
            </Form>
          </Col>
        </Row>
      </React.Fragment>
    );
  }
}

export { TaskPage };
