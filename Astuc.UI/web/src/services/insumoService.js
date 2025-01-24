// eventoService.js

import { API_URL } from "../config";
import { eventBus } from "../views/pages/public/bus/insumoBus";

const insumoService = {
  async getAll() {
    try {
      const res = await fetch(`${API_URL}/insumo`);
      const data = await res.json();
       eventBus.value.setInsumos(data);
      return data;
    } catch (error) {
      //.error(error);
    }
  },
 

  async getById(id) {
    try {
      const res = await fetch(`${API_URL}/insumo/${id}`);
      const data = await res.json();
      return data;
    } catch (error) {
      //.error(error);
    }
  },
 

  async add(eventoData) {
    try {
      const res = await fetch(`${API_URL}/insumo`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(eventoData),
      });

      if (res.ok) {
        //.log("Insumo agregado exitosamente", res.json());
      } else {
        //.error("Error al agregar insumo");
      }
    } catch (error) {
      //.error(error);
    }
  },

  async edit(id, editEventoData) {
    try {
      const res = await fetch(`${API_URL}/insumo/${id}`, {
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
      const res = await fetch(`${API_URL}/insumo/${id}`, {
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

export default insumoService;
