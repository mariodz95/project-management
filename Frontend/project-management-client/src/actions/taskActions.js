import { taskConstants } from "../constants/taskConstants";

export const createTask = (task, userd) => (dispatch) => {
  dispatch(request());
  taskService.createProject(task, userd).then(
    (task) => {
      dispatch(success(task));
      history.push("/taskpage");
    },
    (error) => {
      dispatch(failure(error));
      dispatch(displayError(error));
    }
  );

  function request() {
    return { type: taskConstants.CREATE_REQUEST };
  }
  function success(taskConstants) {
    return { type: taskConstants.CREATE_SUCCESS, task };
  }
  function failure(error) {
    return { type: taskConstants.CREATE_FAILURE, error };
  }
};
