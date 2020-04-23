import { authHeader } from "../helpers/authHeader";

export const organizationService = {
  getAll,
  createOrganization,
};

function getAll() {
  const requestOptions = {
    method: "GET",
    headers: authHeader(),
  };
  return fetch(
    `https://localhost:44301/organization/getall`,
    requestOptions
  ).then(handleResponse);
}

function logout() {
  // remove user from local storage to log user out
  localStorage.removeItem("user");
}

function createOrganization(organization, id) {
  const requestOptions = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(organization),
  };
  return fetch(
    `https://localhost:44301/organization/${id}`,
    requestOptions
  ).then(handleResponse);
}

function handleResponse(response) {
  return response.text().then((text) => {
    const data = text && JSON.parse(text);
    if (!response.ok) {
      if (response.status === 401) {
        //auto logout if 401 response returned from api
        logout();
        // location.reload(true);
      }

      const error = (data && data.message) || response.statusText;
      return Promise.reject(error);
    }

    return data;
  });
}
