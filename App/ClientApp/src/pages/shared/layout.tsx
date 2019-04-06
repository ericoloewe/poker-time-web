import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { Navigation } from '../../components/navigation';
import { Header } from '../../components/header';

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    return (
      <div className="shared-layout">
        <Header />
        <Container>
          {this.props.children}
        </Container>
        <Navigation />
      </div>
    );
  }
}
