import React, { Component } from "react";
import { TaskDetailPresenter } from "./TaskDetailPresenter";
import { createComment, getAllComments } from "../actions/commentAction";
import PropTypes from "prop-types";
import { connect } from "react-redux";

let value = null;
class TaskDetailContainer extends Component {
  constructor(props) {
    super(props);
    // this.state = { task: this.props.location.state.task };
    /* 1. Initialize Ref */
    this.textInput = React.createRef();
  }
  state = {
    task: this.props.location.state.task,
    comment: {
      text: null,
      userId: null,
      taskId: null,
    },
  };
  componentDidMount() {
    this.props.getAllComments(this.state.task.id);
  }
  submit = () => {
    this.setState({
      comment: {
        ...this.state.comment,
        text: value,
        taskId: this.state.task.id,
        userId: this.props.user.id,
        userName: this.props.user.username,
      },
    });
    console.log("test", this.state.comment);
    this.props.createComment(this.state.comment);
  };
  handleChange() {
    value = this.textInput.current.value;
    // this.state = { comment: value };

    console.log("Handle change", value);
  }
  render() {
    return (
      <div>
        <TaskDetailPresenter
          task={this.state.task}
          submit={this.submit}
          handleChange={this.handleChange}
          textInput={this.textInput}
          allComments={this.props.allComments}
        ></TaskDetailPresenter>
      </div>
    );
  }
}

TaskDetailContainer.propTypes = {
  createComment: PropTypes.func.isRequired,
  getAllComments: PropTypes.func.isRequired,
};

const mapStateToProps = (state) => ({
  user: state.authentication.user,
  allComments: state.comments.allComments,
});

const connectedTaskDetailContainer = connect(mapStateToProps, {
  createComment,
  getAllComments,
})(TaskDetailContainer);
export { connectedTaskDetailContainer as TaskDetailContainer };
