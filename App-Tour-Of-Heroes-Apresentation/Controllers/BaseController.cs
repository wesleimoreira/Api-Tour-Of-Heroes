﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Api_Tour_Of_Heroes_Domain.Interfaces;
using System.Net;
using Api_Tour_Of_Heroes_Application.ViewModels;
using App_Tour_Of_Heroes_Apresentation.Extensions;

namespace App_Tour_Of_Heroes_Apresentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IUserRepository UserRepository;
        protected readonly IHeroRepository HeroRepository;
        protected readonly IMapper Mapper;

        public BaseController(IUserRepository userRepository, IHeroRepository heroRepository, IMapper mapper)
        {
            this.UserRepository = userRepository;
            this.HeroRepository = heroRepository;
            this.Mapper = mapper;
        }

        protected IActionResult ResponseOk() => Response(HttpStatusCode.OK);

        protected IActionResult ResponseOk(object result) => Response(HttpStatusCode.OK, result);

        protected IActionResult ResponseCreated() => Response(HttpStatusCode.Created);

        protected IActionResult ResponseCreated(object data) => Response(HttpStatusCode.Created, data);

        protected IActionResult ResponseNoContent() => Response(HttpStatusCode.NoContent);

        protected IActionResult ResponseNotModified() => Response(HttpStatusCode.NotModified);

        protected IActionResult ResponseBadRequest(string errorMessage) => Response(HttpStatusCode.BadRequest, errorMessage: errorMessage);

        protected IActionResult ResponseBadRequest() => Response(HttpStatusCode.BadRequest, errorMessage: "A requisição é inválida");

        protected IActionResult ResponseNotFound(string errorMessage) => Response(HttpStatusCode.NotFound, errorMessage: errorMessage);

        protected IActionResult ResponseNotFound() => Response(HttpStatusCode.NotFound, errorMessage: "O recurso não foi encontrado");

        protected IActionResult ResponseUnauthorized(string errorMessage) => Response(HttpStatusCode.Unauthorized, errorMessage: errorMessage);

        protected IActionResult ResponseUnauthorized() => Response(HttpStatusCode.Unauthorized, errorMessage: "Permissão negada");

        protected IActionResult ResponseInternalServerError() => Response(HttpStatusCode.InternalServerError);

        protected IActionResult ResponseInternalServerError(string errorMessage) => Response(HttpStatusCode.InternalServerError, errorMessage: errorMessage);

        protected IActionResult ResponseInternalServerError(Exception exception) => Response(HttpStatusCode.InternalServerError, errorMessage: exception.Message);

        protected new JsonResult Response(HttpStatusCode statusCode, object? data, string? errorMessage)
        {
            EstruturaResponse? result;

            if (string.IsNullOrWhiteSpace(errorMessage))
            {
                var success = statusCode.IsSuccess();

                if (data != null)
                    result = new EstruturaResponse(statusCode, success, data);
                else
                    result = new EstruturaResponse(statusCode, success);
            }
            else
            {
                var errors = new List<string>();

                if (!string.IsNullOrWhiteSpace(errorMessage)) errors.Add(errorMessage);

                result = new EstruturaResponse(statusCode, false, errors);
            }

            return new JsonResult(result) { StatusCode = (int)result.StatusCode };
        }

        protected new JsonResult Response(HttpStatusCode statusCode) => Response(statusCode, null, null);

        protected new JsonResult Response(HttpStatusCode statusCode, object result) => Response(statusCode, result, null);

        protected new JsonResult Response(HttpStatusCode statusCode, string errorMessage) => Response(statusCode, null, errorMessage);

    }
}
