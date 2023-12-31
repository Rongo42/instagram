﻿using DomainLayer.Data;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepository;
using ServiceLayer.ICustomServices;

namespace InstagramWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICustomService<Comment> _customService;

        public CommentController(ICustomService<Comment> customService)
        {
            _customService = customService;
        }

        [Authorize]
        [HttpGet(nameof(GetCommentById))]
        public IActionResult GetCommentById(int id)
        {
            var obj = _customService.Get(id);

            return (obj == null) ? NotFound() : Ok(obj);
        }

        [Authorize]
        [HttpGet(nameof(GetAllComments))]
        public IActionResult GetAllComments()
        {
            var obj = _customService.GetAll();

            return (obj == null) ? NotFound() : Ok(obj);
        }

        [Authorize]
        [HttpPost(nameof(CreateComment))]
        public IActionResult CreateComment(Comment comment)
        {
            if (comment != null)
            {
                _customService.Insert(comment);
                return Ok("Created successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }

        [Authorize]
        [HttpPost(nameof(UpdateComment))]
        public IActionResult UpdateComment(Comment comment)
        {
            if (comment != null)
            {
                _customService.Update(comment);
                return Ok("Updated successfully");
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpDelete(nameof(DeleteComment))]
        public IActionResult DeleteComment(Comment comment)
        {
            if (comment != null)
            {
                _customService.Delete(comment);
                return Ok("Deleted successfully");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
