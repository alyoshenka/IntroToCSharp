using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingErrors
{

    struct Vector2
    {
        public float x, y;
        public Vector2(float _x, float _y) { x = _x; y = _y; }
        public static bool operator ==(Vector2 v1, Vector2 v2)
        {
            float tolerance = float.Epsilon * 100;
            return (Math.Abs(v1.x - v2.x) <= tolerance && Math.Abs(v1.y - v2.y) <= tolerance);
        }
        public static bool operator !=(Vector2 v1, Vector2 v2) { return !(v1 == v2); }
    }

    struct Polygon2D : IEquatable<Polygon2D>
    {
        public Vector2[] vertices;
        public float vertexCount { get { return vertices.Length; } }
        // value equality
        public static bool operator ==(Polygon2D p1, Polygon2D p2)
        {
            if (p1.vertexCount != p2.vertexCount) { return false; }
            for (int i = 0; i < p1.vertices.Length; i++)
            {
                if (p1.vertices[i] != p2.vertices[i]) { return false; }
            }
            return true;
        }
        // value equality
        public static bool operator !=(Polygon2D p1, Polygon2D p2) { return !(p1 == p2); }
        public override bool Equals(object obj)
        {
            return this == (Polygon2D)obj;
        }
        public bool Equals(Polygon2D p2) { return this == p2; }
        public override int GetHashCode()
        {
            int hash = 0;
            for (int i = 0; i < vertexCount; i++)
            {
                hash += (int)(vertices[i].x*1000) ^ (int)(vertices[i].y*1000);
            }
            return hash;
        }
    }

    public struct PlayerStateEg : IComparable<PlayerStateEg>
    {
        public string name;
        public int score;
        public PlayerStateEg(string _n, int _s) { name = _n; score = _s; }

        public static bool operator <(PlayerStateEg ps1, PlayerStateEg ps2) { return ps1.score < ps2.score; }
        public static bool operator >(PlayerStateEg ps1, PlayerStateEg ps2) { return ps1.score > ps2.score; }
        public static bool operator <=(PlayerStateEg ps1, PlayerStateEg ps2) { return ps1.score <= ps2.score; }
        public static bool operator >=(PlayerStateEg ps1, PlayerStateEg ps2) { return ps1.score >= ps2.score; }
        public static bool operator ==(PlayerStateEg ps1, PlayerStateEg ps2) { return ps1.score == ps2.score; }
        public static bool operator !=(PlayerStateEg ps1, PlayerStateEg ps2) { return ps1.score != ps2.score; }
        public int CompareTo(PlayerStateEg ps2)
        {
            if (this < ps2) { return -1; }
            if (this > ps2) { return 1; }
            return 0;
        }
    }
}
