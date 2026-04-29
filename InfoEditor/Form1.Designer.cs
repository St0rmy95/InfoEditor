namespace InfoEditor
{
    partial class InfoEditorMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoEditorMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainGrid = new System.Windows.Forms.DataGridView();
            this.TextureNameGrid = new System.Windows.Forms.DataGridView();
            this.ToolMenu = new System.Windows.Forms.ToolStrip();
            this.File = new System.Windows.Forms.ToolStripDropDownButton();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PresetList = new System.Windows.Forms.ToolStripDropDownButton();
            this.OpacityControls = new System.Windows.Forms.ToolStripDropDownButton();
            this.Opacity100 = new System.Windows.Forms.ToolStripMenuItem();
            this.Opacity90 = new System.Windows.Forms.ToolStripMenuItem();
            this.Opacity80 = new System.Windows.Forms.ToolStripMenuItem();
            this.Opacity70 = new System.Windows.Forms.ToolStripMenuItem();
            this.IE_OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.IE_SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.MainGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextureNameGrid)).BeginInit();
            this.ToolMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainGrid
            // 
            this.MainGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MainGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.MainGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.MainGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.MainGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MainGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.MainGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MainGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.MainGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MainGrid.DefaultCellStyle = dataGridViewCellStyle13;
            resources.ApplyResources(this.MainGrid, "MainGrid");
            this.MainGrid.EnableHeadersVisualStyles = false;
            this.MainGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.MainGrid.MultiSelect = false;
            this.MainGrid.Name = "MainGrid";
            this.MainGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MainGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.MainGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MainGrid.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.MainGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainGrid_CellClick);
            this.MainGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainGrid_CellEndEdit);
            this.MainGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainGrid_CellValueChanged);
            this.MainGrid.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.GridView_ColumnAdded);
            this.MainGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.GridView_DataError);
            this.MainGrid.Enter += new System.EventHandler(this.CurrentlySelected_Enter);
            this.MainGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyPress_DataRow);
            // 
            // TextureNameGrid
            // 
            this.TextureNameGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.White;
            this.TextureNameGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.TextureNameGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.TextureNameGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.TextureNameGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextureNameGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.TextureNameGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TextureNameGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.TextureNameGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TextureNameGrid.DefaultCellStyle = dataGridViewCellStyle18;
            resources.ApplyResources(this.TextureNameGrid, "TextureNameGrid");
            this.TextureNameGrid.EnableHeadersVisualStyles = false;
            this.TextureNameGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.TextureNameGrid.Name = "TextureNameGrid";
            this.TextureNameGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TextureNameGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.White;
            this.TextureNameGrid.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.TextureNameGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.TextureNameGrid_CellEndEdit);
            this.TextureNameGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.TextureNameGrid_CellValueChanged);
            this.TextureNameGrid.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.GridView_ColumnAdded);
            this.TextureNameGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.GridView_DataError);
            this.TextureNameGrid.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.TextureNameGrid_UserAddedRow);
            this.TextureNameGrid.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.TextureNameGrid_UserDeletingRow);
            this.TextureNameGrid.Enter += new System.EventHandler(this.CurrentlySelected_Enter);
            this.TextureNameGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyPress_DataRow);
            // 
            // ToolMenu
            // 
            this.ToolMenu.AllowMerge = false;
            this.ToolMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            resources.ApplyResources(this.ToolMenu, "ToolMenu");
            this.ToolMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File,
            this.PresetList,
            this.OpacityControls});
            this.ToolMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.ToolMenu.Name = "ToolMenu";
            this.ToolMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ToolMenu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyPress_DataRow);
            // 
            // File
            // 
            this.File.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            resources.ApplyResources(this.File, "File");
            this.File.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.File.Name = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.saveToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            resources.ApplyResources(this.saveAsToolStripMenuItem, "saveAsToolStripMenuItem");
            this.saveAsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveAsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // PresetList
            // 
            this.PresetList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.PresetList, "PresetList");
            this.PresetList.Name = "PresetList";
            // 
            // OpacityControls
            // 
            this.OpacityControls.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.OpacityControls.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Opacity100,
            this.Opacity90,
            this.Opacity80,
            this.Opacity70});
            resources.ApplyResources(this.OpacityControls, "OpacityControls");
            this.OpacityControls.Name = "OpacityControls";
            // 
            // Opacity100
            // 
            this.Opacity100.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Opacity100.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Opacity100.ForeColor = System.Drawing.Color.White;
            this.Opacity100.Name = "Opacity100";
            resources.ApplyResources(this.Opacity100, "Opacity100");
            this.Opacity100.Click += new System.EventHandler(this.Opacity100_Click);
            // 
            // Opacity90
            // 
            this.Opacity90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Opacity90.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Opacity90.ForeColor = System.Drawing.Color.White;
            this.Opacity90.Name = "Opacity90";
            resources.ApplyResources(this.Opacity90, "Opacity90");
            this.Opacity90.Click += new System.EventHandler(this.Opacity90_Click);
            // 
            // Opacity80
            // 
            this.Opacity80.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Opacity80.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Opacity80.ForeColor = System.Drawing.Color.White;
            this.Opacity80.Name = "Opacity80";
            resources.ApplyResources(this.Opacity80, "Opacity80");
            this.Opacity80.Click += new System.EventHandler(this.Opacity80_Click);
            // 
            // Opacity70
            // 
            this.Opacity70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Opacity70.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Opacity70.ForeColor = System.Drawing.Color.White;
            this.Opacity70.Name = "Opacity70";
            resources.ApplyResources(this.Opacity70, "Opacity70");
            this.Opacity70.Click += new System.EventHandler(this.Opacity70_Click);
            // 
            // IE_OpenFileDialog
            // 
            resources.ApplyResources(this.IE_OpenFileDialog, "IE_OpenFileDialog");
            // 
            // IE_SaveFileDialog
            // 
            resources.ApplyResources(this.IE_SaveFileDialog, "IE_SaveFileDialog");
            // 
            // InfoEditorMain
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Controls.Add(this.TextureNameGrid);
            this.Controls.Add(this.MainGrid);
            this.Controls.Add(this.ToolMenu);
            this.ForeColor = System.Drawing.Color.White;
            this.KeyPreview = true;
            this.Name = "InfoEditorMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InfoEditorMain_FormClosing);
            this.Load += new System.EventHandler(this.InfoEditorMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.InfoEditorMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.InfoEditorMain_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyPress_DataRow);
            ((System.ComponentModel.ISupportInitialize)(this.MainGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextureNameGrid)).EndInit();
            this.ToolMenu.ResumeLayout(false);
            this.ToolMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripDropDownButton File;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton PresetList;
        private System.Windows.Forms.ToolStripDropDownButton OpacityControls;
        private System.Windows.Forms.ToolStripMenuItem Opacity100;
        private System.Windows.Forms.ToolStripMenuItem Opacity90;
        private System.Windows.Forms.ToolStripMenuItem Opacity80;
        private System.Windows.Forms.ToolStripMenuItem Opacity70;
        private System.Windows.Forms.OpenFileDialog IE_OpenFileDialog;
        public System.Windows.Forms.SaveFileDialog IE_SaveFileDialog;
        public System.Windows.Forms.DataGridView TextureNameGrid;
        public System.Windows.Forms.DataGridView MainGrid;
        public System.Windows.Forms.ToolStrip ToolMenu;
    }
}

