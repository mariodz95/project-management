import React from "react";
import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableContainer from "@material-ui/core/TableContainer";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import Paper from "@material-ui/core/Paper";
import Button from "@material-ui/core/Button";
import Input from "@material-ui/core/Input";

export const TaskList = (props) => (
  <React.Fragment>
    <form noValidate autoComplete="off">
      <Input inputProps={{ "aria-label": "description" }} />
    </form>
    <Button variant="contained" color="primary">
      Primary
    </Button>
    <TableContainer component={Paper}>
      <Table aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Task name</TableCell>
            <TableCell align="right">Priority</TableCell>
            <TableCell align="right">Estimated</TableCell>
            <TableCell align="right">AsssignedOn</TableCell>
            <TableCell align="right">CreatedBy</TableCell>
            <TableCell align="right">Description</TableCell>
            <TableCell align="right"></TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {props.tasks.map((item) => (
            <TableRow key={item.name}>
              <TableCell component="th" scope="row">
                {item.name}
              </TableCell>
              <TableCell align="right">{item.priority}</TableCell>
              <TableCell align="right">{item.estimated}</TableCell>
              <TableCell align="right">{item.assignedOn}</TableCell>
              <TableCell align="right">{item.createdBy}</TableCell>
              <TableCell align="right">{item.Description}</TableCell>
              <TableCell align="right">
                <Button
                  href="#text-buttons"
                  color="primary"
                  onClick={() => props.handleDelete(item.Id)}
                >
                  Update
                </Button>
                <Button
                  href="#text-buttons"
                  color="primary"
                  onClick={props.handleDelete}
                >
                  Delete
                </Button>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  </React.Fragment>
);
