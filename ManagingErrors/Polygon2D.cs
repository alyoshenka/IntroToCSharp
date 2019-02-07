using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingErrors
{

    struct Vector2
    {
        float x, y;
        public static bool operator==(Vector2 v1, Vector2 v2)
        {
            float tolerance = 0.000000001f; // make better val
            return (Math.Abs(v1.x - v2.x) <= tolerance && Math.Abs(v1.y - v2.y) <= tolerance);
        }
        public static bool operator!=(Vector2 v1, Vector2 v2) { return !(v1 == v2); }
    }
    struct Polygon2D
    {
        public Vector2[] vertices;
        public float vertexCount { get { return vertices.Length; } }
        // value equality
        public static bool operator==(Polygon2D p1, Polygon2D p2)
        {
            if(p1.vertexCount != p2.vertexCount) { return false; }
            for(int i = 0; i < p1.vertices.Length; i++)
            {
                if(p1.vertices[i] != p2.vertices[i]) { return false; }
            }
            return true;
        }
        // value equality
        public static bool operator!= (Polygon2D p1, Polygon2D p2) { return !(p1 == p2); }
    }
}
