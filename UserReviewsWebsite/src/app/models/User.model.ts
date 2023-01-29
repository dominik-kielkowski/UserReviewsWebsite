export class User{
    public Username: string;
    public Email: string;
    public PasswordHash: string;
    public RoleId: number;

    constructor(username: string, email: string, passwordHash: string, roleId: number){
        this.Username = username;
        this.Email = email;
        this.PasswordHash = passwordHash;
        this.RoleId = roleId;
    }
}