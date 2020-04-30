import { projectConstants } from "../constants/projectConstants";

const initialState = {
  allProjects: [],
  pageCount: 1,
  pageSize: 10,
  newProject: {},
  loading: false,
  error: {},
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
    // case projectConstants.DELETE_REQUEST:
    //   // add 'deleting:true' property to project being deleted
    //   return {
    //     ...state,
    //     allProjects: state.allProjects.map((user) =>
    //       user.id === action.id ? { ...user, deleting: true } : user
    //     ),
    //   };
    case projectConstants.DELETE_SUCCESS:
      // remove deleted project from state
      return {
        ...state,
        allProjects: state.allProjects.filter(
          (item, index) => item.id === action.id
        ),
      };
    // case projectConstants.DELETE_FAILURE:
    //   // remove 'deleting:true' property and add 'deleteError:[error]' property to user
    //   return {
    //     ...state,
    //     items: state.items.map((user) => {
    //       if (user.id === action.id) {
    //         // make copy of user without 'deleting:true' property
    //         const { deleting, ...userCopy } = user;
    //         // return copy of user with 'deleteError:[error]' property
    //         return { ...userCopy, deleteError: action.error };
    //       }

    //       return user;
    //     }),
    //   };
    default:
      return state;
  }
}
