import { organizationConstants } from "../constants/organizationConstants";

const initialState = {
  allOrganizations: [],
  pageCount: 1,
  pageSize: 20,
  newOrganization: {},
  loading: false,
  error: {},
};

export default function organizations(state = initialState, action) {
  switch (action.type) {
    case organizationConstants.GETALL_REQUEST: {
      return { ...state, loading: true };
    }
    case organizationConstants.GETALL_SUCCESS: {
      return {
        ...state,
        allOrganizations: action.organizations,
      };
    }
    case organizationConstants.GETALL_FAILURE: {
      return { ...state, error: action.error };
    }
    case organizationConstants.CREATE_REQUEST: {
      return { ...state, loading: true };
    }
    case organizationConstants.CREATE_SUCCESS: {
      return { ...state, newOrganization: action.organization };
    }
    case organizationConstants.CREATE_FAILURE: {
      return { ...state, error: action.error };
    }
    case organizationConstants.CREATE_FAILURE: {
      return { ...state, error: action.error };
    }
    case organizationConstants.GET_PAGE_COUNT: {
      return { ...state, pageCount: action.pageCount };
    }
    default:
      return state;
  }
}
