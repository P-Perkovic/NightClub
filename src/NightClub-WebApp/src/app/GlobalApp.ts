export class GlobalApp {
    public static True = "true";
    public static IsAuthenticated = "isAut";
    public static Rola = "rola";
    public static Admin = "admin";
    public static ServerError = 'Problem with server, can not get data.';

    constructor() { }

    public getRole(): string {
        return localStorage.getItem(GlobalApp.Rola);
    }

    public isAuthenticated(): boolean {
        if (localStorage.getItem(GlobalApp.IsAuthenticated) == GlobalApp.True) {
            return true;
        }

        else {
            return false;
        }
    }
}