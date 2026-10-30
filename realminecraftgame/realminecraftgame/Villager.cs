using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace realminecraftgame
{
    public class Villager
    {
        public decimal PositionX = 0;
        public decimal PositionY = 0;

        public bool IsAlive = true;
        Vector2 vector2Position;

        public decimal GetPositionX() => PositionX;
        public decimal GetPositionY() => PositionY;

        public Vector2 GetVector2Position() => vector2Position;

        public bool GetIsAlive() => this.IsAlive;
        public void IDie() => IsAlive = false;

        public Villager(decimal positionX, decimal positionY)
        {
            this.PositionX = positionX;
            this.PositionY = positionY;

            vector2Position.X = (float)positionX;
            vector2Position.Y = (float)positionY;
            IsAlive = true;
        }
    }
}
