using System.Collections.Generic;

namespace MVCRecipes.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Time { get; set; }
        public int Difficulty { get; set; }
        public int Likes { get; set; }
        public string Ingredients { get; set; }
        public string Process { get; set; }
        public string TipsNTricks { get; set; }
    }
}