using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace elemental.Items
{
    public class lightning2 : ModItem
    {
		public int projectileid(Player player, int id = -1){
            ElementalPlayer modPlayer = player.GetModPlayer<ElementalPlayer>(mod);
            if(id != -1) modPlayer.channellightningid = id;
            return modPlayer.channellightningid;
		}
		
		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("Lightning");
		  Tooltip.SetDefault("Casts a lightning bolt.");
		}

        public override void SetDefaults()
        {
            //item.name = "lightning";          
            item.damage = 100;                        
            item.magic = true;                     //this make the item do magic damage
            item.channel = true;
            item.width = 24;
            item.height = 28;
            //item.toolTip = "Casts a lightning bolt.";
            item.useTime = 50;
            item.useAnimation = 50;
            item.useStyle = 5;        //this is how the item is held
            item.noMelee = true;
            item.knockBack = 7.5f;        
            item.value = 1000;
            item.rare = 6;
            item.mana = 50;             //mana use
            item.UseSound = SoundID.DD2_EtherianPortalDryadTouch;            //this is the sound when you use the item
            item.autoReuse = false;
            item.shoot = mod.ProjectileType ("WaterShot");  //this make the item shoot your projectile
            item.shootSpeed = 12.5f;    //projectile speed when shoot
        }    
        public override void AddRecipes(){
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LightningMaterial", 30);   //you need 20 Wind
            recipe.AddTile(TileID.GemLocks);   //at work bench
            recipe.AddTile(TileID.LunarBlockStardust);
            recipe.AddTile(TileID.LunarBlockVortex);
            recipe.AddTile(TileID.LunarBlockNebula);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
		
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
 
        public override void HoldItem(Player player){
            if (player.altFunctionUse == 2)     //2 is right click
            {
				item.useTime = 1;
				item.useAnimation = 2;
				item.shoot = mod.ProjectileType("LightningBlast2");
				item.shootSpeed = 10f;    //projectile speed when shoot      
				item.damage = 25;
                item.channel = true;
                item.autoReuse = false;
                item.mana = 10;             //mana use
                item.noUseGraphic = true;
            }
			else{
				
            item.useTime = 50;
            item.useAnimation = 50;
            //item.shoot = 614;
			item.shoot = 466;
            item.shootSpeed = 25f;    //projectile speed when shoot      
            item.damage = 50;
            item.channel = true;
            item.autoReuse = true;
            item.mana = 50;             //mana use
            item.noUseGraphic = false;
            }
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)     //2 is right click
            {
				item.useTime = 1;
				item.useAnimation = 2;
				item.shoot = mod.ProjectileType("LightningBlast2");
				item.shootSpeed = 10f;    //projectile speed when shoot      
				item.damage = 25;
                item.channel = true;
                item.autoReuse = false;
                item.mana = 10;             //mana use
                item.noUseGraphic = true;
                item.UseSound = null;            //this is the sound when you use the item
            }
			else{
				
            item.useTime = 50;
            item.useAnimation = 50;
            //item.shoot = 614;
			item.shoot = 466;
            item.shootSpeed = 25f;    //projectile speed when shoot      
            item.damage = 50;
            item.channel = true;
            item.autoReuse = true;
            item.mana = 50;             //mana use
            item.noUseGraphic = false;
            item.UseSound = SoundID.DD2_EtherianPortalDryadTouch;            //this is the sound when you use the item
            }
            return base.CanUseItem(player);
        }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            ElementalPlayer modPlayer = player.GetModPlayer<ElementalPlayer>(mod);
            if(player.altFunctionUse != 2){
				int numberProjectiles = 3 + Main.rand.Next(4);  //This defines how many projectiles to shot
				for (int index = 0; index < numberProjectiles; ++index)
				{
					Vector2 vector2_1 = new Vector2((float)((double)player.position.X + (double)player.width * 0.5 + (double)(Main.rand.Next(201) * -player.direction) + ((double)Main.mouseX + (double)Main.screenPosition.X - (double)player.position.X)), (float)((double)player.position.Y + (double)player.height * 0.5 - 600.0));   //this defines the projectile width, direction and position
					vector2_1.X = (float)(((double)vector2_1.X + (double)player.Center.X) / 2.0) + (float)Main.rand.Next(-200, 201);
					vector2_1.Y -= (float)(100 * index);
					float num12 = (float)Main.mouseX + Main.screenPosition.X - vector2_1.X;
					float num13 = (float)Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
					if ((double)num13 < 0.0) num13 *= -1f;
					if ((double)num13 < 20.0) num13 = 20f;
					float num14 = (float)Math.Sqrt((double)num12 * (double)num12 + (double)num13 * (double)num13);
					float num15 = item.shootSpeed / num14;
					float num16 = num12 * num15;
					float num17 = num13 * num15;
					float SpeedX = num16 + (float)Main.rand.Next(-30, 31) * 0.02f;  //this defines the projectile X position speed and randomnes
					float SpeedY = num17 + (float)Main.rand.Next(-40, 41) * 0.02f;  //this defines the projectile Y position speed and randomnes
                    Vector2 sixhundred = new Vector2(0,700);
                    Vector2 vector82 = -(Main.player[Main.myPlayer].Center - sixhundred) + Main.MouseWorld;
                    float ai = Main.rand.Next(100);
                    int a = Projectile.NewProjectile(vector2_1.X, vector2_1.Y, SpeedX, SpeedY, type, damage, knockBack, player.whoAmI, vector82.ToRotation(), ai);
                    //int a = Projectile.NewProjectile(vector2_1.X, vector2_1.Y, SpeedX, SpeedY, type, damage, knockBack, Main.myPlayer, 75f);
					Main.projectile[a].magic = true;
					Main.projectile[a].friendly = true;
					Main.projectile[a].hostile = false;
                    Main.projectile[a].penetrate = -1;
                    Main.projectile[a].timeLeft *= 3;
                }
				return false;
			}else if(player.altFunctionUse == 2 && modPlayer.channellightning >= 1){
				Main.projectile[projectileid(player)].position = position;
                Main.projectile[projectileid(player)].timeLeft = 3600;
                Main.projectile[projectileid(player)].velocity = new Vector2(speedX, speedY);
                int a = Dust.NewDust(position, 0, 0, 131, 0, 0, 0, new Color(0, 255, 255));
                Main.dust[a].noGravity = true;
			}else if(player.altFunctionUse == 2 && !(modPlayer.channellightning >= 1)){
                projectileid(player, Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI));
			}
            modPlayer.channellightning = 5;
			return false;
        }  
    }
}