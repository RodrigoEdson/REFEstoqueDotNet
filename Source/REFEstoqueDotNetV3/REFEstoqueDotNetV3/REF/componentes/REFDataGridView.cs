using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using REFEstoqueDotNetV3.model.DIC;

namespace REFEstoqueDotNetV3.REF.componentes
{
    public class REFDataGridView : DataGridView
    {
        public REFDataGridView()
        {
            this.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGreen;//Color.FromArgb(180,240,192);
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AutoGenerateColumns = false;
            this.MultiSelect = false;
            this.ReadOnly = true;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TabIndex = 0;
        }

        public void initGrid(List<ColunaBean> list)
        {
            //popular grid com as colunas a serem exibidas
            this.Columns.Clear();
            foreach (ColunaBean item in list)
            {
                DataGridViewTextBoxColumn gridCol = new DataGridViewTextBoxColumn();

                gridCol.DataPropertyName = item.nomeColunaBean;
                gridCol.HeaderText = item.labelColuna;
                gridCol.Visible = item.indVisivelGrid == "S" ? true : false;
                gridCol.Width = item.tamanhoColunaGrid;

                System.Windows.Forms.DataGridViewCellStyle style = new System.Windows.Forms.DataGridViewCellStyle();
                if (item.tipoColuna == "NUMBER")
                {
                    style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
                    switch (item.casasDecimais)
                    {
                        case 0:
                            style.Format = "N0";
                            break;
                        case 1:
                            style.Format = "N1";
                            break;
                        case 2:
                            style.Format = "N2";
                            break;
                        case 3:
                            style.Format = "N3";
                            break;
                        case 4:
                            style.Format = "N4";
                            break;
                    }
                }
                else if (item.tipoColuna == "DATE")
                {
                    style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                    style.Format = "dd/MM/yyyy";
                }
                else if (item.tipoColuna == "DATETIME")
                {
                    style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                    style.Format = "dd/MM/yyyy HH:mm:ss";
                }
                else if (item.tipoColuna == "STRING")
                {
                    style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                }
                else
                {
                    style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                }
                gridCol.DefaultCellStyle = style;

                this.Columns.Add(gridCol);
            }
            this.Refresh();
        }

    }
}
