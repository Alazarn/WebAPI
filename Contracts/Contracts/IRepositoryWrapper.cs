
namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IProductRepository Product { get; }
        IProductSystemRequirementsRepository SystemRequirements { get; }
        void Save();
    }
}
