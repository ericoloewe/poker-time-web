class PostService {
  async getPosts(): Promise<Models.Post[]> {
    return fetch('/api/posts')
      .then(response => response.json())
  }
}

export const postService = new PostService();