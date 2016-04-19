using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hierarchy
{
    class LeavenBuilder: Builder
    {
        Panel leavenPanel;
        Label leavenPanelLabel;
        TextBox water;
        Label waterLabel;

        ComboBox material;
        Label materialLabel;

        TextBox materialCount;
        Label materiaCountLabel;

        TextBox yeald;
        Label yealdLabel;

        TextBox sugar;
        Label sugarLabel;

        public void MakingYealdPanel(Panel panel)//,int x,int y)
        {
            leavenPanel = new Panel();
            leavenPanelLabel = new Label();

            panel.Controls.Add(leavenPanelLabel);
            panel.Controls.Add(leavenPanel);

            leavenPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            leavenPanel.Location = new System.Drawing.Point(20, 168);
            leavenPanel.Name = "panel1";
            leavenPanel.Size = new System.Drawing.Size(349, 147);
            leavenPanel.TabIndex = 1;

            leavenPanelLabel.AutoSize = true;
            leavenPanelLabel.Location = new System.Drawing.Point(23, 160);
            leavenPanelLabel.Size = new System.Drawing.Size(116, 13);
            leavenPanelLabel.TabIndex = 1;
            leavenPanelLabel.Text = "Leaven";

            water = new TextBox();
            waterLabel = new Label();
            material = new ComboBox();
            materialLabel = new Label();
            materialCount = new TextBox();
            materiaCountLabel = new Label();
            yeald = new TextBox();
            yealdLabel = new Label();
            sugar = new TextBox();
            sugarLabel = new Label();



            leavenPanel.Controls.Add(waterLabel);
            leavenPanel.Controls.Add(water);
            leavenPanel.Controls.Add(material);
            leavenPanel.Controls.Add(materialLabel);
            leavenPanel.Controls.Add(materialCount);
            leavenPanel.Controls.Add(materiaCountLabel);
            leavenPanel.Controls.Add(yeald);
            leavenPanel.Controls.Add(yealdLabel);
            leavenPanel.Controls.Add(sugar);
            leavenPanel.Controls.Add(sugarLabel);

            water.Location = new System.Drawing.Point(178, 4);
            water.Name = "textBox1";
            water.Size = new System.Drawing.Size(121, 20);
            water.TabIndex = 0;

            waterLabel.AutoSize = true;
            waterLabel.Location = new System.Drawing.Point(23, 7);
            waterLabel.Name = "label1";
            waterLabel.Size = new System.Drawing.Size(116, 13);
            waterLabel.TabIndex = 1;
            waterLabel.Text = "Water count for portion";

            material.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            material.FormattingEnabled = true;
            material.Items.AddRange(new object[] {
            Leaven.rawMaterials.wheat,
            Leaven.rawMaterials.barley,
            Leaven.rawMaterials.ginger});
            material.Location = new System.Drawing.Point(178, 31);
            material.Name = "comboBox1";
            material.Size = new System.Drawing.Size(121, 21);
            material.TabIndex = 2;

            materialLabel.AutoSize = true;
            materialLabel.Location = new System.Drawing.Point(23, 34);
            materialLabel.Name = "label2";
            materialLabel.Size = new System.Drawing.Size(73, 13);
            materialLabel.TabIndex = 3;
            materialLabel.Text = "Raw materials";

            materialCount.Location = new System.Drawing.Point(178, 59);
            materialCount.Name = "textBox2";
            materialCount.Size = new System.Drawing.Size(121, 20);
            materialCount.TabIndex = 4;

            materiaCountLabel.AutoSize = true;
            materiaCountLabel.Location = new System.Drawing.Point(23, 62);
            materiaCountLabel.Name = "label3";
            materiaCountLabel.Size = new System.Drawing.Size(103, 13);
            materiaCountLabel.TabIndex = 5;
            materiaCountLabel.Text = "Raw materials count";

            yeald.Location = new System.Drawing.Point(178, 86);
            yeald.Name = "textBox3";
            yeald.Size = new System.Drawing.Size(121, 20);
            yeald.TabIndex = 6;

            yealdLabel.AutoSize = true;
            yealdLabel.Location = new System.Drawing.Point(23, 89);
            yealdLabel.Name = "label4";
            yealdLabel.Size = new System.Drawing.Size(64, 13);
            yealdLabel.TabIndex = 7;
            yealdLabel.Text = "Yeald count";

            sugar.Location = new System.Drawing.Point(178, 112);
            sugar.Name = "textBox4";
            sugar.Size = new System.Drawing.Size(121, 20);
            sugar.TabIndex = 8;

            sugarLabel.AutoSize = true;
            sugarLabel.Location = new System.Drawing.Point(23, 115);
            sugarLabel.Name = "label5";
            sugarLabel.Size = new System.Drawing.Size(65, 13);
            sugarLabel.TabIndex = 9;
            sugarLabel.Text = "Sugar count";


        }

        public void DisposeLeavenPanel()
        {
            

            leavenPanel.Dispose();
            leavenPanelLabel.Dispose();
            water.Dispose();
            waterLabel.Dispose();
            material.Dispose();
            materialLabel.Dispose();
            materialCount.Dispose();
            materiaCountLabel.Dispose();
            yeald.Dispose();
            yealdLabel.Dispose();
            sugar.Dispose();
            sugarLabel.Dispose();

        }

        public void ChangingLeavenElement(Leaven element)
        {
            water.Text = element.CountOfWater.ToString();
            material.SelectedItem = element.RawMaterials;
            materialCount.Text = element.CountOfMaterials.ToString();
            yeald.Text = element.CountOfYeast.ToString();
            sugar.Text = element.CountOfSugar.ToString();

        }

        public Leaven MakingLeavenObject()
        {
            try
            {
                if (Convert.ToInt32(water.Text) < 0) throw new Exception("Please, enter count of water more than zero");
                if (material.SelectedIndex == -1) throw new Exception("Please, choose the type of material");
                if (Convert.ToInt32(materialCount.Text) < 0) throw new Exception("Please, enter count of materials more than zero");
                if (Convert.ToInt32(yeald.Text) < 0) throw new Exception("Please, enter count of yeald more than zero");
                if (Convert.ToInt32(sugar.Text) < 0) throw new Exception("Please, enter count of sugar more than zero");

                Leaven temp = new Leaven(Convert.ToInt32(water.Text), material.SelectedIndex, Convert.ToInt32(materialCount.Text), Convert.ToInt32(yeald.Text), Convert.ToInt32(sugar.Text));
                return temp;
            }
            finally
            {

            }

        }

    }
}
