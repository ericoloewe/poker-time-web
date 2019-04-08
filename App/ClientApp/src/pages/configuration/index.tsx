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
              (
                <React.Fragment>
                  <Link className="btn btn-primary btn-block" to="/login">Entrar</Link>
                  <Link className="btn btn-secondary btn-block" to="/usuario">Cadastrar-se</Link>
                </React.Fragment>
              ) :
              <h1>Configurações (Em contrução)</h1>
          )}
        </LoggedUserContext.Consumer>
      </article>
    );
  }
}
