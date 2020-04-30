import React from "react";
import { NavigationBar } from "../NavigationBar/NavigationBar";
import { Link } from "react-router-dom";
import { getAllProjects, deleteProject } from "../actions/projectActions";
import ReactPaginate from "react-paginate";
import PropTypes from "prop-types";
import { connect } from "react-redux";
import { Table, Button } from "react-bootstrap";
import "../styles/HomePage.css";
import { FiDelete } from "react-icons/fi";
import { IconContext } from "react-icons";

class ProjectPage extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      data: [],
      pages: 0,
    };
  }

  componentDidMount() {
    this.props.getAllProjects(
      this.props.user.id,
      this.props.pageCount,
      this.props.pageSize
    );
  }

  handlePageClick = (data) => {
    let selected = data.selected + 1;
    this.props.getAllProjects(
      this.props.user.id,
      selected,
      this.props.pageSize
    );
  };

  deleteProject = (project) => {
    this.props.deleteProject(project.id);
  };

  render() {
    return (
      <React.Fragment>
        <NavigationBar />
        <Link to="/createproject" className="btn btn-link">
          Create New Project
        </Link>{" "}
        <div className="table">
          {this.props.allProjects.length !== 0 ? (
            <React.Fragment>
              <Table striped bordered hover>
                <thead>
                  <tr>
                    <th>Name</th>
                    <th>Description</th>
                    <th>Delete</th>
                  </tr>
                </thead>
                {this.props.allProjects.map((item, index) => (
                  <tbody key={index}>
                    <tr>
                      <td>{item.name}</td>
                      <td>{item.description}</td>
                      <td>
                        <button>
                          <IconContext.Provider
                            value={{
                              color: "blue",
                              size: "2em",
                              className: "global-class-name",
                            }}
                          >
                            <div
                              onClick={() => {
                                this.deleteProject(item);
                              }}
                            >
                              <FiDelete />
                            </div>
                          </IconContext.Provider>
                        </button>
                      </td>
                    </tr>
                  </tbody>
                ))}
              </Table>
              <div className="pagination">
                <ReactPaginate
                  previousLabel={"previous"}
                  nextLabel={"next"}
                  breakLabel={"..."}
                  breakClassName={"break-me"}
                  pageCount={this.props.pageCount}
                  marginPagesDisplayed={2}
                  pageRangeDisplayed={5}
                  onPageChange={this.handlePageClick}
                  containerClassName={"pagination"}
                  subContainerClassName={"pages pagination"}
                  activeClassName={"active"}
                />
              </div>
            </React.Fragment>
          ) : (
            <div className="message"> "No organizations for display!"</div>
          )}
        </div>
      </React.Fragment>
    );
  }
}

ProjectPage.propTypes = {
  getAllProjects: PropTypes.func.isRequired,
  allProjects: PropTypes.array.isRequired,
  deleteProject: PropTypes.func.isRequired,
};

const mapStateToProps = (state) => ({
  user: state.authentication.user,
  allProjects: state.projects.allProjects,
  pageCount: state.projects.pageCount,
  pageSize: state.projects.pageSize,
});

const connectedProjectPage = connect(mapStateToProps, {
  getAllProjects,
  deleteProject,
})(ProjectPage);
export { connectedProjectPage as ProjectPage };
