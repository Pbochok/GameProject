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
    public class Player : Basic
    {
        public int speed = 2;
        public bool isTouchBottom;
        public bool isTouchTop;
        public bool isTouchRight;
        public bool isTouchLeft;

        public Player(string path, Vector2 pos) : base(path, pos)
        {
            isTouchBottom = false;
            isTouchTop = false;
            isTouchRight = false;
            isTouchLeft = false;
        }

        public override void Update()
        {
            PlayerMovement();

            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
        }

        private void PlayerMovement()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A) && !isTouchLeft)
                pos = new Vector2(pos.X - speed, pos.Y);
            if (Keyboard.GetState().IsKeyDown(Keys.D) && !isTouchRight)
                pos = new Vector2(pos.X + speed, pos.Y);
            if (Keyboard.GetState().IsKeyDown(Keys.W) && !isTouchTop)
                pos = new Vector2(pos.X, pos.Y - speed);
            if (Keyboard.GetState().IsKeyDown(Keys.S) && !isTouchBottom)
                pos = new Vector2(pos.X, pos.Y + speed);
        }
    }
}
