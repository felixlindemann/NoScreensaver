using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoScreenSaver
{
    public partial class FormMausMock : Form
    {
        public FormMausMock()
        {
            InitializeComponent();
            button1_Click(null, null);
        }

        /// <summary>
        /// Initial Direction go up
        /// </summary>
        private EDirection nextDirection = EDirection.Up;


        private void button1_Click(object sender, EventArgs e)
        {
            if (this.timer1.Enabled)
            {
                this.timer1.Enabled = false;
                this.buttonStartStop.Text = "Start Mouse-Move-Fake";

            }
            else
            {
                this.timer1.Enabled = true;
                this.buttonStartStop.Text = "Stop Mouse-Move-Fake";
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point newPosition = new Point(20, 20);
            try
            {
                var position = System.Windows.Forms.Cursor.Position;
                switch (this.nextDirection)
                {
                    case EDirection.Up:
                        newPosition = new Point(position.X, position.Y - 1);
                        this.nextDirection = EDirection.Left;
                        break;
                    case EDirection.Left:
                        newPosition = new Point(position.X - 1, position.Y); this.nextDirection = EDirection.Down;
                        break;
                    case EDirection.Down:
                        newPosition = new Point(position.X, position.Y + 1); this.nextDirection = EDirection.Right;
                        break;
                    case EDirection.Right:
                    default:
                        newPosition = new Point(position.X + 1, position.Y); this.nextDirection = EDirection.Up;
                        break;
                }

            }
            catch (Exception)
            {

            }
            finally
            {
                try
                {
                    System.Windows.Forms.Cursor.Position = newPosition;
                }
                catch (Exception)
                {

                }
            }

        }

        private void FormMausMock_Load(object sender, EventArgs e)
        {

        }
    }

}
