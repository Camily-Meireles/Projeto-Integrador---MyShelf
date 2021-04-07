using Microsoft.AspNet.Identity.EntityFramework;
using MyShelf.Areas.Seguranca.Models;
using System.Data.Entity;

namespace MyShelf.DAL
{
    public class IdentityDbContextAplicacao : IdentityDbContext<Usuario>
    {
        public IdentityDbContextAplicacao() : base("IdentityDB")
        { }
        static IdentityDbContextAplicacao()
        {
            Database.SetInitializer<IdentityDbContextAplicacao>(new IdentityDBInit());
        }
        public static IdentityDbContextAplicacao Create()
        {
            return new IdentityDbContextAplicacao();
        }
        public class IdentityDBInit : DropCreateDatabaseIfModelChanges<IdentityDbContextAplicacao>
        {
        }
    }
}