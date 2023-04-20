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
    public class Basic
    {
        public Vector2 pos;
        public Texture2D texture;
        public Rectangle rectangle;
        public Basic(string path, Vector2 pos)
        {
            this.pos = pos;

            texture = Globals.content.Load<Texture2D>(path);

            rectangle = new Rectangle((int)pos.X, (int)pos.Y, texture.Width, texture.Height);
        }
        public virtual void Update()
        {
            rectangle = new Rectangle((int)pos.X, (int)pos.Y, texture.Width, texture.Height);
        }

        public virtual void Draw()
        {
            if (texture != null)
                Globals.spriteBatch.Draw(texture, pos, Color.White);
        }
    }
}
