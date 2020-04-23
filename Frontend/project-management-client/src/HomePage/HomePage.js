import React from "react";
import { Link } from "react-router-dom";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import { getAll, _delete, logout } from "../actions/userActions";
import { getAllOrganizations } from "../actions/organizationActions";
import { NavigationBar } from "../NavigationBar/NavigationBar";
import Table from "react-bootstrap/Table";

class HomePage extends React.Component {
  componentDidMount() {
    if (this.props.allOrganizations === undefined) {
      this.props.getAllOrganizations(this.props.user.id);
    }
  }
  render() {
    const { user } = this.props;
    return (
      <React.Fragment>
        <NavigationBar />
        <Link to="/createorganization" className="btn btn-link">
          Create Organization
        </Link>
        <div className="col-md-6 col-md-offset-3">
          <p>
            <Link to="/login">Logout</Link>
            {user.username}
          </p>
        </div>
        {this.props.organizations !== undefined ? (
          this.props.organizations.lenght === 0 ? (
            <Link to="/organization" className="btn btn-link">
              Create Organization
            </Link>
          ) : (
            <Table striped bordered hover>
              <thead>
                <tr>
                  <th>#</th>
                  <th>Name</th>
                  <th>Email</th>
                  <th>Country</th>
                  <th>Address</th>
                  <th>Description</th>
                  <th>State</th>
                  <th>Zip</th>
                </tr>
              </thead>
              {this.props.organizations.map((item, index) => (
                <tbody key={index}>
                  <tr>
                    <td>1</td>
                    <td>{item.name}</td>
                    <td>{item.email}</td>
                    <td>{item.country}</td>
                    <td>{item.address}</td>
                    <td>{item.description}</td>
                    <td>{item.state}</td>
                    <td>{item.zip}</td>
                  </tr>
                </tbody>
              ))}
            </Table>
          )
        ) : null}
      </React.Fragment>
    );
  }
}

HomePage.propTypes = {
  logout: PropTypes.func.isRequired,
  getAllOrganizations: PropTypes.func.isRequired,
  organizations: PropTypes.array.isRequired,
};

const mapStateToProps = (state) => ({
  user: state.authentication.user,
  users: state.authentication.users,
  organizations: state.organizations.allOrganizations,
});

const connectedHomePage = connect(mapStateToProps, {
  _delete,
  getAll,
  logout,
  getAllOrganizations,
})(HomePage);
export { connectedHomePage as HomePage };
