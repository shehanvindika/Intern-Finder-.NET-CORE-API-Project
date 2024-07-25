using Core.Data;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Controller
{
    public interface PostController
    {
        string SavePostData(Post post);
        List<Post> ReadAllPost();
        List<Post> ReadAllPostFromSearchByCompnay(string companyName);
        List<Post> ReadAllPostFromSearchByPosition(string position);
        List<Post> ReadAllPostFromSearchByLocation(string location);
    }

    public class PostControllerImpl : PostController
    {

        public string SavePostData(Post post)
        {
            string message;

            using MyDbContext db = new MyDbContext();

            using (var context = new MyDbContext())
            {
                var prePost = context.posts
                                      .Where(s => s.CompanyId == post.CompanyId && s.Position == post.Position)
                                      .ToList();

                //foreach (Post p in prePost)
                //{
                //    Console.WriteLine($"{student.StudentId} - {student.FirstName} {student.LastName}");
                //}

                if (prePost.Count == 0)
                {
                    Post post1 = new Post()
                    {
                        Position = post.Position,
                        ClosingDate = post.ClosingDate,
                        Description = post.Description,
                        CompanyId = post.CompanyId,
                    };

                    context.Add(post1);
                    context.SaveChanges();
                    message = "Ad successfully created!!!";
                }
                else
                {
                    message = "Ad was already created!!!";
                }
            }

            
            return message;
        }

        public List<Post> ReadAllPost()
        {
            using MyDbContext db = new MyDbContext();

            using (var context = new MyDbContext())
            {
                List<Post> allPosts = context.posts.ToList();

                return allPosts;
            }
        }

        public List<Post> ReadAllPostFromSearchByCompnay(string companyName)
        {
            using MyDbContext db = new MyDbContext();

            using (var context = new MyDbContext())
            {
                var allPosts = context.posts
                      .Join(context.company,
                            post => post.CompanyId,
                            company => company.Id,
                            (post, company) => new
                            {
                                Post = post,
                                Company = company
                            })
                      .Where(joined => joined.Company.CompanyName == companyName)
                      .Select(joined => joined.Post)
                      .ToList();
                return allPosts;
            }
        }

        public List<Post> ReadAllPostFromSearchByPosition(string position)
        {
            using MyDbContext db = new MyDbContext();

            using (var context = new MyDbContext())
            {
                var allPosts = context.posts
                                      .Where(predicate => predicate.Position == position)
                                      .ToList();
                return allPosts;
            }
        }

        public List<Post> ReadAllPostFromSearchByLocation(string location)
        {
            using MyDbContext db = new MyDbContext();

            using (var context = new MyDbContext())
            {
                var allPosts = context.posts
                      .Join(context.company,
                            post => post.CompanyId,
                            company => company.Id,
                            (post, company) => new
                            {
                                Post = post,
                                Company = company
                            })
                      .Where(joined => joined.Company.CompanyLocation == location)
                      .Select(joined => joined.Post)
                      .ToList();

                return allPosts;
            }
        }
    }
}
