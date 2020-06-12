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
  console.log("prije zadnje{");

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
      console.log("Zadnje");
      return {
        ...state,
        allTasks: action.tasks,
      };
    }
    case taskConstants.GETALL_FAILURE: {
      return { ...state, error: action.error };
    }
    default:
      return state;
  }
}
