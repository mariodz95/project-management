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
import { OrganizationPage } from "../OrganizationPage/OrganizationPage";
import { CreateOrganizationPage } from "../OrganizationPage/CreateOrganizationPage";
import { ProjectPage } from "../ProjectPage/ProjectPage";
import { CreateProjectPage } from "../ProjectPage/CreateProjectPage";
import { TaskPage } from "../TaskPage/TaskPage";
import { TaskFormPage } from "../TaskPage/TaskFormPage";
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
          <PrivateRoute exact path="/home" component={HomePage} />
          <Route path="/login" component={LoginPage} />
          <Route path="/register" component={RegisterPage} />
          <Route path="/organization" component={OrganizationPage} />
          <Route path="/projects" component={ProjectPage} />
          <Route path="/createproject" component={CreateProjectPage} />
          <Route path="/taskpage" component={TaskPage} />
          <Route path="/taskfrom" component={TaskFormPage} />
          <Route
            path="/createorganization"
            component={CreateOrganizationPage}
          />
          <Redirect from="*" to="/home" />
        </Switch>
      </Router>
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
