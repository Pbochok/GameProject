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
        public Vector2 pos, dims, startDrawPos;
        public Texture2D texture;
        public Rectangle rectangle;
        public Basic(string path, Vector2 pos, Vector2 dims)
        {
            this.pos = pos;
            this.dims = dims;

            texture = Globals.content.Load<Texture2D>(path);

            rectangle = new Rectangle((int)pos.X, (int)pos.Y, (int)dims.X, (int)dims.Y);
            startDrawPos = new Vector2(texture.Bounds.Width / 2, texture.Bounds.Height / 2);
        }
        public virtual void Update()
        {

        }

        public virtual void Draw()
        {
            if (texture != null)
                Globals.spriteBatch.Draw(texture, new Rectangle((int)pos.X, (int)pos.Y, (int)dims.X, (int)dims.Y), 
                                         null, Color.White, 0.0f, 
                                         new Vector2(texture.Bounds.Width / 2, texture.Bounds.Height / 2), 
                                         new SpriteEffects(), 0);
        }
    }
}
