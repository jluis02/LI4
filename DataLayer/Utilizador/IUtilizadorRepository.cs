namespace DataLayer.Utilizador
{
    public interface IUtilizadorRepository
    {
        public Task<UtilizadorModel> Find(string username);
        public Task<UtilizadorModel> FindId(int id);
        public Task<List<UtilizadorModel>> FindAll();
        public Task Create(UtilizadorModel card);
        public Task<UtilizadorModel> Update(UtilizadorModel user);
        public Task<UtilizadorModel> UpdateNumLeilao(string user, int numLeilao);
        public Task<UtilizadorModel> UpdateAvaliacaoMedia(string user, int numLeilao);
        public Task Remove(int code);
    }
}