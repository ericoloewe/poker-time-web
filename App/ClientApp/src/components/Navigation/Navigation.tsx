import React, { Component } from 'react';
import { UserAvatar } from '../UserAvatar';
import home from './home.svg';
import dice from './dice.svg';
import question from './question.svg';
import cog from './cog.svg';
import './Navigation.scss';

export class Navigation extends Component {
  render() {
    return (
      <section className="navigation">
        <a href="/" className="link home">
          <img src={home} alt="Link home" />
        </a>
        <a href="/" className="link game">
          <img src={dice} alt="Link game" />
        </a>
        <UserAvatar />
        <a href="/" className="link about">
          <img src={question} alt="Link about" />
        </a>
        <a href="/" className="link settings">
          <img src={cog} alt="Link setting" />
        </a>
      </section >
    );
  }
}
