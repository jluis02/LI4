namespace DataLayer.LeilaoFavorito
{
    public interface ILeilaoFavoritoRepository
    {
        public Task<LeilaoFavoritoModel> Find(int id);
        public Task<List<LeilaoFavoritoModel>> FindAll();
        public Task Create(LeilaoFavoritoModel card);
        public Task<LeilaoFavoritoModel> Update(LeilaoFavoritoModel leilao);
        public Task Remove(int code);
    }
}
