import React from 'react';
import './index.scss';
import { ReactComponent as Plus } from './plus.svg';
import { Link } from 'react-router-dom';
import logo from './logo-v2.jpg';

export class Header extends React.Component {
  render() {
    return (
      <section className="header">
        <Link to="/">
          <img src={logo} alt="PokerTime logo" />
        </Link>
        <Link to="/criar-postagem" className="link">
          <Plus />
        </Link>
      </section>
    )
  }
}
