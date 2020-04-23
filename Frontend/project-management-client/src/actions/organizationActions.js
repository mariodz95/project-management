import { organizationConstants } from "../constants/organizationConstants";
import { organizationService } from "../services/organizationService";
import { displayError } from "./alertActions";
import { history } from "../helpers/history";

export const getAllOrganizations = (userId) => (dispatch) => {
  dispatch(request());

  organizationService.getAll(userId).then(
    (organizations) => {
      dispatch(success(organizations, userId));
    },
    (error) => {
      dispatch(failure(error));
      dispatch(displayError(error));
    }
  );

  function request() {
    return { type: organizationConstants.GETALL_REQUEST };
  }
  function success(organizations) {
    return { type: organizationConstants.GETALL_SUCCESS, organizations };
  }
  function failure(error) {
    return { type: organizationConstants.GETALL_FAILURE, error };
  }
};

export const createOrganization = (organization, id) => (dispatch) => {
  dispatch(request());
  organizationService.createOrganization(organization, id).then(
    (organization) => {
      dispatch(success(organization));
      history.push("/home");
    },
    (error) => {
      dispatch(failure(error));
      dispatch(displayError(error));
    }
  );

  function request() {
    return { type: organizationConstants.CREATE_REQUEST };
  }
  function success(organization) {
    return { type: organizationConstants.CREATE_SUCCESS, organization };
  }
  function failure(error) {
    return { type: organizationConstants.CREATE_FAILURE, error };
  }
};
