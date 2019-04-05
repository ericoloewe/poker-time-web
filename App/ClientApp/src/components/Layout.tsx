import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { Navigation } from './Navigation/Navigation';

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    return (
      <div>
        <Container>
          {this.props.children}
        </Container>
        <Navigation />
      </div>
    );
  }
}