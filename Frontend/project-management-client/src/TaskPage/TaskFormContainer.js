import React, { Component } from "react";
import { TaskFormPresenter } from "./TaskFormPresenter";
import * as yup from "yup";
import { Formik } from "formik";
import PropTypes from "prop-types";
import { connect } from "react-redux";
import { createTask } from "../actions/taskActions";
import { getAll } from "../actions/userActions";

const schema = yup.object({
  name: yup
    .string()
    .max(30, "Must be 15 characters or less")
    .required("Name is required field"),
  description: yup.string().required("Description is required field"),
  estimated: yup.number(),
});

const priority = [
  { value: "Low", label: "Low" },
  { value: "Medium", label: "Medium" },
  { value: "High", label: "High" },
];

class TaskFormContainer extends Component {
  constructor(props) {
    super(props);
  }
  state = {
    selectedOption: null,
    selectedPriorityOption: null,
    dropdownUsers: [],
    task: {
      name: "",
      description: "",
      priority: "",
      estimated: "",
      assignedOn: null,
      createdBy: null,
      projectName: null,
    },
  };

  componentDidMount() {
    //TODO change this
    this.props.getAll("D3C01634-1671-4B36-96A9-6AA8BBB77027");
  }

  handleDropdownChange = (selectedOption) => {
    if (
      selectedOption.value === "Low" ||
      selectedOption.value === "Medium" ||
      selectedOption.value === "High"
    ) {
      this.setState({ selectedPriorityOption: selectedOption });
    } else {
      this.setState({ selectedOption });
    }
  };

  render() {
    let userList = [];
    if (this.props.users.allUsers !== undefined) {
      this.props.users.allUsers.forEach(function (element) {
        userList.push({ label: element.firstName, value: element.firstName });
      });
    }

    return (
      <Formik
        initialValues={{
          name: "",
          description: "",
          priority: "",
          estimated: "",
          assign: "",
        }}
        validationSchema={schema}
        onSubmit={(values, { setSubmitting }) => {
          var project = JSON.parse(localStorage.getItem("Project"));
          this.setState({
            task: {
              ...this.state.task,
              name: values.name,
              description: values.description,
              priority: this.state.selectedPriorityOption.value,
              estimated: values.estimated,
              assignedOn: this.state.selectedOption.value,
              createdBy: this.props.user.username,
              projectName: project.name,
            },
          });
          this.props.createTask(this.state.task);
          setSubmitting(false);
        }}
        validateOnBlur={false}
      >
        {({
          handleSubmit,
          handleChange,
          resetForm,
          handleBlur,
          touched,
          errors,
        }) => (
          <TaskFormPresenter
            schema={schema}
            userList={userList}
            touched={touched}
            errors={errors}
            handleSubmit={handleSubmit}
            handleChange={handleChange}
            resetForm={resetForm}
            handleBlur={handleBlur}
            selectedOption={this.state.selectedOption}
            handleDropdownChange={this.handleDropdownChange}
            selectedPriorityOption={this.state.selectedPriorityOption}
            priority={priority}
          ></TaskFormPresenter>
        )}
      </Formik>
    );
  }
}

TaskFormContainer.propTypes = {
  createTask: PropTypes.func.isRequired,
  getAll: PropTypes.func.isRequired,
};

const mapStateToProps = (state) => ({
  user: state.authentication.user,
  users: state.users,
});

const connectedTaskFormContainer = connect(mapStateToProps, {
  createTask,
  getAll,
})(TaskFormContainer);
export { connectedTaskFormContainer as TaskFormContainer };
