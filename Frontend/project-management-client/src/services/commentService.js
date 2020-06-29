import { authHeader } from "../helpers/authHeader";
import { handleResponse } from "./handleResponse";

export const commentService = {
  createComment,
  getAll,
  _delete,
  update,
};

const url = "https://localhost:44301";

function createComment(comment) {
  const requestOptions = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(comment),
  };

  return fetch(`${url}/comment/create`, requestOptions).then(handleResponse);
}

function getAll(taskId) {
  const requestOptions = {
    method: "GET",
    headers: authHeader(),
  };

  return fetch(`${url}/comment/getall/${taskId}`, requestOptions).then(
    handleResponse
  );
}

function _delete(id) {
  const requestOptions = {
    method: "DELETE",
    headers: authHeader(),
  };

  return fetch(`${url}/comment/delete/${id}`, requestOptions).then(
    handleResponse
  );
}

function update(id, comment) {
  const requestOptions = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(comment),
  };

  return fetch(`${url}/comment/update/${id}`, requestOptions).then(
    handleResponse
  );
}
