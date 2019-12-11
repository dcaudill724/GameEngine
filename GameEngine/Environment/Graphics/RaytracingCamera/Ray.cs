using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;

namespace GameEngine {
    public class Ray {
        public Vector3 Position;
        public Vector3 Direction;
        public Color RayColor;

        public Ray (Vector3 position, Vector3 direction) {
            Position = position;
            Direction = direction;
            RayColor = Color.Black;
        }

        public Ray (Vector3 position, Vector3 direction, Color rayColor) {
            Position = position;
            Direction = direction;
            RayColor = rayColor;
        }

        public void RotateX (float angle) {
            float y = (float)(Direction.Y * Math.Cos(angle) - Direction.Z * Math.Sin(angle));
            float z = (float)(Direction.Y * Math.Sin(angle) + Direction.Z * Math.Cos(angle));
            Direction = new Vector3(Direction.X, y, z);
        }

        public void RotateY (float angle) {
            float x = (float)(Direction.X * Math.Cos(angle) + Direction.Z * Math.Sin(angle));
            float z = (float)(-Direction.X * Math.Sin(angle) + Direction.Z * Math.Cos(angle));
            Direction = new Vector3(x, Direction.Y, z);
        }

        public void RotateZ (float angle) {
            float x = (float)(Direction.X * Math.Cos(angle) - Direction.Y * Math.Sin(angle));
            float y = (float)(Direction.X * Math.Sin(angle) + Direction.Y * Math.Cos(angle));
            Direction = new Vector3(x, y, Direction.Z);
        }

        public void TurretRotateX(float angle) {
            float angleFromZ = (float)Math.Acos(Vector3.Dot(Direction, new Vector3(0, 0, 1)));
            RotateY(-angleFromZ);
            RotateX(angle);
            RotateY(angleFromZ);
        }
    }
}
