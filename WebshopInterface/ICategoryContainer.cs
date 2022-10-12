namespace WebshopInterface
{
    public interface ICategoryContainer
    {
        bool CreateCategory(string categoryname);
        List<CategoryDTO> GetAllCategories();
        void DeleteCategoryID(int categoryID);
    }
}
