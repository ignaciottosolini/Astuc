// eventoService.js

import { API_URL } from "../config";

const publicacionService = {
  async getPublicaciones() {
    try {
      const res = await fetch(`${API_URL}/publicacion`);
      const data = await res.json();
      //.log("getPublicaciones:", data);
      return data;
    } catch (error) {
      //.error(error);
    }
  },

  async getPublicacionById(id) {
    try {
      const res = await fetch(`${API_URL}/publicacion/${id}`);
      const data = await res.json();
      //.log("publicacion obtenido:", data);
      return data;
    } catch (error) {
      //.error(error);
    }
  },

  async add(publicacionData) {
    try {
      const res = await fetch(`${API_URL}/publicacion`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(publicacionData),
      });

      if (res.ok) {
        //.log("publicacion agregado exitosamente", res.json());
      } else {
        //.error("Error al agregar una publicacion");
      }
    } catch (error) {
      //.error(error);
    }
  },

  async edit(id, editpublicacionData) {
    try {
      const res = await fetch(`${API_URL}/publicacion/${id}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(editpublicacionData),
      });

      if (res.ok) {
        //.log("publicacion editada exitosamente", res);
      } else {
        //.error("Error al editar una publicacion");
      }
    } catch (error) {
      //.error(error);
      throw new Error("Error al editar la publicacion");
    }
  },

  async remove(id) {
    try {
      const res = await fetch(`${API_URL}/publicacion/${id}`, {
        method: "DELETE",
      });
      if (!res.ok) {
        throw new Error("Error al eliminar la publicacion");
      }
      return true;
    } catch (error) {
      //.error(error);
    }
  },
};

export default publicacionService;
