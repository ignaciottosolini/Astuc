<template>

  <Modal :visible="visible" @update:visible="closeForm" :title="modal.title">
    <Toast :visible="visibleToast" :message="'Contraseña cambiada!'"></Toast>
    <div class="col-span-12 sm:col-span-6 relative">
      <label :for="oldPass" class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300">Contraseña
        vieja</label>
      <svg v-if="inputType[0] == 'password'" @click="changeTypePassword(0)" class="cursor-pointer w-4 h-6 bottom-2 absolute right-3 " xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 640 512">
        <path
          d="M38.8 5.1C28.4-3.1 13.3-1.2 5.1 9.2S-1.2 34.7 9.2 42.9l592 464c10.4 8.2 25.5 6.3 33.7-4.1s6.3-25.5-4.1-33.7L525.6 386.7c39.6-40.6 66.4-86.1 79.9-118.4c3.3-7.9 3.3-16.7 0-24.6c-14.9-35.7-46.2-87.7-93-131.1C465.5 68.8 400.8 32 320 32c-68.2 0-125 26.3-169.3 60.8L38.8 5.1zM223.1 149.5C248.6 126.2 282.7 112 320 112c79.5 0 144 64.5 144 144c0 24.9-6.3 48.3-17.4 68.7L408 294.5c8.4-19.3 10.6-41.4 4.8-63.3c-11.1-41.5-47.8-69.4-88.6-71.1c-5.8-.2-9.2 6.1-7.4 11.7c2.1 6.4 3.3 13.2 3.3 20.3c0 10.2-2.4 19.8-6.6 28.3l-90.3-70.8zM373 389.9c-16.4 6.5-34.3 10.1-53 10.1c-79.5 0-144-64.5-144-144c0-6.9 .5-13.6 1.4-20.2L83.1 161.5C60.3 191.2 44 220.8 34.5 243.7c-3.3 7.9-3.3 16.7 0 24.6c14.9 35.7 46.2 87.7 93 131.1C174.5 443.2 239.2 480 320 480c47.8 0 89.9-12.9 126.2-32.5L373 389.9z" />
      </svg>
      <svg v-else @click="changeTypePassword(0)" class="cursor-pointer w-4 h-6 bottom-2 absolute right-3 " xmlns="http://www.w3.org/2000/svg" viewBox="0 0 576 512"><path d="M288 32c-80.8 0-145.5 36.8-192.6 80.6C48.6 156 17.3 208 2.5 243.7c-3.3 7.9-3.3 16.7 0 24.6C17.3 304 48.6 356 95.4 399.4C142.5 443.2 207.2 480 288 480s145.5-36.8 192.6-80.6c46.8-43.5 78.1-95.4 93-131.1c3.3-7.9 3.3-16.7 0-24.6c-14.9-35.7-46.2-87.7-93-131.1C433.5 68.8 368.8 32 288 32zM144 256a144 144 0 1 1 288 0 144 144 0 1 1 -288 0zm144-64c0 35.3-28.7 64-64 64c-7.1 0-13.9-1.2-20.3-3.3c-5.5-1.8-11.9 1.6-11.7 7.4c.3 6.9 1.3 13.8 3.2 20.7c13.7 51.2 66.4 81.6 117.6 67.9s81.6-66.4 67.9-117.6c-11.1-41.5-47.8-69.4-88.6-71.1c-5.8-.2-9.2 6.1-7.4 11.7c2.1 6.4 3.3 13.2 3.3 20.3z"/></svg>
      <input v-model="form.oldPass" id="oldPass" :type="inputType[0]"
        class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white">
    </div>
    <div class="col-span-12 sm:col-span-6 relative">
      <label :for="newPass" class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300">Nueva
        contraseña</label>
        <svg v-if="inputType[1] == 'password'" @click="changeTypePassword(1)" class="cursor-pointer w-4 h-6 bottom-2 absolute right-3 " xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 640 512">
        <path
          d="M38.8 5.1C28.4-3.1 13.3-1.2 5.1 9.2S-1.2 34.7 9.2 42.9l592 464c10.4 8.2 25.5 6.3 33.7-4.1s6.3-25.5-4.1-33.7L525.6 386.7c39.6-40.6 66.4-86.1 79.9-118.4c3.3-7.9 3.3-16.7 0-24.6c-14.9-35.7-46.2-87.7-93-131.1C465.5 68.8 400.8 32 320 32c-68.2 0-125 26.3-169.3 60.8L38.8 5.1zM223.1 149.5C248.6 126.2 282.7 112 320 112c79.5 0 144 64.5 144 144c0 24.9-6.3 48.3-17.4 68.7L408 294.5c8.4-19.3 10.6-41.4 4.8-63.3c-11.1-41.5-47.8-69.4-88.6-71.1c-5.8-.2-9.2 6.1-7.4 11.7c2.1 6.4 3.3 13.2 3.3 20.3c0 10.2-2.4 19.8-6.6 28.3l-90.3-70.8zM373 389.9c-16.4 6.5-34.3 10.1-53 10.1c-79.5 0-144-64.5-144-144c0-6.9 .5-13.6 1.4-20.2L83.1 161.5C60.3 191.2 44 220.8 34.5 243.7c-3.3 7.9-3.3 16.7 0 24.6c14.9 35.7 46.2 87.7 93 131.1C174.5 443.2 239.2 480 320 480c47.8 0 89.9-12.9 126.2-32.5L373 389.9z" />
      </svg>
      <svg v-else @click="changeTypePassword(1)" class="cursor-pointer w-4 h-6 bottom-2 absolute right-3 " xmlns="http://www.w3.org/2000/svg" viewBox="0 0 576 512"><path d="M288 32c-80.8 0-145.5 36.8-192.6 80.6C48.6 156 17.3 208 2.5 243.7c-3.3 7.9-3.3 16.7 0 24.6C17.3 304 48.6 356 95.4 399.4C142.5 443.2 207.2 480 288 480s145.5-36.8 192.6-80.6c46.8-43.5 78.1-95.4 93-131.1c3.3-7.9 3.3-16.7 0-24.6c-14.9-35.7-46.2-87.7-93-131.1C433.5 68.8 368.8 32 288 32zM144 256a144 144 0 1 1 288 0 144 144 0 1 1 -288 0zm144-64c0 35.3-28.7 64-64 64c-7.1 0-13.9-1.2-20.3-3.3c-5.5-1.8-11.9 1.6-11.7 7.4c.3 6.9 1.3 13.8 3.2 20.7c13.7 51.2 66.4 81.6 117.6 67.9s81.6-66.4 67.9-117.6c-11.1-41.5-47.8-69.4-88.6-71.1c-5.8-.2-9.2 6.1-7.4 11.7c2.1 6.4 3.3 13.2 3.3 20.3z"/></svg>
      
      <input v-model="form.newPass" id="newPass" :type="inputType[1]"
        class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white">
    </div>
    <div class="col-span-12 sm:col-span-6 relative">
      <label :for="confirmNewPass" class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300">Confirmar
        nueva contraseña</label>
        <svg v-if="inputType[2] == 'password'" @click="changeTypePassword(2)" class="cursor-pointer w-4 h-6 bottom-2 absolute right-3 " xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 640 512">
        <path
          d="M38.8 5.1C28.4-3.1 13.3-1.2 5.1 9.2S-1.2 34.7 9.2 42.9l592 464c10.4 8.2 25.5 6.3 33.7-4.1s6.3-25.5-4.1-33.7L525.6 386.7c39.6-40.6 66.4-86.1 79.9-118.4c3.3-7.9 3.3-16.7 0-24.6c-14.9-35.7-46.2-87.7-93-131.1C465.5 68.8 400.8 32 320 32c-68.2 0-125 26.3-169.3 60.8L38.8 5.1zM223.1 149.5C248.6 126.2 282.7 112 320 112c79.5 0 144 64.5 144 144c0 24.9-6.3 48.3-17.4 68.7L408 294.5c8.4-19.3 10.6-41.4 4.8-63.3c-11.1-41.5-47.8-69.4-88.6-71.1c-5.8-.2-9.2 6.1-7.4 11.7c2.1 6.4 3.3 13.2 3.3 20.3c0 10.2-2.4 19.8-6.6 28.3l-90.3-70.8zM373 389.9c-16.4 6.5-34.3 10.1-53 10.1c-79.5 0-144-64.5-144-144c0-6.9 .5-13.6 1.4-20.2L83.1 161.5C60.3 191.2 44 220.8 34.5 243.7c-3.3 7.9-3.3 16.7 0 24.6c14.9 35.7 46.2 87.7 93 131.1C174.5 443.2 239.2 480 320 480c47.8 0 89.9-12.9 126.2-32.5L373 389.9z" />
      </svg>
      <svg v-else @click="changeTypePassword(2)" class="cursor-pointer w-4 h-6 bottom-2 absolute right-3 " xmlns="http://www.w3.org/2000/svg" viewBox="0 0 576 512"><path d="M288 32c-80.8 0-145.5 36.8-192.6 80.6C48.6 156 17.3 208 2.5 243.7c-3.3 7.9-3.3 16.7 0 24.6C17.3 304 48.6 356 95.4 399.4C142.5 443.2 207.2 480 288 480s145.5-36.8 192.6-80.6c46.8-43.5 78.1-95.4 93-131.1c3.3-7.9 3.3-16.7 0-24.6c-14.9-35.7-46.2-87.7-93-131.1C433.5 68.8 368.8 32 288 32zM144 256a144 144 0 1 1 288 0 144 144 0 1 1 -288 0zm144-64c0 35.3-28.7 64-64 64c-7.1 0-13.9-1.2-20.3-3.3c-5.5-1.8-11.9 1.6-11.7 7.4c.3 6.9 1.3 13.8 3.2 20.7c13.7 51.2 66.4 81.6 117.6 67.9s81.6-66.4 67.9-117.6c-11.1-41.5-47.8-69.4-88.6-71.1c-5.8-.2-9.2 6.1-7.4 11.7c2.1 6.4 3.3 13.2 3.3 20.3z"/></svg>
      
      <input v-model="form.confirmNewPass" id="confirmNewPass" :type="inputType[2]"
        class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white">
    </div>

    <div class="col-span-12">

      <p class="mt-2 text-sm text-red-600 dark:text-red-500">{{ confirmPasswordError }}</p>

      <p class="mt-2 text-sm text-red-600 dark:text-red-500" v-for="error in translatedErrors">{{ error }}</p>
    </div>


    <template #footer>
      <button @click="changePassword" :disabled="visibleToast"
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
import authService from '../../../../services/AuthService';
import Modal from '@/views/components/Modal.vue';
import Toast from '../../../components/Toast.vue';
export default {
  components: {
    Input,
    Modal,
    Toast
  },
  props: {
    visible: Boolean,
    email: String
  },
  emits: ['update', 'close'],
  setup(props, { emit }) {
    const form = ref({})
    const errors = ref([])
    const visibleToast = ref(false)
    const confirmPasswordError = ref()
    const { visible, email } = toRefs(props);
    const validateInput = ref(false);
    const inputType = ref(["password","password","password"])
    const buttonText = computed(() => {
      return 'Actualizar'
    });
    const modal = ref({
      title: "Cambiar Contraseña",
      visible: false
    });


    const validatePasswords = () => {
      if (form.value.newPass === form.value.confirmNewPass) {
        confirmPasswordError.value = ""
        return true
      } else {
        confirmPasswordError.value = "La contraseña no coincide"
        return false
      }

    }
    const setAlert = () => {
      visibleToast.value = true;
      setTimeout(() => {
        visibleToast.value = false;
        closeForm()
      }, 3000);
    }
    const translatedErrors = computed(() => {
      const translationMap = {
        "PasswordRequiresLower": "La contraseña debe tener al menos una letra minuscula (a-z)",
        "PasswordTooShort": "La contraseña es demasiado corta",
        "PasswordRequiresNonAlphanumeric": "La contraseña debe tener al menos un carácter no alfanumérico.",
        "PasswordRequiresDigit": "La contraseña debe tener al menos un dígito ('0'-'9').",
        "PasswordRequiresUpper": "La contraseña debe tener al menos una letra mayúscula ('A'-'Z').",
        "PasswordMismatch": "Contraseña Incorrecta"
      }
      return errors.value.map(error => translationMap[error.code]);


    });
    const cleanForm = () => {
      form.value = {}
    }
    const changePassword = async () => {
      if (!form.value.newPass || !form.value.oldPass || !form.value.confirmNewPass) {
        confirmPasswordError.value = "Complete todos los campos"
        return false
      }
      if (!validatePasswords()) {
        return
      }
      try {
        const data = {
          newPassword: form.value.newPass,
          oldPassword: form.value.oldPass,
          email: email.value
        }
        errors.value = []
        await authService.changePassword(data).then(res => {

          res.errors ? (errors.value = res.errors) : null
          res.message ? (setAlert(), cleanForm()) : null
        })
      } catch (error) {
        //.error(error)
      }
    }
    const changeTypePassword= (i) => {
      inputType.value[i] = inputType.value[i] == "password" ? "text" : "password"
    }


    const closeForm = (value) => {
      emit('closePass');
    };


    return {
      modal,
      visible,
      closeForm,
      validateInput,
      buttonText,
      email,
      form,
      errors,
      visibleToast,
      confirmPasswordError,
      changePassword,
      translatedErrors,
      setAlert,
      validatePasswords
      , cleanForm,
      inputType,
      changeTypePassword

    };
  },
};
</script>
<style></style>