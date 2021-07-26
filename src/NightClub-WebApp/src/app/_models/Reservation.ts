import { Table } from "./Table";
import { User } from "./User";

export class Reservation {
        id: number;
        tableId: number;
        userStringId: string;
        dateOfReservation: Date;
        numberOfGuests: number;
        isCanceled: boolean;
        reservedFor: string;
        note: string;
        table: Table;
        user: User;
}