using System;

namespace 反射委托
{
    class Program
    {
        static void Main(string[] args)
        {
            // 调用的目标实例。
            var instance = new StubClass();

            // 使用反射找到的方法。
            var method = typeof(StubClass).GetMethod(nameof(StubClass.Test), new[] { typeof(int),typeof(bool) });

            var d=(Func<int, bool, int>)method.CreateDelegate(typeof(Func<int, bool, int>),instance);
            d(5,true);
        }
    }

    class StubClass
    {
        public int Test(int i,bool flag)
        {
            return i;
        }
    }
}
