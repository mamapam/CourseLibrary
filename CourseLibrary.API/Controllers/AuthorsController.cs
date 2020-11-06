using CourseLibrary.API.Helpers;
using CourseLibrary.API.Models;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CourseLibrary.API.Controllers
{
	[ApiController]
	[Route("api/authors")]
	public class AuthorsController : ControllerBase
	{
		private readonly ICourseLibraryRepository _courseLibraryRepository;

		public AuthorsController(ICourseLibraryRepository courseLibraryRepository)
		{
			_courseLibraryRepository = courseLibraryRepository ?? throw new ArgumentNullException(nameof(courseLibraryRepository));
		}

		[HttpGet]
		public ActionResult<IEnumerable<AuthorDto>> GetAuthors()
		{
			var authorsFromRepo = _courseLibraryRepository.GetAuthors();
			var authors = new List<AuthorDto>();

			foreach (var author in authorsFromRepo)
			{
				authors.Add(new AuthorDto()
				{
					Id = author.Id,
					Name = $"{author.FirstName} {author.LastName}",
					MainCategory = author.MainCategory,
					Age = author.DateOfBirth.GetCurrentAge()
				});
			}
			return Ok(authors);
		}

		[HttpGet("{authorId}")]
		public IActionResult GetAuthor(Guid authorId)
		{
			var authorFromRepo = _courseLibraryRepository.GetAuthor(authorId);

			if (authorFromRepo == null)
			{
				return NotFound();
			}

			return Ok(authorFromRepo);
		}
	}
}
