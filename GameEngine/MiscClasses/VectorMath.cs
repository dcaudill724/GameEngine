using System;
using System.Numerics;

namespace GameEngine {
    static class VectorMath {

        #region Rotate Functions

        public static Vector3 RotateVector3X (Vector3 vector, float angle) {
            float y = (float)(vector.Y * Math.Cos(angle) - vector.Z * Math.Sin(angle));
            float z = (float)(vector.Y * Math.Sin(angle) + vector.Z * Math.Cos(angle));
            return new Vector3(vector.X, y, z);
        }

        public static Vector3 RotateVector3Y (Vector3 vector, float angle) {
            float x = (float)(vector.X * Math.Cos(angle) + vector.Z * Math.Sin(angle));
            float z = (float)(-vector.X * Math.Sin(angle) + vector.Z * Math.Cos(angle));
            return new Vector3(x, vector.Y, z);
        }

        public static Vector3 RotateVector3Z (Vector3 vector, float angle) {
            float x = (float)(vector.X * Math.Cos(angle) - vector.Y * Math.Sin(angle));
            float y = (float)(vector.X * Math.Sin(angle) + vector.Y * Math.Cos(angle));
            return new Vector3(x, y, vector.Z);
        }

        public static Vector3 TurretRotateVector3X (Vector3 vector, float angle, float angleFromZ) {
            vector = RotateVector3Y(vector, -angleFromZ);
            vector = RotateVector3X(vector, angle);
            vector = RotateVector3Y(vector, angleFromZ);
            return vector;
        }

        #endregion

        #region Matrix Functions

        public static Vector3 MultiplyProjectionMatrix (Vector3 vec, float[,] matrix) {
            Vector3 temp = new Vector3(0, 0, 0);
            temp.X = vec.X * matrix[0, 0] + vec.Y * matrix[1, 0] + vec.Z * matrix[2, 0] + matrix[3, 0];
            temp.Y = vec.X * matrix[0, 1] + vec.Y * matrix[1, 1] + vec.Z * matrix[2, 1] + matrix[3, 1];
            temp.Z = vec.X * matrix[0, 2] + vec.Y * matrix[1, 2] + vec.Z * matrix[2, 2] + matrix[3, 2];
            float w = vec.X * matrix[0, 3] + vec.Y * matrix[1, 3] + vec.Z * matrix[2, 3] + matrix[3, 3];
            //Console.WriteLine(temp.X);
            if (w != 0) {
                temp.X /= w;
                temp.Y /= w;
                temp.Z /= w;
            }

            return temp;
        }

        #endregion
    }
}
