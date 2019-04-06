class PostService {
  async search(): Promise<Models.Post[]> {
    return fetch('/api/posts')
      .then(response => response.json())
  }

  async save() {
    return fetch('/api/posts', { method: "POST" })
      .then(response => response.json())
  }
}

export const postService = new PostService();