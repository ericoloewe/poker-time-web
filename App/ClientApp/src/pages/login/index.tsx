import React from 'react';
import './index.scss';
import { FormGroup, Label, Input, Form, Button, Col, FormText } from 'reactstrap';
import { userService } from '../../services/user';

export default class Login extends React.Component {
  static displayName = Login.name;

  state = {
    email: '',
    password: '',
  }

  private handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { value, name } = event.target

    this.setState(() => ({ [name]: value }))
  }

  private handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event && event.preventDefault();

    const { email, password } = this.state

    if (name == null || email == null || password == null) {
      throw new Error('Fill the fields!')
    }

    await userService.login({ email, password })
    location.href = '';
  }

  render() {
    return (
      <article className="user">
        <Form onSubmit={this.handleSubmit}>
          {this.renderEmail()}
          {this.renderPassword()}
          <Button color="primary">Entrar</Button>
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

  private renderPassword() {
    const { password } = this.state

    return (
      <FormGroup>
        <Label for="password">Senha</Label>
        <Input type="password" name="password" id="password" value={password} onChange={this.handleChange} placeholder="Sua senha" />
      </FormGroup>
    );
  }
}
