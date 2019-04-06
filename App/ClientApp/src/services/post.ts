class PostService {
  async search(): Promise<Models.Post[]> {
    return fetch('/api/post')
      .then(response => response.json())
  }

  async save(post: Models.NewPost) {
    var formData = new FormData();

    for (var name in post) {
      formData.append(name, post[name]);
    }

    return fetch('/api/post', { method: "POST", body: formData })
      .then(response => response.json())
  }
}

export const postService = new PostService();