using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Entities;

namespace KitchenAmericanBreakfast.Systems
{
    public class HandleThirdPancake : GameSystemBase, IModSystem
    {
        protected override void OnUpdate()
        {
            ItemSet pancakes = Refs.PlatedPancakes.DerivedSets[1];
            int newMax = HasStatus((RestaurantStatus)VariousUtils.GetID("triplestack")) ? 3 : 2;

            if (pancakes.Max != newMax)
            {
                pancakes.Max = newMax;
                Refs.PlatedPancakes.DerivedSets[1] = pancakes;
                Data.ItemSetView.Initialise(Data);
            }
        }
    }
}
