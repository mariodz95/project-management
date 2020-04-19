import React from "react";
import { Link } from "react-router-dom";
import { connect } from "react-redux";

import { userActions, getAll } from "../actions/userActions";

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

function mapState(state) {
  const { users, authentication } = state;
  const { user } = authentication;
  return { user, users };
}

const actionCreators = {
  getUsers: userActions.getAll,
  deleteUser: userActions.delete,
};

const connectedHomePage = connect(mapState, { actionCreators, getAll })(
  HomePage
);
export { connectedHomePage as HomePage };
