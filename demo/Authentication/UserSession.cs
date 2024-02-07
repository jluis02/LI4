using DataLayer.Utilizador;

namespace BlazorServerAutheticationAndAuthorization.Authetication
{
    public class UserSession
    {
        public string UserName { get; set; }
        public string Role { get; set; }
        public string UserId {  get; set; }
        public string UserMediumEval { get; set; }
        public string UserNumLeiloesFavoritos { get; set; }
        public string UserRegisterDate { get; set; }
    }
}
