import React from "react";
import { Link } from "react-router-dom";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import { getAll, _delete, logout } from "../actions/userActions";
import { getAllOrganizations } from "../actions/organizationActions";
import { NavigationBar } from "../NavigationBar/NavigationBar";

class HomePage extends React.Component {
  componentDidMount() {
    // this.props.getAll();
    if (this.props.allOrganizations === undefined) {
      this.props.getAllOrganizations();
    }
  }

  handleDeleteUser(id) {
    return (e) => this.props.deleteUser(id);
  }

  render() {
    const { user } = this.props;
    console.log("user", user);
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
            this.props.organizations.map((item) => <p>{item.name}</p>)
          )
        ) : null}
      </React.Fragment>
    );
  }
}

HomePage.propTypes = {
  logout: PropTypes.func.isRequired,
  getAllOrganizations: PropTypes.func.isRequired,
  allOrganizations: PropTypes.array.isRequired,
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
