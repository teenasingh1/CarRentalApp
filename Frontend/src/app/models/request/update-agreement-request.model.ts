export interface UpdateAgreementRequest { 
    startDate:Date,
    endDate:Date,
    totalCost:number,
    returnRequest?:Date|null
}
