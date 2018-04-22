using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Repo;
using RequestModel;
using Service;
using ViewModel;

namespace LmsApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Teachers")]
    public class TeachersController : Controller
    {
        private LmsDbContext _db;
        private TeacherService _service;

        public TeachersController(LmsDbContext db, IGenericRepository<Teacher> repository)
        {
            _db = db;
            _service = new TeacherService(repository);
        }

        [HttpPost]
        [Route("Search")]
        public async Task<IActionResult> GetTeachers([FromBody] TeacherRequestModel request)
        {
            var teachers = await _service.SearchAsync(request);
            return Ok(teachers);
        }


    }
}