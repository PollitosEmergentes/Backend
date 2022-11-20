using PeruStar.API.Shared.Domain.Services.Communication;

namespace PeruStar.API.Specialty.Domain.Services.Communication
{
    public class SpecialtyResponse : BaseResponse<Specialty.Domain.Models.Specialty>
    {
        public SpecialtyResponse(Specialty.Domain.Models.Specialty resource) : base(resource)
        {
        }

        public SpecialtyResponse(string message) : base(message)
        {
        }
    }
}
