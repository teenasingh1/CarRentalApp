import { Maker } from "./maker.model";
import { Model } from "./model.model";

export interface GetCarResponse {
    id:string;
    name:string;
    maker:Maker;
    makerId:number;
    modelId:number;
    model:Model;
    rentalPrice:number;
    carImage:string;
    agreementStatus:number;
}
