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
        public string name;
        public Vector2 pos;
        public Texture2D texture;
        public float speed;
        public Vector2 velocity;
        public Vector2 ChunkPos
        {
            get
            {
                return new Vector2(Chunk.GetChunkPos(pos).Item1, Chunk.GetChunkPos(pos).Item2);
            }
        }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)pos.X, (int)pos.Y, texture.Width, texture.Height);
            }
        }
        public Basic(string path, Vector2 pos, string name)
        {
            this.pos = pos;
            texture = Globals.content.Load<Texture2D>(path);
            this.name = name;
        }
        public virtual void Update(GameTime gameTime, List<Basic> entities)
        {

        }

        public virtual void Draw()
        {
            if (texture != null)
                Globals.spriteBatch.Draw(texture, pos, Color.White);
        }

        protected bool isTouchingLeft(Basic entity)
        {
            return Rectangle.Right + velocity.X > entity.Rectangle.Left &&
                   Rectangle.Left < entity.Rectangle.Left &&
                   Rectangle.Bottom > entity.Rectangle.Top &&
                   Rectangle.Top < entity.Rectangle.Bottom;
        }

        protected bool IsTouchingRight(Basic entity)
        {
            return Rectangle.Left + velocity.X < entity.Rectangle.Right &&
                   Rectangle.Right > entity.Rectangle.Right &&
                   Rectangle.Bottom > entity.Rectangle.Top &&
                   Rectangle.Top < entity.Rectangle.Bottom;
        }

        protected bool IsTouchingTop(Basic entity)
        {
            return Rectangle.Bottom + velocity.Y > entity.Rectangle.Top &&
                   Rectangle.Top < entity.Rectangle.Top &&
                   Rectangle.Right > entity.Rectangle.Left &&
                   Rectangle.Left < entity.Rectangle.Right;
        }

        protected bool IsTouchingBottom(Basic entity)
        {
            return Rectangle.Top + velocity.Y < entity.Rectangle.Bottom &&
                   Rectangle.Bottom > entity.Rectangle.Bottom &&
                   Rectangle.Right > entity.Rectangle.Left &&
                   Rectangle.Left < entity.Rectangle.Right;
        }

        protected void CheckCollisions(List<Basic> enities)
        {
            foreach (var entity in enities)
            {
                if (entity == this)
                    continue;
                if ((velocity.X > 0 && this.isTouchingLeft(entity)) ||
                    (velocity.X < 0 && this.IsTouchingRight(entity)))
                    velocity.X = 0;

                if ((velocity.Y > 0 && this.IsTouchingTop(entity)) ||
                    (velocity.Y < 0 && this.IsTouchingBottom(entity)))
                    velocity.Y = 0;
            }
        }
        protected void Move()
        {
            if(!(pos.X + velocity.X >= World.Size.X || pos.X + velocity.X <= 0))
                pos.X += velocity.X;
            if(!(pos.Y + velocity.Y >= World.Size.Y || pos.Y + velocity.Y <= 0))
                pos.Y += velocity.Y;
            velocity = Vector2.Zero;
        }
    }
}
