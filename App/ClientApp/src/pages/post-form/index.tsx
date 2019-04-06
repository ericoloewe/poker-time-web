import React from 'react';
import { Form, FormGroup, Label, Input, Button, Col, FormText } from 'reactstrap';
import './index.scss';
import { postService } from '../../services/post';

export default class PostForm extends React.Component {
  static displayName = PostForm.name;

  private submit = (event: React.FormEvent<HTMLFormElement>) => {
    console.log(event);
  }

  render() {
    return (
      <article className="post-form">
        <Form onSubmit={this.submit}>
          <FormGroup>
            <Label for="message">Mensagem</Label>
            <Input type="text" name="message" id="message" placeholder="Sua mensagem" />
          </FormGroup>
          <FormGroup row>
            <Label for="image" sm={2}>Imagem</Label>
            <Col sm={10}>
              <Input type="file" name="image" id="image" />
              <FormText color="muted">
                Extensões suportadas: jpg, jpeg, png e gif
              </FormText>
            </Col>
          </FormGroup>
          <Button>Enviar</Button>
        </Form>
      </article>
    );
  }
}
