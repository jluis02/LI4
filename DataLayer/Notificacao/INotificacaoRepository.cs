namespace DataLayer.Notificacao
{
    public interface INotificacaoRepository
    {
        public Task<NotificacaoModel> Find(int idNotificacao);
        public Task<List<NotificacaoModel>> FindAllFromUtilizador(int idUser);
        public Task Create(NotificacaoModel card);
        public Task<NotificacaoModel> Update(NotificacaoModel noti);
        public Task Remove(int id);
    }
}