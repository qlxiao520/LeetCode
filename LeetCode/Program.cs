using System;
using System.Reflection;
namespace LeetCode {
    using questions;
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("----------LeetCode Test Start:----------");
            //获取当前命名空间下所有类
            Type[] t = Assembly.GetExecutingAssembly ().GetTypes ();
            foreach (var item in t) {
                //如果包含命名LeetCode_,通过反射执行该类
                if (item.Name.Contains ("LeetCode_")) {
                    object obj = Activator.CreateInstance (item, true);
                    item.GetMethod ("Test").Invoke (obj, null);
                }
            }
            Console.WriteLine ("----------LeetCode Test End:------------");
        }
    }
}
