using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDemo
{

    public class People
    {
        [StringLength(MaximumLength = 1000, Desc = "IAmName")]
        public string Name { get; set; }

        [StringLength(MaximumLength = 1000)]
        public string Description { get; set; }
        [StringLength(Desc = "IAnDesc")]
        public string PeopleDesc { get; set; }
    }
    class Program
    {

        /*
         Attribute  特性 一般 是写框架的时候使用的, 
             
             */


        static void Main(string[] args)
        {
            var people = new People()
            {
                Name = "qweasdzxcasdqweasdzxc",
                Description = "description",
                PeopleDesc = "helloWorld"
            };
            try
            {
                new ValidationModel().Validate(people);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }



        //   MemberInfo, FieldInfo, MemberInfo  的区别
        static void Main11(string[] args)
        {

            myClass aa = new myClass();
            PropertyInfo[] pro = aa.GetType().GetProperties();  // 所有的属性
            FieldInfo[] fil = aa.GetType().GetFields();     // 所有的字段
            MemberInfo[] men = aa.GetType().GetMembers();
            foreach (var item in pro)
            {
                Console.WriteLine(item.GetValue(aa) + "|" + item.Name + "|" + (item.GetCustomAttributes(typeof(DescriptionAttribute), false).First() as DescriptionAttribute).Description);
            }
            Console.WriteLine("FieldInfo的循环");
            foreach (FieldInfo item in fil)
            {
                Console.WriteLine(item.GetValue(aa) + "|" + item.Name + "|" + (item.GetCustomAttributes(typeof(DescriptionAttribute)).First() as DescriptionAttribute).Description);
            }
            Console.WriteLine("MemberInfo的循环");
            foreach (MemberInfo item in fil)
            {
                Console.WriteLine("|" + item.Name + "|" + (item.GetCustomAttributes(typeof(DescriptionAttribute)).First() as DescriptionAttribute).Description);
            }

            Console.ReadKey();
        }
    }


    public class myClass
    {
        private int a = 1;
        [Description("2描述")]
        public int A { get; set; } = 2;
        [Description("4私有属性")]
        private int APu { get; set; } = 20;
        [Description("4私有属性")]
        private int APr { get; set; } = 30;
        [Description("3描述")]
        public int b = 3;
    }


}
