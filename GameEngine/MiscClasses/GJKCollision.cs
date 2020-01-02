using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace GameEngine {
    static class GJKCollision {
        private static List<Vector3> verticies;
        private static Vector3 direction;

        public static bool CheckCollision (RayPyramid shape1, EnvironmentObject shape2) {
            verticies = new List<Vector3>();
            direction = shape2.GetCenter() - shape1.GetCenter();

            int result = 0;
            int count = 0;
            while (result == 0 && count < 100) {
                result = evolveSimplex(shape1, shape2);
                count++;
            }

            return result > 0;
        }

        private static Vector3 calculateSupport(Vector3 direction, RayPyramid shape1, EnvironmentObject shape2) {
            Vector3 newVertex = shape1.GetSupportingPoint(direction);
            newVertex -= shape2.GetSupportPoint(-1 * direction);
            return newVertex;
        }

        private static bool addSupport(Vector3 direction, RayPyramid shape1, EnvironmentObject shape2) {
            Vector3 newVertex = calculateSupport(direction, shape1, shape2);
            verticies.Add(newVertex);
            return Vector3.Dot(direction, newVertex) >= 0;
        }

        private static int evolveSimplex(RayPyramid shape1, EnvironmentObject shape2) {
            switch (verticies.Count) {
                case 0:
                    direction = shape2.GetCenter() - shape1.GetCenter();
                    break;
                case 1:
                    direction *= -1;
                    break;
                case 2:
                    //ab is line segment of the two points already gotten
                    Vector3 ab = verticies[1] - verticies[0];
                    //a0 is from the first point to the origin
                    Vector3 a0 = verticies[0] * -1;

                    Vector3 temp = Vector3.Cross(ab, a0);
                    //Vector3 temp = Vector3.Cross(a0, ab);

                    direction = Vector3.Cross(temp, ab);
                    //direction = Vector3.Cross(ab, temp);


                    break;
                case 3:
                    Vector3 ac = verticies[2] - verticies[0];
                    ab = verticies[1] - verticies[0];

                    direction = Vector3.Cross(ac, ab);
                    

                    a0 = verticies[0] * -1;
                    if (Vector3.Dot(direction, a0) < 0) {
                        direction *= -1;
                    }
                    break;
                case 4:
                    Vector3 da = verticies[3] - verticies[0];
                    Vector3 db = verticies[3] - verticies[1];
                    Vector3 dc = verticies[3] - verticies[2];

                    Vector3 d0 = verticies[3] * -1;

                    Vector3 abdNorm = Vector3.Cross(da, db);
                    Vector3 bcdNorm = Vector3.Cross(db, dc);
                    Vector3 cadNorm = Vector3.Cross(dc, da);

                    if (Vector3.Dot(abdNorm, d0) > 0) {
                        verticies.Remove(verticies[2]);
                        direction = abdNorm;
                    } else if (Vector3.Dot(bcdNorm, d0) > 0) {
                        verticies.Remove(verticies[0]);
                        direction = bcdNorm;
                    } else if (Vector3.Dot(cadNorm, d0) > 0) {
                        verticies.Remove(verticies[1]);
                        direction = cadNorm;
                    } else {
                        return 1;
                    }

                    break;
            }

            return addSupport(direction, shape1, shape2) ? 0 : -1;
        }
    }
}
