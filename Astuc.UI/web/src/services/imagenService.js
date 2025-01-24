// tinyService.js

// Importa la API Key de TinyPNG
const API_KEY = 'KnqJWJ9q4LdF29Pr5YjZLmr8FdBvnFky';

// Función para comprimir una imagen utilizando Fetch
export async function comprimirImagen(imagen) {
  try {
    const formData = new FormData();
    formData.append('source', imagen);

    const response = await fetch('https://api.tinify.com/shrink', {
      method: 'POST',
      headers: {
        Authorization: `Basic ${btoa(`api:${API_KEY}`)}`,
      },
      body: formData,
    });

    if (response.ok) {
      const data = await response.json();
      return data;
    } else {
      throw new Error('Error al comprimir la imagen');
    }
  } catch (error) {
    //.error(error);
    throw error;
  }
}