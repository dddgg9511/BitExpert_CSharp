using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberLib
{
    public class MemberInfo
    {
        internal string Name { get; private set; }
        internal string Addr { get; private set; }
        internal MemberInfo(string name, string addr)
        {
            Name = name;
            Addr=addr;
        }
        public override string ToString()
        {
            return Name;
        }
    }

    public class Mamber
    {
        MemberInfo mi = null;
        public string Name
        {
            get
            {
                return mi.Name;
            }
        }
        public string Addr  //다른 어셈블리에서 접근 가능
        {
            get
            {
                return mi.Addr;
            }
        }
        public Mamber(string name,string addr)  //다른 어셈블리에서 접근 가능
        {
            mi = new MemberInfo(name,addr);
        }

        public override string ToString()   //다른 어셈블리에서 접근 가능
        {
            return mi.ToString();
        }
    }
}
