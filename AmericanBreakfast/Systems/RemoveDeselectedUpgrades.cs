using KitchenLib.Preferences;
using KitchenLib.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Collections;
using Unity.Entities;

namespace KitchenAmericanBreakfast.Systems
{
    [UpdateInGroup(typeof(GameTransitionsCleanupGroup))]
    class RemoveDeselectedUpgrades : FranchiseCleanupSystem, IModSystem
    {
        EntityQuery Query;
        Dish americanBreakfastDish;
        Dish wafflesDish;
        PreferenceInt pancakesOrWafflesInt;
        
        protected override void Initialise()
        {
            Query = GetEntityQuery(new QueryHelper()
                .All(
                    typeof(CUpgrade), typeof(CPersistThroughSceneChanges)));

            americanBreakfastDish = Refs.AmericanBreakfastDish;
            wafflesDish = Refs.WafflesDish;
            pancakesOrWafflesInt = Mod.PrefManager.GetPreference<PreferenceInt>(Mod.PANCAKE_OR_WAFFLES_ID);

        }
        protected override void OnUpdate()
        {
            using var ents = Query.ToEntityArray(Allocator.Temp);
            using var cUpgrades = Query.ToComponentDataArray<CUpgrade>(Allocator.Temp);

            int pancakesOrWaffles = pancakesOrWafflesInt.Get();

            for (int i = 0; i < ents.Length; i++)
            {
                var ent = ents[i];
                var cUpgrade = cUpgrades[i];
                int idToDestroy = 0;

                if (pancakesOrWaffles == 0)
                    idToDestroy = wafflesDish.ID;
                else
                    idToDestroy = americanBreakfastDish.ID;

                if (idToDestroy != 0 && cUpgrade.ID == idToDestroy)
                {
                    EntityManager.DestroyEntity(ent);
                }
            }
        }
    }
}
