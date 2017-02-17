using System.Collections.Generic;
using System.Linq;
using PartyInvites.Domain.Abstract;
using PartyInvites.Domain.Entities;

namespace PartyInvites.Domain.Concrete {
    public class PersistentGPRepository : IRepository<GuestResponse> {
        private readonly EFDbContext db;

        public PersistentGPRepository() {
            db = new EFDbContext();
        }

        public IEnumerable<GuestResponse> GetAllResponses() {
            return db.GuestResponses;
        }

        public bool AddResponse(GuestResponse response) {
            if (db.GuestResponses.Any(r => r.Email == response.Email)) return false;
            db.GuestResponses.Add(response);
            db.SaveChanges();
            return true;
        }

        public void RemoveResponse(GuestResponse response) {
            db.GuestResponses.Remove(response);
            db.SaveChanges();
        }
    }
}