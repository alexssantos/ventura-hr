import { Criterio } from './criterio.model';

export class Vacancy {
	public empresaId: string;
	public empresa: any;
	public id: string;
	public titulo: string;
	public descricao: string;
	public criterios: Array<Criterio>;
	public dataCriacao: string;
	public dataExpiracao: string;
	public respostas: Array<any>;
}