using System.Threading.Tasks;

namespace ComicsUniverse.Activation
{
    public interface IActivationHandler
    {
        bool CanHandle(object args);

        Task HandleAsync(object args);
    }
}
