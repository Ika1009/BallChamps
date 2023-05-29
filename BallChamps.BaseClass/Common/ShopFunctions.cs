using BallChamps.Domain;


namespace BallChampsBaseClass.Common
{
    public class ShopFunctions
    {

        public static (List<Product> filteredList, string cat) FilerShopCategory(List<Product> shopList, string category)
        {
            List<Product> filteredList = new List<Product>();

            if (category == "All" || category == null)
            {
                filteredList = shopList;
                category = "All Items";
            }
            if (category == "Events")
            {
                filteredList = shopList.Where(s => s.Category == "Events").ToList();
            }
            if (category == "Shirts")
            {
                filteredList = shopList.Where(s => s.Category == "Shirts").ToList();
            }
            if (category == "Shoes")
            {
                filteredList = shopList.Where(s => s.Category == "Shoes").ToList();
            }
            if (category == "Shorts")
            {
                filteredList = shopList.Where(s => s.Category == "Shorts").ToList();
            }
            if (category == "Accessories")
            {
                filteredList = shopList.Where(s => s.Category == "Accessories").ToList();
            }
            return (filteredList, category);
        }

    }
}
