import React from "react";
import { Table, Button, Row } from "react-bootstrap";
import { Link } from "react-router-dom";
import "./Task.scss";
import ReactPaginate from "react-paginate";

export const TaskListPresenter = (props) => (
  <React.Fragment>
    <Row>
      <h1>Project name: {props.project.name}</h1>
    </Row>
    <Row>
      <Link
        className="taskLink"
        fontSize={"16px"}
        to={{
          pathname: "/taskfrom",
          state: { project: props.project },
        }}
      >
        <Button variant="link" size="lg">
          Create New Task
        </Button>
      </Link>
    </Row>

    <Table responsive>
      <thead>
        <tr>
          <th>Task name</th>
          <th>Priority</th>
          <th>Estimated/h</th>
          <th>AsssignedOn</th>
          <th>CreatedBy</th>
          <th>Created</th>
          <th>Updated</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        {props.tasks.map((item) => (
          <tr key={item.name}>
            <td>
              <Link
                to={{
                  pathname: "/taskdetail",
                  state: { task: item },
                }}
              >
                {item.name}
              </Link>
            </td>
            <td>{item.priority}</td>
            <td>{item.estimated}</td>
            <td>{item.assignedOn}</td>
            <td>{item.createdBy}</td>
            <td>{item.dateCreated}</td>
            <td>{item.dateUpdated}</td>
            <td>
              <Button variant="link" size="lg">
                Update
              </Button>
              <Button
                size="lg"
                variant="link"
                onClick={() => props.handleDelete(item.id)}
              >
                Delete
              </Button>
            </td>
          </tr>
        ))}
      </tbody>
    </Table>
    <div className="pagination">
      <ReactPaginate
        previousLabel={"previous"}
        nextLabel={"next"}
        breakLabel={"..."}
        breakClassName={"break-me"}
        pageCount={props.pageCount}
        marginPagesDisplayed={2}
        pageRangeDisplayed={5}
        onPageChange={props.handlePageClick}
        containerClassName={"pagination"}
        subContainerClassName={"pages pagination"}
        activeClassName={"active"}
      />
    </div>
  </React.Fragment>
);
