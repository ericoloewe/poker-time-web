import React, { Component } from 'react';
import './UserAvatar.scss';

export class UserAvatar extends Component {
  render() {
    return (
      <div className="user-avatar">
        <img className="avatar-image" src="https://cdn3.iconfinder.com/data/icons/business-round-flat-vol-1-1/36/user_account_profile_avatar_person_student_male-512.png" alt="User Avatar" />
      </div>
    );
  }
}
