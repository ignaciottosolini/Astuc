<template>
    <div class="container mx-auto min-h-screen p-10">
        <div class="flex flex-col gap-10 justify-center">
            <div class="flex flex-col gap-5 text-center">
                <p class="text-[56px] font-monserrat">Quienes Somos</p>
                <p class="text-[40px] font-monserrat">Breve descripción</p>
            </div>
            <div class="flex md:flex-row justify-between flex-col gap-12">
                <div v-for="card in cards" class="flex flex-col gap-6 basis-1/3">
                    <div class="h-[300px] flex justify-center items-center bg-[#f6f7fa]  ">

                        <i><svg class="w-12 h-16 text-black" aria-hidden="true" xmlns="http://www.w3.org/2000/svg"
                                fill="currentColor" viewBox="0 0 24 24">
                                <path fill-rule="evenodd"
                                    d="M12 4a4 4 0 1 0 0 8 4 4 0 0 0 0-8Zm-2 9a4 4 0 0 0-4 4v1c0 1.1.9 2 2 2h8a2 2 0 0 0 2-2v-1a4 4 0 0 0-4-4h-4Z"
                                    clip-rule="evenodd" />
                            </svg>
                        </i>
                    </div>
                    <p class="text-bold text-3xl font-rubik">{{ card.nombre }}</p>
                    <p class="text-gray-400 font-bold text-2md font-rubik">{{ card.rol }}</p>
                    <p class="text-gray-400 text-2md font-rubik">{{ card.descripcion }}</p>
                </div>

            </div>

        </div>

    </div>

</template>
<script setup>
import { ref } from 'vue'

const cards = ref([
    {
        img: 'https://source.unsplash.com/random/800x600',
        nombre: 'Sebastián Tosolini',
        rol: 'Presidente',
        descripcion: 'Miembro de UATRE'
    },
    {
        img: 'https://source.unsplash.com/random/800x600',
        nombre: 'Fabián Petiton',
        rol: 'Vicepresidente',
        descripcion: 'Fitomejorador'
    },
    {
        img: 'https://source.unsplash.com/random/800x600',
        nombre: 'Juan Acevedo',
        rol: 'Staff',
        descripcion: 'Médico Clínico especialista en Cannabis medicinal'
    }
])
</script>