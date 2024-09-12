using System.Windows.Forms;
using _08_RasTaggerLib;
using System.ComponentModel;

namespace _10_Tagger
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            grid.DataSource = Fields;
            grid.Columns["Path"].Visible = false;
            grid.AllowUserToAddRows = false;
            grid.CellEndEdit += Grid_CellEndEdit;
        }

        private void Grid_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn column = grid.Columns[e.ColumnIndex];
            var row = grid.Rows[e.RowIndex];
            object value = row.Cells[e.ColumnIndex].Value;
            string name = column.Name;
            RasFields fields = Fields[e.RowIndex];
            fields.Update(name, value);
            int a = 5;
        }

        private void openFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Fields.Clear();
                RasTagger.traverse(dialog.SelectedPath, bla);
            }
            dialog.Dispose();
        }

        #region Private
        BindingList<RasFields> Fields = [];
        bool bla(RasFields fields)
        {
            Fields.Add(fields);
            return true;
        }
        #endregion
    }
}
