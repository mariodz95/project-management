import { organizationConstants } from "../constants/organizationConstants";

const initialState = {
  allOrganizations: [],
  loading: false,
  error: {},
};

export default function organizations(state = initialState, action) {
  switch (action.type) {
    case organizationConstants.GETALL_REQUEST: {
      return { ...state, loading: true };
    }
    case organizationConstants.GETALL_SUCCESS: {
      return { ...state, allOrganizations: action.organizations };
    }
    case organizationConstants.GETALL_FAILURE: {
      return { ...state, error: action.error };
    }
    default:
      return state;
  }
}
