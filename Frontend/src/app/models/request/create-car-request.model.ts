export interface CreateCarRequest {
    name:string;
    makerId:number;
    modelId:number;
    rentalPrice:number;
    carImage?:string;
}
