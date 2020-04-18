import { combineReducers } from "redux";
import alert from "./alertReducer";
import authentication from "./authenticationReducer";
import users from "./userReducer";
import { registration } from "./registrationReducer";
const rootReducer = combineReducers({
  authentication,
  registration,
  users,
  alert,
});

export default rootReducer;
