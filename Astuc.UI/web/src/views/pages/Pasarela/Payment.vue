<template>
  
  <div class="flex flex-row justify-center">
    <Toast :toastStyle="toastStyle" :visible="showToast" :message="messageToast"></Toast>
    <div class="flex flex-col basis-1/4">
      <h2 class="text-4xl pl-2">Checkout</h2>

      <div id="cardPaymentBrick_container"></div>
    </div>
    <div class="basis-1/4 w-full ">
      <div id="wallet_container"></div>
      <div></div>

    </div>

  </div>

  <!-- <h2 class="font-bold text-md mt-6 mb-6">Eventos Disponibles</h2>
  <ul>
    <li v-for="evento in eventos" :key="evento.id" @click="seleccionarEvento(evento)">
      {{ evento.nombre }} - {{ evento.descripcion }}
    </li>
  </ul> -->

</template>

<script>
import { ref, toRefs, onMounted,computed } from 'vue';
import mercadoPagoService from '../../../services/mercadoPagoService';
import insumoPedidoService from '../../../services/insumoPedidoService';
import { MercadoPagoConfig } from 'mercadopago';
import Toast from '../../components/Toast.vue';
 export default {

  name: "Payment",
  components: {
    Toast
  },
  props: {
    insumos: Array,
    userInfo: Object,
    cartId: Number

  },
  setup(props, { emit }) {
    const { insumos,userInfo, cartId } = toRefs(props)
    const showToast = ref(false)
    const messageToast =ref("")
    const toastStyle = ref([])
    const statusPay = ref ("")
    const mpApiKey = "APP_USR-f740c63d-cdb4-4a83-9fdb-aa2e6a2c9650";
    const totalPrice = computed(() => {
            if(insumos.value){

                return insumos.value.reduce((total, insumo) => total + (insumo.cantidad * insumo.insumo.precioVenta), 0)
            }
        });
        
    const createPaymentBrick = () => {
      
      

      // const mp = new MercadoPago('APP_USR-4b253a8b-e664-4c68-b118-c9be712efb50', {
      //   // const mp = new MercadoPago('TEST-ef62b8be-dcdc-4e9d-a97f-d7fc76cf81ca', {
      //   locale: 'es-AR'
      // });
      const mp = new MercadoPago(mpApiKey, {
        locale: 'es-AR'
      });
  


      const bricksBuilder = mp.bricks();
      const renderCardPaymentBrick = async (bricksBuilder) => {
        const settings = {
          initialization: {
            amount: totalPrice.value, // monto a ser pago
            payer: {
              email: "",
            },
          },
          customization: {
            visual: {
              hideFormTitle: true,
              style: {
                customVariables: {
                  baseColor: "#000000",
                  buttonTextColor: "#FFFFFF"
                }
              }
            },
            paymentMethods: {
              maxInstallments: 1,
            }
          },
          callbacks: {
            onReady: () => {
              // callback llamado cuando Brick esté l isto
            },
            onSubmit:async (cardFormData) => {
              showToast.value = false
              // return new Promise((resolve, reject) => {
              //   mercadoPagoService.pay(cardFormData)
              // });
              await mercadoPagoService.pay(cardFormData).then(res => {
              if(res.status && res.statusDetail){
                if(res.status == 'rejected'){
                  toastStyle.value = ['bg-red-500']
                  messageToast.value = `${translatedErrors(res.status)} \n ${translatedErrors(res.statusDetail)  }`
                  showToast.value = true
                }
                if(res.status == 'approved'){
                  statusPay.value = 'approved'
                  toastStyle.value = ['bg-green-500']
                  messageToast.value = `${translatedErrors(res.status)} \n ${translatedErrors(res.statusDetail)  }`
                  showToast.value = true
                  const dataPedido = setDataPedido()
                   insumoPedidoService.add(dataPedido).then(res => {
                   })
                }
                if(res.status == "in_process"){
                  toastStyle.value = ['bg-yellow-500']
                  statusPay.value = 'in_process'

                  messageToast.value = `${translatedErrors(res.status)} \n ${translatedErrors(res.statusDetail)  }`
                  showToast.value = true
                  const dataPedido = setDataPedido()
                   insumoPedidoService.add(dataPedido).then(res => {
                   })
                }}
              windows.cardPaymentBrickController.unmount()
            })
            },
            onError: (error) => {
              // callback llamado para todos los casos de error de Brick
            },
          },
        };
        window.cardPaymentBrickController = await bricksBuilder.create('cardPayment', 'cardPaymentBrick_container', settings);
      };
      renderCardPaymentBrick(bricksBuilder);
    }
    const createPaymentCheckoutPro = () => {
      const mp = new MercadoPago(mpApiKey, {
        // const mp = new MercadoPago('TEST-ef62b8be-dcdc-4e9d-a97f-d7fc76cf81ca', {
        locale: 'es-AR'
      });
      const bricksBuilder = mp.bricks();
      mp.bricks().create("wallet", "wallet_container", {
        initialization: {
          // preferenceId: "<PREFERENCE_ID>",
        },
        customization: {
          texts: {
            valueProp: 'smart_option',
          },
        },
        callbacks: {
          onReady: () => {
            // callback llamado cuando Brick esté listo
          },
          onSubmit: (cardFormData) => {
            // return new Promise((resolve, reject) => {
            //   mercadoPagoService.pay(cardFormData)
            // });
           
          },
          onError: (error) => {
            // callback llamado para todos los casos de error de Brick
          },
        },
      })
    }
    const loadPreferences = () => {
      const client = new MercadoPagoConfig({ accessToken:mpApiKey });
      const preference = new Preference(client);

      preference.create({
        body: {
          items: [
            {
              title: 'Productos Astuc',
              quantity: 1,
              unit_price: 100
            }
          ],
        }
      })
        .then()
        .catch();
    }
    const initBrick = async () => {
      await createPaymentBrick()

    }
    const setDataPedido = () => {
      const data = {
        email: userInfo.value.email,
        celular: userInfo.value.phone.toString(),
        ciudad: userInfo.value.city,
        codigoPostal: userInfo.value.postalCode,
        carritoId: cartId.value,
        total: totalPrice.value,
        direccion: userInfo.value.address,
        estado: translatedErrors(statusPay.value)
      }
      return data
    }
    onMounted(async() => {
      
      // await createPaymentCheckoutPro()
    })
    const translatedErrors =(error) =>{
    const translationMap = {
        "rejected" : "Pago Rechazado",
        "cc_rejected_insufficient_amount": "No tiene fondos suficientes.",
        "cc_rejected_card_error": "No pudimos procesar tu tarjeta",
        "cc_rejected_card_disabled	": "Tarjeta deshabilitada",
        "cc_rejected_blacklist": "No pudimos procesar tu pago",
        "cc_rejected_bad_filled_security_code": "Revisa el codigo de seguridad de tu tarjeta",
        "cc_rejected_bad_filled_other": "Revisa los datos",
        "cc_rejected_bad_filled_date": "Revisa la fecha de vencimiento",
        "cc_rejected_bad_filled_card_number": "Revisa el numero de tu tarjeta",
        "approved": "Aprobado",
        "accredited": "¡Listo! Se acreditó tu pago",
        "cc_rejected_high_risk": "Prueba con otros medios de pago",
        "in_process": "Proceso",
        "pending_review_manual": "Pago en revisión, te llegara un email cuando se realice el pago",
        
      }
      return translationMap[error];


};
    return{
      loadPreferences,
      createPaymentBrick,
      createPaymentCheckoutPro,
      insumos,
      totalPrice,
      initBrick,showToast,
      messageToast,toastStyle,
      translatedErrors,setDataPedido,
      userInfo,cartId
      ,statusPay,
      mpApiKey
    }

  }

}





</script>


<style scoped>
.btn {
  background-color: #4caf50;
  /* Color de fondo */
  color: white;
  /* Color del texto */
  border: none;
  /* Sin borde */
  padding: 10px 20px;
  /* Relleno interno */
  text-align: center;
  /* Alineación del texto */
  text-decoration: none;
  /* Sin decoración de texto */
  display: inline-block;
  font-size: 16px;
  margin: 4px 2px;
  cursor: pointer;
  border-radius: 4px;
  /* Bordes redondeados */
}

#cardPaymentBrick_container form div section div div select {
  background-image: none;
}

.svelte-p4q4i8 {
  background-image: none;

}

/* Estilos adicionales según sea necesario */
</style>
