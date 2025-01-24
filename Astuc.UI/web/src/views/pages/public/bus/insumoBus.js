import { ref } from 'vue';
import insumoService from '../../../../services/insumoService';
export const eventBus = ref({
  insumos: [],
  async getBusAll() {
    if(this.insumos.length > 0){
      return this.insumos
    }
    else{
      this.insumos = await insumoService.getAll()
     
      return this.insumos
    }
  },
    setInsumos(ins){
    this.insumos = ins
  },
  
  async getByNombreByBus(name) {
    
    const insumosBus = await this.getBusAll()
    return insumosBus.find( e=> 
       e.nombre.toLowerCase().includes(name.toLowerCase())
    )
  },
  

});
