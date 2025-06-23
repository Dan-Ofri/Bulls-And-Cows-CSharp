using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Ex05
{
    public partial class ColorPickerForm : Form
    {
        public eColor SelectedEnumColor { get; private set; }
        public Color SelectedColor { get; private set; }

        private Dictionary<Button, eColor> r_ButtonToColorMap = new Dictionary<Button, eColor>();

        public static Dictionary<eColor, Color> EnumToColorMap { get; private set; }

        public List<eColor> AvailableColors
        {
            get { return r_ButtonToColorMap.Values.ToList(); }
        }

        public ColorPickerForm()
        {
            InitializeComponent();
            mapButtonsToColors();
            hookButtonEvents();
        }

        private void mapButtonsToColors()
        {
            r_ButtonToColorMap = new Dictionary<Button, eColor>
            {
                { btnRed, eColor.Red },
                { btnBlue, eColor.Blue },
                { btnGreen, eColor.Green },
                { btnYellow, eColor.Yellow },
                { btnOrange, eColor.Orange },
                { btnPurple, eColor.Purple },
                { btnLightBlue, eColor.LightBlue },
                { btnPink, eColor.Pink }
            };

            EnumToColorMap = r_ButtonToColorMap.ToDictionary(pair => pair.Value, pair => pair.Key.BackColor);
        }

        private void hookButtonEvents()
        {
            foreach (Button btn in r_ButtonToColorMap.Keys)
            {
                btn.Click += colorButton_Click;
            }
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (r_ButtonToColorMap.TryGetValue(clickedButton, out eColor chosenColor))
            {
                SelectedEnumColor = chosenColor;
                SelectedColor = clickedButton.BackColor;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
