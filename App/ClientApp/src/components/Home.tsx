import React, { Component } from 'react';
import { Post } from './Post/Post';
import './Home.scss';
import { postService } from '../services/post';

interface HomeState {
  posts: Array<Models.Post>
}

export class Home extends Component {
  static displayName = Home.name;

  state: HomeState = {
    posts: []
  }

  componentDidMount() {
    this.load();
  }

  private async load() {
    const posts = await postService.getPosts();

    this.setState(() => ({ posts }));
  }

  render() {
    const { posts } = this.state

    return (
      <article className="home">
        {posts.map(p => (
          <Post
            key={p.message}
            image={p.image}
            message={p.message}
          />
        ))}
      </article>
    );
  }
}
