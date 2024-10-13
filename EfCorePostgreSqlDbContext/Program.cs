using System;
using System.Linq;
using EfCorePostgreSqlDbContext;

using var db = new BloggingContext();

//Create
System.Console.WriteLine("inserting a new blog");

db.Add(new Blog{Url = "http://blogs.msdn.com/adonet/", Rating = 5});
db.SaveChanges();

//Read
System.Console.WriteLine("Querying for a blog");
var blog = db.Blogs
.Where(b => b.Rating == 5)
.OrderBy(b => b.BlogId)
.FirstOrDefault();

System.Console.WriteLine(blog!.Url);

//Update
System.Console.WriteLine("Updating the blog and adding a post");
blog.Url = "https://devblogs.microsoft.com/dotnet";
var post = new Post{Title = "Hello World!", Content = "I wrote an app using EF Core!"};
blog.Posts = [post];
db.SaveChanges();


//Delete
// System.Console.WriteLine("Delete the blog");
// db.Remove(blog);
// db.SaveChanges();

System.Console.WriteLine(blog!.Url);