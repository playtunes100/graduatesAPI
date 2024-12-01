using Microsoft.EntityFrameworkCore;

namespace graduatesAPI.Models
{
    public class GraduatesContext: DbContext
    {
        public GraduatesContext(DbContextOptions<GraduatesContext> options)
        : base(options)
        {
        }

        public DbSet<GraduatesModel> GraduatesModels { get; set; } = null!;

    }
}
