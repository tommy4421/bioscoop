using System.Collections.Generic;
using System.Linq;
using PartyInvites.Domain.Abstract;
using PartyInvites.Domain.Entities;

namespace PartyInvites.Domain.Concrete {
    public class GuestResponseRepository : IRepository<GuestResponse> {
        private static readonly List<GuestResponse> GuestResponses = new List<GuestResponse>();

        public IEnumerable<GuestResponse> GetAllResponses() {
            return GuestResponses;
        }

        public bool AddResponse(GuestResponse response) {
            if (GuestResponses.Any(r => r.Email == response.Email)) return false;
            GuestResponses.Add(response);
            return true;
        }

        public void RemoveResponse(GuestResponse response) {
            GuestResponses.Remove(response);
        }
    }
}