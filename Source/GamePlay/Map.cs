using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GameProject
{
    public enum MapCell
    {
        Empty,
        Wall
    };

    public class Map
    {
        public MapCell[,] map;
        public Player target;

        public Map(List<Basic> entities, Player target)
        {
            map = FillMap(entities);
            this.target = target;
        }

        public void MapTargetUpdate(Player updTarget)
        {
            target = updTarget;
        }

        public MapCell[,] FillMap(List<Basic> entities)
        {
            var map = new MapCell[(int)World.WorldSize.X, (int)World.WorldSize.Y];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = MapCell.Empty;
                }
            }

            foreach (var entity in entities)
            {
                if (entity.name != "Wall")
                    continue;
                for (int i = (int)entity.pos.X; i < entity.Rectangle.Right; i++)
                {
                    for (int j = (int)entity.pos.Y; j < entity.Rectangle.Bottom; j++)
                    {
                        map[i, j] = MapCell.Wall;
                    }
                }
            }
            return map;
        }
    }
}
