// eventoService.js

import { API_URL } from "../config";

const contactoService = {
 
  async sendEmail(data) {
    try {
      const res = await fetch(`${API_URL}/contacto`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      });

      if (res.ok) {
        // //.log("Correo enviado", res.json());
      } else {
        //.error("Error al enviar el correo");
      }
    } catch (error) {
      //.error(error);
    }
  },

  
};


    






export default contactoService;
