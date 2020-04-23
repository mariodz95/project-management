import { organizationConstants } from "../constants/organizationConstants";
import { organizationService } from "../services/organizationService";
import { displayError, displaySuccess } from "./alertActions";

export const getAllOrganizations = () => (dispatch) => {
  dispatch(request());

  organizationService.getAll().then(
    (organizations) => dispatch(success(organizations)),
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
    (organizations) => dispatch(success(organizations)),
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
