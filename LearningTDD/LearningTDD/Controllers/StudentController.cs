﻿using LearningTDD.Domain.DTO;
using LearningTDD.InfraData.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LearningTDD.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController(IStudent student) : ControllerBase
    {
        private readonly IStudent _business = student;

        [HttpPost, Route("[action]")]
        public async Task<IActionResult> Insert(StudentDTO student)
        {
            var response = await _business.Add(student);
            IActionResult result = response > 0 ? Ok(response) : BadRequest(response);
            return result;

        }
        [HttpGet, Route("[action]")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _business.Get(id);
            IActionResult result = response is not null ? Ok(response) : BadRequest(response);
            return result;

        }

        [HttpDelete, Route("[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _business.Delete(id);
            IActionResult result = response ? Ok(response) : BadRequest(response);
            return result;

        }
        [HttpPut, Route("[action]")]
        public async Task<IActionResult> Update(StudentDTO student)
        {
            var response = await _business.Update(student);
            IActionResult result = response ? Ok(response) : BadRequest(response);
            return result;

        }
    }
}
