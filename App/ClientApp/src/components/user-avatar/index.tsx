import React from 'react';
import './index.scss';
import { LoggedUserContext } from '../../contexts/logged-user';

export function UserAvatar() {
  return (
    <LoggedUserContext.Consumer>
      {loggedUser => (
        <div className="user-avatar">
          <img className="avatar-image" src={loggedUser.image} alt="User Avatar" />
        </div>
      )}
    </LoggedUserContext.Consumer>
  );
}
