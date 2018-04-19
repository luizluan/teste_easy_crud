using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using CRUD_EASY.Authorization.Roles;
using CRUD_EASY.Authorization.Users;
using CRUD_EASY.Candidatos.Attributes.Conhecimentos.Entity;
using CRUD_EASY.Candidatos.Attributes.Entity.Bancos;
using CRUD_EASY.Candidatos.Attributes.HorariosDisponiveis.Entity;
using CRUD_EASY.Candidatos.Attributes.MelhoresHorarios.Entity;
using CRUD_EASY.Candidatos.Entity;
using CRUD_EASY.MultiTenancy;

namespace CRUD_EASY.EntityFramework
{
    public class CRUD_EASYDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        public virtual IDbSet<Candidato> Candidatos { get; set; }
        public virtual IDbSet<Banco> Bancos { get; set; }
        public virtual IDbSet<Conhecimento> Conhecimentos { get; set; }
        public virtual IDbSet<MelhorHorario> MelhoresHorarios { get; set; }
        public virtual IDbSet<HorarioDisponivel> HorariosDisponiveis { get; set; }






        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public CRUD_EASYDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in CRUD_EASYDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of CRUD_EASYDbContext since ABP automatically handles it.
         */
        public CRUD_EASYDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public CRUD_EASYDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public CRUD_EASYDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
