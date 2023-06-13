using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualizzaCanvassXML
{
    public partial class XmlExplore : Form
    {
        private string file = "";

        public XmlExplore()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this); // Apre il file picker => l'esecuzione è interrotta fino alla chiusura del file picker

            file = openFileDialog1.InitialDirectory + openFileDialog1.FileName; // Ottiene il path del file selezionato

            textBox1.Text = file;

            dataSet1 = new DataSet();
            dataSet1.ReadXml(file);

            comboBox1.Items.Clear();

            foreach (DataTable dt in dataSet1.Tables)
            {

                comboBox1.Items.Add(new Elenco(dt.TableName, dt));
                
            }
            comboBox1.DisplayMember = "NomeTabella";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ((Elenco)((ComboBox)sender).SelectedItem).Tabella;
        }

        public class  Elenco
        {
            public string NomeTabella { get; set; }
            public DataTable Tabella { get; set; }
            public Elenco(string nomeTebella, DataTable tabella)
            {
                this.NomeTabella = nomeTebella;
                this.Tabella = tabella;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
