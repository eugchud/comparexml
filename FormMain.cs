using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;

namespace CompareCFGs
{
    public partial class FormMain : Form
    {
        public string filename1 = string.Empty;
        public string filename2 = string.Empty;
        public int n1total = 0;

        List<List<int>> children1 = new List<List<int>>();
        List<List<int>> children2 = new List<List<int>>();

        List<List<int>> paths1 = new List<List<int>>();
        List<List<int>> paths2 = new List<List<int>>();

        public FormMain()
        {
            InitializeComponent();

            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler
                    (backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        private void processFile(string source, ref DataTable dataTable, ref List<List<int>> children)
        {

            XmlTextReader reader = new XmlTextReader(source);

            dataTable = new DataTable();
            DataColumn[] columns = { new DataColumn("ID"), new DataColumn("Элемент"), new DataColumn("Значение"), new DataColumn("Уровень"), new DataColumn("Родитель"), new DataColumn("Список детей"), new DataColumn("Дети"), new DataColumn("Имеются атрибуты"), new DataColumn("Результат сравнения"), new DataColumn("Соотв. элемент в друг. файле"), new DataColumn("Путь до узла"), new DataColumn("Номер узла в пути"), new DataColumn("Различий внутри") };
            dataTable.Columns.AddRange(columns);

            children = new List<List<int>>();
            int n = 1, lvl = 0, parent = 0, listnum = -1;
            string str = "", s="";
            bool prevCloser = false, prevSelfClosing = false;
            Object[] row1 = { "", "", "", "", "", "", "", "", "", "", "", "" };

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: //Нашли открывающий тег
                        if ((!prevCloser) && (!prevSelfClosing)) //Если уходим на уровень глубже
                        { 
                            lvl++;
                        }
                        str = reader.Name;


                        row1[0] = n;
                        row1[1] = "";
                        row1[2] = str;
                        row1[3] = lvl;
                        row1[4] = parent;
                        row1[5] = "";

                        if (parent != 0) //Добавляем элемент в список детей его родителя
                        {
                            s = dataTable.Rows[parent - 1][5].ToString();
                            children[int.Parse(s)].Add(n);
                            if (dataTable.Rows[parent - 1][6].ToString() != "")
                            {
                                dataTable.Rows[parent - 1][6] = dataTable.Rows[parent - 1][6].ToString() + ", " + n;
                            }
                            else
                            {
                                dataTable.Rows[parent - 1][6] = n;
                            }

                        }

                        if (!reader.IsEmptyElement) //Если является родителем чего-либо, то создаем список детей
                        {
                            parent = n;
                            listnum += 1;
                            row1[5] = listnum;
                            children.Add(new List<int>());
                        }
                        if (reader.AttributeCount != 0) { row1[7] = reader.AttributeCount; }
                        else { row1[7] = ""; }
                        dataTable.Rows.Add(row1);
                        n++;
                        for (int attInd = 0; attInd < reader.AttributeCount; attInd++) //Перебираем атрибуты, если таковые имеются
                        {
                            reader.MoveToAttribute(attInd);
                            row1[0] = n;
                            str = reader.Name;
                            row1[1] = str;
                            str = reader.Value;
                            row1[2] = str;
                            row1[3] = lvl;
                            row1[4] = "";
                            row1[5] = "";
                            row1[7] = "";
                            dataTable.Rows.Add(row1);
                            n++;
                        }
                        reader.MoveToElement();
                        prevCloser = false;
                        if (reader.IsEmptyElement) { prevSelfClosing = true; }
                        else { prevSelfClosing = false; }
                        break;

                    case XmlNodeType.EndElement:  //Нашли закрывающий тег
                        lvl--;
                        str = "</" + reader.Name + ">";
                        row1[0] = n;
                        row1[1] = "";
                        row1[2] = str;
                        row1[3] = lvl;
                        row1[4] = "";
                        row1[5] = "";
                        dataTable.Rows.Add(row1);
                        n++;
                        parent = int.Parse(dataTable.Rows[parent-1][4].ToString());
                        prevCloser = true;
                        n1total = n;
                        break;

                    case XmlNodeType.Text: //Нашли текстовое значение
                        dataTable.Rows[n-2][2] += " = " + reader.Value;
                        break;
                }


            }

        }

        private void buttonFile1Open_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxFile1Address.Text = openFileDialog.FileName;
                processFile(textBoxFile1Address.Text, ref Global.dataTable1, ref children1);
                buttonFile1Read.Enabled = true;
                buttonDebug1.Enabled = true;
                treeView1.Nodes.Clear();
                AddToTree(ref Global.dataTable1, new TreeNode(), treeView1, 1, ref children1, false);
            }
        }

        private void buttonFile1Read_Click(object sender, EventArgs e)
        {
            if (textBoxFile1Address.Text == null || textBoxFile1Address.Text == string.Empty)
            {
                MessageBox.Show("Файл 1 не выбран");
                return;
            }
            if (!File.Exists(textBoxFile1Address.Text))
            {
                MessageBox.Show("Файл 1 по заданному пути не существует");
                return;
            }
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            processFile(textBoxFile1Address.Text, ref Global.dataTable1, ref children1);
            treeView1.Nodes.Clear();
            AddToTree(ref Global.dataTable1, new TreeNode(), treeView1, 1, ref children1, false);
        }

        private void buttonFile2Open_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxFile2Address.Text = openFileDialog.FileName;
                processFile(textBoxFile2Address.Text, ref Global.dataTable2, ref children2);
                buttonFile2Read.Enabled = true;
                buttonDebug2.Enabled = true;
                treeView2.Nodes.Clear();
                AddToTree(ref Global.dataTable2, new TreeNode(), treeView2, 1, ref children2, false);
            }
        }

        private void buttonFile2Read_Click(object sender, EventArgs e)
        {
            if (textBoxFile2Address.Text == null || textBoxFile2Address.Text == string.Empty)
            {
                MessageBox.Show("Файл 2 не выбран");
                return;
            }
            if (!File.Exists(textBoxFile2Address.Text))
            {
                MessageBox.Show("Файл 2 по заданному пути не существует");
                return;
            }
            dataGridView2.DataSource = null;
            dataGridView2.Refresh();
            processFile(textBoxFile2Address.Text, ref Global.dataTable2, ref children2);
            treeView2.Nodes.Clear();
            AddToTree(ref Global.dataTable2, new TreeNode(), treeView2, 1, ref children2, false);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            string[] files = System.IO.Directory.GetFiles(Application.StartupPath, "*.htm");

            foreach (string file in files)
            {
                System.IO.File.Delete(file);
            }
        }

        private void doesntExist(int n, ref DataTable dataTable, ref List<List<int>> children)
        {
            if ((dataTable.Rows[n - 1][8].ToString() != "Совпадает и нет детей") && (dataTable.Rows[n - 1][8].ToString() != "Совпадает, дети не исследованы"))
            {
                dataTable.Rows[n - 1][8] = "Отсутствует";
                if (dataTable.Rows[n - 1][5].ToString() != "")
                {
                    foreach (int i in children[int.Parse(dataTable.Rows[n - 1][5].ToString())])
                    {
                        doesntExist(i, ref dataTable, ref children);
                    }
                }
            }
        }



        private void processChildren(ref DataTable dataTable_1, ref DataTable dataTable_2, int n1, int n2, ref List<List<int>> children1, ref List<List<int>> children2)
        {
            //Если у первого есть дети, а у второго нет
            if ((dataTable_1.Rows[n1 - 1][5].ToString() != "") && (dataTable_2.Rows[n2 - 1][5].ToString() == ""))
            {
                foreach (int i in children1[int.Parse(dataTable_1.Rows[n1 - 1][5].ToString())])
                {
                    doesntExist(i, ref dataTable_1, ref children1);
                }
            }
            //Если у второго есть дети, а у первого нет
            if ((dataTable_2.Rows[n2 - 1][5].ToString() != "") && (dataTable_1.Rows[n1 - 1][5].ToString() == ""))
            {
                foreach (int i in children2[int.Parse(dataTable_2.Rows[n2 - 1][5].ToString())])
                {
                    doesntExist(i, ref dataTable_2, ref children2);
                }
            }
            //Если у обоих есть дети
            bool foundname = false, foundmatch = false;
            int attributesNum1 = 0;
            int attributesNum2 = 0;
            int onesClosest = 0;
            int foundN1 = 0;
            int foundN2 = 0;
            int attributesNum1Found = 0;
            int attributesNum2Found = 0;
            string[,] attributes1Found = null;
            string[,] attributes2Found = null;

            if ((dataTable_1.Rows[n1 - 1][5].ToString() != "") && (dataTable_2.Rows[n2 - 1][5].ToString() != ""))
            {
                foreach (int i1 in children1[int.Parse(dataTable_1.Rows[n1 - 1][5].ToString())])
                {
                    foundname = false;
                    foundmatch = false;
                    attributesNum1 = 0;
                    attributesNum2 = 0;
                    onesClosest = 0;
                    foundN1 = 0;
                    foundN2 = 0;
                    attributesNum1Found = 0;
                    attributesNum2Found = 0;
                    attributes1Found = null;
                    attributes2Found = null;

                    foreach (int i2 in children2[int.Parse(dataTable_2.Rows[n2 - 1][5].ToString())])
                    {

                        if (dataTable_1.Rows[i1 - 1][2].ToString() == dataTable_2.Rows[i2 - 1][2].ToString()) // Если нашли детей с одинаковыми именами
                        {
                            foundname = true;

                            bool currmatch = false;

                            if (dataTable_1.Rows[i1 - 1][7].ToString() == "") //Если оба не имеют атрибутов
                            {
                                if (dataTable_2.Rows[i2 - 1][7].ToString() == "")
                                {
                                    dataTable_1.Rows[i1 - 1][9] = i2;
                                    dataTable_2.Rows[i2 - 1][9] = i1;
                                    foundmatch = true;
                                    currmatch = true;
                                }
                            }
                            else
                            {

                                attributesNum1 = int.Parse(dataTable_1.Rows[i1 - 1][7].ToString());
                                if (dataTable_2.Rows[i2 - 1][7].ToString() != "") //Если оба имеют атрибуты, то сравниваем их
                                {

                                    ///////////////////// СРАВНИТЕЛЬ АТРИБУТОВ //////////////////////////

                                    attributesNum2 = int.Parse(dataTable_2.Rows[i2 - 1][7].ToString());
                                    string[,] attributes1 = new string[attributesNum1, 4];
                                    for (int i = 0; i < attributesNum1; i++) //Считываем атрибуты первого
                                    {
                                        attributes1[i, 0] = dataTable_1.Rows[i1 + i][1].ToString();
                                        attributes1[i, 1] = dataTable_1.Rows[i1 + i][2].ToString();
                                        attributes1[i, 2] = "0";
                                        attributes1[i, 3] = "0";
                                    }
                                    string[,] attributes2 = new string[attributesNum2, 4];
                                    for (int i = 0; i < attributesNum2; i++) //Считываем атрибуты второго
                                    {
                                        attributes2[i, 0] = dataTable_2.Rows[i2 + i][1].ToString();
                                        attributes2[i, 1] = dataTable_2.Rows[i2 + i][2].ToString();
                                        attributes2[i, 2] = "0";
                                        attributes2[i, 3] = "0";
                                    }
                                    for (int i = 0; i < attributesNum1; i++) //Находим одинаковые атрибуты и сравниваем их значения
                                    {
                                        for (int j = 0; j < attributesNum2; j++)
                                        {
                                            if (attributes1[i, 0] == attributes2[j, 0])
                                            {
                                                attributes1[i, 2] = j.ToString();
                                                attributes2[j, 2] = i.ToString();
                                                if (attributes1[i, 1] == attributes2[j, 1])
                                                {
                                                    attributes1[i, 3] = "1";
                                                    attributes2[j, 3] = "1";
                                                }
                                            }
                                        }
                                    }

                                    int countOnes=0;
                                    if (attributesNum1 == attributesNum2) //Если количество атрибутов одинаковое
                                    {
                                        for (int i = 0; i < attributesNum1; i++)
                                        {
                                            if (attributes1[i, 3] == "1") countOnes++;
                                        }
                                        if (countOnes == attributesNum1) //Все поля совпали!
                                        {
                                            dataTable_1.Rows[i1 - 1][8] = "Совпадает, дети не исследованы";
                                            dataTable_1.Rows[i1 - 1][9] = i2;
                                            for (int i = 0; i < attributesNum1; i++)
                                            {
                                                if (attributes1[i, 3] == "1") dataTable_1.Rows[i1 + i][8] = "+";
                                                else dataTable_1.Rows[i1 + i][8] = "-";
                                            }
                                            dataTable_2.Rows[i2 - 1][8] = "Совпадает, дети не исследованы";
                                            dataTable_2.Rows[i2 - 1][9] = i1;
                                            for (int i = 0; i < attributesNum2; i++)
                                            {
                                                if (attributes2[i, 3] == "1") dataTable_2.Rows[i2 + i][8] = "+";
                                                else dataTable_2.Rows[i2 + i][8] = "-";
                                            }
                                            foundmatch = true;
                                            currmatch = true;
                                        }
                                        
                                    }


                                    ///////////////////// /СРАВНИТЕЛЬ АТРИБУТОВ //////////////////////////


                                }
                            }

                            //Если нашли совпадение
                            if (currmatch)
                            {
                                bool foundperfect = false;
                                string childrenof1 = dataTable_1.Rows[i1 - 1][6].ToString();
                                string childrenof2 = dataTable_2.Rows[i2 - 1][6].ToString();
                                if ((childrenof1 == "") && (childrenof2 == ""))     //И ни у одного нет детей
                                {
                                    dataTable_1.Rows[i1 - 1][8] = "Совпадает и нет детей";    //То помечаем соответствующим образом
                                    dataTable_2.Rows[i2 - 1][8] = "Совпадает и нет детей";
                                    foundperfect = true;
                                }
                                else  //А если есть, то перебираем их
                                {
                                    dataTable_1.Rows[i1 - 1][8] = "Совпадает, дети не исследованы";
                                    dataTable_2.Rows[i2 - 1][8] = "Совпадает, дети не исследованы";
                                    processChildren(ref dataTable_1, ref dataTable_2, i1, i2, ref children1, ref children2);
                                }
                                if (foundperfect)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    if (!foundmatch) //А если не нашли
                    {
                        if (!foundname) //То либо детей с таким же именем нет вообще
                        {
                            doesntExist(i1, ref dataTable_1, ref children1);
                        }

                        if (foundname) //Либо есть с тем же именем, но с другими атрибутами
                        {
                            doesntExist(i1, ref dataTable_1, ref children1);
                            dataTable_1.Rows[i1 - 1][8] = "Вероятно, отсутствует (не совпадают значения атрибутов)";
                        }
                    }


                }
            }


        }






        private void countDifferences(ref DataTable dataTable_1, int n1, ref List<List<int>> children1)
        {
            if (dataTable_1.Rows[n1 - 1][5].ToString() != "")
            {
                int diffsInside = 0;

                foreach (int i1 in children1[int.Parse(dataTable_1.Rows[n1 - 1][5].ToString())])
                {

                    if (dataTable_1.Rows[i1 - 1][8].ToString() == "Совпадает, дети не исследованы")
                    {
                        countDifferences(ref dataTable_1, i1, ref children1);
                    }

                    if ((dataTable_1.Rows[i1 - 1][8].ToString() == "Вероятно, отсутствует (не совпадают значения атрибутов)") || (dataTable_1.Rows[i1 - 1][8].ToString() == "Отсутствует"))
                    {
                        diffsInside++;
                    }

                }

                if (dataTable_1.Rows[n1 - 1][5].ToString() != "")
                {
                    foreach (int i in children1[int.Parse(dataTable_1.Rows[n1 - 1][5].ToString())])
                    {
                        if (dataTable_1.Rows[i - 1][12].ToString() != "")
                        {
                            diffsInside += int.Parse(dataTable_1.Rows[i - 1][12].ToString());
                        }
                    }
                }

                if (diffsInside == 0)
                {
                    dataTable_1.Rows[n1 - 1][8] = "Совпадает и все дети совпадают";
                }
                else
                {
                    dataTable_1.Rows[n1 - 1][8] = "Cовпадает, дети различаются";
                    dataTable_1.Rows[n1 - 1][12] = diffsInside;
                }
            }
        }


            private void buttonSearchWithAlg_Click(object sender, EventArgs e)
        {
            if (textBoxFile1Address.Text == null || textBoxFile1Address.Text == string.Empty)
            {
                MessageBox.Show("Файл 1 не выбран");
                return;
            }
            if (!File.Exists(textBoxFile1Address.Text))
            {
                MessageBox.Show("Файл 1 по заданному пути не существует");
                return;
            }
            if (textBoxFile2Address.Text == null || textBoxFile2Address.Text == string.Empty)
            {
                MessageBox.Show("Файл 2 не выбран");
                return;
            }
            if (!File.Exists(textBoxFile2Address.Text))
            {
                MessageBox.Show("Файл 2 по заданному пути не существует");
                return;
            }

            label1.Visible = true;

            treeView1.Enabled = false;
            treeView2.Enabled = false;
            buttonDebug1.Enabled = false;
            buttonDebug2.Enabled = false;
            buttonFile1Open.Enabled = false;
            buttonFile2Open.Enabled = false;
            buttonFile1Read.Enabled = false;
            buttonFile2Read.Enabled = false;
            menuStrip1.Enabled = false;
            textBoxFile1Address.Enabled = false;
            textBoxFile2Address.Enabled = false;
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView2.DataSource = null;
            dataGridView2.Refresh();
            dataGridView1.Enabled = false;
            dataGridView2.Enabled = false;

            treeView1.Nodes.Clear();
            treeView2.Nodes.Clear();

            backgroundWorker1.RunWorkerAsync();
            

        }

        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Готово\n");
            label1.Visible = false;

            treeView1.Enabled = true;
            treeView2.Enabled = true;
            buttonDebug1.Enabled = true;
            buttonDebug2.Enabled = true;
            buttonFile1Open.Enabled = true;
            buttonFile2Open.Enabled = true;
            buttonFile1Read.Enabled = true;
            buttonFile2Read.Enabled = true;
            menuStrip1.Enabled = true;
            textBoxFile1Address.Enabled = true;
            textBoxFile2Address.Enabled = true;
            dataGridView1.Enabled = true;
            dataGridView2.Enabled = true;

            AddToTree(ref Global.dataTable1, new TreeNode(), treeView1, 1, ref children1, true);
            AddToTree(ref Global.dataTable2, new TreeNode(), treeView2, 1, ref children2, true);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            allThatStuff();
        }

        private void allThatStuff()
        {
            clearTable(ref Global.dataTable1);
            clearTable(ref Global.dataTable2);
            processChildren(ref Global.dataTable1, ref Global.dataTable2, 1, 1, ref children1, ref children2);
            processChildren(ref Global.dataTable2, ref Global.dataTable1, 1, 1, ref children2, ref children1); //На самом деле, можно быстрее
            countDifferences(ref Global.dataTable1, 1, ref children1);
            countDifferences(ref Global.dataTable2, 1, ref children2);
        }

        private void clearTable(ref DataTable dataTable)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataTable.Rows[i][8] = "";
                dataTable.Rows[i][9] = "";
                dataTable.Rows[i][12] = "";
            }
        }


        private void buttonDebug1_Click(object sender, EventArgs e)
        {
            FormDebug1 f2 = new FormDebug1();
            f2.Show();
        }

        private void buttonDebug2_Click(object sender, EventArgs e)
        {
            FormDebug2 f3 = new FormDebug2();
            f3.Show();
        }

        private void AddToTree(ref DataTable dataTable, TreeNode currNode, TreeView treeView, int n1, ref List<List<int>> children, bool withComparsionResults)
        {
            TreeNode added = null;
            if (!withComparsionResults)
            {
                    added = new TreeNode(dataTable.Rows[n1 - 1][2].ToString());
            }
            else
            {

                string compResult = dataTable.Rows[n1 - 1][8].ToString();
                Color c = Color.Black;
                string prefix = "";
                switch (compResult)
                {
                    case "Отсутствует":
                        c = Color.Red;
                        break;
                    case "Совпадает и нет детей":
                        c = Color.Green;
                        break;
                    case "Совпадает и все дети совпадают":
                        c = Color.Green;
                        break;
                    case "Совпадает, дети не исследованы":
                        c = Color.Blue;
                        break;
                    case "Cовпадает, дети различаются":
                        c = Color.Blue;
                        break;
                    case "Вероятно, отсутствует (не совпадают значения атрибутов)":
                        c = Color.DarkRed;
                        break;
                }

                if (dataTable.Rows[n1 - 1][12].ToString() != "")
                {
                    prefix = " (" + dataTable.Rows[n1 - 1][12].ToString() + ") ";
                }

                added = new TreeNode(prefix + dataTable.Rows[n1 - 1][2].ToString());
                added.ForeColor = c;


            }

            if (n1 == 1)
            {
                treeView.Nodes.Add(added);

                dataTable.Rows[n1 - 1][10] = 0;

                dataTable.Rows[n1 - 1][11] = 0;

            }
            else
            {
                currNode.Nodes.Add(added);

                //Записываем путь

                List<int> indices = new List<int>();

                TreeNode node = added;
                while (node != null)
                {
                    indices.Insert(0, node.Index);
                    node = node.Parent;
                }

                string path = String.Join("-", indices);
                dataTable.Rows[n1 - 1][10] = path;

            } 
            if (dataTable.Rows[n1 - 1][5].ToString() != "")
            {
                int n = 0;
                foreach (int i in children[int.Parse(dataTable.Rows[n1 - 1][5].ToString())])
                {
                    AddToTree(ref dataTable, added, treeView, i, ref children, withComparsionResults);
                    dataTable.Rows[i - 1][11] = n;
                    n++;
                }
            }
                
        }


        private void getAttributes(TreeView treeView, DataTable dataTable, List<List<int>> children, DataGridView dataGridView)
        {
            TreeNode tempnode = treeView.SelectedNode;

            //Получаем путь
            List<int> indices = new List<int>();
            TreeNode node = tempnode;
            while (node.Parent != null)
            {
                indices.Insert(0, node.Index);
                node = node.Parent;
            }

            int n = 1;
            string next = "";

            foreach (int i in indices)
            {
                next = dataTable.Rows[n - 1][5].ToString();
                n = children[int.Parse(next)][i];
            }

            DataTable attrTable = new DataTable();
            DataColumn[] columns = { new DataColumn("Атрибут"), new DataColumn("Значение") };
            attrTable.Columns.AddRange(columns);

            Object[] newRow = { "", "" };

            if (dataTable.Rows[n - 1][7].ToString() != "")
            {
                for (int j = 0; j < int.Parse(dataTable.Rows[n - 1][7].ToString()); j++)
                {
                    newRow[0] = dataTable.Rows[n + j][1];
                    newRow[1] = dataTable.Rows[n + j][2];
                    attrTable.Rows.Add(newRow);
                }
            }

            dataGridView.DataSource = attrTable;
            dataGridView.Columns[0].Width = 150;
            dataGridView.Columns[1].Width = 193;



        }
         

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) //Для выранного в TreeView элемента получаем его атрибуты
        {
            getAttributes(treeView1, Global.dataTable1, children1, dataGridView1);
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            getAttributes(treeView2, Global.dataTable2, children2, dataGridView2);
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        }

    }