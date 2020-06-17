import React, { Component } from "react";
import { TaskDetailPresenter } from "./TaskDetailPresenter";

export class TaskDetailContainer extends Component {
  constructor(props) {
    super(props);
    this.state = { task: this.props.location.state.task };
    console.log("test", this.state.task);
  }
  render() {
    return (
      <div>
        <TaskDetailPresenter task={this.state.task}></TaskDetailPresenter>
      </div>
    );
  }
}

export default TaskDetailContainer;
