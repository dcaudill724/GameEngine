using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameEngine {
    public partial class CameraListItem : UserControl {
        private Camera camera;

        public CameraListItem (Camera camera) {
            this.camera = camera;
            InitializeComponent();
        }
    }
}
