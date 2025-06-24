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

        private readonly Dictionary<Button, eColor> r_ButtonToColorMap = new Dictionary<Button, eColor>();

        public static Dictionary<eColor, Color> EnumToColorMap { get; private set; }

        public List<eColor> AvailableColors => r_ButtonToColorMap.Values.ToList();

        public ColorPickerForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Text = "Pick a Color";
            this.TopMost = true;

            mapButtonsToColors();
            hookButtonEvents();
        }

        private void mapButtonsToColors()
        {
            r_ButtonToColorMap.Add(btnRed, eColor.Red);
            r_ButtonToColorMap.Add(btnBlue, eColor.Blue);
            r_ButtonToColorMap.Add(btnGreen, eColor.Green);
            r_ButtonToColorMap.Add(btnYellow, eColor.Yellow);
            r_ButtonToColorMap.Add(btnOrange, eColor.Orange);
            r_ButtonToColorMap.Add(btnPurple, eColor.Purple);
            r_ButtonToColorMap.Add(btnLightBlue, eColor.LightBlue);
            r_ButtonToColorMap.Add(btnPink, eColor.Pink);

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

            if (clickedButton != null && r_ButtonToColorMap.TryGetValue(clickedButton, out eColor chosenColor))
            {
                SelectedEnumColor = chosenColor;
                SelectedColor = clickedButton.BackColor;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}