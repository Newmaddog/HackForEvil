using System;
using System.Collections.Generic;
using System.Text;

namespace realminecraftgame
{
    internal class SpawnSystem
    {
        public int WhatIsThis1;
        public int WhatIsThis2;

        public List<Villager> Villagers;

        public List<Villager> GetVillagers() => Villagers;

        public SpawnSystem(int this1, int this2, int many)
        {
            Villagers = new List<Villager>();
            WhatIsThis1 = this1;
            WhatIsThis2 = this2;

            Random random = new Random();

            for (int i = 0; i < many; i++)
            {
                Villagers.Add(new Villager(random.Next(350, this1), random.Next(0, this2)));
            }



        }

    }
}
