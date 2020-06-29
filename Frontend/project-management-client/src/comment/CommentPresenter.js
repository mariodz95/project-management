import React from "react";
import { Form, Col, Button, Card } from "react-bootstrap";

export const CommentPresenter = (props) => {
  console.log("pšors", props);
  return (
    <React.Fragment>
      <h2>Comment's:</h2>
      {props.allComments !== undefined
        ? props.allComments.map((item) => (
            <Card className="comment">
              <Card.Header>Added by: {item.userName}</Card.Header>
              <Card.Body>
                <p>
                  {props.edit === false ? (
                    item.text
                  ) : props.itemUpdate.id === item.id ? (
                    <textarea
                      defaultValue={item.text}
                      ref={props.textEdit}
                      onChange={() => props.handleChange()}
                    ></textarea>
                  ) : (
                    item.text
                  )}
                  <Button variant="link" onClick={() => props.update(item)}>
                    Edit
                  </Button>{" "}
                  <Button variant="link" onClick={() => props.delete(item.id)}>
                    Delete
                  </Button>
                </p>
              </Card.Body>
            </Card>
          ))
        : "No comments"}
      {/* <Form> */}
      <Form.Group as={Col} controlId="exampleForm.ControlTextarea1">
        <Form.Label>Add comment</Form.Label>
        <Form.Control
          as="textarea"
          rows="5"
          name="description"
          onChange={() => props.handleChange()}
          ref={props.textInput}
        />
      </Form.Group>
      <Button
        className="button"
        variant="success"
        type="submit"
        size="lg"
        value="Submit"
        onClick={props.submit}
      >
        Submit
      </Button>
      {/* </Form> */}
    </React.Fragment>
  );
};
