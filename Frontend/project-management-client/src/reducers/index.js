import { combineReducers } from "redux";
import alert from "./alertReducer";
import authentication from "./authenticationReducer";
import users from "./userReducer";

const rootReducer = combineReducers({
  authentication,
  users,
  alert,
});

export default rootReducer;
