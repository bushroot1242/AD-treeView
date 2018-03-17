using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;


namespace ActiveDirectoryTree
{
    public partial class FADTreeView : Form
    {
        public FADTreeView()
        {
            InitializeComponent();
            string[] Root = ReadRoot("");
            /*получаем данные о корне*/
            TreeNode MyNodes = new TreeNode()
            {
                Text = Root[0],
                Name = Root[1]
            };

            /*читаем все под ветки передаем ID родителя*/
            List<ADinfo> Child = ReadChilds(Root[1]);
            /*создаем найденные ветки к нашей MyNodes*/

            foreach (ADinfo N in Child)
            {
                /*создаем дочернюю ветку*/
                TreeNode MyNodesChilds = new TreeNode()
                {

                    Text = N.Name,

                    Name = N.GUID

                };

                /*добавляем ветку к корню*/

                MyNodes.Nodes.Add(MyNodesChilds);

            }

            /*добавляем ветки к редеву*/

            tvAD.Nodes.Add(MyNodes);

        }

        /*читаем параметры указанной ветки*/
        string[] ReadRoot(string ID)
        {
            /*обьявляем обьект работы с AD*/
            DirectoryEntry AD;
            /*если ID будет пустым значит читаем корень, если не пустым значит читаем данные об обьекте который выбран*/
            if (ID == "") AD = new DirectoryEntry(); else AD = new DirectoryEntry("LDAP://<GUID=" + ID + ">");
            /*читаем свойства полученного элемента*/
            /*обьявляем в массиве два параметра*/
            string[] Dinfo ={
                AD.Name, //будем хранить имя
                AD.Guid.ToString() //будем хранить ID
                             };
            /*возвращаем данные в виде массива*/
            return Dinfo;

        }

        List<ADinfo> ReadChilds(string ID)
        {

            List<ADinfo> Childs = new List<ADinfo>();
            DirectoryEntry AD;
            if (ID == "") AD = new DirectoryEntry(); else AD = new DirectoryEntry("LDAP://<GUID=" + ID + ">");
            DirectoryEntries D = AD.Children;

            /*создаем курсор для чтения потомков*/

            System.Collections.IEnumerator Reed = D.GetEnumerator();

            /*обьявляем что будем использовать структуру*/

            ADinfo Param;

            /*Двигаем курсор на следующего потомка*/

            while (Reed.MoveNext())

            {

                /*получаем данные о ветке*/

                DirectoryEntry Info = Reed.Current as DirectoryEntry;

                Param.Name = Info.Name; //сохраняем имя

                Param.GUID = Info.Guid.ToString(); //сохраняем номер

                /*сохраняем данные в список*/

                Childs.Add(Param);

            }

            return Childs;

        }

        private void tvAD_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            /*получаем ветку по которому дернул пользователь*/

            TreeNode s = tvAD.SelectedNode;

            /*получаем список дочерних элементов*/

            /*читаем все под ветки передаем ID родителя*/

            List<ADinfo> Child = ReadChilds(s.Name);

            /*очистим содержимое ветки */

            s.Nodes.Clear();

            /*создаем найденные ветки к нашей MyNodes*/

            foreach (ADinfo N in Child)

            {

                /*создаем дочернюю ветку*/

                TreeNode MyNodesChilds = new TreeNode()

                {

                    Text = N.Name,

                    Name = N.GUID

                };

                /*добавляем ветку к выбранному корню*/

                s.Nodes.Add(MyNodesChilds);

            }

        }
    }

    struct ADinfo

    {

        public string Name, GUID;

    }
}
