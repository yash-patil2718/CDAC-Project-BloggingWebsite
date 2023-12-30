namespace BLL;
using BOL;
using MySql.Data.MySqlClient;
using DAL;
public class BusinessLayer
{
    static MySqlConnection conn = Connect.getConnection();

    public static void InsertData(int UserId,string UserName, string Email, string Password){
        string query = "insert into users values (@UserId,@UserName,@Email, @Password)";
        conn.Open();
        MySqlCommand command = new MySqlCommand(query,conn);
        command.Parameters.AddWithValue("@UserId",UserId);
        command.Parameters.AddWithValue("@UserName",UserName);
        command.Parameters.AddWithValue("@Email",Email);
        command.Parameters.AddWithValue("@Password",Password);
        command.ExecuteNonQuery();
        conn.Close();
    }

    public static User Login(string Email, string Password){
        string query = "select * from users where email= @Email and password = @Password";
        conn.Open();
        MySqlCommand command = new MySqlCommand(query, conn);
        command.Parameters.AddWithValue("@Email",Email);
        command.Parameters.AddWithValue("@Password",Password);
        MySqlDataReader reader = command.ExecuteReader();
        User e=null;
        bool flag = false;
        while(reader.Read()){
            e = new User(int.Parse(reader["user_id"].ToString()),reader["username"].ToString(),reader["email"].ToString(),reader["password"].ToString());
            flag = true;
        }
        if(flag){
            conn.Close();
            return e;
        }
        conn.Close();
        return e; 
    }

    public static List<Blog> ViewAllBlog(){
        conn.Open();
        List<Blog> ulist = new List<Blog>();
        string query = "Select * from blogs";
        MySqlCommand command = new MySqlCommand(query,conn);
        MySqlDataReader reader = command.ExecuteReader();
        while(reader.Read()){
            Blog u = new Blog(int.Parse(reader["blog_id"].ToString()),reader["title"].ToString(),reader["content"].ToString(),int.Parse(reader["user_id"].ToString()),int.Parse(reader["category_id"].ToString()));
            ulist.Add(u);
        }
        conn.Close();
        return ulist;
    }

    public static void EditBlog(int BlogId, string Title, string Content,int UserId, int CategoryId){
        conn.Open();
        string query = "update blogs set title = @Title , content = @Content, category_id=@CategoryId where blog_id = @BId";
        MySqlCommand command = new MySqlCommand(query,conn);
        command.Parameters.AddWithValue("@BId",BlogId);
        command.Parameters.AddWithValue("@Title",Title);
        command.Parameters.AddWithValue("@Content",Content);
        command.Parameters.AddWithValue("@CategoryId",CategoryId);
        command.ExecuteNonQuery();
        conn.Close();
    }

    public static void DeleteUser(User emp){
        conn.Open();
        string query = "delete from users where user_id = @Eid";
        MySqlCommand command = new MySqlCommand(query, conn);
        command.Parameters.AddWithValue("@Eid", emp.UserId);
        command.ExecuteNonQuery();
        conn.Close();
    }
}
