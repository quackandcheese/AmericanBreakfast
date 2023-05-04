using Kitchen.Modules;
using KitchenLib.Preferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast
{
    public class AmericanBreakfastMenu<T> : KLMenu<T>
    {
        public AmericanBreakfastMenu(Transform container, ModuleList moduleList) : base(container, moduleList)
        {

        }

        public override void Setup(int player_id)
        {
            AddLabel("American Breakfast");
            AddInfo("Changing these settings only takes effect upon game restart.");
            
            New<SpacerElement>();

            AddLabel("Starting Main for American Breakfast");
            AddSelect<int>(PancakeOrWafflesOption);
            PancakeOrWafflesOption.OnChanged += delegate (object _, int result)
            {
                PreferenceInt preferenceInt = Mod.PrefManager.GetPreference<PreferenceInt>(Mod.PANCAKE_OR_WAFFLES_ID);
                preferenceInt.Set(result);
                Mod.PrefManager.Save();
            };

            New<SpacerElement>();

            AddLabel("Mixed Egg Method");
            AddSelect<int>(MixEggMethodOption);
            MixEggMethodOption.OnChanged += delegate (object _, int result)
            {
                PreferenceInt preferenceInt = Mod.PrefManager.GetPreference<PreferenceInt>(Mod.MIX_EGG_METHOD);
                preferenceInt.Set(result);
                Mod.PrefManager.Save();
            };

            New<SpacerElement>(true);
            New<SpacerElement>(true);
            AddButton(base.Localisation["MENU_BACK_SETTINGS"], delegate (int i)
            {
                this.RequestPreviousMenu();
            }, 0, 1f, 0.2f);
        }


        private Option<int> MixEggMethodOption = new Option<int>(
            new List<int> { 0, 1 },
            (int)Mod.PrefManager.Get<PreferenceInt>(Mod.MIX_EGG_METHOD),
            new List<string> { "Double Chop", "Combine With Milk" }
            );

        private Option<int> PancakeOrWafflesOption = new Option<int>(
            new List<int> { 0, 1 },
            (int)Mod.PrefManager.Get<PreferenceInt>(Mod.PANCAKE_OR_WAFFLES_ID),
            new List<string> { "Pancakes", "Waffles" }
            );
    }
}
