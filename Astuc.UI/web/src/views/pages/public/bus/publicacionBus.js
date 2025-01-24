import { ref } from 'vue';
import publicacionService from '../../../../services/publicacionService';
export const eventBus = ref({
  publicaciones: [],
  async getBusAll() {
    if(this.publicaciones.length > 0){
      return this.publicaciones
    }
    else{
      this.publicaciones = await publicacionService.getPublicaciones()
     
      return this.publicaciones
    }
  },
    setpublicaciones(ins){
    this.publicaciones = ins
  },
  
  async getByNombreByBus(name) {
    
    const publicacionesBus = await this.getBusAll()
    return publicacionesBus.find( e=> 
       e.titulo.toLowerCase().includes(name.toLowerCase())
    )
  },
  

});
