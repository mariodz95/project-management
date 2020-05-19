import { taskConstants } from "../constants/taskConstants";

const initialState = {
    allProjects: [],
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

export default function projects(state = initialState, action) {
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
}
