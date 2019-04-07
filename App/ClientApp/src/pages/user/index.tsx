import React from 'react';
import './index.scss';
import { FormGroup, Label, Input, Form, Button, Col, FormText } from 'reactstrap';
import { userService } from '../../services/user';

export default class User extends React.Component {
  static displayName = User.name;

  state = {
    email: '',
    name: '',
    password: '',
    image: null,
  }

  private handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { value, name } = event.target

    this.setState(() => ({ [name]: value }))
  }

  private handleFileInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { files } = event.target
    let image = null as null | File

    if (files != null) {
      image = files.item(0);
    }

    this.setState(() => ({ image }))
  }

  private handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event && event.preventDefault();

    const { image, name, email, password } = this.state

    if (image == null || name == null || email == null || password == null) {
      throw new Error('Fill the fields!')
    }

    await userService.createAndLogin({ image, name, email, password })
  }

  render() {
    return (
      <article className="user">
        <Form onSubmit={this.handleSubmit}>
          {this.renderEmail()}
          {this.renderName()}
          {this.renderPassword()}
          {this.renderImage()}
          <Button color="primary">Enviar</Button>
        </Form>
      </article>
    );
  }

  private renderEmail() {
    const { email } = this.state

    return (
      <FormGroup>
        <Label for="email">Email</Label>
        <Input type="text" name="email" id="email" value={email} onChange={this.handleChange} placeholder="Seu Email" />
      </FormGroup>
    );
  }

  private renderName() {
    const { name } = this.state

    return (
      <FormGroup>
        <Label for="name">Nome</Label>
        <Input type="text" name="name" id="name" value={name} onChange={this.handleChange} placeholder="Seu nome" />
      </FormGroup>
    );
  }

  private renderPassword() {
    const { password } = this.state

    return (
      <FormGroup>
        <Label for="password">Senha</Label>
        <Input type="password" name="password" id="password" value={password} onChange={this.handleChange} placeholder="Sua senha" />
      </FormGroup>
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
}
