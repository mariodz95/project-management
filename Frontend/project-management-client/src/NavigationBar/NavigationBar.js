import React from "react";
import Nav from "react-bootstrap/Nav";

class NavigationBar extends React.Component {
  render() {
    return (
      <React.Fragment>
        <Nav fill variant="tabs">
          <Nav.Item>
            <Nav.Link href="/home">Organizations</Nav.Link>
          </Nav.Item>
          <Nav.Item>
            <Nav.Link href="/projects">Projects</Nav.Link>
          </Nav.Item>
          <Nav.Item>
            <Nav.Link eventKey="disabled" disabled>
              Disabled
            </Nav.Link>
          </Nav.Item>
        </Nav>
      </React.Fragment>
    );
  }
}

export { NavigationBar };
