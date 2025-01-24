<template>
    <div class="flex md:pr-[10%] md:pl-[10%] md:flex-row flex-col  gap-5 min-h-screen mx-auto">
        <div class="md:w-1/2 container flex flex-col p-[5%] gap-5 mx-auto">
            <div class="flex flex-col gap-3">
                <h2 class="text-[36px]">Charlá con nosotros</h2>
                <p class="text-[22px]"> Lorem ipsum dolor sit amet consectetur, adipisicing elit. Consequuntur temporibus
                    dignissimos ex soluta, </p>
            </div>
            <form @submit.prevent="sendData">
            <div class="container pr-5 pl-5 pt-9 pb-9 bg-[#1E1E1E0A] grid grid-cols-1 gap-x-6 gap-y-8 sm:grid-cols-6 mb-6 justify-center gap-5">

                <div class="sm:col-span-3">
                    <label for="first-name" class="block text-sm  leading-4 text-gray-600">Nombre</label>
                    <div class="mt-2">
                        <input type="text" name="first-name" id="first-name" v-model="form.name" placeholder="John Carter"
                            class="block w-full h-14 rounded-full border-0 py-2.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300
                                 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-green-600 sm:text-sm sm:leading-6" required>
                    </div>
                </div>

                <div class="sm:col-span-3">
                    <label for="first-name" class="block text-sm  leading-4 text-gray-600">Email</label>

                    <div class="mt-2">
                        <input type="email" name="last-name" id="last-name" v-model="form.email" placeholder="example@gmail.com"
                            class="block w-full h-14 rounded-full border-0 py-2.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300
                                 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-green-600 sm:text-sm sm:leading-6" required>
                    </div>
                </div>
                <div class="sm:col-span-3">
                    <label for="first-name" class="block text-sm  leading-4 text-gray-600">Teléfono</label>
                    <div class="mt-2">
                        <input type="number" name="first-name" id="first-name" v-model="form.phone" placeholder="(123) 456 - 789"
                            class="block w-full h-14 rounded-full border-0 py-2.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300
                                 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-green-600 sm:text-sm sm:leading-6" required>
                    </div>
                </div>

                <div class="sm:col-span-3">
                    <label for="first-name" class="block text-sm  leading-4 text-gray-600">Motivo</label>

                    <div class="mt-2">
                        <input type="text" name="last-name" id="last-name" v-model="form.subject" placeholder="Consulta"
                            class="block w-full h-14 rounded-full border-0 py-2.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300
                                 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-green-600 sm:text-sm sm:leading-6" required>
                    </div>
                </div>
                <div class="col-span-full">
                        <label for="first-name" class="block text-sm  leading-6 text-gray-600">Mensaje</label>

                        <div class="mt-2">
                            <textarea  name="street-address" id="street-address" v-model="form.message" placeholder="Escriba su mensaje aquí..."
                            class="resize-none block w-full h-24 rounded-xl border-0 py-2.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300
                                 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-green-600 sm:text-sm sm:leading-6" required></textarea>                     </div>
                    </div>
                    <div class="col-span-full flex justify-center mt-4">
    <button class="bg-black text-white py-3 px-6 rounded-full" type="submit">Enviar</button>
</div>


</div>
</form>
        </div>
        <div class="md:w-1/2 container p-[5%] h-screen justify-center bg-[#1E1E1E0A]">
    <div class="flex flex-col gap-14">
        <h2 class="text-[36px]">Contacto</h2>
        <div>
            <p class="text-[15px] text-[#767494] font-bold">UBICACION</p>
            <p class="text-[17px] sm:text-[28px]">Santo Tomé, Santa Fe, Argentina</p>
        </div>
        <div>
            <p class="text-[15px] text-[#767494] font-bold">TELÉFONO</p>
            <p class="text-[17px] sm:text-[28px]">(123) 456 - 789</p>
        </div>
        <div>
            <p class="text-[15px] text-[#767494] font-bold">EMAIL</p>
            <p class="text-[17px] sm:text-[28px]">contacto@astuc.com</p>
        </div>
        <div>
            <p class="text-[15px] text-[#767494] font-bold">INSTAGRAM</p>
            <br>
            <div class="flex items-center gap-2 ">
                <a class="cursor-pointer" href="https://www.instagram.com/astuc.oficial/" target="_blank">
                    <svg xmlns="http://www.w3.org/2000/svg" class="w-8 h-8" viewBox="0 0 448 512">
                        <path d="M224.1 141c-63.6 0-114.9 51.3-114.9 114.9s51.3 114.9 114.9 114.9S339 319.5 339 255.9 287.7 141 224.1 141zm0 189.6c-41.1 0-74.7-33.5-74.7-74.7s33.5-74.7 74.7-74.7 74.7 33.5 74.7 74.7-33.6 74.7-74.7 74.7zm146.4-194.3c0 14.9-12 26.8-26.8 26.8-14.9 0-26.8-12-26.8-26.8s12-26.8 26.8-26.8 26.8 12 26.8 26.8zm76.1 27.2c-1.7-35.9-9.9-67.7-36.2-93.9-26.2-26.2-58-34.4-93.9-36.2-37-2.1-147.9-2.1-184.9 0-35.8 1.7-67.6 9.9-93.9 36.1s-34.4 58-36.2 93.9c-2.1 37-2.1 147.9 0 184.9 1.7 35.9 9.9 67.7 36.2 93.9s58 34.4 93.9 36.2c37 2.1 147.9 2.1 184.9 0 35.9-1.7 67.7-9.9 93.9-36.2 26.2-26.2 34.4-58 36.2-93.9 2.1-37 2.1-147.8 0-184.8zM398.8 388c-7.8 19.6-22.9 34.7-42.6 42.6-29.5 11.7-99.5 9-132.1 9s-102.7 2.6-132.1-9c-19.6-7.8-34.7-22.9-42.6-42.6-11.7-29.5-9-99.5-9-132.1s-2.6-102.7 9-132.1c7.8-19.6 22.9-34.7 42.6-42.6 29.5-11.7 99.5-9 132.1-9s102.7-2.6 132.1 9c19.6 7.8 34.7 22.9 42.6 42.6 11.7 29.5 9 99.5 9 132.1s2.7 102.7-9 132.1z"/>
                    </svg>
                </a>
                <span class="text-[17px] sm:text-[20px]">@astuc.ar</span>
            </div>
        </div>
    </div>
</div>

    </div>
</template>
<script setup>
import { ref } from 'vue';
import contactoService from "../../../services/contactoService.js"
// Datos dinámicos
const form = ref({
})
const tarjetas = ref([
    {
        img: "https://source.unsplash.com/random/800x600",
        titulo: "TEXTO PRUEBA 1",
        desc: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Ipsam consequuntur molestiae quia ex, id ipsa qui fugit, quasi dolor vel, sit vero nihil impedit explicabo excepturi neque numquam perferendis mollitia"
    },
    {
        img: "https://source.unsplash.com/random/800x600",
        titulo: "TEXTO PRUEBA 2",
        desc: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Ipsam consequuntur molestiae quia ex, id ipsa qui fugit, quasi dolor vel, sit vero nihil impedit explicabo excepturi neque numquam perferendis mollitia"

    }
])

const sendData = async () => {
    await contactoService.sendEmail(form.value).then(res => {
        //.log(res)
    })
}


</script>

<style scoped>/* Estilos adicionales si necesitas ajustes fuera de Tailwind */</style>