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
    public class Wall : Basic
    {
        public Wall(string path, Vector2 pos) : base(path, pos, "Wall")
        {
            speed = 0;
        }
        public override void Update(GameTime gameTime, List<Basic> entities)
        {
            base.Update(gameTime, entities);
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
