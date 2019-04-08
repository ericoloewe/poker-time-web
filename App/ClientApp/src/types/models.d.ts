namespace Models {
  type Dict = { [key: string]: string };
  
  interface NewUser extends Dict {
    email: string;
    password: string;
    image: File;
    name: string;
  }

  interface UserLogin extends Dict {
    email: string;
    password: string;
  }

  interface LoggedUser extends Dict {
    email: string;
    image: string;
    name: string;
  }

  interface Post extends Dict {
    id: string;
    message: string;
    image: string;
    likes?: number;
    liked?: boolean;
  }

  interface NewPost extends Dict {
    message: string;
    image: File;
  }
}