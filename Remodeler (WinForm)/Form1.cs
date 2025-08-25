using System.Diagnostics;

namespace Remodeler_WinForm
{
    public partial class Form1 : Form
    {
        BindingList<string> files = new BindingList<string>();
        Process cmd = new Process();
        bool processRunning = false;

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
            if (rbTS_to_MP4.Checked) openSingle.Filter = "TS|*.ts";
            else if (rbDAV_to_MKV.Checked) openSingle.Filter = "DAV|*.dav";
            if (openSingle.ShowDialog() == DialogResult.OK) files.Add(openSingle.FileName);
        }

        private void bInputFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolder = new FolderBrowserDialog();
            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                string[] filesInFolder = Directory.GetFiles(openFolder.SelectedPath);
                foreach (string file in filesInFolder) 
                    if (rbTS_to_MP4.Checked && Path.GetExtension(file) == ".ts") files.Add(file);
                    else if (rbDAV_to_MKV.Checked && Path.GetExtension(file) == ".dav") files.Add(file);
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

        private void chbDeleteConverted_CheckedChanged(object sender, EventArgs e) { Settings.Default.inputDelete = chbDeleteConverted.Checked; Settings.Default.Save(); }
        private void bOutputSingle_Click(object sender, EventArgs e)
        {
            if (rbTS_to_MP4.Checked)
            {
                this.Enabled = false;
                if (files.Count <= 0 || Settings.Default.ffmpegPath.Length == 0) return;
                string inputFile = files[lbFiles.SelectedIndex] ?? files[0];
                if (!File.Exists(inputFile)) return;
                string outputFile = Path.Combine(String.IsNullOrEmpty(tbOutput.Text) ? Path.GetDirectoryName(inputFile) : tbOutput.Text, Path.ChangeExtension(Path.GetFileName(inputFile), ".mp4"));
                string exec = $"-i \"{inputFile}\" -c:v copy -c:a aac -strict experimental \"{outputFile}\"";
                cmd.StartInfo.FileName = Settings.Default.ffmpegPath;
                cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                cmd.StartInfo.Arguments = exec;
                cmd.Start();
                processRunning = true;
                cmd.WaitForExit();
                if (cmd.ExitCode == 0)
                {
                    MessageBox.Show($"{outputFile} successfully converted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (Settings.Default.inputDelete) { File.Delete(inputFile); files.Remove(inputFile); }
                }
                this.Enabled = true;
                processRunning = false;
            }
            else if(rbDAV_to_MKV.Checked) {
                this.Enabled = false;
                if (files.Count <= 0 || Settings.Default.ffmpegPath.Length == 0) return;
                string inputFile = files[lbFiles.SelectedIndex] ?? files[0];
                if (!File.Exists(inputFile)) return;
                string outputFile = Path.Combine(String.IsNullOrEmpty(tbOutput.Text) ? Path.GetDirectoryName(inputFile) : tbOutput.Text, Path.ChangeExtension(Path.GetFileName(inputFile), ".mkv"));
                string exec = $"-i \"{inputFile}\" -c:v copy -c:a aac -strict experimental \"{outputFile}\"";
                cmd.StartInfo.FileName = Settings.Default.ffmpegPath;
                cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                cmd.StartInfo.Arguments = exec;
                cmd.Start();
                processRunning = true;
                cmd.WaitForExit();
                if (cmd.ExitCode == 0)
                {
                    MessageBox.Show($"{outputFile} successfully converted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (Settings.Default.inputDelete) { File.Delete(inputFile); files.Remove(inputFile); }
                }
                this.Enabled = true;
                processRunning = false;
            }
        }

        private void bOutputList_Click(object sender, EventArgs e)
        {
            if (rbTS_to_MP4.Checked)
            {
                this.Enabled = false;
                foreach (var file in files)
                {
                    if (files.Count <= 0 || Settings.Default.ffmpegPath.Length == 0) return;
                    string inputFile = file;
                    if (!File.Exists(inputFile)) return;
                    string outputFile = Path.Combine(String.IsNullOrEmpty(tbOutput.Text) ? Path.GetDirectoryName(inputFile) : tbOutput.Text, Path.ChangeExtension(Path.GetFileName(inputFile), ".mp4"));
                    string exec = $"-i \"{inputFile}\" -c:v copy -c:a aac -strict experimental \"{outputFile}\"";                
                    cmd.StartInfo.FileName = Settings.Default.ffmpegPath;
                    cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    cmd.StartInfo.Arguments = exec;
                    cmd.Start();
                    processRunning = true;
                    cmd.WaitForExit();
                    if(cmd.ExitCode == 0)
                    {
                        MessageBox.Show($"{outputFile} successfully converted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (Settings.Default.inputDelete) { File.Delete(inputFile); files.Remove(inputFile); }
                    }
                }
                this.Enabled = true;
                processRunning = false;
            }
            else if (rbDAV_to_MKV.Checked)
            {
                this.Enabled = false;
                foreach (var file in files)
                {
                    if (files.Count <= 0 || Settings.Default.ffmpegPath.Length == 0) return;
                    string inputFile = file;
                    if (!File.Exists(inputFile)) return;
                    string outputFile = Path.Combine(String.IsNullOrEmpty(tbOutput.Text) ? Path.GetDirectoryName(inputFile) : tbOutput.Text, Path.ChangeExtension(Path.GetFileName(inputFile), ".mkv"));
                    string exec = $"-i \"{inputFile}\" -c:v copy -c:a aac -strict experimental \"{outputFile}\"";
                    cmd.StartInfo.FileName = Settings.Default.ffmpegPath;
                    cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    cmd.StartInfo.Arguments = exec;
                    cmd.Start();
                    processRunning = true;
                    cmd.WaitForExit();
                    if (cmd.ExitCode == 0)
                    {
                        MessageBox.Show($"{outputFile} successfully converted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (Settings.Default.inputDelete) { File.Delete(inputFile); files.Remove(inputFile); }
                    }
                }
                this.Enabled = true;
                processRunning = false;
            }
        }

        private void tbFfmpeg_TextChanged(object sender, EventArgs e) { Settings.Default.ffmpegPath = tbFfmpeg.Text; Settings.Default.Save(); }
        private void tbOutput_TextChanged(object sender, EventArgs e) { Settings.Default.outputPath = tbOutput.Text; Settings.Default.Save(); }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (processRunning)
            {
                var dialog = MessageBox.Show("Conversion is still in progress. Are you sure you want to exit the program?", "Conversion still in progress", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                if (dialog == DialogResult.Yes) cmd.Close();
                else e.Cancel = dialog == DialogResult.No;
            }
        }
    }
}
