import { taskConstants } from "../constants/taskConstants";
import { taskService } from "../services/taskService";
import { displayError } from "./alertActions";
import { history } from "../helpers/history";

export const createTask = (task) => (dispatch) => {
  dispatch(request());
  taskService.createTask(task).then(
    (task) => {
      dispatch(success(task));
      history.push("/projects");
    },
    (error) => {
      dispatch(failure(error));
      dispatch(displayError(error));
    }
  );

  function request() {
    return { type: taskConstants.CREATE_REQUEST };
  }
  function success(task) {
    return { type: taskConstants.CREATE_SUCCESS, task };
  }
  function failure(error) {
    return { type: taskConstants.CREATE_FAILURE, error };
  }
};

export const getAllTasks = (projectName, pageCount, pageSize) => (dispatch) => {
  console.log("Tessadsdast");

  dispatch(request());
  taskService.getAll(projectName, pageCount, pageSize).then(
    (data) => {
      dispatch(success(data.tasks, projectName));
      dispatch(getPageCount(data.totalPages));
    },
    (error) => {
      dispatch(failure(error));
      dispatch(displayError(error));
    }
  );

  function request() {
    return { type: taskConstants.GETALL_REQUEST };
  }
  function success(tasks) {
    return { type: taskConstants.GETALL_SUCCESS, tasks };
  }
  function failure(error) {
    return { type: taskConstants.GETALL_FAILURE, error };
  }
  function getPageCount(pageCount) {
    return { type: taskConstants.GET_PAGE_COUNT, pageCount };
  }
};
