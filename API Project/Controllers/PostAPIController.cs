using Core.Controller;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostAPIController : ControllerBase
    {
        [HttpPost]
        [Route("api/v1/InsertPostData")]
        public string InsertPostDetails([FromBody] Post post)
        {
            PostController postController = new PostControllerImpl();
            return postController.SavePostData(post);
        }

        [HttpGet]
        [Route("api/v1/ReadAllPost")]
        public List<Post> ReadAllPostReadAllPost()
        {
            PostController postController = new PostControllerImpl();
            return postController.ReadAllPost();
        }

        [HttpGet]
        [Route("api/v1/ReadAllPostByCompany")]
        public List<Post> ReadAllPostByCompany(string companyName)
        {
            PostController postController = new PostControllerImpl();
            return postController.ReadAllPostFromSearchByCompnay(companyName);
        }

        [HttpGet]
        [Route("api/v1/ReadAllPostByPosition")]
        public List<Post> ReadAllPostByPosition(string positionName)
        {
            PostController postController = new PostControllerImpl();
            return postController.ReadAllPostFromSearchByPosition(positionName);
        }

        [HttpGet]
        [Route("api/v1/ReadAllPostByLocation")]
        public List<Post> ReadAllPostByLocation(string location)
        {
            PostController postController = new PostControllerImpl();
            return postController.ReadAllPostFromSearchByLocation(location);
        }
    }
}
