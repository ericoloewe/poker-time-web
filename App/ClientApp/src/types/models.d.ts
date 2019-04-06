namespace Models {
  interface Post {
    id: string;
    message: string;
    image: string;
    liked?: boolean;
  }
}