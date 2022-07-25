using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_GUI
{
    public class Player: Element
    {
        public int PosLeft = Field.MiddleOfField + 1;// 11
        public int PosTop = Field.MatrixWidth - 1;

        public int labelX = GameForm.labelPlayer1.Location.X;
        public int labelY = GameForm.labelPlayer1.Location.Y;

        public int Life { get; set; } = 0;

        public static Player first = new Player()
        {
            PosLeft = Field.MiddleOfField + 1,
            PosTop = Field.MatrixWidth - 1,
        };

        public static Player second = new Player()
        {
            PosLeft = Field.MiddleOfField + 1,
            PosTop = Field.MatrixWidth - 1,
        };

        public static Dictionary<int, System.Drawing.Color> color = new Dictionary<int, System.Drawing.Color>()
        {
            {0, System.Drawing.Color.Green },
            {1, System.Drawing.Color.Yellow },
            {2, System.Drawing.Color.Orange },
            {3, System.Drawing.Color.Red }
        };

        public override void Define()
        {

        }
    }
}
