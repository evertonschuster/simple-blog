using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Application.Blogs;
using SimpleBlog.Application.Blogs.Dtos;

namespace SimpleBlog.API.Controllers
{
    /// <summary>
    /// Handles blog post operations
    /// </summary>
    [ApiController]
    [Route("api/posts")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        /// <summary>
        /// Retrieves a post by its ID.
        /// </summary>
        /// <param name="id">The ID of the post to retrieve.</param>
        /// <returns>The post corresponding to the specified ID.</returns>
        [AllowAnonymous]
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var post = await _postService.GetByIdAsync(id);
            return Ok(post);
        }

        /// <summary>
        /// Creates a new post.
        /// </summary>
        /// <param name="postDto">The post data transfer object containing the post details.</param>
        /// <returns>A newly created post.</returns>
        [Authorize]
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PostDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(PostDto postDto)
        {
            var post = await _postService.CreateAsync(postDto);
            return Created($"/api/posts/{post.Id}", post);
        }

        /// <summary>
        /// Updates an existing post.
        /// </summary>
        /// <param name="postDto">The post DTO containing the updated details of the post.</param>
        /// <returns>The updated post.</returns>
        [Authorize]
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync(PostDto postDto)
        {
            var post = await _postService.UpdateAsync(postDto);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        /// <summary>
        /// Deletes a post by its ID.
        /// </summary>
        /// <param name="id">The ID of the post to delete.</param>
        /// <returns>An HTTP No Content response on successful deletion.</returns>
        [Authorize]
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _postService.DeleteAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Retrieves all posts.
        /// </summary>
        /// <returns>A list of all posts.</returns>
        [AllowAnonymous]
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PostDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAsync()
        {
            var posts = await _postService.ListAllAsync();
            return Ok(posts);
        }
    }
}