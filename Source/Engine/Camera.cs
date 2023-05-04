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
    public class Camera
    {
        public Matrix Transform { get; private set; }

        public void Follow(Player target)
        {
            var offset = Matrix.CreateTranslation(
                Main.ScreenWidth / 2,
                Main.ScreenHeight / 2,
                0);

            var position = Matrix.CreateTranslation(
                -target.pos.X - (target.Rectangle.Width / 2),
                -target.pos.Y - (target.Rectangle.Height / 2),
                0);

            Transform = position * offset;
        }
    }
}
