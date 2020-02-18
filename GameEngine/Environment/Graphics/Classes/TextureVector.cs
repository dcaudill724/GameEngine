using System.Numerics;

namespace GameEngine {
   public  class TextureVector {
        private Vector2 vector;
        public float W;

        public float U {
            get { return vector.X; }
            set { vector.X = value; }
        }

        public float V {
            get { return vector.Y; }
            set { vector.Y = value;  }
        }

        public TextureVector (float u, float v) {
            U = u;
            V = v;
            W = 1;
        }

        public TextureVector(float u, float v, float w) {
            U = u;
            V = v;
            W = w;
        }

        public TextureVector (Vector2 vector) {
            this.vector = vector;
            W = 1;
        }

        public TextureVector (Vector2 vector, float w) {
            this.vector = vector;
            W = w;
        }

        public TextureVector (TextureVector original) {
            U = original.U;
            V = original.V;
            W = original.W;
        }

        public TextureVector () {
            vector = new Vector2(0, 0);
            W = 1;
        }
    }
}
