import React from 'react';
import { Post } from '../../components/post';
import './index.scss';
import { postService } from '../../services/post';

interface HomeState {
  posts: Array<Models.Post>
}

export default class Home extends React.Component {
  static displayName = Home.name;

  state: HomeState = {
    posts: []
  }

  componentDidMount() {
    this.load();
  }

  private async load() {
    const posts = await postService.search();

    this.setState(() => ({ posts }));
  }

  render() {
    const { posts } = this.state

    return (
      <article className="home">
        {
          posts.length > 0 ?
            this.renderPosts(posts) :
            <p className="post-message">Nenhum post no momento</p>
        }
      </article>
    );
  }

  private renderPosts(posts: Models.Post[]): React.ReactNode {
    return posts.map(p => (<Post key={p.message} image={p.image} message={p.message} />));
  }
}
