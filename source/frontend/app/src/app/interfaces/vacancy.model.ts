import { Criterio } from './criterio.model';

export class Vacancy {
	
	constructor() {
		this.criterios = [];		
	}
	
	titulo: string;
	descricao: string;
	criterios: Array<Criterio>;
}