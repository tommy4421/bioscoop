using System.Collections.Generic;
using PartyInvites.Domain.Entities;

namespace PartyInvites.Domain.Abstract {
    public interface IRepository<T> {
        IEnumerable<GuestResponse> GetAllResponses();
        bool AddResponse(GuestResponse response);
        void RemoveResponse(GuestResponse response);
    }
}