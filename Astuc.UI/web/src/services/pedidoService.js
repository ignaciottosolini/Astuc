import { API_URL } from "../config";
import authService from './AuthService.js'

const pedidoService = {
  async getPedidos() {
    try {
      const res = await fetch(`${API_URL}/pedido`);
      const data = await res.json();
      //.log("getPedidos:", data);
      return data;
    } catch (error) {
      //.error(error);
    }
  },

  async getPedidoById(id) {
    try {
      const res = await fetch(`${API_URL}/pedido/${id}`);
      const data = await res.json();
      //.log("pedido obtenido:", data);
      return data;
    } catch (error) {
      //.error(error);
    }
  },
  async getPedidosByUserId() {
    try {
      const user = await authService.getUserLogged()

      const res = await fetch(`${API_URL}/pedido/GetByUserId/${user.id}`);
      const data = await res.json();
      //.log("pedido obtenido:", data);
      return data;
    } catch (error) {
      //.error(error);
    }
  },
  async add(pedidoData) {
    try {
      const res = await fetch(`${API_URL}/pedido`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(pedidoData),
      });

      if (res.ok) {
        //.log("pedido agregado exitosamente", res.json());
      } else {
        //.error("Error al agregar una pedido");
      }
    } catch (error) {
      //.error(error);
    }
  },

  async edit(id, editpedidoData) {
    try {
      const res = await fetch(`${API_URL}/pedido/${id}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(editpedidoData),
      });

      if (res.ok) {
        //.log("pedido editada exitosamente", res);
      } else {
        //.error("Error al editar una pedido");
      }
    } catch (error) {
      //.error(error);
      throw new Error("Error al editar la pedido");
    }
  },

  async remove(id) {
    try {
      const res = await fetch(`${API_URL}/pedido/${id}`, {
        method: "DELETE",
      });
      if (!res.ok) {
        throw new Error("Error al eliminar la pedido");
      }
      return true;
    } catch (error) {
      //.error(error);
    }
  },
};

export default pedidoService;
