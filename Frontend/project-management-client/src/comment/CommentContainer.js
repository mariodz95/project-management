import React, { Component } from "react";
import { CommentPresenter } from "./CommentPresenter";
import {
  createComment,
  getAllComments,
  _delete,
  updateComment,
} from "../actions/commentAction";
import PropTypes from "prop-types";
import { connect } from "react-redux";

let value = null;
let editValue = null;

export default class CommentContainer extends Component {
  constructor(props) {
    super(props);
    // this.state = { task: this.props.location.state.task };
    this.textInput = React.createRef();
    this.textEdit = React.createRef();
  }

  state = {
    edit: false,
    update: null,
    task: this.props.task,
    comment: {
      text: null,
      userId: null,
      taskId: null,
      userName: null,
    },
  };
  componentDidMount() {
    this.props.getAllComments(this.state.task.id);
  }
  submit = () => {
    if (this.state.edit === false) {
      this.setState(
        {
          comment: {
            text: value,
            taskId: this.state.task.id,
            userId: this.props.user.id,
            userName: this.props.user.username,
          },
        },
        () => this.props.createComment(this.state.comment),
        this.setState({ comment: { text: null } })
      );
    } else {
      this.state.update.text = editValue;
      this.props.updateComment(this.state.update.id, this.state.update);
    }
    this.textInput.current.value = null;
    this.setState({ edit: false });
  };

  handleChange = () => {
    if (this.state.edit === false) {
      value = this.textInput.current.value;
    } else {
      editValue = this.textEdit.current.value;
    }
  };

  delete = (id) => {
    this.props._delete(id);
  };

  update = (comment) => {
    this.setState({ edit: true });
    this.setState({ update: comment });
  };
  render() {
    return (
      <CommentPresenter
        submit={this.submit}
        handleChange={this.handleChange}
        textInput={this.textInput}
        allComments={this.props.allComments}
        delete={this.delete}
        update={this.update}
        edit={this.state.edit}
        itemUpdate={this.state.update}
        textEdit={this.textEdit}
      ></CommentPresenter>
    );
  }
}

CommentContainer.propTypes = {
  createComment: PropTypes.func.isRequired,
  getAllComments: PropTypes.func.isRequired,
  _delete: PropTypes.func.isRequired,
  updateComment: PropTypes.func.isRequired,
};

const mapStateToProps = (state) => ({
  user: state.authentication.user,
  allComments: state.comments.allComments,
});

const connectedCommentContainer = connect(mapStateToProps, {
  createComment,
  getAllComments,
  _delete,
  updateComment,
})(CommentContainer);
export { connectedCommentContainer as CommentContainer };
