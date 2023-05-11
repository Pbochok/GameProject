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
        public static Vector2 Size = new Vector2(800, 800);
        public Map map;

        public World()
        {
            entities = new List<Basic>();

            player = new Player("Black2", new Vector2(320, 352), 2);

            entities.Add(player);

            entities.Add(new Wall("White3", new Vector2(320, 320)));
            entities.Add(new Wall("White3", new Vector2(352, 352)));
            entities.Add(new Wall("White3", new Vector2(352, 288)));

            map = new Map(entities, player);
            var enemy = new Enemy("Enemy2", new Vector2(352, 320), 1, map);

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
