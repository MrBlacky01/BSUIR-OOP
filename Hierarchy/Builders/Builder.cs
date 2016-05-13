using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hierarchy
{
     class Builder :IBuildable
    {
        public string Name { get; protected set; }
        public TextBox nameBox { get; set; }
        public Label nameBoxLabel;

        public NumericUpDown volume;
        public Label volumeBoxLabel;
        public Button save;

        public TextBox percentBox;
        public Label percentLabel;

        public delegate void DAdd(Drinks element);
        public DAdd delToAdd;

        public delegate void DChange(Drinks element);
        public DChange delToChange;

        public virtual void MakingPanel(Panel panel, DAdd del)
        {
            
        }

        public virtual void ChangingElement(Panel panel,Drinks element, DChange del)
        {

        }

        public void MakingTemplate(Panel panel)
        {

            nameBox = new TextBox();
            nameBoxLabel = new Label();

            volume = new NumericUpDown();
            volumeBoxLabel = new Label();

            save = new Button();
            panel.Controls.Add(save);

            panel.Controls.Add(nameBox);
            panel.Controls.Add(nameBoxLabel);
            panel.Controls.Add(volume);
            panel.Controls.Add(volumeBoxLabel);

            nameBoxLabel.AutoSize = true;
            nameBoxLabel.Location = new System.Drawing.Point(45, 79);
            nameBoxLabel.Name = "label1";
            nameBoxLabel.Size = new System.Drawing.Size(35, 13);
            nameBoxLabel.TabIndex = 1;
            nameBoxLabel.Text = "Name";

            nameBox.Location = new System.Drawing.Point(180, 76);
            nameBox.Name = "textBox1";
            nameBox.Size = new System.Drawing.Size(181, 20);
            nameBox.TabIndex = 2;

            volumeBoxLabel.AutoSize = true;
            volumeBoxLabel.Location = new System.Drawing.Point(45, 132);
            volumeBoxLabel.Name = "label2";
            volumeBoxLabel.Size = new System.Drawing.Size(42, 13);
            volumeBoxLabel.TabIndex = 3;
            volumeBoxLabel.Text = "Volume";

            volume.DecimalPlaces = 1;
            volume.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            volume.Location = new System.Drawing.Point(242, 130);
            volume.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            volume.Name = "numericUpDown1";
            volume.Size = new System.Drawing.Size(67, 20);
            volume.TabIndex = 4;
            volume.ThousandsSeparator = true;
            volume.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});

            save.Location = new System.Drawing.Point(137, 329);
            save.Name = "button1";
            save.Size = new System.Drawing.Size(112, 46);
            save.TabIndex = 9;
            save.Text = "Make Object";
            save.UseVisualStyleBackColor = true;

        }

        public void ClearPartOfPanel()
        {
      
            nameBox.Dispose();
            nameBoxLabel.Dispose();
            nameBox = new TextBox { };
            nameBoxLabel = new Label { };

            volume.Dispose();
            volumeBoxLabel.Dispose();
            save.Dispose();
        }

       

        protected void AdditingToList(Drinks template, DAdd del)
        {
            del.Invoke(template);
            
        }

        
        protected void ChooseAction(Drinks template)
        {
            if (delToAdd != null)
                AdditingToList(template, delToAdd);
            else
            {
                ChangingElement(template, delToChange);
            }
        }
        protected void ChangingElement(Drinks template, DChange del)
        {
            del.Invoke(template);
        }

        public void MakingAlcoPanel(Panel panel,  int x, int y)
        {
            MakingTemplate(panel);

            percentBox = new TextBox();
            percentLabel = new Label();

            
            panel.Controls.Add(percentBox);
            panel.Controls.Add(percentLabel);

            percentLabel.AutoSize = true;
            percentLabel.Location = new System.Drawing.Point(45, x);
            percentLabel.Name = "label3";
            percentLabel.Size = new System.Drawing.Size(95, 13);
            percentLabel.TabIndex = 5;
            percentLabel.Text = "Persent Of Alcohol";

            percentBox.Location = new System.Drawing.Point(242, y);
            percentBox.Name = "textBox2";
            percentBox.Size = new System.Drawing.Size(67, 20);
            percentBox.TabIndex = 6;

        }

        public void DisposeAlcoPanel()
        {
            ClearPartOfPanel();

      
            percentBox.Dispose();
            percentLabel.Dispose();
        }

        public virtual void ClearPanel()
        {
            
        }
     
    }
}
