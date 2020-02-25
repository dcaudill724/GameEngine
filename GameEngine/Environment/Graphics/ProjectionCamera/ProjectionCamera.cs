using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace GameEngine {
    class ProjectionCamera : Camera {
        private Matrix4x4 projectionMatrix;
        private Frame frame;

        #region Constructors

        public ProjectionCamera () {
            Name = "Projection Camera";
            Position = new Vector3(0, 0, 0);
            Direction = new Vector3(1, 0, 0);
            HorizontalFOV = 70 * ((float)Math.PI / 180);
            VerticalFOV = 70 * ((float)Math.PI / 180);
            sensitivity = 1;
            AngleFromZ = (float)Math.PI / 2;
            FrameHeight = 1080;
            FrameWidth = 1920;
        }

        public ProjectionCamera (string Name, Vector3 Position, Vector3 Direction, float viewWidth, float viewHeight, float sensitivity, int horizontalRes, int verticalRes) {
            this.Name = Name;
            this.Position = Position;
            this.Direction = Direction;
            HorizontalFOV = viewWidth;
            VerticalFOV = viewHeight;
            this.sensitivity = sensitivity;
            AngleFromZ = (float)Math.PI / 2;
            FrameWidth = horizontalRes;
            FrameHeight = verticalRes;

            projectionMatrix = Matrix4x4.CreatePerspectiveFieldOfView((float)(Math.PI / 3), FrameWidth / FrameHeight, 0.1f, 1000.0f);

            frame = new Frame((int)FrameWidth, (int)FrameHeight);
        }

        #endregion

        public override Frame GetFrame () {
            frame.Clear();

            Vector3 lightDirection = Vector3.Normalize(new Vector3(-0.75f, -1f, -0.5f));

            //Get all the triangles that can be seen by the camera projected to view space
            
            List<GraphicsTriangle> trianglesToRaster = projectVisibleTriangles();

            //Loop through all of the projected and clipped triangles
            foreach (GraphicsTriangle tri in trianglesToRaster) {
                //obtain the brightness value by evaluating the the dot product between the normal of the triangle's surface
                //and the direction of the light
                float brightness = Vector3.Dot(tri.Normal, lightDirection);
                if (brightness < 0) {
                    brightness = 0;
                }

                //converts the triangle in 3D view space into a normalized (x and y between -1 and 1) 2D screen space
                GraphicsTriangle nearPlaneClipped = ConvertToScreenSpace(tri.Copy(), FrameWidth, FrameHeight);

                //stores the triangles to clipped against the edges of the screen, so we put in the original to be clipped by the first edge
                //The size of this will change as the triangles in this list get clipped by the edges
                List<GraphicsTriangle> clipQueue = new List<GraphicsTriangle>() { nearPlaneClipped };
                
                //loop through the four edges of screen
                for (int j = 0; j < 4; ++j) {

                    //holds the triangles that the triangles in clipQueue become as they are clipped by the current clipping edge
                    List<GraphicsTriangle> newTris = new List<GraphicsTriangle>();

                    //loop through all of the triangles in clipQueue in order to clip them be the current clipping edge
                    foreach (GraphicsTriangle current in clipQueue) {

                        //to select the plane we are clipping based on the loop interation
                        switch (j) {
                            case 0:
                                //clip against the top edge of the screen
                                newTris.AddRange(ClipTriangleAgainstPlane(new Vector3(0, 0, 0), new Vector3(0, -1, 0), current));
                                break;
                            case 1:
                                //clip against left edge of the screen
                                newTris.AddRange(ClipTriangleAgainstPlane(new Vector3(0, 0, 0), new Vector3(-1, 0, 0), current));
                                break;
                            case 2:
                                //clip against bottom edge of the screen
                                newTris.AddRange(ClipTriangleAgainstPlane(new Vector3(0, -FrameHeight, 0), new Vector3(0, 1, 0), current));
                                break;
                            case 3:
                                //clip against right edge of the screen
                                newTris.AddRange(ClipTriangleAgainstPlane(new Vector3(-FrameWidth, 0, 0), new Vector3(1, 0, 0), current));
                                break;
                        }
                    }

                    //once all of the triangles in clipQueue have been clipped by the edge, newTris will be populated by said clipped triangles
                    //But all of these clipped triangles also need to be clipped by the remaining edges so we must set the clipQueue to newTris
                    clipQueue.Clear(); //set it to a new list
                    clipQueue.AddRange(newTris); //add the clipped triangles

                }

                //once the loop of clipping the edges has completed, clipQueue should be full of the triangles that need to be rastered

                //Draw them all!
                foreach (GraphicsTriangle rasterReady in clipQueue) {
                    frame.FillTriangle(rasterReady, rasterReady.Color, brightness);
                    frame.DrawTriangle(rasterReady, Color.White, 2);
                }
            }

            return frame;
        }

        private List<GraphicsTriangle> projectVisibleTriangles() {
            //create a look at matrix to transfrom the environment objects from world space to view space
            Matrix4x4 viewMatrix = Matrix4x4.CreateLookAt(Position, Position + Direction, new Vector3(0, 1, 0));

            List<GraphicsTriangle> trianglesToRaster = new List<GraphicsTriangle>();

            //loops through each object in the environment and if any triangle of the object can be seen, it gets projected
            //to view space and clips them against the near plane (so objects behind the camera aren't rendered)
            foreach (EnvironmentObject e in Environment.EnvironmentObjects) {
                List<GraphicsTriangle> triangles = e.Mesh.GraphicsTriangles;
                for (int i = 0; i < triangles.Count; ++i) {
                    GraphicsTriangle t = triangles[i]; //Current triangle

                    //Creates vector from the camera position to the triangle, if the dot product is less than 0 then the camera 
                    //can see the triangle so the projection and clipping can be done
                    if (GraphicsVector3.Dot(t.Normal, t.Points[0] - Position) < 0.0f) {
                        GraphicsTriangle projected = t.Copy();
                        //Convert from world space to view space (Still 3D)
                        projected.TransformMatrix4x4(viewMatrix);

                        //Clip the triangle against the near plane while adding it to the list of triangles to raster
                        trianglesToRaster.AddRange(ClipTriangleAgainstPlane(new Vector3(0f, 0f, 0.1f), new Vector3(0f, 0f, 1f), projected));
                    }
                }
            }

            return trianglesToRaster;
        }

        private GraphicsTriangle ConvertToScreenSpace (GraphicsTriangle triangle, float frameWidth, float frameHeight) {
            GraphicsVector3[] newPoints = new GraphicsVector3[3];
            for (int i = 0; i < 3; ++i) {
                GraphicsVector3 newPoint = GraphicsVector3.Transform(triangle.Points[i], projectionMatrix);
                newPoint.Value /= newPoint.W;
                newPoint.Value.X += 1.0f;
                newPoint.Value.Y += 1.0f;
                newPoint.Value.X *= (0.5f * frameWidth);
                newPoint.Value.Y *= (0.5f * frameHeight);
                newPoints[i] = newPoint;
            }
            return new GraphicsTriangle(newPoints, triangle.TexturePoints, triangle.Normal, triangle.Color);
        }

        #region Clipping Functions

        private GraphicsVector3 LinePlaneIntersection (Vector3 planePosition, Vector3 planeNormal, GraphicsVector3 lineStart, GraphicsVector3 lineEnd, out float t) {
            planeNormal = Vector3.Normalize(planeNormal);
            float planeDot = Vector3.Dot(planeNormal, planePosition);
            float ad = Vector3.Dot(lineStart.Value, planeNormal);
            float bd = Vector3.Dot(lineEnd.Value, planeNormal);
            t = (-planeDot - ad) / (bd - ad);
            Vector3 lineToIntersect = (lineEnd.Value - lineStart.Value) * t;
            return new GraphicsVector3(lineStart.Value + lineToIntersect);
        }

        private GraphicsTriangle[] ClipTriangleAgainstPlane (Vector3 planePosition, Vector3 planeNormal, GraphicsTriangle triangle) {
            planeNormal = Vector3.Normalize(planeNormal);

            List<GraphicsVector3> insidePoints = new List<GraphicsVector3>();
            List<GraphicsVector3> outsidePoints = new List<GraphicsVector3>();

            List<TextureVector> insideTexturePoints = new List<TextureVector>();
            List<TextureVector> outsideTexturePoints = new List<TextureVector>();

            float[] distances = new float[3];
            for (int i = 0; i < 3; ++i) {
                distances[i] = GetShortestDistanceToPlane(triangle.Points[i], planePosition, planeNormal);
            }

            for (int i = 0; i < 3; ++i) {
                if (distances[i] >= 0) {
                    insidePoints.Add(triangle.Points[i]);
                    insideTexturePoints.Add(triangle.TexturePoints[i]);
                } else {
                    outsidePoints.Add(triangle.Points[i]);
                    outsideTexturePoints.Add(triangle.TexturePoints[i]);
                }
            }

            if (insidePoints.Count == 0) {
                return new GraphicsTriangle[] { };
            }

            if (insidePoints.Count == 3) {
                return new GraphicsTriangle[] { triangle };
            }

            if (insidePoints.Count == 1 && outsidePoints.Count == 2) {
                GraphicsVector3 p1 = insidePoints[0];
                TextureVector tp1 = insideTexturePoints[0];

                float t;

                GraphicsVector3 p2 = LinePlaneIntersection(planePosition, planeNormal, p1, outsidePoints[0], out t);
                TextureVector tp2 = clipTextureVector(insideTexturePoints[0], outsideTexturePoints[0], t);

                GraphicsVector3 p3 = LinePlaneIntersection(planePosition, planeNormal, p1, outsidePoints[1], out t);
                TextureVector tp3 = clipTextureVector(insideTexturePoints[0], outsideTexturePoints[1], t);

                return new GraphicsTriangle[] { new GraphicsTriangle(p1, p2, p3, tp1, tp2, tp3, triangle.Normal, triangle.Color) };
            }

            if (insidePoints.Count == 2 && outsidePoints.Count == 1) {
                float t;

                GraphicsVector3 t1p1 = insidePoints[0];
                GraphicsVector3 t1p2 = insidePoints[1];
                GraphicsVector3 t1p3 = LinePlaneIntersection(planePosition, planeNormal, t1p1, outsidePoints[0], out t);

                TextureVector t1tp1 = insideTexturePoints[0];
                TextureVector t1tp2 = insideTexturePoints[1];
                TextureVector t1tp3 = clipTextureVector(t1tp1, outsideTexturePoints[0], t);

                GraphicsVector3 t2p1 = insidePoints[1];
                GraphicsVector3 t2p2 = t1p3;
                GraphicsVector3 t2p3 = LinePlaneIntersection(planePosition, planeNormal, t2p1, outsidePoints[0], out t);

                TextureVector t2tp1 = insideTexturePoints[1];
                TextureVector t2tp2 = t1tp3;
                TextureVector t2tp3 = clipTextureVector(t2tp1, outsideTexturePoints[0], t);

                return new GraphicsTriangle[] {
                    new GraphicsTriangle(t1p1, t1p3, t1p2, t1tp1, t1tp2, t1tp3, triangle.Normal, triangle.Color),
                    new GraphicsTriangle(t2p1, t2p2, t2p3, t2tp1, t2tp2, t2tp3, triangle.Normal, triangle.Color)
                };
            }
            return null; //To satisfy the compliers :(
        }

        private float GetShortestDistanceToPlane(GraphicsVector3 point, Vector3 planePosition, Vector3 planeNormal) {
            return planeNormal.X * -point.Value.X + planeNormal.Y * -point.Value.Y + planeNormal.Z * -point.Value.Z - Vector3.Dot(planeNormal, planePosition);
        }

        private TextureVector clipTextureVector (TextureVector insidePoint, TextureVector outsidePoint, float t) {
            return new TextureVector(t * (outsidePoint.U - insidePoint.U) + insidePoint.U, t * (outsidePoint.V - insidePoint.V) + insidePoint.V, t * (outsidePoint.W - insidePoint.W) + insidePoint.W);
        }

        #endregion

        #region Update Functions

        public override void Update (List<EnvironmentObject> objects, int mouseXDif, int mouseYDif, Vector3 direction) {
            Position += direction;
            if (mouseXDif != 0 || mouseYDif != 0) {
                updateDirection(-mouseXDif, mouseYDif, direction);
            }
        }

        private void updateDirection (int mouseXDif, int mouseYDif, Vector3 direction) {
            float yAxisAngle = (mouseXDif / 100f) * sensitivity;
            float xAxisAngle = (mouseYDif / 100f) * -sensitivity;
            Direction = VectorMath.RotateVector3Y(Direction, yAxisAngle);
            Direction = VectorMath.TurretRotateVector3X(Direction, xAxisAngle, AngleFromZ);
            AngleFromZ += xAxisAngle;
        }

        #endregion
        public override void Dispose () {
            Delete();
        }
    }
}