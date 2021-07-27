import { Table } from "./Table";

export class Reservation {
        id: number;
        tableId: number;
        userStringId: string;
        dateOfReservation: Date;
        numberOfGuests: number;
        isCanceled: boolean;
        reservedFor: string;
        note: string;
        status: number;
        table: Table;
}