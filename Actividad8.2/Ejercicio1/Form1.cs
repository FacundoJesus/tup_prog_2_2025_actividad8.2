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

        private void Form1_Load(object sender, EventArgs e) { }


        List<IExportable> exportables = new List<IExportable>();

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            lsbResultado.Items.Clear();
            foreach (IExportable m in exportables)
            {
                lsbResultado.Items.Add(m);
            }
            //lsbResultado.Items.AddRange(exportables.ToArray());
        }

        private void lsbResultado_SelectedValueChanged(object sender, EventArgs e)
        {
            Multa selececcionada = lsbResultado.SelectedItem as Multa;
            if (selececcionada != null)
            {
                tbPatente.Text = selececcionada.Patente;
                dtpVencimiento.Value = selececcionada.Vencimiento.ToDateTime(new TimeOnly(0, 0));
                tbImporte.Text = selececcionada.Importe.ToString("f2");
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            IExportable nuevaMulta = null;
            try
            {
                string patente = tbPatente.Text;
                DateOnly vencimiento = DateOnly.FromDateTime(dtpVencimiento.Value);
                double importe = Convert.ToDouble(tbImporte.Text);

                nuevaMulta = new Multa(patente, vencimiento, importe);

                exportables.Sort();
                int idx = exportables.BinarySearch(nuevaMulta);
                if (idx > -1)
                {
                    Multa multa = exportables[idx] as Multa;
                    multa.Importe += importe;
                    if (multa.Vencimiento < ((Multa)nuevaMulta).Vencimiento)
                    {
                        multa.Vencimiento = ((Multa)nuevaMulta).Vencimiento;
                    }
                }
                else
                {
                    exportables.Add(nuevaMulta);
                }

                #region Limpio Campos
                btnActualizar.PerformClick();
                tbPatente.Clear();
                dtpVencimiento.Value = DateTime.Now;
                tbImporte.Clear();
                #endregion

            }catch(PatenteNoValidaException excePatente)
            {
                MessageBox.Show(excePatente.Message,"ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "(csv)|*.csv|(json)|*.json|(txt)|*.txt|(xml)|*.xml";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string nombre = openFileDialog1.FileName;
                int tipoArchivo = openFileDialog1.FilterIndex;

                IExportador exportador = (new ExportadorFactory()).GetInstance(tipoArchivo);

                FileStream fs = null;
                StreamReader sr = null;

                try
                {
                    fs = new FileStream(nombre, FileMode.Open, FileAccess.Read);
                    sr = new StreamReader(fs);

                    sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        string linea = sr.ReadLine();

                        IExportable nuevo = new Multa();

                        if (nuevo.Importar(linea, exportador) == true)
                        {

                            int idx = exportables.BinarySearch(nuevo);
                            if (idx >= 0)
                            {
                                Multa multa = exportables[idx] as Multa;
                                multa.Importe += ((Multa)nuevo).Importe;
                                if (multa.Vencimiento < ((Multa)nuevo).Vencimiento) ;
                                multa.Vencimiento = ((Multa)nuevo).Vencimiento;
                            }
                            else
                                exportables.Add(nuevo);
                        }
                    }
                }
                catch (PatenteNoValidaException excePatente)
                {
                    MessageBox.Show(excePatente.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sr != null) sr.Close(); 
                    if (fs != null) fs.Close();
                }

                btnActualizar.PerformClick();
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            
            saveFileDialog1.Filter = "(csv)|*.csv|(json)|*.json|(txt)|*.txt|(xml)|*.xml";            

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string nombre = openFileDialog1.FileName;
                int tipoArchivo = openFileDialog1.FilterIndex;

                IExportador exportador = (new ExportadorFactory()).GetInstance(tipoArchivo);

                FileStream fs = null;
                StreamWriter sw = null;
                try
                {
                    fs = new FileStream(nombre, FileMode.OpenOrCreate, FileAccess.Write);
                    sw = new StreamWriter(fs);

                    //Debo escribir la 1º linea...VER
                    if (exportador is CSVExportador) 
                        sw.WriteLine("Patente;Vencimiento;Importe");
                    if (exportador is CampoFijoExportador) sw.WriteLine("Patente  Venc.     Importe");
                    if (exportador is XMLExportador) sw.WriteLine("<Multas>");

                    foreach (IExportable exportable in exportables) {
                        sw.WriteLine(exportable.Exportar(exportador));
                    }

                }
                catch(Exception ex) 
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if(sw != null) sw.Close();
                    if(fs != null) fs.Close();
                }

            }


        }
            
    }
}
