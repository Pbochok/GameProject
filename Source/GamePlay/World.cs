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
        public World()
        {
            player = new Player("Black1", new Vector2(200, 200), new Vector2(30, 60));
        }

        public virtual void Update()
        {
            player.Update();
        }

        public virtual void Draw()
        {
            player.Draw();
        }
    }
}
