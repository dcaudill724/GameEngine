using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine {
    class Sphere : EnvironmentObject {
        private Vector3 position;
        private float radius;
        private Color color;

        public Sphere(int x, int y, int z, float radius, Color color) {
            position = new Vector3(x, y, z);
            this.radius = radius;
            this.color = color;
        }
        public Sphere(Vector3 position, float radius, Color color) {
            this.position = position;
            this.radius = radius;
            this.color = color;
        }

        public float RayCollision (Ray r) {
            Vector3 oc = Vector3.Subtract(r.Position, position);
            float a = Vector3.Dot(r.Direction, r.Direction);
            float b = 2.0f * Vector3.Dot(oc, r.Direction);
            float c = Vector3.Dot(oc, oc) - radius * radius;
            float discriminant = b * b - 4 * a * c;
            if (discriminant < 0) {
                return -1.0f;
            } else {
                float numerator = -b - (float)Math.Sqrt(discriminant);
                if (numerator > 0.0) {
                    return numerator / (2.0f * a);
                }
                numerator = -b + (float)Math.Sqrt(discriminant);
                if (numerator > 0.0) {
                    return numerator / (2.0f * a);
                } else {
                    return -1.0f;
                }
            }
        }

        public Color GetColor() {
            return color;
        }
    }
}
