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
        public World()
        {
            player = new Player("Black1", new Vector2(610, 360), 3);
            var enemy = new Enemy("Enemy1", new Vector2(900, 100), 2, player);
            entities = new List<Basic>();
            entities.Add(player);
            entities.Add(enemy);
            entities.Add(new Wall("White1", new Vector2(400, 370)));
            entities.Add(new Wall("White2", new Vector2(300, 300)));
            entities.Add(new Wall("White2", new Vector2(400, 300)));
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (var entity in entities)
            {
                entity.Update(gameTime,entities);
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
