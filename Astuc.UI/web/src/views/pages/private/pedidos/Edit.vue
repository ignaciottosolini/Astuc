<template>
  <Modal :visible="visible" @update:visible="closeForm" :title="modal.title">
    <Input id="cliente" label="Cliente" placeholder="" v-model="pedido.cliente" />    
    <div class="flex flex-col col-span-12 sm:col-span-6">
      <label for="fechaPedido" class="mr-2">Fecha</label>      
      <input type="datetime-local" id="fechaPedido" v-model="pedido.fechaPedido"
      class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 
      dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">      
    </div>    
    <Input id="total" label="Total" placeholder="" v-model="pedido.total" />
    <Input id="total" label="Total" placeholder="" v-model="pedido.direccion" />
    <Input id="total" label="Total" placeholder="" v-model="pedido.ciudad" />
    <Input id="total" label="Total" placeholder="" v-model="pedido.codigoPostal" />
    <Input id="total" label="Total" placeholder="" v-model="pedido.celular" />
    <div class="flex flex-col col-span-12 sm:col-span-6">
      <label for="countries" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Estado</label>
      <select id="countries" v-model="pedido.estado"
        class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 
        dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
        <option selected>Seleccione el estado</option>
        <option value="Pendiente">Pendiente</option>
        <option value="Entregado">Entregado</option>
        <option value="Aprobado">Aprobado</option>
      </select>
    </div>
      
    

    <template #footer>
      <button @click="handleSubmit"
        class="text-white bg-blue-500 focus:ring-2 focus:ring-primary-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center"
        type="submit">{{ buttonText }}</button>
      <div v-if="validateInput" class="bg-red-500 text-white p-2 px-4 rounded-lg">
        <p>Por favor rellene todos los campos</p>
      </div>
    </template>
  </Modal>
</template>

<script>
import { ref, toRefs, watch, computed } from 'vue';
import Input from '@/views/components/Input.vue';
import Modal from '@/views/components/Modal.vue';
import { subirImagen } from '../../../../services/cloudinaryService';
import { image } from '@cloudinary/url-gen/qualifiers/source';
export default {
  components: {
    Input,
    Modal
  },
  props: {
    visible: Boolean,
    pedido: Object,
  },
  emits: ['update', 'close'],
  setup(props, { emit }) {

    const { pedido, visible } = toRefs(props);
    const isEditing = ref(false);
    const validateInput = ref(false);
    // const imageFile = ref()
    const buttonText = computed(() => {
      return pedido.value.id ? 'Actualizar Pedido' : 'Agregar Pedido';
    });
    const modal = ref({
      title: "Gestionar Pedido",
      visible: false
    });
    watch(visible, (newValue) => {
      isEditing.value = newValue.value;
    });
    const handleSubmit = () => {
      if (pedido.value && pedido.value.id) {
        handleUpdate();
      } else {
        handleCreate();
      }
    };
    const handleCreate = async () => {
      // await subirImagen(imageFile.value).then(res => {
      //   pedido.value.imagenPrincipal = res
      // })

      emit('update', { ...pedido.value, isNew: true });
      closeForm();
    };
    const handleUpdate = async () => {
      // await subirImagen(imageFile.value).then(res => {
      //   pedido.value.imagenPrincipal = res
      // })
      emit('update', { ...pedido.value, isNew: false });
      closeForm();
    };
    const closeForm = () => {
      emit('close');
    };
    // const handleImageUpload = async (event) => {

    //   imageFile.value = event.target.files[0];


    // };

    return {
      modal,
      isEditing,
      handleSubmit,
      handleCreate,
      handleUpdate,
      closeForm,
      validateInput,
      pedido,
      buttonText,
      // handleImageUpload,
      // imageFile
    };
  },
};
</script>

<style>
/* Estilos para el modal, form-group y botones */
</style>