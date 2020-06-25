import { authHeader } from "../helpers/authHeader";

export const commentService = {
  createComment,
  getAll,
};

function createComment(comment) {
  console.log("Comment service", comment);

  const requestOptions = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(comment),
  };
  return fetch(`https://localhost:44301/comment/create`, requestOptions).then(
    handleResponse
  );
}

function getAll(taskId) {
  const requestOptions = {
    method: "GET",
    headers: authHeader(),
  };

  return fetch(
    `https://localhost:44301/comment/getall/${taskId}`,
    requestOptions
  ).then(handleResponse);
}

export const handleResponse = (response) => {
  return response.text().then((text) => {
    const data = text && JSON.parse(text);

    if (!response.ok) {
      if (response.status === 401) {
        //auto logout if 401 response returned from api
        //logout();
        // location.reload(true);
      }

      const error = (data && data.message) || response.statusText;
      return Promise.reject(error);
    }

    return data;
  });
};
