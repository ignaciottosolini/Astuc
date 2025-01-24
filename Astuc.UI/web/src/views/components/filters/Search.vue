<!-- Search.vue -->
<template>
  <div class="relative w-48 sm:w-64 xl:w-96 mt-1">
        <input v-model="searchTerm" @input="onSearch" type="text"       class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-500 focus:border-primary-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500"
:placeholder="placeholder"  />
    </div>
</template>
  
<script>
import { ref, watchEffect,computed } from 'vue';

export default {
    name: 'Search',
    props: {
        modelValue: String,
        placeholder: String,
        items: {
            type: Array,
            default: () => [],
        },
    },
    emits: ['update:modelValue', 'filtered'],
    setup(props, { emit }) {
        const searchTerm = ref(props.modelValue);

        const filteredItems = computed(() => {
            if (!searchTerm.value) {
                return props.items;
            }
            return props.items.filter((item) =>
                item.dni.toLowerCase().includes(searchTerm.value.toLowerCase())
            );
        });        

        // Emitimos los elementos filtrados para que el componente padre pueda usarlos
        watchEffect(() => {
            emit('filtered', filteredItems.value);
        });


        const onSearch = () => {
            emit('update:modelValue', searchTerm.value);
        };

        return {
            searchTerm,
            onSearch,
        };
    },
};
</script>
  