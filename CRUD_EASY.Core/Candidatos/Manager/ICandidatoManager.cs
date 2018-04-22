using Abp.Domain.Services;
using CRUD_EASY.Candidatos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_EASY.Candidatos.Manager
{
    public interface ICandidatoManager : IDomainService
    {
        Task<Guid> CreateOrUpdate(Candidato candidato);

        Task Delete(Guid Id);

        List<Candidato> Get(Expression<Func<Candidato,bool>> expression);

    }
}
