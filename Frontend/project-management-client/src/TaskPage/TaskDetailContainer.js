import React, { Component } from "react";
import { TaskDetailPresenter } from "./TaskDetailPresenter";
import { connect } from "react-redux";

class TaskDetailContainer extends Component {
  constructor(props) {
    super(props);
  }
  state = {
    task: this.props.location.state.task,
    comment: {
      text: null,
      userId: null,
      taskId: null,
      userName: null,
    },
  };
  render() {
    return (
      <div>
        <TaskDetailPresenter task={this.state.task}></TaskDetailPresenter>
      </div>
    );
  }
}

const mapStateToProps = (state) => ({
  user: state.authentication.user,
});

const connectedTaskDetailContainer = connect(
  mapStateToProps,
  {}
)(TaskDetailContainer);
export { connectedTaskDetailContainer as TaskDetailContainer };
