using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Champions_Stuff
{
    public partial class Form1 : Form
    {
        HashSet<Entity> entitySet;
        HashSet<Entity> hideSet;
        int currentRow = -1, currentColumn = 1;
        public Form1()
        {
            InitializeComponent();
            entitySet = new HashSet<Entity>();
            hideSet = new HashSet<Entity>();

            EntityTest();
            entityDGV.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            RefreshCombatChart();

            combatChartDGV.ClearSelection();
        }

        private void EntityTest()
        {
            AddEntity(new Entity("Quantum", 3, 15));
            AddEntity(new Entity("Rampage", 2, 20));
            AddEntity(new Entity("Darklight", 4, 15));
            AddEntity(new Entity("Mountainash", 4, 15));
            AddEntity(new Entity("Rampage (buffed)", 6, 40));
            AddEntity(new Entity("Zom-Boi", 4, 20));
            AddEntity(new Entity("Summer", 6, 25));
        }

        private void AddEntity(Entity entity)
        {
            entitySet.Add(entity);
            entityDGV.Rows.Add(new DataGridViewRow());

            DataGridViewRow row = entityDGV.Rows[entityDGV.Rows.Count - 1];

            row.Cells[0].Value = entity;
            row.Cells[1].Value = entity.Speed;
            row.Cells[2].Value = entity.Dexterity;
        }
        private void RefreshCombatChart()
        {
            combatChartDGV.Rows.Clear();

            HashSet<Entity> toDisplay = new HashSet<Entity>(entitySet.Except<Entity>(hideSet));
            foreach (Entity e in toDisplay)
                AddToCombatChart(e);
        }
        private void AddToCombatChart(Entity entity)
        {
            combatChartDGV.Rows.Add(new DataGridViewRow());

            DataGridViewRow row = combatChartDGV.Rows[combatChartDGV.Rows.Count - 1];

            row.Cells[0].Value = entity;
            HashSet<int> phases = Program.SpeedPhases(entity.Speed);

            foreach (int phase in phases)
            {
                row.Cells[phase].Value = true;
                row.Cells[phase].Style.BackColor = Color.Crimson;
            }

            combatChartDGV.Sort(combatChartDGV.Columns[0], ListSortDirection.Descending);
            combatChartDGV.ClearSelection();
        }
        private bool HideEntity(Entity entity)
        {
            DataGridViewRow[] rows = new DataGridViewRow[combatChartDGV.Rows.Count];
            combatChartDGV.Rows.CopyTo(rows, 0);

            IEnumerable<DataGridViewRow> matched =
                from row in rows
                where row.Cells[0].Value == entity
                select row;

            if (matched.Count() == 0)
                return false;

            foreach (DataGridViewRow row in matched)
                combatChartDGV.Rows.Remove(row);

            return true;
        }
        private void NextPhase()
        {
            //foreach (DataGridViewRow row in combatChartDGV.Rows)
            //    row.Cells[currentColumn].Style = combatChartDGV.DefaultCellStyle;

            if(currentRow >= 0)
                combatChartDGV.Rows[currentRow].Cells[currentColumn].Style.BackColor = Color.Crimson;

            int row = currentRow + 1;
            int column = currentColumn;
            for (; column <= 12; ++column)
            {
                for (; row < combatChartDGV.Rows.Count; ++row)
                {
                    DataGridViewCheckBoxCell cell = combatChartDGV.Rows[row].Cells[column] as DataGridViewCheckBoxCell;
                    if (combatChartDGV.Rows[row].Cells[column].Value == null)
                        continue;

                    currentColumn = column;
                    currentRow = row;
                    //ColorColumn(column, Color.Crimson);
                    combatChartDGV.Rows[row].Cells[column].Style.BackColor = Color.Green;
                    break;
                }

                if (currentRow == row && currentColumn == column)
                    break;

                if (column == 12)
                    column = 1;
                if (row == combatChartDGV.Rows.Count)
                    row = 0;
            }

            currentColumn = column;
            currentRow = row;

        }
        private void combatChartDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            combatChartDGV.CurrentCell = null;
        }
        private void hideButton_Click(object sender, EventArgs e)
        {
            if (entityDGV.CurrentRow.Index == -1)
                return;

            Entity entity = (Entity)entityDGV.CurrentRow.Cells[0].Value;
            if (!HideEntity(entity))
                AddToCombatChart(entity);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (entityDGV.CurrentRow.Index == -1)
                return;

            Entity entity = entityDGV.CurrentRow.Cells[0].Value as Entity;

            entitySet.Remove(entity);
            entityDGV.Rows.Remove(entityDGV.CurrentRow);
            HideEntity(entity);
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            NextPhase();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddEntityForm aef = new AddEntityForm();
            if(aef.ShowDialog() == DialogResult.OK)
            {
                AddEntity(aef.Entity);
                AddToCombatChart(aef.Entity);
                combatChartDGV.Invalidate();
            }
        }

        private void adjustButton_Click(object sender, EventArgs e)
        {
            if (entityDGV.CurrentRow.Index == -1)
                return;

            EntityAdjustmentForm eaf = new EntityAdjustmentForm();
            if(eaf.ShowDialog() == DialogResult.OK)
            {
                Entity entity = entityDGV.CurrentRow.Cells[0].Value as Entity;
                entity.Speed += eaf.SpeedAdjustment;
                entity.Dexterity += eaf.DexterityAdjustment;

                entityDGV.CurrentRow.Cells[1].Value = entity.Speed;
                entityDGV.CurrentRow.Cells[2].Value = entity.Dexterity;
                RefreshCombatChart();
            }
        }

        private void combatChartDGV_SelectionChanged(object sender, EventArgs e)
        {
            combatChartDGV.CurrentCell = null;
        }

        private void ColorColumn(int column, Color color)
        {
            DataGridViewCellStyle style = combatChartDGV.DefaultCellStyle.Clone();
            if (color != Color.Empty)
                style.BackColor = color;

            foreach (DataGridViewRow row in combatChartDGV.Rows)
                row.Cells[column].Style = style;
                
        }
    }
}
