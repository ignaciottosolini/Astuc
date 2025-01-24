<template>
  <Modal :visible="visible" @update:visible="closeForm" :title="modal.title">    
    <Input id="descripcion" label="Descripción" placeholder="" v-model="publicacion.descripcion" />
    <Input id="titulo" label="Titulo" placeholder="" v-model="publicacion.titulo" />
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
    publicacion: Object,
  },
  emits: ['update', 'close'],
  setup(props, { emit }) {
    const { publicacion, visible } = toRefs(props);
    const isEditing = ref(false);
    const validateInput = ref(false); 
    const imageFile = ref()

    // Utilizamos computed para determinar el texto del botón de forma reactiva
    const buttonText = computed(() => {
      return publicacion.value.id ? 'Actualizar Publicación' : 'Agregar Publicación';
    });

    const modal = ref({
      title: "Gestionar Publicación",
      visible: false // Suponiendo que también quieras manejar la visibilidad dentro del mismo objeto
    });

    // Use a watcher to determine if we're in editing mode
    watch(visible, (newValue) => {
      isEditing.value = newValue.value;
    });

    const handleSubmit = () => {
      if (publicacion.value && publicacion.value.id) {
        handleUpdate();
      } else {
        handleCreate();
      }
    };
    

    const handleCreate = async () => {

      await subirImagen(imageFile.value).then(res => {
        publicacion.value.imagenPrincipal = res
      })
      emit('update', { ...publicacion.value, isNew: true });
      closeForm();
    };

    const handleUpdate =async () => {
      if (imageFile.value) {

      await subirImagen(imageFile.value).then(res => {
        publicacion.value.imagenPrincipal = res
      })
    }

      emit('update', { ...publicacion.value, isNew: false });
      closeForm();
    };

    const closeForm = () => {
      emit('close');
    };

    const handleImageUpload = async (event) => {
      imageFile.value=   event.target.files[0];
    };




    return {
      modal,
      isEditing,
      handleSubmit,
      handleCreate,
      handleUpdate,
      closeForm,
      validateInput,
      publicacion,
      buttonText,
      handleImageUpload,
      imageFile
    };
  },
};
</script>
  
<style>
/* Estilos para el modal, form-group y botones */
</style>
  