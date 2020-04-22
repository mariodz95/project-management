import React from "react";
import { Router, Route, Switch, Redirect } from "react-router-dom";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import { history } from "../helpers/history";
import { clear } from "../actions/alertActions";
import { PrivateRoute } from "../components/privateRoute";
import { LoginPage } from "../LoginPage/LoginPage";
import { HomePage } from "../HomePage/HomePage";
import { RegisterPage } from "../RegisterPage/RegisterPage";
import { OrganizationPage } from "../organization/OrganizationPage";
import { CreateOrganizationPage } from "../organization/CreateOrganizationPage";
import Container from "react-bootstrap/Container";

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
      <Container className="container">
        <Router history={history}>
          <Switch>
            <PrivateRoute exact path="/" component={HomePage} />
            <Route path="/login" component={LoginPage} />
            <Route path="/register" component={RegisterPage} />
            <Route path="/organization" component={OrganizationPage} />
            <Route
              path="/createorganization"
              component={CreateOrganizationPage}
            />
            <Redirect from="*" to="/" />
          </Switch>
        </Router>
      </Container>
    );
  }
}

App.propTypes = {
  clear: PropTypes.func.isRequired,
};

const mapStateToProps = (state) => ({
  clear: state.alert,
});

const connectedApp = connect(mapStateToProps, { clear })(App);
export { connectedApp as App };
