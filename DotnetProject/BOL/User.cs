namespace BOL;

public class User
{
    public int UserId{get; set;}
    public String UserName{get; set;}
    public String Email{get; set;}
    public String Password{get; set;}

    public User(int UserId,string UserName, string Email, string Password){
        this.UserName = UserName;
        this.Email=Email;
        this.Password=Password;
        this.UserId=UserId;
    }

    public override string ToString(){
        return (this.UserId+" "+this.UserName+" "+this.Email+" "+this.Password);
    }
}
