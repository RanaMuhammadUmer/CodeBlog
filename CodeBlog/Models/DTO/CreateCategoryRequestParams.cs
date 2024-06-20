namespace CodeBlog.Models.DTO
{
    public class CreateCategoryRequestParams
    {
        public string Name { get; set; } = string.Empty;
        public string UrlHandle { get; set; } = string.Empty;
    }
}
