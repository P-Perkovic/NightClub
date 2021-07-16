export class User {
    id: string;
    name: string;
    nickname: string;
    email: string;

    copyInto(authUser: any): void {
        this.id = authUser.sub;
        this.name = authUser.name;
        this.nickname = authUser.nickname;
        this.email = authUser.email;
    }
}