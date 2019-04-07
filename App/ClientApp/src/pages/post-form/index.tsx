import React from 'react';
import { Form, FormGroup, Label, Input, Button, Col, FormText } from 'reactstrap';
import './index.scss';
import { postService } from '../../services/post';

export default class PostForm extends React.Component {
  static displayName = PostForm.name;

  state = {
    image: null,
    message: '',
  }

  private handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { value } = event.target

    this.setState(() => ({ message: value }))
  }

  private handleFileInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { files } = event.target
    let image = null as null | File

    if (files != null) {
      image = files.item(0);
    }

    this.setState(() => ({ image }))
  }

  private submit = async (event: React.FormEvent<HTMLFormElement>) => {
    event && event.preventDefault();

    const { image, message } = this.state

    if (image == null || message == null) {
      throw new Error('Fill the fields!')
    }

    await postService.save({ image, message })
  }

  render() {
    return (
      <article className="post-form">
        <Form onSubmit={this.submit}>
          {this.renderMessage()}
          {this.renderImage()}
          <Button color="primary">Enviar</Button>
        </Form>
      </article>
    );
  }

  private renderImage() {
    return (
      <FormGroup row>
        <Label for="image" sm={2}>Imagem</Label>
        <Col sm={10}>
          <Input type="file" name="image" id="image" onChange={this.handleFileInputChange} />
          <FormText color="muted">
            Extensões suportadas: jpg, jpeg, png e gif
        </FormText>
        </Col>
      </FormGroup>
    );
  }

  private renderMessage() {
    const { message } = this.state

    return (
      <FormGroup>
        <Label for="message">Mensagem</Label>
        <Input type="textarea" name="message" id="message" value={message} onChange={this.handleChange} placeholder="Sua mensagem" />
      </FormGroup>
    );
  }
}
