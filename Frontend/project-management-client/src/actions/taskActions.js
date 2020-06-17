import { taskConstants } from "../constants/taskConstants";
import { taskService } from "../services/taskService";
import { displayError } from "./alertActions";
import { history } from "../helpers/history";

export const createTask = (task) => (dispatch) => {
  dispatch(request());
  taskService.createTask(task).then(
    (task) => {
      dispatch(success(task));
      // history.push("/taskpage");
      history.goBack();
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

export const deleteTask = (id) => (dispatch) => {
  dispatch(request());
  taskService._deleteTask(id).then(
    (data) => {
      dispatch(success(id));
    },
    (error) => {
      dispatch(failure(error));
      dispatch(displayError(error));
    }
  );

  function request() {
    return { type: taskConstants.DELETE_REQUEST };
  }
  function success(id) {
    return { type: taskConstants.DELETE_SUCCESS, id };
  }
  function failure(error) {
    return { type: taskConstants.DELETE_FAILURE, error };
  }
};
