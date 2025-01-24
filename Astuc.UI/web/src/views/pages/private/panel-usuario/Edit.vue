<template>
  <Modal :visible="visible" @update:visible="closeForm" :title="modal.title">
    <Input id="email" label="Email" placeholder="" v-model="usuario.email" disabled />
    <Input id="nombre" label="Nombre" placeholder="" v-model="usuario.name" />
    <Input id="apellido" label="Apellido" placeholder="" v-model="usuario.lastName" />
    <Input id="celular" type="number" label="Celular" placeholder="" v-model="usuario.phone" />
    <Input id="cp" type="number" label="Codigo Postal" placeholder="" v-model="usuario.postalCode" />
    <Input id="ciudad" label="Ciudad" placeholder="" v-model="usuario.city" />
    <Input id="direccion" label="Direccion" placeholder="" v-model="usuario.address" />
    
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
export default {
  components: {
    Input,
    Modal
  },
  props: {
    visible: Boolean,
    usuario: Object,
  },
  emits: ['update', 'close'],
  setup(props, { emit }) {

    const { usuario, visible } = toRefs(props);
    const isEditing = ref(false);
    const validateInput = ref(false);
    const buttonText = computed(() => {
      return 'Actualizar Usuario'
    });
    const modal = ref({
      title: "Mis Datos",
      visible: false
    });
    watch(visible, (newValue) => {
      isEditing.value = newValue.value;
    });
    const handleSubmit = () => {

      handleUpdate();

    };
    
    const handleUpdate = async () => {

      emit('update', { ...usuario.value });
      closeForm();
    };
    const closeForm = (value) => {
      emit('close');
    };


    return {
      modal,
      isEditing,
      handleSubmit,
      handleUpdate,
      closeForm,
      validateInput,
      usuario,
      buttonText,

    };
  },
};
</script>    
<style></style>
 