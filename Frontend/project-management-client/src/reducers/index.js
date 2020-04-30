import { combineReducers } from "redux";
import alert from "./alertReducer";
import authentication from "./authenticationReducer";
import users from "./userReducer";
import { registration } from "./registrationReducer";
import organizations from "./organizationReducer";
import projects from "./projectReducer";

const rootReducer = combineReducers({
  authentication,
  registration,
  users,
  alert,
  organizations,
  projects,
});

export default rootReducer;
