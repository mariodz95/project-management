import React from "react";
import { Form, Button, FormControl, Row, Col } from "react-bootstrap";
import { Link } from "react-router-dom";
import { getAllTasks } from "../actions/taskActions";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import { TaskList } from "./TaskList";

class TaskListContainer extends React.Component {
  constructor(props) {
    super(props);
  }

  componentDidMount() {
    this.props.getAllTasks(
      this.props.location.state.project,
      this.props.pageCount,
      this.props.pageSize
    );
  }

  handleDelete = (taskId) => {
    console.log("Task id", taskId);
    var answer = window.confirm("Are you sure you want to delete this task?");
    if (answer) {
      // Save it!
    } else {
      // Do nothing!
    }
  };

  render() {
    return (
      <React.Fragment>
        <Row xs={4} md={4} lg={6}>
          <Col>
            <Link
              to={{
                pathname: "/taskfrom",
                state: { project: this.props.location.state.project },
              }}
            >
              Create New Task
            </Link>
          </Col>
        </Row>
        <TaskList
          tasks={this.props.allTasks}
          handleDelete={this.handleDelete}
        ></TaskList>
      </React.Fragment>
    );
  }
}

TaskListContainer.propTypes = {
  getAllTasks: PropTypes.func.isRequired,
  allTasks: PropTypes.array.isRequired,
};

const mapStateToProps = (state) => ({
  allTasks: state.tasks.allTasks,
  pageCount: state.tasks.pageCount,
  pageSize: state.tasks.pageSize,
});

const connectedTaskListContainer = connect(mapStateToProps, {
  getAllTasks,
})(TaskListContainer);
export { connectedTaskListContainer as TaskListContainer };
