using IngredientLib.Ingredient.Providers;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using IngredientLib.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenAmericanBreakfast.Mains;

namespace KitchenAmericanBreakfast
{
    internal class Refs
    {
        #region Vanilla References
        // Items
        public static Item Plate => Find<Item>(ItemReferences.Plate);
        public static Item DirtyPlate => Find<Item>(ItemReferences.PlateDirty);
        public static Item Flour => Find<Item>(ItemReferences.Flour);
        public static Item Egg => Find<Item>(ItemReferences.Egg);
        public static Item CrackedEgg => Find<Item>(ItemReferences.EggCracked);
        public static Item Sugar => Find<Item>(ItemReferences.Sugar);
        public static Item Burnt => Find<Item>(ItemReferences.BurnedFood);

        // Processes
        public static Process Cook => Find<Process>(ProcessReferences.Cook);
        public static Process Chop => Find<Process>(ProcessReferences.Chop);
        public static Process Knead => Find<Process>(ProcessReferences.Knead);
        public static Process Oven => Find<Process>(ProcessReferences.RequireOven);
        #endregion

        #region IngredientLib References
        public static Item Pork => Find<Item>(IngredientLib.References.GetIngredient("pork"));
        public static Item Bacon => Find<Item>(IngredientLib.References.GetIngredient("bacon"));
        public static Item Syrup => Find<Item>(IngredientLib.References.GetSplitIngredient("syrup"));
        public static Item SyrupBottle => Find<Item>(IngredientLib.References.GetIngredient("syrup"));
        public static Item EggNoodle => Find<Item>(IngredientLib.References.GetIngredient("egg dough"));
        public static Item UnmixedEggDough => Find<Item>(IngredientLib.References.GetIngredient("unmixed egg dough"));
        public static Item Butter => Find<Item>(IngredientLib.References.GetIngredient("butter"));
        public static Item ButterSlice => Find<Item>(IngredientLib.References.GetSplitIngredient("butter"));
        #endregion

        #region Modded References
        // Items
        public static Item Pancake => Find<Item, Pancake>();
        public static ItemGroup PlatedPancakes => Find<ItemGroup, PlatedPancakes>();
        public static ItemGroup UnmixedBatter => Find<ItemGroup, UnmixedBatter>();
        public static Item Batter => Find<Item, Batter>();

        public static Item Waffle => Find<Item, Waffle>();
        // Cards
        public static Dish AmericanBreakfastDish => Find<Dish, AmericanBreakfastDish>();
        public static Dish PancakeSyrupCard => Find<Dish, PancakeSyrupCard>();
        public static Dish PancakeBaconCard => Find<Dish, PancakeBaconCard>();
        public static Dish PancakeButterCard => Find<Dish, PancakeButterCard>();

        // Appliances
        public static Appliance WaffleIron => Find<Appliance, WaffleIron>();

        //Processes
        public static Process CookWaffle => Find<Process, CookWaffle>();
        #endregion



        internal static T Find<T>(int id) where T : GameDataObject
        {
            return (T)GDOUtils.GetExistingGDO(id) ?? (T)GDOUtils.GetCustomGameDataObject(id)?.GameDataObject;
        }

        internal static T Find<T, C>() where T : GameDataObject where C : CustomGameDataObject
        {
            return GDOUtils.GetCastedGDO<T, C>();
        }

        internal static T Find<T>(string modName, string name) where T : GameDataObject
        {
            return GDOUtils.GetCastedGDO<T>(modName, name);
        }

        private static Appliance.ApplianceProcesses FindApplianceProcess<C>() where C : CustomSubProcess
        {
            ((CustomApplianceProccess)CustomSubProcess.GetSubProcess<C>()).Convert(out var process);
            return process;
        }
    }
}
