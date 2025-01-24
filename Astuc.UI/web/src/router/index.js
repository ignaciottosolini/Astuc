import { createWebHistory, createRouter } from "vue-router";
import Landing from "../views/pages/public/Landing.vue"
import Tienda from "../views/pages/public/Tienda.vue"
import ProductoDetalle from "../views/pages/public/ProductoDetalle.vue"
import Insumos from "../views/pages/private/insumos/Insumos.vue"
import Eventos from "../views/pages/private/eventos/Eventos.vue"
import Panel from "../views/pages/private/panel-usuario/Panel.vue"
import Orders from "../views/pages/private/panel-usuario/Orders.vue"
import Admin from "../views/pages/private/admin/Index.vue"
import Login from "../views/pages/auth/Login.vue"
import ResetPassword from "../views/pages/auth/ResetPassword.vue"
import Register from "../views/pages/auth/Register.vue"
import Membresias from "../views/pages/public/Membresias.vue";
import Usuarios from "../views/pages/private/usuarios/Usuarios.vue"
import Publicaciones from "../views/pages/private/publicaciones/Publicaciones.vue"
import Pedidos from "../views/pages/private/Pedidos/Pedidos.vue"

import PaymentGateway from "../views/pages/Pasarela/PaymentGateway.vue"
import NoticiaDetalle from "../views/pages/public/NoticiaDetalle.vue"


const routes = [
  {
    path: "/",
    name: "Landing",
    component: Landing,
  },
  {
    path: "/iniciar-sesion",
    name: "Login",
    component: Login,
  },
  {
    path: "/recuperar-contrasena",
    name: "ResetPassword",
    component: ResetPassword,
  },
  {
    path: "/asociarse",
    name: "Register",
    component: Register,
  },
  {
    path: "/pedido",
    name: "Pedido",
    component: PaymentGateway,
  },
  // {
  //   path: "/insumos",
  //   name: "Insumos",
  //   component: Insumos,
  // },

  // {
  //   path: "/eventos",
  //   name: "Eventos",
  //   component: Eventos,
  // },

  // {
  //   path: "/publicaciones",
  //   name: "Publicaciones",
  //   component: Publicaciones,
  // },
  // {
  //   path: "/pedidos",
  //   name: "Pedidos",
  //   component: Pedidos,
  // },
  {
    path: "/tienda",
    name: "Tienda",
    component: Tienda,
  },
  {
    path: "/panel-usuario",
    name: "Panel",
    component: Panel,
     },
     {
      path: "/mis-ordenes", // Ruta anidada para "Insumos" bajo "/admin"
      name: "Orders",
      component: Orders,
    },
  {
    path: "/membresias",
    name: "Membresias",
    component: Membresias,
  },
  {
    path: "/producto/:id",
    name: "ProductoDetalle",
    component: ProductoDetalle,
   
  },
  {
    path: "/noticia/:id",
    name: "NoticiaDetalle",
    component: NoticiaDetalle,
   
  },
  {
    path: "/admin",
    name: "Admin",
    component: Admin,
    children: [
      {
        path: "insumos", // Ruta anidada para "Insumos" bajo "/admin"
        name: "AdminInsumos",
        component: Insumos,
      },
      {
        path: "eventos", // Nueva ruta para "/admin/eventos"
        name: "AdminEventos",
        component: Eventos,
      },
      {
        path: "usuarios", // Nueva ruta para "/admin/eventos"
        name: "AdminUsuarios",
        component: Usuarios,
      },
      {
        path: "pedidos", // Nueva ruta para "/admin/eventos"
        name: "AdminPedidos",
        component: Pedidos,
      },
      {
        path: "publicaciones", 
        name: "AdminPublicaciones",
        component: Publicaciones,
      },
    ],
  },
  
];

const router = createRouter({
  mode: history,
  history: createWebHistory(),
  routes,
});

export default router;
