namespace CodeFirstExample
{
    /// <summary>
    /// ProductModel class for Service layer.
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Product Id.
        /// </summary>
        public int ProductId { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Product Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Product Image.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Product Image Url.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Product Price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Product Sale Price.
        /// </summary>
        public decimal SalePrice { get; set; }
    }
}
