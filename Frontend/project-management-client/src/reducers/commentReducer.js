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
      return {
        ...state,
        allComments: state.allComments.concat(action.comment),
      };
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
    case commentConstants.DELETE_REQUEST:
      return {
        ...state,
        deleting: true,
      };
    case commentConstants.DELETE_SUCCESS:
      return {
        ...state,
        allComments: state.allComments.filter((item) => item.id !== action.id),
      };
    case commentConstants.DELETE_FAILURE:
      return {
        ...state,
        allComments: state.allComments.map((comment) => {
          if (comment.id === action.id) {
            return { deleteError: action.error };
          }

          return comment;
        }),
      };
    case commentConstants.UPDATE_REQUEST: {
      return {
        ...state,
        edit: true,
      };
    }
    case commentConstants.UPDATE_SUCCESS:
      return {
        ...state,
        allProjects: state.allProjects,
      };
    case commentConstants.UPDATE_FAILURE: {
      return { ...state, updateError: action.error };
    }
    default:
      return state;
  }
}
