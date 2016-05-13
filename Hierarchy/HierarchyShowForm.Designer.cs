namespace Hierarchy
{
    partial class HierarchyForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxForDrinks = new System.Windows.Forms.ListBox();
            this.buttonAdding = new System.Windows.Forms.Button();
            this.buttonRemoving = new System.Windows.Forms.Button();
            this.buttonChanging = new System.Windows.Forms.Button();
            this.panelForActions = new System.Windows.Forms.Panel();
            this.comboBoxDrinks = new System.Windows.Forms.ComboBox();
            this.buttonSerialize = new System.Windows.Forms.Button();
            this.buttonDesirealize = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.buttonClear = new System.Windows.Forms.Button();
            this.comboBoxForArhivate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelForActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxForDrinks
            // 
            this.listBoxForDrinks.FormattingEnabled = true;
            this.listBoxForDrinks.Location = new System.Drawing.Point(12, 12);
            this.listBoxForDrinks.Name = "listBoxForDrinks";
            this.listBoxForDrinks.Size = new System.Drawing.Size(337, 329);
            this.listBoxForDrinks.TabIndex = 0;
            // 
            // buttonAdding
            // 
            this.buttonAdding.Location = new System.Drawing.Point(12, 356);
            this.buttonAdding.Name = "buttonAdding";
            this.buttonAdding.Size = new System.Drawing.Size(96, 41);
            this.buttonAdding.TabIndex = 1;
            this.buttonAdding.Text = "Add";
            this.buttonAdding.UseVisualStyleBackColor = true;
            this.buttonAdding.Click += new System.EventHandler(this.buttonAdding_Click);
            // 
            // buttonRemoving
            // 
            this.buttonRemoving.Location = new System.Drawing.Point(258, 356);
            this.buttonRemoving.Name = "buttonRemoving";
            this.buttonRemoving.Size = new System.Drawing.Size(91, 41);
            this.buttonRemoving.TabIndex = 2;
            this.buttonRemoving.Text = "Remove";
            this.buttonRemoving.UseVisualStyleBackColor = true;
            this.buttonRemoving.Click += new System.EventHandler(this.buttonRemoving_Click);
            // 
            // buttonChanging
            // 
            this.buttonChanging.Location = new System.Drawing.Point(131, 356);
            this.buttonChanging.Name = "buttonChanging";
            this.buttonChanging.Size = new System.Drawing.Size(99, 41);
            this.buttonChanging.TabIndex = 3;
            this.buttonChanging.Text = "Change";
            this.buttonChanging.UseVisualStyleBackColor = true;
            this.buttonChanging.Click += new System.EventHandler(this.buttonChanging_Click);
            // 
            // panelForActions
            // 
            this.panelForActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelForActions.Controls.Add(this.comboBoxDrinks);
            this.panelForActions.Location = new System.Drawing.Point(461, 12);
            this.panelForActions.Name = "panelForActions";
            this.panelForActions.Size = new System.Drawing.Size(387, 407);
            this.panelForActions.TabIndex = 4;
            // 
            // comboBoxDrinks
            // 
            this.comboBoxDrinks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDrinks.FormattingEnabled = true;
            this.comboBoxDrinks.Location = new System.Drawing.Point(118, 16);
            this.comboBoxDrinks.Name = "comboBoxDrinks";
            this.comboBoxDrinks.Size = new System.Drawing.Size(141, 21);
            this.comboBoxDrinks.TabIndex = 0;
            this.comboBoxDrinks.SelectedIndexChanged += new System.EventHandler(this.comboBoxDrinks_SelectedIndexChanged);
            // 
            // buttonSerialize
            // 
            this.buttonSerialize.Location = new System.Drawing.Point(13, 419);
            this.buttonSerialize.Name = "buttonSerialize";
            this.buttonSerialize.Size = new System.Drawing.Size(95, 31);
            this.buttonSerialize.TabIndex = 5;
            this.buttonSerialize.Text = "Serialize";
            this.buttonSerialize.UseVisualStyleBackColor = true;
            this.buttonSerialize.Click += new System.EventHandler(this.buttonSerialize_Click);
            // 
            // buttonDesirealize
            // 
            this.buttonDesirealize.Location = new System.Drawing.Point(131, 419);
            this.buttonDesirealize.Name = "buttonDesirealize";
            this.buttonDesirealize.Size = new System.Drawing.Size(99, 31);
            this.buttonDesirealize.TabIndex = 6;
            this.buttonDesirealize.Text = "Deserialize";
            this.buttonDesirealize.UseVisualStyleBackColor = true;
            this.buttonDesirealize.Click += new System.EventHandler(this.buttonDesirealize_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "All files|*|XML|*.xml|Binary|*.dat|Text|*.txt";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "XML|*.xml|Binary|*.dat|Text|*.txt";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(258, 419);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(91, 31);
            this.buttonClear.TabIndex = 7;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxForArhivate
            // 
            this.comboBoxForArhivate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxForArhivate.FormattingEnabled = true;
            this.comboBoxForArhivate.Location = new System.Drawing.Point(131, 456);
            this.comboBoxForArhivate.Name = "comboBoxForArhivate";
            this.comboBoxForArhivate.Size = new System.Drawing.Size(99, 21);
            this.comboBoxForArhivate.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 459);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Type of archivation:";
            // 
            // HierarchyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 491);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxForArhivate);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonDesirealize);
            this.Controls.Add(this.buttonSerialize);
            this.Controls.Add(this.panelForActions);
            this.Controls.Add(this.buttonChanging);
            this.Controls.Add(this.buttonRemoving);
            this.Controls.Add(this.buttonAdding);
            this.Controls.Add(this.listBoxForDrinks);
            this.Name = "HierarchyForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Hierarchy";
            this.panelForActions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonAdding;
        private System.Windows.Forms.Button buttonRemoving;
        private System.Windows.Forms.Button buttonChanging;
        private System.Windows.Forms.ComboBox comboBoxDrinks;
        private System.Windows.Forms.ListBox listBoxForDrinks;
        private System.Windows.Forms.Panel panelForActions;
        private System.Windows.Forms.Button buttonSerialize;
        private System.Windows.Forms.Button buttonDesirealize;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.ComboBox comboBoxForArhivate;
        private System.Windows.Forms.Label label1;
    }
}

