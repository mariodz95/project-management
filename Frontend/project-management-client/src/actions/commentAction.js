import { commentConstants } from "../constants/commentConstants";
import { commentService } from "../services/commentService";
import { displayError } from "./alertActions";

export const createComment = (comment) => (dispatch) => {
  dispatch(request());
  commentService.createComment(comment).then(
    (comment) => {
      dispatch(success(comment));
    },
    (error) => {
      dispatch(failure(error));
      dispatch(displayError(error));
    }
  );

  function request() {
    return { type: commentConstants.CREATE_REQUEST };
  }
  function success(comment) {
    return { type: commentConstants.CREATE_SUCCESS, comment };
  }
  function failure(error) {
    return { type: commentConstants.CREATE_FAILURE, error };
  }
};

export const getAllComments = (taskId) => (dispatch) => {
  dispatch(request());
  commentService.getAll(taskId).then(
    (data) => {
      dispatch(success(data));
    },
    (error) => {
      dispatch(failure(error));
      dispatch(displayError(error));
    }
  );

  function request() {
    return { type: commentConstants.GETALL_REQUEST };
  }
  function success(comments) {
    return { type: commentConstants.GETALL_SUCCESS, comments };
  }
  function failure(error) {
    return { type: commentConstants.GETALL_FAILURE, error };
  }
};

export const _delete = (id) => (dispatch) => {
  dispatch(request(id));

  commentService._delete(id).then(
    (user) => dispatch(success(id)),
    (error) => dispatch(failure(id, error.toString()))
  );

  function request(id) {
    return { type: commentConstants.DELETE_REQUEST, id };
  }
  function success(id) {
    return { type: commentConstants.DELETE_SUCCESS, id };
  }
  function failure(id, error) {
    return { type: commentConstants.DELETE_FAILURE, id, error };
  }
};

export const updateComment = (id, comment) => (dispatch) => {
  dispatch(request());
  commentService.update(id, comment).then(
    (data) => {
      dispatch(success(comment));
    },
    (error) => {
      dispatch(failure(error));
      dispatch(displayError(error));
    }
  );

  function request() {
    return { type: commentConstants.UPDATE_REQUEST };
  }
  function success(comment) {
    return { type: commentConstants.UPDATE_SUCCESS, comment };
  }
  function failure(error) {
    return { type: commentConstants.UPDATE_FAILURE, error };
  }
};
