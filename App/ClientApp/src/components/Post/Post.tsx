import React, { Component } from 'react';
import { Card, CardImg, CardBody, CardText } from 'reactstrap';
import { ReactComponent as RegularHearth } from './regular-hearth.svg';
import { ReactComponent as SolidHearth } from './solid-hearth.svg';
import './Post.scss';

interface PostProps {
  message: string;
  image: string;
}

interface PostState {
  liked: boolean;
  showLike: boolean;
}

export class Post extends Component<PostProps, PostState> {
  state = {
    liked: false,
    showLike: false,
  }

  private _like = (event: React.MouseEvent<HTMLElement, MouseEvent>) => {
    this.setState((prevState: PostState) => ({
      liked: !prevState.liked,
      showLike: true
    }), () => {
      setTimeout(() => {
        this.setState(() => ({ showLike: false }))
      }, 500)
    })
  }

  render() {
    const { image, message } = this.props

    return (
      <Card className="post" onClick={this._like}>
        {this.renderLike()}
        <CardImg top width="100%" src={image} alt="Card image cap" />
        <CardBody>
          <CardText>{message}</CardText>
        </CardBody>
      </Card>
    );
  }

  private renderLike() {
    const { liked, showLike } = this.state

    if (showLike) {
      let component = null

      if (liked) {
        component = <SolidHearth className="like solid" />
      } else {
        component = <RegularHearth className="like regular" />
      }

      return (
        <div className="like-box">
          {component}
        </div>
      )
    }

    return null;
  }
}
