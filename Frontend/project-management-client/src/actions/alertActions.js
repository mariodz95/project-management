import { alertConstants } from "../constants/alertConstants";

export const alertActions = {
  success,
  error,
};

function success(message) {
  return { type: alertConstants.SUCCESS, message };
}

function error(message) {
  return { type: alertConstants.ERROR, message };
}

export const clear = () => {
  return { type: alertConstants.CLEAR };
};
