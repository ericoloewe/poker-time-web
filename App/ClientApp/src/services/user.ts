class UserService {
  async createAndLogin(newUser: Models.NewUser): Promise<Models.LoggedUser> {
    var formData = new FormData();

    for (var name in newUser) {
      formData.append(name, newUser[name]);
    }

    return fetch('/api/user/create-and-login', { method: "POST", body: formData })
      .then(response => response.json())
  }

  async login(user: Models.UserLogin): Promise<Models.LoggedUser> {
    return fetch('/api/user/login', {
      method: "POST",
      body: JSON.stringify(user)
    }).then(response => response.json())
  }
}

export const userService = new UserService();