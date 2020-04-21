import { organizationConstants } from "../constants/organizationConstants";

const initialState = {
  allOrganizations: [],
};

export default function organizations(state = initialState, action) {
  switch (action.type) {
    case organizationConstants.GETALL_SUCCESS: {
      return { ...state, allOrganizations: action.organizations };
    }
    default:
      return state;
  }
}
