using System;
using System.Collections.Generic;
using System.Text;

namespace realminecraftgame
{
    internal class KillDisplay
    {
        private int originalVillagerPopulation = 1000;

        public void VillagerCensus()
        {
            
        }
        public int GetKillCount (SpawnSystem spawn)
        {
            int killCount = 0;
            if ( spawn.Villagers.Count < originalVillagerPopulation)
            {
                killCount = originalVillagerPopulation - spawn.Villagers.Count;
                return killCount;
            }
            else
            {
                return killCount;
            }
        }
    }
}
