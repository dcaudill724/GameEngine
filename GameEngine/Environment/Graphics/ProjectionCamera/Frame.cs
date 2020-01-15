using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine {
    class Frame {
        public Bitmap Image;
        public Graphics Graphics;
        public bool Clean;
        public bool Locked;

        public Frame(float width, float height) {
            Image = new Bitmap((int)width, (int)height);
            Graphics = Graphics.FromImage(Image);
            Clean = true;
            Locked = false;
        }

        public void CleanImage() {
            Locked = true;
            if (!Clean) {
                Graphics.Clear(Color.Black);
                Clean = true;
            }
            Locked = false;
        }
    }
}
