import React from "react";
import { getAllTasks, deleteTask } from "../actions/taskActions";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import { TaskListPresenter } from "./TaskListPresenter";

class TaskListContainer extends React.Component {
  constructor(props) {
    super(props);
    this.state = { project: this.props.location.state.project };
  }

  componentDidMount() {
    this.props.getAllTasks(
      this.state.project,
      this.props.pageCount,
      this.props.pageSize
    );
  }

  handleDelete = (taskId) => {
    var answer = window.confirm("Are you sure you want to delete this task?");
    if (answer) {
      this.props.deleteTask(taskId);
    } else {
    }
  };

  handlePageClick = (data) => {
    let selected = data.selected + 1;
    this.props.getAllTasks(this.state.project, selected, this.props.pageSize);
  };

  render() {
    return (
      <React.Fragment>
        <TaskListPresenter
          tasks={this.props.allTasks}
          project={this.state.project}
          handlePageClick={this.handlePageClick}
          handleDelete={this.handleDelete}
          pageCount={this.props.pageCount}
        ></TaskListPresenter>
      </React.Fragment>
    );
  }
}

TaskListContainer.propTypes = {
  getAllTasks: PropTypes.func.isRequired,
  allTasks: PropTypes.array.isRequired,
  deleteTask: PropTypes.func.isRequired,
};

const mapStateToProps = (state) => ({
  allTasks: state.tasks.allTasks,
  pageCount: state.tasks.pageCount,
  pageSize: state.tasks.pageSize,
});

const connectedTaskListContainer = connect(mapStateToProps, {
  getAllTasks,
  deleteTask,
})(TaskListContainer);
export { connectedTaskListContainer as TaskListContainer };
