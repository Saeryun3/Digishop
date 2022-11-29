namespace WebshopInterface
{
    public interface ICategoryContainer
    {
        bool CreateCategory(string categoryname);
        List<CategoryDTO> GetAllCategories();
        bool CategoryExist(string categoryname);
        void DeleteCategoryID(int categoryID);
        string GetCategoryNameByCategoryID(int categoryID);
    }
}
