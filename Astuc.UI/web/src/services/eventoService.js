// eventoService.js

import { API_URL } from "../config";

const eventoService = {
  async getEventos() {
    try {
      const res = await fetch(`${API_URL}/evento`);
      let data = await res.json();
      //.log("getEventos:", data);     
      
      
  
      return data;
    } catch (error) {
      //.error(error);
      throw error; // Puedes lanzar el error nuevamente o manejarlo según sea necesario
    }
  },
  
  async getEventoById(id) {
    try {
      const res = await fetch(`${API_URL}/evento/${id}`)
      let data = await res.json();
     
      //.log("evento obtenido:", data);
            
      
      return data;
    } catch (error) {
      //.error(error);
      throw error; // Puedes lanzar el error nuevamente o manejarlo según sea necesario
    }
  },

  async add(eventoData) {
    try {
      const res = await fetch(`${API_URL}/evento`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(eventoData),
      });

      if (res.ok) {
        //.log("Evento agregado exitosamente", res.json());
      } else {
        //.error("Error al agregar evento");
      }
    } catch (error) {
      //.error(error);
    }
  },

  async edit(id, editEventoData) {
    try {
      const res = await fetch(`${API_URL}/evento/${id}`, {
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
      const res = await fetch(`${API_URL}/evento/${id}`, {
        method: "DELETE",
      });
      if (!res.ok) {
        throw new Error("Error al eliminar el evento");
      }
      return true;
    } catch (error) {
      //.error(error);
    }
  },
  
};


    






export default eventoService;
