namespace LeetCode {
    using System.Reflection;
    using System;
    public class LeetCode {
        Type t; //取类名
        public string MethodName; //要执行的测试方法
        public string Tag;  //暂未使用。计划是标注题目类型
        public LeetCode () {
            t = GetType ();
        }
        public virtual void Test () { }//每个leetcode必须有测试方法

        public void AreEqual<T1, T2> (T1 testcaseA, T2 testcaseB) {
            if (MethodName != null) {
                //指定一个methodName来获取当前leetcode的待执行函数
                var input = t.GetMethod (MethodName);

                if (input != null) {
                    //因为对比的类型，调用函数的返回类型必然是expect T2的类型
                    //使用反射 Invoke调用函数，如果不需要参数就传个null
                    T2 result = (T2) input.Invoke (this, new object[] { testcaseA });

                    if (result.Equals (testcaseB)) {
                        Console.WriteLine ($"{t.Name} TestCase Passed!, result: {result}, expect: {testcaseB}");
                    } else {
                        Console.WriteLine ($"{t.Name} TestCase Failed!, result: {result}, expect: {testcaseB}");
                    }

                } else {
                    Console.WriteLine ($"{t.Name} GetMethod({MethodName}) is null!");
                }

            } else {
                //Console.WriteLine ($"{t.Name} has no MethondName, Pass");
            }

        }
        public void AreEqual<T1, T2> (T1 testcaseA, T1 testcaseB, T2 testcaseC) {
            if (MethodName != null) {
                //指定一个methodName来获取当前leetcode的待执行函数
                var input = t.GetMethod (MethodName);

                if (input != null) {
                    //因为对比的类型，调用函数的返回类型必然是expect T2的类型
                    //使用反射 Invoke调用函数，如果不需要参数就传个null
                    T2 result = (T2) input.Invoke (this, new object[] { testcaseA, testcaseB });

                    if (result.Equals (testcaseC)) {
                        Console.WriteLine ($"{t.Name} TestCase Passed!, result: {result}, expect: {testcaseC}");
                    } else {
                        Console.WriteLine ($"{t.Name} TestCase Failed!, result: {result}, expect: {testcaseC}");
                    }

                }

            } else {
                //Console.WriteLine ($"{t.Name} has no MethondName, Pass");
            }

        }
    }
}