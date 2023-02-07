using LaMafiaRS.Datos;
using LaMafiaRS.Helper;
using LaMafiaRS.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using XAct;

namespace LaMafiaRS.Repositories
{
    public class RepositoryWeb
    {
        private ApplicationDbContext context;
        public RepositoryWeb(ApplicationDbContext context)
        {
            this.context = context;
        }
        public int GetCurrentUserId()
        {
            var consulta = from datos in this.context.User
                           select datos.Id;
            int id = consulta.FirstOrDefault();
            return id;
        }
        private int GetMaxIdUsuario()
        {
            if (this.context.User.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.User.Max(z => z.Id) + 1;
            }
        }
        private bool ExisteEmail(string email)
        {
            var consulta = from datos in this.context.User
                           where datos.Email == email
                           select datos;
            if (consulta.Count() > 0)
            {
                //el email existe en la base de datos
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RegistrarUsuario(string email, string password, string username, DateTime creationdate, string tipo)
        {
            bool ExisteEmail = this.ExisteEmail(email);
            if (ExisteEmail)
            {
                return false;
            }
            else
            {
                int idusuario = this.GetMaxIdUsuario();
                User usuario = new User();
                //usuario.UserId = idusuario;
                usuario.ProfilePictureUrl = "~/imagenes/default.png";
                usuario.Email = email;
                usuario.Username = username;
                usuario.Tipo = tipo;
                //genera un salt aleatorio para cada usuario
                usuario.Salt = HelperCryptography.GenerateSalt();
                //genera su password con el salt
                usuario.PASS = HelperCryptography.EncriptarPassword(password, usuario.Salt);
                this.context.User.Add(usuario);
                this.context.SaveChanges();

                return true;
            }
        }
        public User LogInUsuario(string email, string password)
        {
            User usuario = context.User.SingleOrDefault(x => x.Email == email);
            if (usuario == null)
            {
                return null;
            }
            else
            {
                byte[] passUsuario = usuario.PASS;
                string salt = usuario.Salt;

                byte[] temporal = HelperCryptography.EncriptarPassword(password, salt);

                bool respuesta = HelperCryptography.compareArrays(passUsuario, temporal);
                if (respuesta == true)
                {
                    return usuario;
                }
                else
                {
                    return null;
                }
            }
        }
        public List<User> GetUsuarios()
        {
            var consulta = from datos in this.context.User
                           select datos;
            return consulta.ToList();
        }
    }
}
