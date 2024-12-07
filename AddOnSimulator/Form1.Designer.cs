namespace AddOnSimulator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_ocusync_port = new System.Windows.Forms.TextBox();
            this.tb_ocusync_IP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_loop_ip = new System.Windows.Forms.TextBox();
            this.tb_loop_port = new System.Windows.Forms.TextBox();
            this.tb_adsb_ip = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_adsb_port = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_node_ip = new System.Windows.Forms.TextBox();
            this.tb_node_port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cb_ocusync = new System.Windows.Forms.CheckBox();
            this.cb_adsb = new System.Windows.Forms.CheckBox();
            this.cb_loop = new System.Windows.Forms.CheckBox();
            this.cb_direction = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cb_sp_folder = new System.Windows.Forms.ComboBox();
            this.cb_ocusyncFolder = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.08621F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.02674F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.53343F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.43239F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tb_ocusync_port, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tb_ocusync_IP, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.tb_loop_ip, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.tb_loop_port, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.tb_adsb_ip, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.tb_adsb_port, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.tb_node_ip, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.tb_node_port, 7, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 95);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1180, 58);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(290, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 26);
            this.label5.TabIndex = 8;
            this.label5.Text = "ADSB IP";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ocusync IP";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ocusync Port";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(290, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "ADSB Port";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_ocusync_port
            // 
            this.tb_ocusync_port.Location = new System.Drawing.Point(91, 32);
            this.tb_ocusync_port.Name = "tb_ocusync_port";
            this.tb_ocusync_port.Size = new System.Drawing.Size(116, 21);
            this.tb_ocusync_port.TabIndex = 3;
            // 
            // tb_ocusync_IP
            // 
            this.tb_ocusync_IP.Location = new System.Drawing.Point(91, 3);
            this.tb_ocusync_IP.Name = "tb_ocusync_IP";
            this.tb_ocusync_IP.Size = new System.Drawing.Size(116, 21);
            this.tb_ocusync_IP.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(588, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 26);
            this.label7.TabIndex = 8;
            this.label7.Text = "Loop Port";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_loop_ip
            // 
            this.tb_loop_ip.Location = new System.Drawing.Point(719, 3);
            this.tb_loop_ip.Name = "tb_loop_ip";
            this.tb_loop_ip.Size = new System.Drawing.Size(116, 21);
            this.tb_loop_ip.TabIndex = 4;
            // 
            // tb_loop_port
            // 
            this.tb_loop_port.Location = new System.Drawing.Point(719, 32);
            this.tb_loop_port.Name = "tb_loop_port";
            this.tb_loop_port.Size = new System.Drawing.Size(108, 21);
            this.tb_loop_port.TabIndex = 5;
            // 
            // tb_adsb_ip
            // 
            this.tb_adsb_ip.Location = new System.Drawing.Point(392, 3);
            this.tb_adsb_ip.Name = "tb_adsb_ip";
            this.tb_adsb_ip.Size = new System.Drawing.Size(116, 21);
            this.tb_adsb_ip.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(588, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 26);
            this.label6.TabIndex = 8;
            this.label6.Text = "Loop IP";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_adsb_port
            // 
            this.tb_adsb_port.Location = new System.Drawing.Point(392, 32);
            this.tb_adsb_port.Name = "tb_adsb_port";
            this.tb_adsb_port.Size = new System.Drawing.Size(108, 21);
            this.tb_adsb_port.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(881, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 26);
            this.label8.TabIndex = 8;
            this.label8.Text = "spiderShield IP";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(881, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 26);
            this.label9.TabIndex = 8;
            this.label9.Text = "spiderShield Port";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_node_ip
            // 
            this.tb_node_ip.Location = new System.Drawing.Point(1017, 3);
            this.tb_node_ip.Name = "tb_node_ip";
            this.tb_node_ip.Size = new System.Drawing.Size(116, 21);
            this.tb_node_ip.TabIndex = 4;
            // 
            // tb_node_port
            // 
            this.tb_node_port.Location = new System.Drawing.Point(1017, 32);
            this.tb_node_port.Name = "tb_node_port";
            this.tb_node_port.Size = new System.Drawing.Size(108, 21);
            this.tb_node_port.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(995, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 34);
            this.label1.TabIndex = 4;
            this.label1.Text = "Add On Simulator";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1089, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "전송";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.BackColor = System.Drawing.SystemColors.InfoText;
            this.listBox1.ForeColor = System.Drawing.Color.Honeydew;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 172);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1178, 208);
            this.listBox1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.cb_ocusync, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cb_adsb, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.cb_loop, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.cb_direction, 3, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 43);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1178, 38);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // cb_ocusync
            // 
            this.cb_ocusync.Location = new System.Drawing.Point(3, 3);
            this.cb_ocusync.Name = "cb_ocusync";
            this.cb_ocusync.Size = new System.Drawing.Size(118, 32);
            this.cb_ocusync.TabIndex = 0;
            this.cb_ocusync.Text = "ocusync";
            this.cb_ocusync.UseVisualStyleBackColor = true;
            // 
            // cb_adsb
            // 
            this.cb_adsb.Location = new System.Drawing.Point(297, 3);
            this.cb_adsb.Name = "cb_adsb";
            this.cb_adsb.Size = new System.Drawing.Size(118, 32);
            this.cb_adsb.TabIndex = 1;
            this.cb_adsb.Text = "adsb";
            this.cb_adsb.UseVisualStyleBackColor = true;
            // 
            // cb_loop
            // 
            this.cb_loop.Checked = true;
            this.cb_loop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_loop.Location = new System.Drawing.Point(591, 3);
            this.cb_loop.Name = "cb_loop";
            this.cb_loop.Size = new System.Drawing.Size(118, 32);
            this.cb_loop.TabIndex = 1;
            this.cb_loop.Text = "loop";
            this.cb_loop.UseVisualStyleBackColor = true;
            // 
            // cb_direction
            // 
            this.cb_direction.Checked = true;
            this.cb_direction.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_direction.Location = new System.Drawing.Point(885, 3);
            this.cb_direction.Name = "cb_direction";
            this.cb_direction.Size = new System.Drawing.Size(118, 32);
            this.cb_direction.TabIndex = 1;
            this.cb_direction.Text = "spider shield";
            this.cb_direction.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(18, 400);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 31);
            this.button2.TabIndex = 8;
            this.button2.Text = "ws_disconnect";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(158, 400);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 31);
            this.button3.TabIndex = 9;
            this.button3.Text = "ws_abort";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // cb_sp_folder
            // 
            this.cb_sp_folder.FormattingEnabled = true;
            this.cb_sp_folder.Location = new System.Drawing.Point(897, 152);
            this.cb_sp_folder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_sp_folder.Name = "cb_sp_folder";
            this.cb_sp_folder.Size = new System.Drawing.Size(224, 20);
            this.cb_sp_folder.TabIndex = 10;
            // 
            // cb_ocusyncFolder
            // 
            this.cb_ocusyncFolder.FormattingEnabled = true;
            this.cb_ocusyncFolder.Location = new System.Drawing.Point(12, 152);
            this.cb_ocusyncFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_ocusyncFolder.Name = "cb_ocusyncFolder";
            this.cb_ocusyncFolder.Size = new System.Drawing.Size(224, 20);
            this.cb_ocusyncFolder.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1203, 450);
            this.Controls.Add(this.cb_ocusyncFolder);
            this.Controls.Add(this.cb_sp_folder);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Location = new System.Drawing.Point(15, 15);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.ComboBox cb_sp_folder;

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_node_ip;
        private System.Windows.Forms.TextBox tb_node_port;

        private System.Windows.Forms.CheckBox cb_direction;

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_loop_ip;
        private System.Windows.Forms.TextBox tb_loop_port;
        private System.Windows.Forms.CheckBox cb_loop;

        private System.Windows.Forms.CheckBox cb_ocusync;
        private System.Windows.Forms.CheckBox cb_adsb;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_ocusync_IP;
        private System.Windows.Forms.TextBox tb_ocusync_port;
        private System.Windows.Forms.TextBox tb_adsb_ip;
        private System.Windows.Forms.TextBox tb_adsb_port;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        #endregion

        private System.Windows.Forms.ComboBox cb_ocusyncFolder;
    }
}