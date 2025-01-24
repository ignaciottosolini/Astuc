<template>
  <Modal :visible="visible" @update:visible="closeForm" :title="modal.title">
    <Input id="email" label="Email" placeholder="" v-model="usuario.email" />
    <Input id="nombre" label="Nombre" placeholder="" v-model="usuario.name" />
    <Input id="apellido" label="Apellido" placeholder="" v-model="usuario.lastName" />
    <Input id="celular" type="number" label="Celular" placeholder="" v-model="usuario.phone" />
    <Input id="cp" type="number" label="Codigo Postal" placeholder="" v-model="usuario.postalCode" />
    <Input id="ciudad" label="Ciudad" placeholder="" v-model="usuario.city" />
    <Input id="direccion" label="Direccion" placeholder="" v-model="usuario.address" />
    <div class="col-span-12 sm:col-span-6">
      <label :for="id" class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300">Membresia</label>
      <select class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white" id="membresia" label="Membresia" v-model="usuario.membresiaId">
      <option :value="2">Membresia A</option>
      <option :value="3">Membresia B</option>

      <option :value="4">Membresia A</option>

      </select>
    </div>
   
    <div class="col-span-12 sm:col-span-6">
      <label :for="id" class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300">Activo</label>
      <input class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block  p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white" type="checkbox" v-model="usuario.active"/>
    </div>
    <div class="col-span-12 sm:col-span-6">
      <label :for="id" class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300">Reprocainn</label>
      <input class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block  p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white" type="checkbox" v-model="usuario.reprocainn"/>
    </div>
    <Input id="rol" label="Rol" placeholder="Rol" v-model="usuario.role" />
    
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
      title: "Gestionar Usuario",
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
 