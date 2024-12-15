namespace Proiect_SOAC
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
            preview = new TextBox();
            processed = new TextBox();
            load = new Button();
            immediateMerging = new CheckBox();
            movReabsorption = new CheckBox();
            antiAlias = new CheckBox();
            process = new Button();
            SuspendLayout();
            // 
            // preview
            // 
            preview.Location = new Point(171, 62);
            preview.Multiline = true;
            preview.Name = "preview";
            preview.ScrollBars = ScrollBars.Vertical;
            preview.Size = new Size(405, 630);
            preview.TabIndex = 0;
            // 
            // processed
            // 
            processed.Location = new Point(610, 62);
            processed.Multiline = true;
            processed.Name = "processed";
            processed.ScrollBars = ScrollBars.Vertical;
            processed.Size = new Size(412, 630);
            processed.TabIndex = 1;
            // 
            // load
            // 
            load.Location = new Point(203, 735);
            load.Name = "load";
            load.Size = new Size(226, 47);
            load.TabIndex = 2;
            load.Text = "Load";
            load.UseVisualStyleBackColor = true;
            load.Click += load_Click;
            // 
            // immediateMerging
            // 
            immediateMerging.AutoSize = true;
            immediateMerging.Location = new Point(8, 104);
            immediateMerging.Name = "immediateMerging";
            immediateMerging.Size = new Size(163, 24);
            immediateMerging.TabIndex = 3;
            immediateMerging.Text = "Immediate Merging";
            immediateMerging.UseVisualStyleBackColor = true;
            // 
            // movReabsorption
            // 
            movReabsorption.AutoSize = true;
            movReabsorption.Location = new Point(8, 149);
            movReabsorption.Name = "movReabsorption";
            movReabsorption.Size = new Size(157, 24);
            movReabsorption.TabIndex = 4;
            movReabsorption.Text = "MOV Reabsorption";
            movReabsorption.UseVisualStyleBackColor = true;
            // 
            // antiAlias
            // 
            antiAlias.AutoSize = true;
            antiAlias.Location = new Point(8, 192);
            antiAlias.Name = "antiAlias";
            antiAlias.Size = new Size(94, 24);
            antiAlias.TabIndex = 5;
            antiAlias.Text = "Anti-alias";
            antiAlias.UseVisualStyleBackColor = true;
            // 
            // process
            // 
            process.Location = new Point(21, 262);
            process.Name = "process";
            process.Size = new Size(105, 42);
            process.TabIndex = 6;
            process.Text = "Process";
            process.UseVisualStyleBackColor = true;
            process.Click += process_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1148, 808);
            Controls.Add(process);
            Controls.Add(antiAlias);
            Controls.Add(movReabsorption);
            Controls.Add(immediateMerging);
            Controls.Add(load);
            Controls.Add(processed);
            Controls.Add(preview);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox preview;
        private TextBox processed;
        private Button load;
        private CheckBox immediateMerging;
        private CheckBox movReabsorption;
        private CheckBox antiAlias;
        private Button process;
    }
}
