namespace Menu.Models
{
    public class Ingredients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object DishIngredients { get; internal set; }
    }
}
