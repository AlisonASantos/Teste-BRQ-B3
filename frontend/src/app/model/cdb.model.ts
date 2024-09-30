export interface CDBCalculo {
    id:string;
    valorInicial:number;
    cdi: number;
    taxaBanco: number;
    meses:number;
}

export interface CDBResult {
    id:string;
    valorInicial:number;
    cdi: number;
    taxaBanco: number;
    meses:number;
    valorFinal:number;
}
