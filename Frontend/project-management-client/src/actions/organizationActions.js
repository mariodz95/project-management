import { organizationConstants } from "../constants/organizationConstants";
import { organizationService } from "../services/organizationService";
import { displayError } from "./alertActions";
import { history } from "../helpers/history";

export const getAllOrganizations = (userId, pageCount, pageSize) => (
  dispatch
) => {
  dispatch(request());
  organizationService.getAll(userId, pageCount, pageSize).then(
    (data) => {
      dispatch(success(data.organizations, userId));
      dispatch(getPageCount(data.totalPages));
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
  function getPageCount(pageCount) {
    return { type: organizationConstants.GET_PAGE_COUNT, pageCount };
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
