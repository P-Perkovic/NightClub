export enum ConfigType {
    Day = 'Day',
    Month = 'Month',
    Year = 'Year',
    Decimal = 'decimal',
    Int = 'int32'
}

export class ReservData {

    constructor() { }

    public getDataList(period: string): string[] {
        switch (period) {
            case ConfigType.Day: {
                return ['5', '10', '15', '20', '25'];
            }
            case ConfigType.Month: {
                return ['1', '2', '3', '6', '9'];
            }
            case ConfigType.Year: {
                return ['1', '2', '3'];
            }
            case ConfigType.Int: {
                return ['3', '4', '5', '6', '7', '8', '9', '10', '11', '12'];
            }
            case ConfigType.Decimal: {
                return ['200.00', '300.00', '400.00', '500.00', '600.00', '700.00', '800.00', '900.00', '1000.00'];
            }
        }
    }
}
