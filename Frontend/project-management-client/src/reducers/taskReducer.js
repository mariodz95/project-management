import { taskConstants } from "../constants/taskConstants";

const initialState = {
  allTasks: [],
  pageCount: 1,
  pageSize: 10,
  newTask: {},
  loading: false,
  error: {},
  edit: false,
  deleting: false,
  deleteError: null,
  updateError: null,
};

export default function tasks(state = initialState, action) {
  switch (action.type) {
    case taskConstants.CREATE_REQUEST: {
      return { ...state, loading: true };
    }
    case taskConstants.CREATE_SUCCESS: {
      return { ...state, newTask: action.project };
    }
    case taskConstants.CREATE_FAILURE: {
      return { ...state, error: action.error };
    }
    case taskConstants.GETALL_REQUEST: {
      return { ...state, loading: true };
    }
    case taskConstants.GETALL_SUCCESS: {
      return {
        ...state,
        allTasks: action.tasks,
      };
    }
    case taskConstants.GETALL_FAILURE: {
      return { ...state, error: action.error };
    }
    case taskConstants.DELETE_REQUEST:
      return {
        ...state,
        deleting: true,
      };
    case taskConstants.GET_PAGE_COUNT: {
      return { ...state, pageCount: action.pageCount };
    }
    case taskConstants.DELETE_SUCCESS:
      return {
        ...state,
        allTasks: state.allTasks.filter((item) => item.id !== action.id),
      };
    case taskConstants.DELETE_FAILURE:
      return {
        ...state,
        allTasks: state.allTasks.map((task) => {
          if (task.id === action.id) {
            return { deleteError: action.error };
          }
          return task;
        }),
      };
    default:
      return state;
  }
}
