using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Astuc.Application.Models;
using EIRL.Application.Services;
using Astuc.Domain.DTOs;

namespace EIRL.API.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(IAuthService authService, IHttpContextAccessor httpContextAccessor)
        {
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;
        }
        public class LoginRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
        public class EmailReq
        {
            public string Email { get; set; }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (await _authService.ValidateCredentials(request.Email, request.Password))
            {
                var token = await _authService.GenerateToken(request.Email);
                if (token != null)
                    return Ok(new { token });
            }
            return Unauthorized();
        }



        [HttpGet("GetLoggedUser")]
        public async Task<IActionResult> GetLoggedUser()
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            if (authHeader.StartsWith("Bearer "))
            {
                var token = authHeader.Substring("Bearer ".Length);
                var user = await _authService.GetLoggedUser(token);
                var principal = _authService.ValidateToken(token);
                if (principal != null)
                {
                    return Ok(user);
                }
            }
            return Unauthorized();
        }



        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] LoginRequest request)
        //{
        //    if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
        //    {
        //        return BadRequest(new { Message = "Invalid input" });
        //    }

        //    var result = await _authService.Login(request.Email, request.Password);
        //    if (result.Succeeded)
        //    {
        //        var user = await _authService.GetLoggedUser();
        //        if (user == null)
        //        {
        //            return BadRequest(new { Message = "Unable to retrieve user information" });
        //        }

        //        // Obtén el token del encabezado de la respuesta, suponiendo que se ha configurado en el servicio AuthService
        //        var token = _httpContextAccessor.HttpContext.Response.Headers["Access-Token"].ToString();

        //        if (string.IsNullOrEmpty(token))
        //        {
        //            return BadRequest(new { Message = "Token generation failed" });
        //        }

        //        return Ok(new
        //        {
        //            Message = "Logged in successfully",
        //            AccessToken = token
        //        });
        //    }

        //    return BadRequest(new { Message = "Login failed" });
        //}




        [HttpPost("ActivateUser")]

        public async Task<IActionResult> ActivateUser(string email)
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            if (authHeader.StartsWith("Bearer "))
            {
                var token = authHeader.Substring("Bearer ".Length);
                var activate = await _authService.ActivateUser(email);
                var principal = _authService.ValidateToken(token);
                if (principal != null && activate)
                {
                    return Ok(new { Message = "Activated successful" });
                }
                if (!activate)
                {
                    return BadRequest(new { Message = "The user is already activated" });

                }
            }

            return Unauthorized();
            
        }
        [HttpPost("DesactivateUser")]
        public async Task<IActionResult> DesactivateUser(string email)
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            if (authHeader.StartsWith("Bearer "))
            {
                var token = authHeader.Substring("Bearer ".Length);
                var activate = await _authService.DesactivateUser(email);
                var principal = _authService.ValidateToken(token);
                if (principal != null && activate)
                {
                    return Ok(new { Message = "Desactivated successful" });
                }
                if (!activate)
                {
                    return BadRequest(new { Message = "The user is already desactivated" });
                }
            }

            return Unauthorized();

        }
        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            if (authHeader.StartsWith("Bearer "))
            {
                var token = authHeader.Substring("Bearer ".Length);
                var result = await _authService.DeleteUser(id);
                var principal = _authService.ValidateToken(token);
                if (principal != null && result.Succeeded)
                {
                    return Ok(new { Message = "Eliminated successful" });
                }
                return BadRequest();
                
            }

            return Unauthorized();

        }
        [HttpPut("EditUser")]
        public async Task<IActionResult> Edit(string id, UserDTO user)
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            if (authHeader.StartsWith("Bearer "))
            {
                var token = authHeader.Substring("Bearer ".Length);
                var principal = _authService.ValidateToken(token);
                 var res = await _authService.Update(user);
                if (principal != null && res)
                {
                    return Ok(new { Message = "Edit successful" });
                }
                if (!res)
                {
                    return BadRequest(new { Message = "User Not Found" });

                }
            }

            return Unauthorized();

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.Register(model);
                if (result.Succeeded)
                {
                    return Ok(new { Message = "Registration successful" });
                }

                return BadRequest(new { Errors = result.Errors });
            }

            return BadRequest(new { Message = "Invalid registration request" });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.Logout();
            return Ok(new { Message = "Logged out successfully" });
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] EmailReq request)
        {
            var res = await _authService.ResetPassword(request.Email);
            if (res.Succeeded)
            {
                return Ok(new { Message = res });

            }
            return BadRequest(new { Errors = res.Errors });
        }
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var res = await _authService.ChangePasswordAsync(request);
            if (res.Succeeded)
            {
                return Ok(new { Message = res });

            }
            return BadRequest(new { Errors = res.Errors });
        }


        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _authService.GetUsersWithRoles();
            return Ok(users);
        }

        [HttpGet("roles")]
        public IActionResult GetRoles()
        {
            var roles = _authService.GetRoles(); // Implementa este método en tu servicio de autenticación para obtener los roles disponibles
            return Ok(roles);
        }


        [HttpGet("user/{userId}/roles")]
        public async Task<IActionResult> GetUserRoles(string userId)
        {
            var roles = await _authService.GetUserRoles(userId);
            if (roles != null)
            {
                return Ok(roles);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRoleToUser(string userId, string roleName)
        {
            var result = await _authService.AssignRoleToUser(userId, roleName); // Implementa este método en tu servicio de autenticación para asignar el rol al usuario
            if (result.Succeeded)
            {
                return Ok(new { Message = $"Rol '{roleName}' asignado al usuario correctamente" });
            }
            else
            {
                return BadRequest(new { Message = $"Error al asignar el rol '{roleName}' al usuario", Errors = result.Errors });
            }
        }



    }
}
