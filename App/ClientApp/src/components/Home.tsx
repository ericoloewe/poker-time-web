import React, { Component } from 'react';
import { Post } from './Post/Post';
import './Home.scss';

export class Home extends Component {
  static displayName = Home.name;

  state = {
    posts: [
      {
        image: "https://assets.entrepreneur.com/content/3x2/2000/20151023204134-poker-game-gambling-gamble-cards-money-chips-game.jpeg?width=700&crop=2:1",
        message: "Some quick example text to build on the card title and make up the bulk of the card's content."
      },
      {
        image: "https://3c1703fe8d.site.internapcdn.net/newman/gfx/news/hires/2018/aguidetopoke.jpg",
        message: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Facilis, esse voluptatem ex iure aliquam quas sed aperiam ut molestias! Aperiam, voluptates ex eaque ullam facere blanditiis doloribus quis reiciendis provident."
      },
      {
        image: "http://www.clearwatercasino.com/wp-content/uploads/2014/03/Web-Landing-700x386.png",
        message: "Sit amet consectetur adipisicing elit. Facilis, esse voluptatem ex iure aliquam quas sed aperiam ut molestias! Aperiam, voluptates ex eaque ullam facere blanditiis doloribus quis reiciendis provident."
      },
    ]
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
