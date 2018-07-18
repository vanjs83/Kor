using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class Master : Form
    {
        public Master()
        {
            InitializeComponent();
        }

        private void openHotel(object sender, EventArgs e)
        {
            Hotel hotel = new Hotel();
            this.Hide();
            hotel.Show();
           
        }

        private void openSobe(object sender, EventArgs e)
        {
            Sobe sobe = new Sobe();
            this.Hide();
            sobe.Show();
            
        }

        private void openGosti(object sender, EventArgs e)
        {
            Gosti gosti = new Gosti();
            this.Hide();
            gosti.Show();
          
        }
    }
}
