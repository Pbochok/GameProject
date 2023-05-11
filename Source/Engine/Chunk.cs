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
    public class Chunk
    {
        public enum State
        {
            Empty,
            Wall
        }
        public static int Size{ get { return 32; } }

        public State state;

        public Vector2 pos;

        public Chunk(Vector2 pos, State state)
        {
            this.pos = pos;
            this.state = state;
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)pos.X, (int)pos.Y, 32, 32);
            }
        }

        public Vector2 ChunkPos
        {
            get
            {
                return new Vector2((int)pos.X / Size, (int)pos.Y / Size);
            }
        }

        public static (int,int) GetChunkPos(Vector2 pos)
        {
            return ((int)pos.X / Size, (int)pos.Y / Size);
        }
    }
}
