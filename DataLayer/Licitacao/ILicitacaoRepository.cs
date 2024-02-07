namespace DataLayer.Licitacao
{
    public interface ILicitacaoRepository
    {
        public Task<LicitacaoModel> Find(int idLicitacao);
        public Task<List<LicitacaoModel>> FindAllFromLeilao(int idLeilao);
        public Task Create(LicitacaoModel card);
        public Task<LicitacaoModel> Update(LicitacaoModel user);
        public Task Remove(int code);
    }
}