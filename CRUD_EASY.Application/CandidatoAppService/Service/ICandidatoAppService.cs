using Abp.Application.Services;
using CRUD_EASY.CandidatoAppService.Dtos.Base;
using CRUD_EASY.CandidatoAppService.Dtos.Busca;
using CRUD_EASY.CandidatoAppService.Dtos.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_EASY.CandidatoAppService.Service
{
    /// <summary>
    /// Interface do AppService tudo que tem no ApplicationService vira api através da framework
    /// </summary>
    public interface ICandidatoAppService : IApplicationService
    {

        LoadOutput LoadAtributos();

        Task<Guid> CreateOrUpdate(CandidatoDto input);

        List<CandidatoOutput> GetAll(BuscaCandidatoInput input);

        Task Delete(DeleteInput input);
    }
}
