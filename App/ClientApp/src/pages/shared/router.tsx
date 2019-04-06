import React, { Component, lazy } from 'react';
import { Route } from 'react-router';
import { Layout } from './layout';

export class Router extends Component {
  static displayName = Router.name;

  render() {
    const Home = lazy(() => import('../home'))
    const PostForm = lazy(() => import('../post-form'))

    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path='/criar-postagem' component={PostForm} />
      </Layout>
    );
  }
}
