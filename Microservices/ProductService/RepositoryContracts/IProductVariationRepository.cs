namespace ProductService.RepositoryContracts
{
    public interface IProductVariationRepository
    {
        Task<List<int>> GetIdsByProductAsync(int productId);
        Task SaveAsync(int productId, IEnumerable<int> variationValueIds);
    }
}
