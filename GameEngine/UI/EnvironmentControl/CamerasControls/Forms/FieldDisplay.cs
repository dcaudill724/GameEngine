using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace GameEngine {
    public partial class FieldDisplay : UserControl {

        public FieldDisplay (FieldInfo fieldInfo, Camera c, Control parent) {
            InitializeComponent();
            FieldNameLabel.Text = fieldInfo.Name + ":";
            FieldValueTextBox.Text = Convert.ToString(fieldInfo.GetValue(c));
            Parent = parent;
            Width = Parent.Width;
        }
    }
}
