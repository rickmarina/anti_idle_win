namespace anti_idle_win;

partial class FormAntiIdle
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
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAntiIdle));
        timerCheckIdle = new System.Windows.Forms.Timer(components);
        groupBox1 = new GroupBox();
        label2 = new Label();
        label1 = new Label();
        numericUpDownSeconds = new NumericUpDown();
        comboBoxAplicaciones = new ComboBox();
        bTakeScreenshot = new Button();
        groupBox1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numericUpDownSeconds).BeginInit();
        SuspendLayout();
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(label2);
        groupBox1.Controls.Add(label1);
        groupBox1.Controls.Add(numericUpDownSeconds);
        groupBox1.Location = new Point(16, 9);
        groupBox1.Margin = new Padding(3, 2, 3, 2);
        groupBox1.Name = "groupBox1";
        groupBox1.Padding = new Padding(3, 2, 3, 2);
        groupBox1.Size = new Size(320, 68);
        groupBox1.TabIndex = 0;
        groupBox1.TabStop = false;
        groupBox1.Text = "Configuration";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(200, 27);
        label2.Name = "label2";
        label2.Size = new Size(29, 15);
        label2.TabIndex = 2;
        label2.Text = "secs";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(17, 27);
        label1.Name = "label1";
        label1.Size = new Size(71, 15);
        label1.TabIndex = 1;
        label1.Text = "Check every";
        // 
        // numericUpDownSeconds
        // 
        numericUpDownSeconds.Location = new Point(98, 26);
        numericUpDownSeconds.Margin = new Padding(3, 2, 3, 2);
        numericUpDownSeconds.Name = "numericUpDownSeconds";
        numericUpDownSeconds.Size = new Size(96, 23);
        numericUpDownSeconds.TabIndex = 0;
        numericUpDownSeconds.ValueChanged += numericUpDownSeconds_ValueChanged;
        // 
        // comboBoxAplicaciones
        // 
        comboBoxAplicaciones.FormattingEnabled = true;
        comboBoxAplicaciones.Location = new Point(32, 90);
        comboBoxAplicaciones.Margin = new Padding(3, 2, 3, 2);
        comboBoxAplicaciones.Name = "comboBoxAplicaciones";
        comboBoxAplicaciones.Size = new Size(133, 23);
        comboBoxAplicaciones.TabIndex = 1;
        // 
        // bTakeScreenshot
        // 
        bTakeScreenshot.Location = new Point(181, 89);
        bTakeScreenshot.Name = "bTakeScreenshot";
        bTakeScreenshot.Size = new Size(155, 23);
        bTakeScreenshot.TabIndex = 2;
        bTakeScreenshot.Text = "Take screenshot";
        bTakeScreenshot.UseVisualStyleBackColor = true;
        bTakeScreenshot.Click += bTakeScreenshot_Click;
        // 
        // FormAntiIdle
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(379, 304);
        Controls.Add(bTakeScreenshot);
        Controls.Add(comboBoxAplicaciones);
        Controls.Add(groupBox1);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(3, 2, 3, 2);
        Name = "FormAntiIdle";
        Text = "Anti Idle";
        Load += FormAntiIdle_Load;
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numericUpDownSeconds).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Timer timerCheckIdle;
    private GroupBox groupBox1;
    private Label label2;
    private Label label1;
    private NumericUpDown numericUpDownSeconds;
    private ComboBox comboBoxAplicaciones;
    private Button bTakeScreenshot;
}
