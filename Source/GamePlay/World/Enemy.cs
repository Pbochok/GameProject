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
    public class Enemy : Basic
    {
        private Player target;
        private bool trigerred;
        private Vector2 vectorToTarget;
        public Enemy(string path, Vector2 pos, float speed, Player target) : base(path, pos)
        {
            this.speed = speed;
            this.target = target;
        }

        public override void Update(GameTime gameTime, List<Basic> entities)
        {
            vectorToTarget = target.pos - this.pos;
            EnemyMovement(target);
            CheckCollisions(entities);

            Move();

            base.Update(gameTime, entities);
        }

        public override void Draw()
        {
            base.Draw();
        }

        private bool IsTrigerred(Player target)
        {
            if (Vector2.Distance(target.pos, this.pos) <= 200 && !trigerred)
                trigerred = true;
            if (Vector2.Distance(target.pos, this.pos) >= 300 && trigerred)
                trigerred = false;
            return trigerred;
        }
        
        private void EnemyMovement(Player target)
        {
            if (IsTrigerred(target))
            {
                if (vectorToTarget.X < 0)
                    velocity.X = -speed;
                else
                    velocity.X = speed;

                if (vectorToTarget.Y < 0)
                    velocity.Y = -speed;
                else
                    velocity.Y = speed;
            }
        }
    }
}
