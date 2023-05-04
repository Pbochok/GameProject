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
    public class World
    {
        public Player player;
        public List<Basic> entities;
        public static Vector2 WorldSize = new Vector2(1000, 1000);
        public Map map;

        public World()
        {
            entities = new List<Basic>();

            player = new Player("Black2", new Vector2(610, 360), 2);

            entities.Add(player);
            entities.Add(new Wall("White3", new Vector2(400, 370)));
            entities.Add(new Wall("White3", new Vector2(300, 300)));
            entities.Add(new Wall("White3", new Vector2(332, 300)));

            map = new Map(entities, player);
            var enemy = new Enemy("Enemy1", new Vector2(900, 100), 1, map);

            entities.Add(enemy);
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (var entity in entities)
            {
                entity.Update(gameTime,entities);
                if (entity.name == "Player")
                    map.MapTargetUpdate((Player)entity);
            }
        }

        public virtual void Draw()
        {
            foreach (var entiry in entities)
            {
                entiry.Draw();
            }
        }
    }
}
