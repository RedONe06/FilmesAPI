using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data;
using UsuariosAPI.Data.DTOs.Usuario;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private EmailService _emailService;
        private RoleManager<IdentityRole<int>> _roleManager;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> manager, EmailService emailService, RoleManager<IdentityRole<int>> roleManager)
        {
            _mapper = mapper;
            _userManager = manager;
            _emailService = emailService;
            _roleManager = roleManager;
        }

        public Result CadastrarUsuario(CreateUsuarioDTO usuarioDTO)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioDTO);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            IdentityResult resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, usuarioDTO.Password).GetAwaiter().GetResult();
            var createRoleResult = _roleManager.CreateAsync(new IdentityRole<int>("admin")).GetAwaiter().GetResult();
            var usuarioRoleResult = _userManager.AddToRoleAsync(usuarioIdentity, "admin").GetAwaiter().GetResult();

            if (resultadoIdentity.Succeeded)
            {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity);
                _emailService.EnviarEmail(new[] { usuarioIdentity.Email }, "Link de ativação", usuarioIdentity.Id, code.Result);
                return Result.Ok().WithSuccess(code.Result);
            }
            return Result.Fail(resultadoIdentity.ToString());
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            var identityUser = _userManager.Users.FirstOrDefault(usuario => usuario.Id == request.UsuarioId);
            var identityResult = _userManager.ConfirmEmailAsync(identityUser, request.CodigoDeAtivacao).Result;
            if(identityResult.Succeeded)
            {
                return Result.Ok().WithSuccess(identityResult.ToString());
            }
            return Result.Fail(identityResult.ToString());
        }
    }
}
