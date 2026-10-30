using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace realminecraftgame
{
    public class Villager
    {
        public decimal IStHIS1 = 0; public decimal IStHIS2 = 0; public bool IsAlive = true; Vector2 NO2; public decimal GetIStHIS1() => IStHIS1; public decimal GetIStHIS2() => IStHIS2; public Vector2 GetVector2Position() => NO2; public bool GetIsAlive() => this.IsAlive; public void IDie() => IsAlive = false; public Villager(decimal toThis1, decimal toTHIS2)
        {
            this.IStHIS1 = toThis1;
            this.IStHIS2 = toTHIS2;

            NO2.X = (float)toThis1;
            NO2.Y = (float)toTHIS2;
            IsAlive = true;
        }
    }
}
