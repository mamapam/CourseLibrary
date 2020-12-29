using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Profiles
{
	public class CoursesProfile : Profile
	{
		CreateMap<Entities.Course, Models.CourseDto>();
	}
}
