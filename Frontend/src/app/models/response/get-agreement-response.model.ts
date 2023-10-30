import { GetCarResponse } from "./get-car-response.model";

export interface GetAgreementResponse {
    id:string;
    car:GetCarResponse,
    startDate:string,
    endDate:string,
    totalCost:number,
    agreementStatus:number
}
