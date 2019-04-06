import React, { Component } from 'react';
import { UserAvatar } from '../user-avatar';
import { ReactComponent as Home } from './home.svg';
import { ReactComponent as Dice } from './dice.svg';
import { ReactComponent as Question } from './question.svg';
import { ReactComponent as Cog } from './cog.svg';
import './index.scss';

export class Navigation extends Component {
  render() {
    return (
      <section className="navigation">
        <a href="/" className="link home">
          <Home />
        </a>
        <a href="/" className="link game">
          <Dice />
        </a>
        <UserAvatar />
        <a href="/" className="link about">
          <Question />
        </a>
        <a href="/" className="link settings">
          <Cog />
        </a>
      </section >
    );
  }
}
