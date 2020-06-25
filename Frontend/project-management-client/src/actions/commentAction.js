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
