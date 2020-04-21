import React from "react";
import { Router, Route, Switch, Redirect } from "react-router-dom";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import { history } from "../helpers/history";
import { clear } from "../actions/alertActions";
import { PrivateRoute } from "../components/privateRoute";
import { HomePage } from "../HomePage/HomePage";
import { LoginPage } from "../LoginPage/LoginPage";
import { RegisterPage } from "../RegisterPage/RegisterPage";
import "../styles/App.css";

class App extends React.Component {
  constructor(props) {
    super(props);

    history.listen((location, action) => {
      // clear alert on location change
      this.props.clear();
    });
  }

  render() {
    return (
      <Router history={history}>
        <Switch>
          <PrivateRoute exact path="/" component={HomePage} />
          <Route path="/login" component={LoginPage} />
          <Route path="/register" component={RegisterPage} />
          <Redirect from="*" to="/" />
        </Switch>
      </Router>
    );
  }
}

App.propTypes = {
  clear: PropTypes.func.isRequired,
};

const mapStateToProps = (state) => (
  console.log("state,", state),
  {
    clear: state.alert,
  }
);

const connectedApp = connect(mapStateToProps, { clear })(App);
export { connectedApp as App };
