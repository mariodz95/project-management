import { authHeader } from "../helpers/authHeader";

export const projectService = {
  createProject,
  getAll,
  _deleteProject,
};

function createProject(project, id) {
  const requestOptions = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(project),
  };
  return fetch(
    `https://localhost:44301/project/create/${id}`,
    requestOptions
  ).then(handleResponse);
}

function getAll(userId, pageNumber, pageSize) {
  const requestOptions = {
    method: "GET",
    headers: authHeader(),
  };

  return fetch(
    `https://localhost:44301/project/getall/${userId}&${pageNumber}&${pageSize}`,
    requestOptions
  ).then(handleResponse);
}

function _deleteProject(id) {
  const requestOptions = {
    method: "POST",
    headers: authHeader(),
  };

  return fetch(
    `https://localhost:44301/project/delete/${id}`,
    requestOptions
  ).then(handleResponse);
}

function logout() {
  // remove user from local storage to log user out
  localStorage.removeItem("user");
}

export const handleResponse = (response) => {
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
};
