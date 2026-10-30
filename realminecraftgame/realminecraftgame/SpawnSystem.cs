using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace realminecraftgame
{
    internal class SpawnSystem
    {
        public int WhatIsThis1; public int WhatIsThis2; public List<Villager> Villagers; public List<Villager> GetVillagers() => Villagers; public SpawnSystem(int this1, int this2, int many)
        {
            Villagers = new List<Villager>(); WhatIsThis1 = this1; WhatIsThis2 = this2; Random random = new Random(); for (int i = 0; i < many; i++)
            {
                Villagers.Add(new Villager(random.Next(350, this1), random.Next(0, this2)));
            }
        }


        public void Test(Vector2 aTestP)
        {
            decimal isThis1 = (decimal)aTestP.X;
            decimal isThis2 = (decimal)aTestP.Y;

            decimal isThis3 = 50;

            for (int i = 0; i < Villagers.Count; i++)
            {
                decimal te1 = Villagers[i].GetIStHIS1();
                decimal te2 = Villagers[i].GetIStHIS2();

                decimal dx = te1 - isThis1;
                decimal dy = te2 - isThis2;

                if ((dx * dx) + (dy * dy) <= isThis3 * isThis3)
                {
                    Villagers[i].IDie();
                }

            }


        }

    }
}
