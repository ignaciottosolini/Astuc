// eventoService.js

import { API_URL } from "../config";

const insumoPedidoService = {
  async getAll() {
    try {
      const res = await fetch(`${API_URL}/insumoPedido`);
      const data = await res.json();
      return data;
    } catch (error) {
      //.error(error);
    }
  },

  async getById(id) {
    try {
      const res = await fetch(`${API_URL}/insumoPedido/${id}`);
      const data = await res.json();
      return data;
    } catch (error) {
      //.error(error);
    }
  },
  async getByPedidoId(id) {
    try {
      const res = await fetch(`${API_URL}/insumoPedido/GetByPedidoId/${id}`);
      const data = await res.json();
      //.log(data)
      return data;
    } catch (error) {
      //.error(error);
    }
  },

  async add(pedidoInsumo) {
    try {
      const res = await fetch(`${API_URL}/insumoPedido`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(pedidoInsumo),
      });
     
      return await res.json()
    } catch (error) {
      //.error(error);
    }
  },

  async edit(id, editEventoData) {
    try {
      const res = await fetch(`${API_URL}/insumoPedido/${id}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(editEventoData),
      });

      if (res.ok) {
        //.log("Evento editado exitosamente", res);
      } else {
        //.error("Error al editar evento");
      }
    } catch (error) {
      //.error(error);
      throw new Error("Error al editar el evento");
    }
  },

  async remove(id) {
    try {
      const res = await fetch(`${API_URL}/insumoPedido/${id}`, {
        method: "DELETE",
      });
      if (!res.ok) {
        throw new Error("Error al eliminar el Insumo");
      }
      return true;
    } catch (error) {
      //.error(error);
    }
  },
};

export default insumoPedidoService;
