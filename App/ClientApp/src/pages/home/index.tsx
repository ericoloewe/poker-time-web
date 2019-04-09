import React from 'react';
import { Post } from '../../components/post';
import './index.scss';
import { postService } from '../../services/post';
import { Input } from 'reactstrap';

interface HomeState {
  posts: Array<Models.Post>
  searchText: string
}

export default class Home extends React.Component {
  static displayName = Home.name;

  searchTimeout: NodeJS.Timeout | number | unknown = null;
  state: HomeState = {
    posts: [],
    searchText: '',
  }

  componentDidMount() {
    this.load();
  }

  private async load() {
    const posts = await postService.search();

    this.setState(() => ({ posts }));
  }

  private handleSearch = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { value } = event.target

    clearTimeout(this.searchTimeout as number)

    this.searchTimeout = setTimeout(() => {
      this.setState(() => ({ searchText: value }))
    }, 500)
  }

  render() {
    const { posts } = this.state

    return (
      <article className="home">
        {this.renderSearch()}
        {
          posts.length > 0 ?
            this.renderPosts(posts) :
            <p className="post-message">Nenhum post no momento</p>
        }
      </article>
    );
  }

  private renderPosts(posts: Models.Post[]): React.ReactNode {
    const { searchText } = this.state

    return posts
      .filter(p => searchText.length === 0 || p.message.includes(searchText))
      .map(p => (<Post key={p.id} image={p.image} message={p.message} likes={p.likes} liked={p.liked} />));
  }

  private renderSearch() {
    return (
      <Input name="search" onChange={this.handleSearch} placeholder="O que você procura?" />
    )
  }
}
