import React from "react";
import { Link } from "react-router-dom";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import { getAll, _delete, logout } from "../actions/userActions";
import { getAllOrganizations } from "../actions/organizationActions";
import { NavigationBar } from "../NavigationBar/NavigationBar";
import { Table, Pagination } from "react-bootstrap";
import "../styles/HomePage.css";

class HomePage extends React.Component {
  componentDidMount() {
    if (this.props.allOrganizations === undefined) {
      this.props.getAllOrganizations(this.props.user.id);
    }
  }
  render() {
    const { user } = this.props;
    let counter = 1;
    return (
      <React.Fragment>
        <NavigationBar />
        <Link to="/createorganization" className="btn btn-link">
          Create Organization
        </Link>
        <p>
          <Link to="/login">Logout</Link>
          {user.username}
        </p>
        <div>
          {this.props.organizations.length !== 0 ? (
            <React.Fragment>
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
                      <td>{counter++}</td>
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
              <div className="pagination">
                <Pagination>
                  <Pagination.First />
                  <Pagination.Prev />
                  <Pagination.Item>{1}</Pagination.Item>
                  <Pagination.Ellipsis />

                  <Pagination.Item>{10}</Pagination.Item>
                  <Pagination.Item>{11}</Pagination.Item>
                  <Pagination.Item active>{12}</Pagination.Item>
                  <Pagination.Item>{13}</Pagination.Item>
                  <Pagination.Item disabled>{14}</Pagination.Item>

                  <Pagination.Ellipsis />
                  <Pagination.Item>{20}</Pagination.Item>
                  <Pagination.Next />
                  <Pagination.Last />
                </Pagination>
              </div>
            </React.Fragment>
          ) : (
            <div className="message"> "No organizations for display!"</div>
          )}
        </div>
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
