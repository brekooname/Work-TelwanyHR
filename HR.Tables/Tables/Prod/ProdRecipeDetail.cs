using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProdRecipeDetail
    {
        public int RecipeDetaiId { get; set; }
        public int? RecipeId { get; set; }
        public int? BillOfMaterialId { get; set; }
        public int? ProLineId { get; set; }

        public virtual ProdRecipe Recipe { get; set; }
    }
}
