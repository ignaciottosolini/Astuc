<template>
  <Modal :visible="visible" @update:visible="closeForm" :title="modal.title">
    <Input id="nombre" label="Nombre" placeholder="" v-model="evento.nombre" />
    <Input id="descripcion" label="Descripción" placeholder="" v-model="evento.descripcion" />
    <!-- <input type="datetime-local" id="FechaYHora" label="Fecha y hora" v-model="evento.FechaYHora" /> -->
    <Input id="lugar" label="Lugar" placeholder="" v-model="evento.lugar" />
    <div class="flex flex-col col-span-12 sm:col-span-6">
      <label for="fechaYHora" class="mr-2">Fecha</label>
      <input type="datetime-local" id="fechaYHora" v-model="evento.fechaYHora"
        class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 
      dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
    </div>
    <Input id="precio" type="number" label="Precio" placeholder="" v-model="evento.precio" />
    <Input type="file" id="imagen" label="Imagen" @change="handleImageUpload" />
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
    evento: Object,
  },
  emits: ['update', 'close'],
  setup(props, { emit }) {

    const { evento, visible } = toRefs(props);
    const isEditing = ref(false);
    const validateInput = ref(false);
    const imageFile = ref()
    const buttonText = computed(() => {
      return evento.value.id ? 'Actualizar Evento' : 'Agregar Evento';
    });
    const modal = ref({
      title: "Gestionar Evento",
      visible: false
    });
    watch(visible, (newValue) => {
      isEditing.value = newValue.value;
    });
    const handleSubmit = () => {
      if (evento.value && evento.value.id) {
        handleUpdate();
      } else {
        handleCreate();
      }
    };
    const handleCreate = async () => {
      await subirImagen(imageFile.value).then(res => {
        evento.value.imagenPrincipal = res
      })

      emit('update', { ...evento.value, isNew: true });
      closeForm();
    };
    const handleUpdate = async () => {
      if (imageFile.value) {
        await subirImagen(imageFile.value).then(res => {
          evento.value.imagenPrincipal = res;
        });
      }
      
      emit('update', { ...evento.value, isNew: false });
      closeForm();
    };
    const closeForm = () => {
      emit('close');
    };
    const handleImageUpload = async (event) => {

      imageFile.value = event.target.files[0];


    };

    return {
      modal,
      isEditing,
      handleSubmit,
      handleCreate,
      handleUpdate,
      closeForm,
      validateInput,
      evento,
      buttonText,
      handleImageUpload,
      imageFile
    };
  },
};
</script>
<style></style>

