import { commentConstants } from "../constants/commentConstants";

const initialState = {
  allComments: [],
  loading: false,
  newComment: null,
  loading: false,
  error: {},
  edit: false,
  deleting: false,
  deleteError: null,
  updateError: null,
};

export default function comments(state = initialState, action) {
  switch (action.type) {
    case commentConstants.CREATE_REQUEST: {
      return { ...state, loading: true };
    }
    case commentConstants.CREATE_SUCCESS: {
      return { ...state, newComment: action.comment };
    }
    case commentConstants.CREATE_FAILURE: {
      return { ...state, error: action.error };
    }
    case commentConstants.GETALL_REQUEST: {
      return { ...state, loading: true };
    }
    case commentConstants.GETALL_SUCCESS: {
      return {
        ...state,
        allComments: action.comments,
      };
    }
    case commentConstants.GETALL_FAILURE: {
      return { ...state, error: action.error };
    }
    default:
      return state;
  }
}
