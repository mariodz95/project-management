import React from "react";
import { Link } from "react-router-dom";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import { getAll, _delete, logout } from "../actions/userActions";
import { getAllOrganizations } from "../actions/organizationActions";
import { NavigationBar } from "../NavigationBar/NavigationBar";
import { Table, Row, Col } from "react-bootstrap";
import "../styles/HomePage.css";
import ReactPaginate from "react-paginate";

class HomePage extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      data: [],
      pages: 0,
    };
  }

  componentDidMount() {
    if (this.props.allOrganizations === undefined) {
      this.props.getAllOrganizations(
        this.props.user.id,
        this.props.pageCount,
        this.props.pageSize
      );
    }
  }

  handlePageClick = (data) => {
    let selected = data.selected + 1;
    this.props.getAllOrganizations(
      this.props.user.id,
      selected,
      this.props.pageSize
    );
  };

  render() {
    const { user } = this.props;
    return (
      <React.Fragment>
        <NavigationBar />
        <Row>
          <Col>
            <Link to="/createorganization" className="btn btn-link">
              Create Organization
            </Link>
          </Col>
          <Col>
            <p>
              <Link to="/login" className="push">
                Logout
              </Link>
              {user.username}
            </p>
          </Col>
        </Row>
        <div className="table">
          {this.props.organizations.length !== 0 ? (
            <React.Fragment>
              <Table striped bordered hover>
                <thead>
                  <tr>
                    <th>#</th>
                    <th>Name</th>
                    <th>Email</th>
                    <th>Country</th>
                    <th>Address</th>
                    <th>Description</th>
                    <th>State</th>
                    <th>Zip</th>
                  </tr>
                </thead>
                {this.props.organizations.map((item, index) => (
                  <tbody key={index}>
                    <tr>
                      <td></td>
                      <td>{item.name}</td>
                      <td>{item.email}</td>
                      <td>{item.country}</td>
                      <td>{item.address}</td>
                      <td>{item.description}</td>
                      <td>{item.state}</td>
                      <td>{item.zip}</td>
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

HomePage.propTypes = {
  logout: PropTypes.func.isRequired,
  getAllOrganizations: PropTypes.func.isRequired,
  organizations: PropTypes.array.isRequired,
};

const mapStateToProps = (state) => ({
  user: state.authentication.user,
  users: state.authentication.users,
  organizations: state.organizations.allOrganizations,
  pageCount: state.organizations.pageCount,
  pageSize: state.organizations.pageSize,
});

const connectedHomePage = connect(mapStateToProps, {
  _delete,
  getAll,
  logout,
  getAllOrganizations,
})(HomePage);
export { connectedHomePage as HomePage };
