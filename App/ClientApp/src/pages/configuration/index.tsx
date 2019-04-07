import React from 'react';
import './index.scss';
import { LoggedUserContext } from '../../contexts/logged-user';
import { Link } from 'react-router-dom';

export default class Configuration extends React.Component {
  static displayName = Configuration.name;

  render() {
    return (
      <article className="configuration">
        <LoggedUserContext.Consumer>
          {loggedUser => (
            loggedUser == null ?
              <Link to="/usuario" /> :
              <h1>Configurações (Em contrução)</h1>
          )}
        </LoggedUserContext.Consumer>
      </article>
    );
  }
}
