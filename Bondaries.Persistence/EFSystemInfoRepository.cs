using Core.Boundaries;

namespace Bondaries.Persistence
{
    public sealed class EFSystemInfoRepository : ISystemInfoRepository
    {
        int ISystemInfoRepository.GetActiveUsers() => 5;
        
    }
}