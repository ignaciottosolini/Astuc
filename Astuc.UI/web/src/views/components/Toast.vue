<template>
    <div v-if="visible" v-bind:class="toastStyle" id="toast-simple" class="z-[100] fixed flex
     items-center w-full max-w-xs p-4 space-x-4 text-dark
  bg-white divide-x divide-gray-200 rounded-lg shadow top-20 right-5 dark:text-gray-400 dark:divide-gray-700
  space-x dark:bg-gray-800">
        <svg aria-hidden="true" class="flex-shrink-0 w-5 h-5" fill="currentColor" viewBox="0 0 20 20"
            xmlns="http://www.w3.org/2000/svg">
            <path fill-rule="evenodd"
                d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-7-4a1 1 0 11-2 0 1 1 0 012 0zM9 9a1 1 0 000 2v3a1 1 0 001 1h1a1 1 0 100-2v-3a1 1 0 00-1-1H9z"
                clip-rule="evenodd"></path>
        </svg>
        <span class="sr-only">Info</span>
        <div class="pl-4 text-sm font-normal">{{ message }}</div>
        <button @click="closeModal" type="button" class="ms-auto -mx-1.5 -my-1.5 bg-white text-gray-400 hover:text-gray-900 rounded-lg focus:ring-2 focus:ring-gray-300 p-1.5 hover:bg-gray-100 inline-flex items-center justify-center h-8 w-8 dark:text-gray-500 dark:hover:text-white dark:bg-gray-800 dark:hover:bg-gray-700" >
        <span class="sr-only">Close</span>
        <svg class="w-3 h-3" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 14 14">
            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="m1 1 6 6m0 0 6 6M7 7l6-6M7 7l-6 6"/>
        </svg>
    </button>
    </div>
</template>

<script>
import { ref, toRefs } from 'vue'
export default{
    name: "Toast",
    props: {
        visible: Boolean,
        message: String,
        toastStyle: String
    },
    setup(props, { emit }) {
        const { visible, message,toastStyle } = toRefs(props)


        const closeModal = () => {
            emit("closeModal")
        }

        return {
            visible,
            message,
            closeModal,
            toastStyle
        }

    }
}
</script>
