﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Input;

namespace GameEngine {
    class Cube : EnvironmentObject {
        private Color c;

        public Cube(Vector3 position, Vector3 size, Color c) {
            AddMessageAction(MessageType.KeyDown, (object[] parameters) => {
                Console.WriteLine("HUH");
                Console.WriteLine((Key)parameters[0]);
            });

            Position = position;

            Vector3[] points = {
                new Vector3(position.X + size.X / 2, position.Y + size.Y / 2, position.Z + size.Z / 2),
                new Vector3(position.X + size.X / 2, position.Y + size.Y / 2, position.Z - size.Z / 2),
                new Vector3(position.X + size.X / 2, position.Y - size.Y / 2, position.Z + size.Z / 2),
                new Vector3(position.X + size.X / 2, position.Y - size.Y / 2, position.Z - size.Z / 2),
                new Vector3(position.X - size.X / 2, position.Y + size.Y / 2, position.Z + size.Z / 2),
                new Vector3(position.X - size.X / 2, position.Y + size.Y / 2, position.Z - size.Z / 2),
                new Vector3(position.X - size.X / 2, position.Y - size.Y / 2, position.Z + size.Z / 2),
                new Vector3(position.X - size.X / 2, position.Y - size.Y / 2, position.Z - size.Z / 2)
            };

            Vector3[,] faces = {
                { points[1], points[0], points[2], points[3] }, //right 
                { points[4], points[0], points[1], points[5] }, //bottom
                { points[0], points[4], points[6], points[2] }, //back 
                { points[4], points[5], points[7], points[6] }, //left 
                { points[6], points[7], points[3], points[2] }, //top
                { points[5], points[1], points[3], points[7] }  //front
            };

            List<Triangle> triangles = new List<Triangle>();

            for (int i = 0; i < 6; ++i) {
                triangles.Add(new Triangle(faces[i, 0], faces[i, 1], faces[i, 3], c));
                triangles.Add(new Triangle(faces[i, 3], faces[i, 1], faces[i, 2], c));
            }

            Mesh = new Mesh(triangles);

            this.c = c;
        }

        public override void Update(Vector3 direction) {
            Position += direction;
            Mesh.Update(direction);
            return;
        }

        public override Vector3 GetCenter () {
            return Position;
        }

        public override Color GetColor () {
            return c;
        }

        public override Vector3 GetSupportPoint (Vector3 direction) {
            //throw new NotImplementedException();
            return new Vector3();
        }

        public override float RayCollision (Ray r) {
            //throw new NotImplementedException();
            return 0;
        }
    }
}
