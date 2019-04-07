import React, { Component, lazy } from 'react';
import { Route } from 'react-router';
import { Layout } from './layout';

export class Router extends Component {
  static displayName = Router.name;

  render() {
    const Home = lazy(() => import('../home'))
    const PostForm = lazy(() => import('../post-form'))
    const Game = lazy(() => import('../game'))
    const About = lazy(() => import('../about'))
    const Configuration = lazy(() => import('../configuration'))

    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path='/criar-postagem' component={PostForm} />
        <Route exact path='/jogo' component={Game} />
        <Route exact path='/sobre' component={About} />
        <Route exact path='/configuracoes' component={Configuration} />
      </Layout>
    );
  }
}
