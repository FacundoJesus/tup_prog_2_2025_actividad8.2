using Ejercicio1.Models;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<IExportable> multas = new List<IExportable>();

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            lsbResultado.Items.Clear();
            foreach (IExportable m in multas)
            {
                lsbResultado.Items.Add(m);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

        }
    }
}
