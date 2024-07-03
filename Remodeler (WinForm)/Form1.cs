using System.Diagnostics;

namespace Remodeler_WinForm
{
    public partial class Form1 : Form
    {
        BindingList<string> files = new BindingList<string>();

        public Form1()
        {
            InitializeComponent();
            lbFiles.DataSource = files;
            tbFfmpeg.Text = Settings.Default.ffmpegPath;
            tbFfmpeg.SelectionStart = tbFfmpeg.TextLength;
            tbOutput.Text = Settings.Default.outputPath;
            tbOutput.SelectionStart = tbOutput.TextLength;
            chbDeleteConverted.Checked = Settings.Default.inputDelete;
        }

        private void bFfmpeg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFFmpeg = new OpenFileDialog();
            openFFmpeg.Filter = "FFmpeg Executable|*.exe";
            openFFmpeg.DefaultExt = ".exe";
            if (openFFmpeg.ShowDialog() == DialogResult.OK)
            {
                tbFfmpeg.Text = openFFmpeg.FileName;
                tbFfmpeg.SelectionStart = tbFfmpeg.TextLength;
                Settings.Default.ffmpegPath = openFFmpeg.FileName;
                Settings.Default.Save();
            }
        }

        private void bInputSingle_Click(object sender, EventArgs e)
        {
            OpenFileDialog openSingle = new OpenFileDialog();
            openSingle.Filter = "TS|*.ts";
            openSingle.DefaultExt = ".ts";
            if (openSingle.ShowDialog() == DialogResult.OK)
            {
                files.Add(openSingle.FileName);
            }
        }

        private void bInputFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolder = new FolderBrowserDialog();
            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                string[] filesInFolder = Directory.GetFiles(openFolder.SelectedPath);
                foreach (string file in filesInFolder) if (Path.GetExtension(file) == ".ts") files.Add(file);
            }
        }

        private void bOutput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog saveFolder = new FolderBrowserDialog();
            if (saveFolder.ShowDialog() == DialogResult.OK)
            {
                tbOutput.Text = saveFolder.SelectedPath;
                tbOutput.SelectionStart = tbOutput.TextLength;
                Settings.Default.outputPath = saveFolder.SelectedPath;
                Settings.Default.Save();
            }
        }

        private void chbDeleteConverted_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.inputDelete = chbDeleteConverted.Checked;
            Settings.Default.Save();
        }

        private void bOutputSingle_Click(object sender, EventArgs e)
        {
            if (files.Count <= 0 || Settings.Default.ffmpegPath.Length == 0) return;
            string inputFile = files[lbFiles.SelectedIndex] ?? files[0];
            string outputFile = Path.Combine(tbOutput.Text, Path.ChangeExtension(Path.GetFileName(inputFile), ".mp4"));
            string exec = $"-i \"{inputFile}\" -c:v copy -c:a aac -strict experimental \"{outputFile}\"";
            Process cmd = new Process();
            cmd.StartInfo.FileName = Settings.Default.ffmpegPath;
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.StartInfo.Arguments = exec;
            cmd.Start();
            cmd.WaitForExit();
            MessageBox.Show($"{outputFile} successfully converted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (Settings.Default.inputDelete) File.Delete(inputFile);
        }

        private void bOutputList_Click(object sender, EventArgs e)
        {
            foreach (var file in files)
            {
                if (files.Count <= 0 || Settings.Default.ffmpegPath.Length == 0) return;
                string inputFile = files[lbFiles.SelectedIndex] ?? files[0];
                string outputFile = Path.Combine(tbOutput.Text ?? Path.GetDirectoryName(inputFile), Path.ChangeExtension(Path.GetFileName(inputFile), ".mp4"));
                string exec = $"-i \"{inputFile}\" -c:v copy -c:a aac -strict experimental \"{outputFile}\"";
                Process cmd = new Process();
                cmd.StartInfo.FileName = Settings.Default.ffmpegPath;
                cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                cmd.StartInfo.Arguments = exec;
                cmd.Start();
                cmd.WaitForExit();
                MessageBox.Show($"{outputFile} successfully converted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (Settings.Default.inputDelete) File.Delete(inputFile);
            }
        }

        private void tbFfmpeg_TextChanged(object sender, EventArgs e) { Settings.Default.ffmpegPath = tbFfmpeg.Text; Settings.Default.Save(); }
        private void tbOutput_TextChanged(object sender, EventArgs e) { Settings.Default.outputPath = tbOutput.Text; Settings.Default.Save(); }
    }
}
