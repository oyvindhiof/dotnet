using System.Threading.Tasks;

namespace ComicsUniverse.Contracts.Services
{
    public interface IActivationService
    {
        Task ActivateAsync(object activationArgs);
    }
}
