using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCRecipes.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public int Time { get; set; }
        [Range(1, 5)]
        public int Difficulty { get; set; }
        public int Likes { get; set; }
        [MaxLength(200)]
        public string Ingredients { get; set; }
        [MaxLength(200)]
        public string Process { get; set; }
        [MaxLength(200)]
        public string TipsNTricks { get; set; }
    }
}