import { projectConstants } from "../constants/projectConstants";
import { act } from "react-dom/test-utils";

const initialState = {
  allProjects: [],
  pageCount: 1,
  pageSize: 10,
  newProject: {},
  loading: false,
  error: {},
  edit: false,
  deleting: false,
  deleteError: null,
  updateError: null,
};

export default function projects(state = initialState, action) {
  switch (action.type) {
    case projectConstants.CREATE_REQUEST: {
      return { ...state, loading: true };
    }
    case projectConstants.CREATE_SUCCESS: {
      return { ...state, newProject: action.project };
    }
    case projectConstants.CREATE_FAILURE: {
      return { ...state, error: action.error };
    }
    case projectConstants.GETALL_REQUEST: {
      return { ...state, loading: true };
    }
    case projectConstants.GETALL_SUCCESS: {
      return {
        ...state,
        allProjects: action.projects,
      };
    }
    case projectConstants.GETALL_FAILURE: {
      return { ...state, error: action.error };
    }
    case projectConstants.GET_PAGE_COUNT: {
      return { ...state, pageCount: action.pageCount };
    }
    case projectConstants.DELETE_REQUEST:
      return {
        ...state,
        deleting: true,
      };
    case projectConstants.DELETE_SUCCESS:
      return {
        ...state,
        allProjects: state.allProjects.filter((item) => item.id !== action.id),
      };
    case projectConstants.DELETE_FAILURE:
      return {
        ...state,
        allProjects: state.allProjects.map((project) => {
          if (project.id === action.id) {
            return { deleteError: action.error };
          }

          return project;
        }),
      };
    case projectConstants.UPDATE_REQUEST: {
      return {
        ...state,
        edit: true,
      };
    }
    case projectConstants.UPDATE_SUCCESS:
      return {
        ...state,
        allProjects: state.allProjects.concat(action.project),
      };
    case projectConstants.UPDATE_FAILURE: {
      return { ...state, updateError: action.error };
    }
    default:
      return state;
  }
}
