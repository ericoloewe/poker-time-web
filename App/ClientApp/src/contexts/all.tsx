import React from 'react';
import { LoggedUserContext } from './logged-user';
import { userService } from '../services/user';

interface AllContextsState {
  loggedUser: any,
}

interface AllContextsProps {
  children: React.ReactNode,
}

export class AllContexts extends React.Component<AllContextsProps, AllContextsState> {
  state = {
    loggedUser: null as any,
  }

  componentDidMount() {
    this.load()
  }

  private async load() {
    const loggedUser = await userService.getLoggedUser()

    this.setState(() => ({ loggedUser }))
  }

  render() {
    const { children } = this.props
    const { loggedUser } = this.state

    return (
      <LoggedUserContext.Provider value={loggedUser}>
        {children}
      </LoggedUserContext.Provider>
    );
  }
}
