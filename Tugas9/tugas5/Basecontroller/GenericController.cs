﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using API.Models;
using API.ViewModels;
using API.Repositories;

namespace API.Basecontroller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<TRepository,TEntity,TKey> : ControllerBase
         where TRepository : IGenericRepo<TEntity, TKey>

    {
        protected readonly TRepository _repository;

        public GenericController(TRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _repository.GetAll();
            //Handle ketika data tidak ada/ kosong

            return Ok(new ResponseDataVM<IEnumerable<TEntity>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = result
            });
        }

        [HttpGet("{key}")]
        public ActionResult GetByKey(TKey key)
        {
            var result = _repository.GetByKey(key);
            if (result == null)
                return NotFound(new ResponseErrorsVM<string>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Errors = "Id Not Found"
                });

            return Ok(new ResponseDataVM<TEntity>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = result
            });
        }

        [HttpPost]
        public ActionResult Insert(TEntity entity)
        {
           /* if (entity.password == "" || entity.password.ToLower() == "string")
            {
                return BadRequest(new ResponseErrorsVM<string>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Errors = "Value Cannot be Null or Default"
                });
            }*/

            var insert = _repository.Insert(entity);
            if (insert > 0)
                return Ok(new ResponseDataVM<TEntity>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Insert Success"
                });

            return BadRequest(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Errors = "Insert Failed / Lost Connection"
            });
        }

        [HttpPut]
        public ActionResult Update(TEntity entity)
        {
            /*if (Account.password == "" || Account.password.ToLower() == "string")
            {
                return BadRequest(new ResponseErrorsVM<string>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Errors = "Value Cannot be Null or Default"
                });
            }*/

            var update = _repository.Update(entity);
            if (update > 0)
                return Ok(new ResponseDataVM<TEntity>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Update Success"
                });

            return BadRequest(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Errors = "Update Failed / Lost Connection"
            });
        }

        [HttpDelete("{key}")]
        public ActionResult Delete(TKey key)
        {
            var delete = _repository.Delete(key);
            if (delete > 0)
                return Ok(new ResponseDataVM<TEntity>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Delete Success"
                });

            return BadRequest(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Errors = "Delete Failed / Lost Connection"
            });
        }

    }
}
