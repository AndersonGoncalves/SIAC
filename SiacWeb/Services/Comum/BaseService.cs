using System.Threading.Tasks;
using SiacWeb.Enums;
using SiacWeb.Models;
using SiacWeb.Models.Interface;

namespace SiacWeb.Services.Comum
{
    public abstract class BaseService
    {
        internal readonly SiacWebContext _context;
        internal readonly IUser _user;
        private readonly AuditoriaService _auditoriaService;

        public BaseService(SiacWebContext context, IUser user, AuditoriaService auditoriaService)
        {
            _context = context;
            _user = user;
            _auditoriaService = auditoriaService;
        }
                
        internal async Task Auditoria(int empresaId, Modulo modulo, SubModulo subModulo, Operacao operacao, string dados)
        {
            Auditoria auditoria = new Auditoria
            {
                EmpresaId = empresaId,
                Modulo = modulo,
                SubModulo = subModulo,
                Operacao = operacao,
                Usuario = _user.Name,
                Dados = dados,
            };
            await _auditoriaService.InsertAsync(auditoria);
        }
    }
}