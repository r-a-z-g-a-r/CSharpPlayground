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
