<template>
  <div class="table-container mt-4 overflow-x-auto">
    <table class="w-full bg-white border border-gray-300">
      <thead class="bg-gray-50">
        <tr>
          <th scope="col" v-for="header in headers" :key="header"
            class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
            <slot :name="`header-${header}`">{{ header }}</slot>
          </th>
          <th scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
            ACCIONES
          </th>
        </tr>
      </thead>
      <tbody class="divide-y divide-gray-200">
        <tr v-for="item in items" :key="item.id">
          <td class="px-6 py-4 whitespace-nowrap" v-for="(value, name) in item" :key="`item-${item.id}-${name}`">
            <slot v-if="name == 'active'" ><div v-html="value"></div></slot>
            <slot v-else :name="`item-${name}`" :value="value">{{ value }}</slot>
          </td>
          <!-- <td class="px-6 py-4 whitespace-nowrap text-right text-sm font-medium">
            <slot name="actions" :item="item"></slot>
          </td> -->
          <td class="px-6 py-4 whitespace-nowrap text-right text-sm font-medium">
            <div class="flex space-x-2">
              <template v-for="action in actions">
                <button :class="['btn', action.danger ? 'btn-danger' : 'btn-primary']"
                  @click="onActionClick(action, item)">
                  <i :class="[action.icon, { 'text-red-500': action.danger, 'text-primary': !action.danger }]"></i>
                </button>
              </template>
            </div>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import { defineComponent, toRefs } from 'vue';

export default defineComponent({
  name: 'Table',
  props: {
    headers: {
      type: Array,
      required: true,
    },
    items: {
      type: Array,
      required: true,
    },
    actions: {
      type: Object,
      default: () => ({}),
    },
  },
  setup(props, { emit }) {
    const { headers, items, actions } = toRefs(props);

    // Emite un evento personalizado con el id de la acción y el item
    const onActionClick = (actionName, item) => {
      emit('action', { actionId: actionName, item });
    };


    return {
      headers,
      items,
      actions,
      onActionClick,
    };
  },
});
</script>

<style scoped>
/* Tus estilos aquí */
</style>
