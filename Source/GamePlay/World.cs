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
        public List<Wall> walls;
        public World()
        {
            player = new Player("Black1", new Vector2(200, 200));

            walls = new List<Wall>();
            walls.Add(new Wall("White2", new Vector2(300, 200)));
        }

        public virtual void Update()
        {
            foreach (var wall in walls)
            {
                wall.Update();
                CheckTouching(wall);
            }
            player.Update();
        }

        public virtual void Draw()
        {
            foreach (var wall in walls)
                wall.Draw();
            player.Draw();
        }

        private void CheckTouching(Wall wall)
        {
            player.isTouchRight = player.rectangle.Right + player.speed > wall.rectangle.Left &&
                player.rectangle.Left < wall.rectangle.Left &&
                player.rectangle.Bottom > wall.rectangle.Top &&
                player.rectangle.Top < wall.rectangle.Bottom;

            player.isTouchLeft = player.rectangle.Left - player.speed < wall.rectangle.Right &&
                player.rectangle.Right > wall.rectangle.Right &&
                player.rectangle.Bottom > wall.rectangle.Top &&
                player.rectangle.Top < wall.rectangle.Bottom;

            player.isTouchBottom = player.rectangle.Bottom + player.speed > wall.rectangle.Top &&
                player.rectangle.Top < wall.rectangle.Top &&
                player.rectangle.Right > wall.rectangle.Left &&
                player.rectangle.Left < wall.rectangle.Right;

            player.isTouchTop = player.rectangle.Top - player.speed < wall.rectangle.Bottom &&
                player.rectangle.Bottom > wall.rectangle.Bottom &&
                player.rectangle.Right > wall.rectangle.Left &&
                player.rectangle.Left < wall.rectangle.Right;
        }
    }
}
