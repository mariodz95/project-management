import React from "react";
import { Link } from "react-router-dom";
import { connect } from "react-redux";
import PropTypes from "prop-types";

import { getAll, _delete, logout } from "../actions/userActions";

class HomePage extends React.Component {
  componentDidMount() {
    this.props.getAll();
  }

  handleDeleteUser(id) {
    return (e) => this.props.deleteUser(id);
  }

  render() {
    const { user, users } = this.props;
    return (
      <div className="col-md-6 col-md-offset-3">
        <p>
          <Link to="/login">Logout</Link>
        </p>
      </div>
    );
  }
}

HomePage.propTypes = {
  logout: PropTypes.func.isRequired,
};

const mapStateToProps = (state) => ({
  users: state.authentication.users,
});

const connectedHomePage = connect(mapStateToProps, { _delete, getAll, logout })(
  HomePage
);
export { connectedHomePage as HomePage };
