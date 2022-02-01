using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Api_Tour_Of_Heroes_Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Api_Tour_Of_Heroes_Domain.Interfaces;
using Api_Tour_Of_Heroes_Application.ViewModels;

namespace App_Tour_Of_Heroes_Apresentation.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IUserRepository userRepository, IHeroRepository heroRepository, IMapper mapper) : base(userRepository, heroRepository, mapper)
        { }

        /// <summary>
        /// Returns a list of User
        /// </summary>       
        [AllowAnonymous]
        [HttpGet("user-list")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var listOfUser = this.Mapper.Map<List<UserViewModel>>(await this.UserRepository.GetAllAsync());

                if (listOfUser.Count == 0 || listOfUser == null)
                {
                    return NotFound(new
                    {
                        status = StatusCodes.Status404NotFound,
                        message = "User list not found.",
                        data = Array.Empty<UserViewModel>()
                    });
                }

                return Ok(new
                {
                    status = StatusCodes.Status200OK,
                    message = "list of User successfully found.",
                    data = listOfUser
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = StatusCodes.Status400BadRequest,
                    message = ex.Message,
                    data = Array.Empty<UserViewModel>()
                });
            }
        }

        /// <summary>
        /// Returns a User by id
        /// </summary>
        /// <param name="id"></param>      
        [AllowAnonymous]
        [HttpGet("user/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                var hero = this.Mapper.Map<UserViewModel>(await this.UserRepository.GetByIdAsync(id));

                if (hero == null)
                {
                    return NotFound(new
                    {
                        status = StatusCodes.Status404NotFound,
                        message = "User not found",
                        data = new object()
                    });
                }

                return Ok(new
                {
                    status = StatusCodes.Status200OK,
                    message = "User successfully found",
                    data = hero
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = StatusCodes.Status400BadRequest,
                    message = ex.Message,
                    data = new object()
                });
            }
        }

        /// <summary>
        /// create a User
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>     
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateAsync(string userName,  string password, string role)
        {
            try
            {
                var newUser = new UserViewModel { UserName = userName, Password = password, Role = role };

                var createUser = await this.UserRepository.CreateAsync(this.Mapper.Map<User>(newUser));

                if (createUser != 1)
                {
                    return BadRequest(new
                    {
                        status = StatusCodes.Status400BadRequest,
                        message = "it was not possible to register the User",
                        data = new object()
                    });
                }

                return Ok(new
                {
                    status = StatusCodes.Status201Created,
                    message = "User created successfully",
                    data = newUser
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = StatusCodes.Status400BadRequest,
                    message = ex.Message,
                    data = new object()
                });
            }
        }

        /// <summary>
        /// Update a User
        /// </summary>
        /// <param name="model"></param>       
        [HttpPut("update-user")]
        public async Task<IActionResult> UpdateAsync([FromQuery] UserViewModel model)
        {
            try
            {
                var updateHero = await this.UserRepository.UpdateAsync(this.Mapper.Map<User>(model));

                if (updateHero != 1)
                {
                    return NotFound(new
                    {
                        status = StatusCodes.Status404NotFound,
                        message = "could not update User.",
                        data = new object()
                    });
                }

                return Ok(new
                {
                    status = StatusCodes.Status200OK,
                    message = "User successfully updated",
                    data = model
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = StatusCodes.Status400BadRequest,
                    message = ex.Message,
                    data = new object()
                });
            }
        }

        /// <summary>
        /// Remove a hero
        /// </summary>
        /// <param name="id"></param>      
        [HttpDelete("delete-user/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                var deleteHero = await this.UserRepository.DeleteAsync(this.Mapper.Map<User>(new UserViewModel { Id = id }));

                if (deleteHero != 1)
                {
                    return NotFound(new
                    {
                        status = StatusCodes.Status404NotFound,
                        message = "could not delete User.",
                        data = new object()
                    });
                }

                return Ok(new
                {
                    status = StatusCodes.Status200OK,
                    message = "User successfully deleted",
                    data = id
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = StatusCodes.Status400BadRequest,
                    message = ex.Message,
                    data = new object()
                });
            }
        }

    }
}
