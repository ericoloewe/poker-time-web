import React from 'react';
import { Container } from 'reactstrap';
import { Navigation } from '../../components/navigation';
import { Header } from '../../components/header';
import { AllContexts } from '../../contexts/all';

export class Layout extends React.Component {
  static displayName = Layout.name;

  render() {
    return (
      <AllContexts>
        <div className="shared-layout">
          <Header />
          <Container>
            {this.props.children}
          </Container>
          <Navigation />
        </div>
      </AllContexts>
    );
  }
}
