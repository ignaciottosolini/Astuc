// eventoService.js

import { API_URL } from "../config";

const membresiaService = {
  async getAll() {
    try {
      const res = await fetch(`${API_URL}/Membresia`);
      const data = await res.json();
      return data;
    } catch (error) {
      //.error(error);
    }
  },

 
};

export default membresiaService;
