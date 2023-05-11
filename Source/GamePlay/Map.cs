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
    public class Map
    {
        public Chunk[,] chunkMap;
        public Chunk targetChunk;
        public Player target;

        public Map(List<Basic> entities, Player target)
        {
            chunkMap = FillMap(entities);
            var targetChunkPos = Chunk.GetChunkPos(target.pos);
            targetChunk = chunkMap[targetChunkPos.Item1,targetChunkPos.Item2];
            this.target = target;
        }

        public void MapTargetUpdate(Player updTarget)
        {
            targetChunk = chunkMap[(int)updTarget.pos.X / Chunk.Size, (int)updTarget.pos.Y / Chunk.Size];
        }

        public Chunk[,] FillMap(List<Basic> entities)
        {
            var worldSizeInChunks = (int)World.Size.X / Chunk.Size;
            var map = new Chunk[worldSizeInChunks, worldSizeInChunks];

            for (int i = 0; i < worldSizeInChunks; i++)
            {
                for (int j = 0; j < worldSizeInChunks; j++)
                {
                    map[i, j] = new Chunk(new Vector2(i * Chunk.Size, j * Chunk.Size), Chunk.State.Empty);
                }
            }

            foreach (var entity in entities)
            {
                if (entity.name != "Wall")
                    continue;
                map[(int)entity.pos.X / Chunk.Size ,(int)entity.pos.Y / Chunk.Size].state = Chunk.State.Wall;
            }

            return map;
        }
    }
}
