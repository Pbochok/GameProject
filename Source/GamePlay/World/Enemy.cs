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
        private Map map;
        private bool trigerred;
        private Vector2 vectorToTarget;
        private List<Chunk> trackToTarget;

        public Enemy(string path, Vector2 pos, float speed, Map map) : base(path, pos, "Enemy")
        {
            this.speed = speed;
            this.map = map;
        }

        public override void Update(GameTime gameTime, List<Basic> entities)
        {
            EnemyMovement(map.target);
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
            if (Vector2.Distance(target.pos, this.pos) <= 3 * Chunk.Size && !trigerred)
                trigerred = true;
            if (Vector2.Distance(target.pos, this.pos) >= 4 * Chunk.Size && trigerred)
                trigerred = false;
            return trigerred;
        }
        
        private void EnemyMovement(Player target)
        {
            var steps = FindPathToTarget().ToList();
            steps.Reverse();
            var vectors = GetTrack();
            if (IsTrigerred(target))
            {
                for (int i = 0; i < vectors.Count; i++)
                {
                    if (vectors[i].X > 0)
                        velocity.X = speed;
                    if (vectors[i].X < 0)
                        velocity.X = -speed;
                    if (vectors[i].Y > 0)
                        velocity.Y = speed;
                    if (vectors[i].Y < 0)
                        velocity.Y = -speed;
                }
            }
        }

        private SinglyLinkedList<Chunk> FindPathToTarget()
        {
            var track = new Dictionary<Chunk, SinglyLinkedList<Chunk>>();
            track[map.chunkMap[(int)ChunkPos.X, (int)ChunkPos.Y]] = new SinglyLinkedList<Chunk>(map.chunkMap[(int)ChunkPos.X, (int)ChunkPos.Y]);

            var queue = new Queue<SinglyLinkedList<Chunk>>();
            queue.Enqueue(track[map.chunkMap[(int)pos.X / Chunk.Size, (int)pos.Y / Chunk.Size]]);
            while (queue.Count != 0)
            {
                var chunk = queue.Dequeue();
                if (chunk.Value.state == Chunk.State.Wall)
                    continue;
                var nextChunks = GetNextChunks(chunk.Value);
                foreach (var nextChunk in nextChunks)
                {
                    if (track.ContainsKey(nextChunk))
                        continue;
                    track[nextChunk] = new SinglyLinkedList<Chunk>(nextChunk, chunk);
                    queue.Enqueue(track[nextChunk]);
                }
                //if (track.ContainsKey(map.targetChunk))
                //    return track[map.targetChunk];
            }
            return track[map.targetChunk];
        }

        private List<Chunk> GetNextChunks(Chunk currentChunk)
        {
            var list = new List<Chunk>();
            for (var dx = -1; dx <= 1; dx++)
            {
                for (var dy = -1; dy <= 1; dy++)
                {
                    if ((dx != 0 && dy != 0) || (dx == 0 && dy == 0))
                        continue;
                    if (currentChunk.ChunkPos.X + dx == Chunk.GetChunkPos(World.Size).Item1 || currentChunk.ChunkPos.X + dx < 0 ||
                        currentChunk.ChunkPos.Y + dy == Chunk.GetChunkPos(World.Size).Item2 || currentChunk.ChunkPos.Y + dy < 0)
                        continue;
                    list.Add(map.chunkMap[(int)currentChunk.ChunkPos.X + dx, (int)currentChunk.ChunkPos.Y + dy]);
                }
            }
            return list;
        }

        private List<Vector2> GetTrack()
        {
            var track = new List<Vector2>();
            var steps = FindPathToTarget().ToList();
            steps.Reverse();

            for (int i = 1; i < steps.Count; i++)
            {
                track.Add(steps[i].pos - steps[i - 1].pos);
            }
            return track;
        }
    }
}
