using Ejercicio1.Models;
using Ejercicio1.Models.Exportadores;
using System.Runtime.Intrinsics.X86;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<IExportable> exportables = new List<IExportable>();

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            lsbResultado.Items.Clear();
            foreach (IExportable m in exportables)
            {
                lsbResultado.Items.Add(m);
            }
            //lsbResultado.Items.AddRange(exportables.ToArray());
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            IExportable nuevo = null;

            string patente = tbPatente.Text;
            DateOnly vencimiento = new DateOnly(dateTimePicker.Value.Year, dateTimePicker.Value.Month, dateTimePicker.Value.Day);
            double importe = Convert.ToDouble(tbImporte.Text);

            nuevo = new Multa(patente, vencimiento, importe);

            exportables.Sort();
            int idx = exportables.BinarySearch(nuevo);
            if (idx > -1)
            {
                Multa multa = exportables[idx] as Multa;
                multa.Importe += importe;
                if (multa.Vencimiento < ((Multa)nuevo).Vencimiento)
                {
                    multa.Vencimiento = ((Multa)nuevo).Vencimiento;
                }
            }
            else
            {
                exportables.Add(nuevo);
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "(csv)|*.csv|(json)|*.json|(txt)|*.txt|(xml)|*.xml";

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string nombre = openFileDialog1.FileName;
                int tipoArchivo = openFileDialog1.FilterIndex;

                IExportador exportador = (new ExportadorFactory()).GetInstance(tipoArchivo);

                FileStream fs = new FileStream(nombre, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                while (!sr.EndOfStream)
                {
                    string linea = sr.ReadLine();

                    IExportable nuevo = new Multa();

                    nuevo.Importar(linea,exportador);

                }
            }
        }
    }
}
