// eventoService.js

import { API_URL } from "../config";
import { toUrl } from "../helpers/routing";
const authService = {
  async getUsers() {
    try {
      const res = await fetch(`${API_URL}/Auth/users`);
      const data = await res.json();
      return data;
    } catch (error) {
      //.error(error);
    }
  },

  async getUserLogged() {
    try {
      if(!localStorage.getItem("token")) return;
      const res = await fetch(`${API_URL}/Auth/GetLoggedUser`, {
        method: "Get",
        headers: {
          Authorization: "Bearer " + localStorage.getItem("token"),
        },
      });
      const data = await res.json();
      
      return data;
    } catch (error) {
      //.error(error);
    }
  },

  async register(userData) {
    try {
      const res = await fetch(`${API_URL}/Auth/register`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(userData),
      });

      if (res.ok) {
        //.log("Registrado", res);
      } else {
        //.error("Error al registrar");
      }
      const data = await res.json()
      return data;
    } catch (error) {
      //.error(error);
    }
  },
  async deleteUser(id) {
    try {
      const res = await fetch(`${API_URL}/Auth/DeleteUser/`+id, {
        method: "DELETE",
        headers: {
          "Content-Type": "application/json",
        Authorization: "Bearer " + localStorage.getItem("token"),

        },

      });

      if (res.ok) {
        //.log("Registrado", res);
      } else {
        //.error("Error al registrar");
      }
      const data = await res.json()
      return data;
    } catch (error) {
      //.error(error);
    }
  },
  async edit(id,userData) {
    try {
      await fetch(`${API_URL}/Auth/editUser?id=${id}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
          Authorization: "Bearer " + localStorage.getItem("token"),
        },
        body: JSON.stringify(userData),
      }).then(res=> {
        if (res.ok) {
          // //.log("Editado", res.json());
        } else {
          //.error("Error al editar");
        }
        return res.json();
      })

      ;
    } catch (error) {
      //.error(error);
    }
  },
  async activateUser(email) {
    try {
      const res = await fetch(
        `${API_URL}/Auth/ActivateUser?=${encodeURIComponent(email)}`,
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
            Authorization: "Bearer " + localStorage.getItem("token"),
          },
          body: JSON.stringify(editEventoData),
        }
      );

      if (res.status == 200) {
        //.log("Usuario Activad", res);
      } else {
        //.error("Error al activar el usuario");
      }
      return res;
    } catch (error) {
      //.error(error);
      throw new Error("Error al activar el usuario");
    }
  },

  async desactivateUser(email) {
    try {
      const res = await fetch(
        `${API_URL}/Auth/DesactivateUser?=${encodeURIComponent(email)}`,
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
            Authorization: "Bearer " + localStorage.getItem("token"),
          },
          body: JSON.stringify(editEventoData),
        }
      );

      if (res.status == 200) {
        //.log("Usuario desactivado", res);
      } else {
        //.error("Error al desactivar el usuario");
      }
      return res;
    } catch (error) {
      //.error(error);
    }
  },
  async login(data) {
    try {
      let res = await fetch(`${API_URL}/Auth/Login`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      })
      const token = await res.json()
      localStorage.setItem('token', token.token)
      await this.handleRedirectUser()
      return res
    } catch (error) {
      //.error(error);
    }
  },
  async forgotPassword(data) {
    try {
      let res = await fetch(`${API_URL}/Auth/forgotPassword`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      })
      
      return res.json()
    } catch (error) {
      //.error(error);
    }
  },
  async changePassword(data) {
    try {
      let res = await fetch(`${API_URL}/Auth/ChangePassword`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      })
      
      return res.json()
    } catch (error) {
      //.error(error);
    }
  },
  async logout() {
    try {
      let res = await fetch(`${API_URL}/Auth/logout`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        }
      })
      //.log(res)
      localStorage.removeItem('token')
      return res
    } catch (error) {
      //.error(error);
    }
  },
  async handleRedirectUser(){
    var user = await this.getUserLogged()
    //.log(user)
    if(user.role === "User"){
      window.location.href="/#inicio"

    }
    else if(user.role === "Admin")
    {
      window.location.href="/#inicio"


    }

  },
};

export default authService;
