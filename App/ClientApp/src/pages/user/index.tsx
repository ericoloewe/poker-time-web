import React from 'react';
import './index.scss';
import { FormGroup, Label, Input, Form, Button } from 'reactstrap';

export default class User extends React.Component {
  static displayName = User.name;

  state = {
    email: '',
    name: '',
  }

  private handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { value, name } = event.target

    this.setState(() => ({ [name]: value }))
  }

  private handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {

  }

  render() {
    return (
      <article className="user">
        <Form onSubmit={this.handleSubmit}>
          {this.renderEmail()}
          {this.renderName()}
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
}
