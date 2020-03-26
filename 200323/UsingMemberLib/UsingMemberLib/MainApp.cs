using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemberInfo;

namespace UsingMemberLib
{
    class MainApp
    {
        static void Main(string[] args)
        {
            Mamber member = new Mamber("홍길동", "대한민국"); ;
            Console.WriteLine("이름 : {0} 주소 : {1}", member.Name, member.Addr);
        }
    }
}
