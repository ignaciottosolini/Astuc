

import { API_URL } from "../config";
import authService from './AuthService.js'
const cartService = {
 
  async addInsumoToCart(data) {
    try {
      const user = await authService.getUserLogged()
      // //.log(data)
      data = {
        ...data,
        userId: user.id
      }
      const res = await fetch(`${API_URL}/insumoCarrito`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      });
      return await res
    } catch (error) {
      //.error(error);
    }
  },
  async getCartByUserId() {
    try {
      const user = await authService.getUserLogged()
      const res = await fetch(`${API_URL}/Carrito/GetByUserId${user.id}`);
      let data = await res.json();
     
            
      
      return data;
    } catch (error) {
      //.error(error);
    }
  },
  async remove(id) {
    try {
      const res = await fetch(`${API_URL}/insumoCarrito/${id}`, {
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

export default cartService;
