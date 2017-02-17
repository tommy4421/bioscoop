using System.Data.Entity;
using PartyInvites.Domain.Entities;

namespace PartyInvites.Domain.Concrete {
    public class EFDbContext : DbContext {
        public virtual DbSet<GuestResponse> GuestResponses { get; set; }
    }
}