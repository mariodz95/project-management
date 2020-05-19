import { authHeader } from "../helpers/authHeader";

export const projectService = {
  createTask,
};

function createTask(task, userId) {
  const requestOptions = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(task),
  };
  return fetch(
    `https://localhost:44301/task/create/${userId}`,
    requestOptions
  ).then(handleResponse);
}
