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
using System.ComponentModel.DataAnnotations;

namespace GameProject
{
    public class Player : Basic
    {
        public Player(string path, Vector2 pos, float speed) : base(path, pos)
        {
            this.speed = speed;
        }

        public override void Update(GameTime gameTime, List<Basic> enities)
        {
            PlayerMovement();
            CheckCollisions(enities);

            pos += velocity;
            velocity = Vector2.Zero;

            base.Update(gameTime, enities);
        }

        public override void Draw()
        {
            base.Draw();
        }

        private void PlayerMovement()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                velocity.X = -speed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                velocity.X = speed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                velocity.Y = -speed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                velocity.Y = speed;
            }
        }
        private void CheckCollisions(List<Basic> enities)
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
    }
}
