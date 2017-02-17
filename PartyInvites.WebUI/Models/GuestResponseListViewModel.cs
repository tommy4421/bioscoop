using System.Collections.Generic;
using PartyInvites.Domain.Entities;

namespace PartyInvites.WebUI.Models {
    public class GuestResponseListViewModel {
        public IEnumerable<GuestResponse> GuestResponses { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}