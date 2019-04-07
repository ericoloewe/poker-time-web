import React, { Component } from 'react';
import { UserAvatar } from '../user-avatar';
import { ReactComponent as Home } from './home.svg';
import { ReactComponent as Dice } from './dice.svg';
import { ReactComponent as Question } from './question.svg';
import { ReactComponent as Cog } from './cog.svg';
import './index.scss';
import { LoggedUserContext } from '../../contexts/logged-user';

export class Navigation extends Component {
  render() {
    return (
      <section className="navigation">
        <a href="/" className="link home">
          <Home />
        </a>
        <a href="/jogo" className="link game">
          <Dice />
        </a>
        {this.renderAvatar()}
        <a href="/sobre" className="link about">
          <Question />
        </a>
        <a href="/configuracoes" className="link settings">
          <Cog />
        </a>
      </section >
    );
  }

  private renderAvatar() {
    return (
      <LoggedUserContext.Consumer>
        {loggedUser => (
          loggedUser == null ?
            null :
            <UserAvatar />
        )}
      </LoggedUserContext.Consumer>
    );
  }
}
