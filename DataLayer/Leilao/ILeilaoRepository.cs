using DataLayer.Utilizador;
using DataLayer.Watches;

namespace DataLayer.Leilao
{
    public interface ILeilaoRepository
    {
        public Task<LeilaoModel> Find(int id);
        public Task<bool> DeleteLeilao(int leilaoId);
        public Task<List<LeilaoModel>> FindAll();
        public Task<WatchModel> FindWatch(int leilaoId);
        public Task<List<LeilaoModel>> FindLeiloesUtilizador(int idUtilizador);
        public Task<int> Create(LeilaoModel card);
        public Task<LeilaoModel> UpdateLicitacaoAtual(int leilaoId, int newLicitacaoAtual);
        public Task Remove(int code);
        public Task<List<LeilaoModel>> FindLeilaoFav(int utilizadorId);
        public Task<UtilizadorModel> FindUser(int leilaoId);
    }
}