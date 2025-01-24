
import { API_URL } from "../config";


const mercadoPagoService = {
  async pay(card) {
    try {      
      const paymentRequest = {
        payment_method_id: card.payment_method_id,
        transaction_amount: card.transaction_amount,
        payer:{
          email : card.payer.email
        } ,
        token: card.token,
        installments: card.installments,
      };
      
      const response = await fetch(`${API_URL}/process_payment`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',          
        },
        body: JSON.stringify(paymentRequest),
      });
      
      if (!response.ok) {
        throw new Error(`Error al procesar el pago: ${response.statusText}`);
      }
      
      const result = await response.json();
      
      //.log('Resultado del pago:', result);
      return result
    } catch (error) {
      //.error('Error al procesar el pago:', error.message);
    }
  },
};

export default mercadoPagoService;


