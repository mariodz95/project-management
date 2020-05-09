import { projectConstants } from "../constants/projectConstants";
import { displayError } from "./alertActions";
import { history } from "../helpers/history";
import { projectService } from "../services/projectService";

export const createProject = (project, id) => (dispatch) => {
  dispatch(request());
  projectService.createProject(project, id).then(
    (project) => {
      dispatch(success(project));
      history.push("/projects");
    },
    (error) => {
      dispatch(failure(error));
      dispatch(displayError(error));
    }
  );

  function request() {
    return { type: projectConstants.CREATE_REQUEST };
  }
  function success(project) {
    return { type: projectConstants.CREATE_SUCCESS, project };
  }
  function failure(error) {
    return { type: projectConstants.CREATE_FAILURE, error };
  }
};

export const getAllProjects = (userId, pageCount, pageSize, search) => (
  dispatch
) => {
  dispatch(request());
  projectService.getAll(userId, pageCount, pageSize, search).then(
    (data) => {
      console.log("Testiranje", data);
      dispatch(success(data.projects, userId));
      dispatch(getPageCount(data.totalPages));
    },
    (error) => {
      dispatch(failure(error));
      dispatch(displayError(error));
    }
  );

  function request() {
    return { type: projectConstants.GETALL_REQUEST };
  }
  function success(projects) {
    return { type: projectConstants.GETALL_SUCCESS, projects };
  }
  function failure(error) {
    return { type: projectConstants.GETALL_FAILURE, error };
  }
  function getPageCount(pageCount) {
    return { type: projectConstants.GET_PAGE_COUNT, pageCount };
  }
};

export const deleteProject = (id) => (dispatch) => {
  dispatch(request());
  projectService._deleteProject(id).then(
    (data) => {
      dispatch(success(id));
    },
    (error) => {
      dispatch(failure(error));
      dispatch(displayError(error));
    }
  );

  function request() {
    return { type: projectConstants.DELETE_REQUEST };
  }
  function success(id) {
    return { type: projectConstants.DELETE_SUCCESS, id };
  }
  function failure(error) {
    return { type: projectConstants.DELETE_FAILURE, error };
  }
};

export const updateProject = (id, project) => (dispatch) => {
  dispatch(request());
  projectService.updateProject(id, project).then(
    (data) => {
      dispatch(success(project));
      history.push("/projects");
    },
    (error) => {
      dispatch(failure(error));
      dispatch(displayError(error));
    }
  );

  function request() {
    return { type: projectConstants.UPDATE_REQUEST };
  }
  function success(project) {
    return { type: projectConstants.UPDATE_SUCCESS, project };
  }
  function failure(error) {
    return { type: projectConstants.UPDATE_FAILURE, error };
  }
};
