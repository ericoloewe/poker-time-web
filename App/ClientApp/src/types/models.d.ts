namespace Models {
  type Dict = { [key: string]: string };
  interface Post extends Dict {
    id: string;
    message: string;
    image: string;
    liked?: boolean;
  }

  interface NewPost extends Dict {
    message: string;
    image: File;
  }
}