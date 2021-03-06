using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace elemental.Items
{
    public class Sanic : ModItem
    {


        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 14;
            //item.toolTip = "Gotta Go Fast";
            item.value = 10;
            item.rare = 3;
            item.accessory = true;
        }
		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Blue");
		  Tooltip.SetDefault("Must Fast");
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WindMaterial", 20);
            recipe.AddTile(TileID.SkyMill);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += 2.15f;
            player.dashDelay = 0;
        }
    }
}