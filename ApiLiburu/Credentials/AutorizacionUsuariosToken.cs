using ApiLiburu.Models;
using ApiLiburu.Repositories;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ApiLiburu.Credentials
{
    public class AutorizacionUsuariosToken: OAuthAuthorizationServerProvider
    {
        RepositoryLiburu repo;

        public AutorizacionUsuariosToken()
        {
            this.repo = new RepositoryLiburu();
        }

        public override Task ValidateClientAuthentication
                    (OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return base.ValidateClientAuthentication(context);
        }

        public override Task GrantResourceOwnerCredentials
            (OAuthGrantResourceOwnerCredentialsContext context)
        {
            //DEBEMOS VALIDAR EL USUARIO Y PASSWORD
            //DICHOS VALORES VIENEN DENTRO DEL CONTEXT
            String login = context.UserName;
            String password = context.Password;
            Usuario user =
                this.repo.ExisteUsuario(login, password);
            if (user == null)
            {
                //SI NO EXISTE EL EMPLEADO, INCLUIMOS UN ERROR
                //DENTROL CONTEXT PARA QUE NO LO VALIDE
                context.SetError("Usuario/Password incorrectos"
                    , "Has introducido mal tus credenciales");
            }
            else
            {
                //EL EMPLEADO EXISTE Y CREAMOS UNA IDENTIDAD
                ClaimsIdentity identidad = new ClaimsIdentity(context.Options.AuthenticationType);
                //AÑADIMOS DATOS A LA IDENTIDAD POR SI
                //DESEAMOS UTILIZARLOS EN ALGUNO MOMENTO
                identidad.AddClaim(new Claim(ClaimTypes.Name, user.Nombre));
                identidad.AddClaim(new Claim(ClaimTypes.NameIdentifier,
                                    user.IdUsuario.ToString()));
                identidad.AddClaim(new Claim(ClaimTypes.Role, user.Rol));
                //INCLUIMOS LA IDENTIDAD DENTRO DE LA VALIDACION
                context.Validated(identidad);
            }
            return base.GrantResourceOwnerCredentials(context);
        }
    }
}