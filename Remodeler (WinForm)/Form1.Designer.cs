namespace Remodeler_WinForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lFfmpeg = new Label();
            bFfmpeg = new Button();
            tbFfmpeg = new TextBox();
            lbFiles = new ListBox();
            tbOutput = new TextBox();
            bOutput = new Button();
            lOutput = new Label();
            bInputFolder = new Button();
            bInputSingle = new Button();
            bOutputList = new Button();
            bOutputSingle = new Button();
            chbDeleteConverted = new CheckBox();
            SuspendLayout();
            // 
            // lFfmpeg
            // 
            lFfmpeg.AutoSize = true;
            lFfmpeg.Location = new Point(12, 16);
            lFfmpeg.Name = "lFfmpeg";
            lFfmpeg.Size = new Size(80, 15);
            lFfmpeg.TabIndex = 0;
            lFfmpeg.Text = "FFmpeg Path:";
            // 
            // bFfmpeg
            // 
            bFfmpeg.Location = new Point(245, 12);
            bFfmpeg.Name = "bFfmpeg";
            bFfmpeg.Size = new Size(50, 23);
            bFfmpeg.TabIndex = 1;
            bFfmpeg.Text = "Locate";
            bFfmpeg.UseVisualStyleBackColor = true;
            bFfmpeg.Click += bFfmpeg_Click;
            // 
            // tbFfmpeg
            // 
            tbFfmpeg.Location = new Point(98, 13);
            tbFfmpeg.Name = "tbFfmpeg";
            tbFfmpeg.Size = new Size(141, 23);
            tbFfmpeg.TabIndex = 2;
            tbFfmpeg.TextChanged += tbFfmpeg_TextChanged;
            // 
            // lbFiles
            // 
            lbFiles.FormattingEnabled = true;
            lbFiles.ItemHeight = 15;
            lbFiles.Location = new Point(12, 76);
            lbFiles.Name = "lbFiles";
            lbFiles.Size = new Size(283, 274);
            lbFiles.TabIndex = 3;
            // 
            // tbOutput
            // 
            tbOutput.Location = new Point(93, 416);
            tbOutput.Name = "tbOutput";
            tbOutput.Size = new Size(146, 23);
            tbOutput.TabIndex = 9;
            tbOutput.TextChanged += tbOutput_TextChanged;
            // 
            // bOutput
            // 
            bOutput.Location = new Point(245, 415);
            bOutput.Name = "bOutput";
            bOutput.Size = new Size(50, 23);
            bOutput.TabIndex = 8;
            bOutput.Text = "Locate";
            bOutput.UseVisualStyleBackColor = true;
            bOutput.Click += bOutput_Click;
            // 
            // lOutput
            // 
            lOutput.AutoSize = true;
            lOutput.Location = new Point(12, 419);
            lOutput.Name = "lOutput";
            lOutput.Size = new Size(75, 15);
            lOutput.TabIndex = 7;
            lOutput.Text = "Output Path:";
            // 
            // bInputFolder
            // 
            bInputFolder.Location = new Point(155, 42);
            bInputFolder.Name = "bInputFolder";
            bInputFolder.Size = new Size(140, 23);
            bInputFolder.TabIndex = 11;
            bInputFolder.Text = "Open Folder";
            bInputFolder.UseVisualStyleBackColor = true;
            bInputFolder.Click += bInputFolder_Click;
            // 
            // bInputSingle
            // 
            bInputSingle.Location = new Point(12, 42);
            bInputSingle.Name = "bInputSingle";
            bInputSingle.Size = new Size(140, 23);
            bInputSingle.TabIndex = 10;
            bInputSingle.Text = "Open File";
            bInputSingle.UseVisualStyleBackColor = true;
            bInputSingle.Click += bInputSingle_Click;
            // 
            // bOutputList
            // 
            bOutputList.Location = new Point(155, 387);
            bOutputList.Name = "bOutputList";
            bOutputList.Size = new Size(140, 23);
            bOutputList.TabIndex = 13;
            bOutputList.Text = "Convert All";
            bOutputList.UseVisualStyleBackColor = true;
            bOutputList.Click += bOutputList_Click;
            // 
            // bOutputSingle
            // 
            bOutputSingle.Location = new Point(12, 387);
            bOutputSingle.Name = "bOutputSingle";
            bOutputSingle.Size = new Size(140, 23);
            bOutputSingle.TabIndex = 12;
            bOutputSingle.Text = "Convert Selected";
            bOutputSingle.UseVisualStyleBackColor = true;
            bOutputSingle.Click += bOutputSingle_Click;
            // 
            // chbDeleteConverted
            // 
            chbDeleteConverted.AutoSize = true;
            chbDeleteConverted.Checked = true;
            chbDeleteConverted.CheckState = CheckState.Checked;
            chbDeleteConverted.Location = new Point(12, 362);
            chbDeleteConverted.Name = "chbDeleteConverted";
            chbDeleteConverted.Size = new Size(171, 19);
            chbDeleteConverted.TabIndex = 14;
            chbDeleteConverted.Text = "Delete files after conversion";
            chbDeleteConverted.UseVisualStyleBackColor = true;
            chbDeleteConverted.CheckedChanged += chbDeleteConverted_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(307, 450);
            Controls.Add(chbDeleteConverted);
            Controls.Add(bOutputList);
            Controls.Add(bOutputSingle);
            Controls.Add(bInputFolder);
            Controls.Add(bInputSingle);
            Controls.Add(tbOutput);
            Controls.Add(bOutput);
            Controls.Add(lOutput);
            Controls.Add(lbFiles);
            Controls.Add(tbFfmpeg);
            Controls.Add(bFfmpeg);
            Controls.Add(lFfmpeg);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Remodeler";
            FormClosing += Form1_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lFfmpeg;
        private Button bFfmpeg;
        private TextBox tbFfmpeg;
        private ListBox lbFiles;
        private TextBox tbOutput;
        private Button bOutput;
        private Label lOutput;
        private Button bInputFolder;
        private Button bInputSingle;
        private Button bOutputList;
        private Button bOutputSingle;
        private CheckBox chbDeleteConverted;
    }
}
