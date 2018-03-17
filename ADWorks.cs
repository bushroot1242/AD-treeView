using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADUsers
{
    class ADWorks
    {
        public ADWorks()
        {
            string NabChelnyUsersDataSet = "LDAP://OU=НЧ,OU=РФ,DC=kamaz,DC=org";
            DirectoryEntry AD = new DirectoryEntry();
            List<DirectoryEntry> s = getChildren(NabChelnyUsersDataSet);
            foreach (DirectoryEntry entry in s)
            {

                //tvADtree.Nodes.Add(entry.Name);
                if (getChildren(entry.Path).Count > 0)
                {
                    List<DirectoryEntry> s1 = getChildren(entry.Path);
                    foreach (DirectoryEntry ent in s1)
                    {
                        //tvADtree.Nodes.Add("   " + ent.Name);
                    }
                }
            }

        }

        List<DirectoryEntry> getChildren(string parent)
        {
            List<DirectoryEntry> children = new List<DirectoryEntry>();
            DirectoryEntry rootEntry = new DirectoryEntry(parent);
            foreach (DirectoryEntry e in rootEntry.Children)
            {
                children.Add(e);
            }
            return children;
        }

    }
}
