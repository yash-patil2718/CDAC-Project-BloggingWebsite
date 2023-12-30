namespace BOL;

public class Blog
{
    public int BlogId{get; set;}
    public String Title{get; set;}
    public String Content{get; set;}
    public int UserId{get; set;}
    public int CategoryId{get; set;}

    public Blog(int BlogId,string Title, string Content, int UserId, int CategoryId){
        this.BlogId = BlogId;
        this.Title=Title;
        this.Content=Content;
        this.UserId=UserId;
        this.CategoryId=CategoryId;
    }

    public override string ToString(){
        return (this.UserId+this.Title);
    }
}
