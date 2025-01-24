<template>
  <Modal :visible="visible" @update:visible="closeForm" :title="modal.title">
    <Input id="nombre" label="Nombre" placeholder="" v-model="insumo.nombre" />
    <Input id="descripcion" label="Descripción" placeholder="" v-model="insumo.descripcion" />
    <Input id="costo" type="number" label="Costo" placeholder="" v-model="insumo.costo" />
    <Input id="precio" type="number" label="Precio" placeholder="" v-model="insumo.precioVenta" />
    <div class="col-span-12 sm:col-span-6">
      <label :for="id" class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300">Categoria</label>
      <select class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white" id="membresia" label="Membresia" v-model="insumo.categoria">
      <option value="Aceite">Aceite</option>
      <option value="Cosmetico">Cosmético</option>
      <option value="Kit">Kit</option>
      <option value="Varios">Varios</option>

      </select>
    </div>
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
export default {
  components: {
    Input,
    Modal
  },
  props: {
    visible: Boolean,
    insumo: Object,
  },
  emits: ['update', 'close'],
  setup(props, { emit }) {
    const { insumo, visible } = toRefs(props);
    const isEditing = ref(false);
    const validateInput = ref(false); // O el valor que corresponda
const imageFile = ref()
    // Utilizamos computed para determinar el texto del botón de forma reactiva
    const buttonText = computed(() => {
      return insumo.value.id ? 'Actualizar Insumo' : 'Agregar Insumo';
    });

    const modal = ref({
      title: "Gestionar Insumo",
      visible: false // Suponiendo que también quieras manejar la visibilidad dentro del mismo objeto
    });

    // Use a watcher to determine if we're in editing mode
    watch(visible, (newValue) => {
      isEditing.value = newValue.value;
    });

    const handleSubmit = () => {
      if (insumo.value && insumo.value.id) {
        handleUpdate();
      } else {
        handleCreate();
      }
    };

    const handleCreate = async() => {
      
      await subirImagen(imageFile.value).then(res => {
        insumo.value.imagenPrincipal = res
      })
      emit('update', { ...insumo.value, isNew: true });
      closeForm();
    };

    const handleUpdate = async () => {
      if (imageFile.value) {

      await subirImagen(imageFile.value).then(res => {
        insumo.value.imagenPrincipal = res
      })
    }
      emit('update', { ...insumo.value, isNew: false });
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
      insumo,
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
  