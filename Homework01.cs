namespace Homework01
{
    interface IProductionFactory
    {
        void Produce_Duck_Neck();//鸭脖
        void Produce_Duck_Wing();//鸭翅
    }
    public class WuhanFactory : IProductionFactory
    {//武汉工厂能生生产鸭脖和鸭翅
        public void Produce_Duck_Neck()
        {
            Console.WriteLine("武汉工厂可以生产鸭脖。");
        }

        public void Produce_Duck_Wing()
        {
            Console.WriteLine("武汉工厂可以生产鸭翅。");
        }
    }
    public class NanjingFactory : IProductionFactory
    {//南京工厂只能生产鸭翅
        public void Produce_Duck_Neck()
        {
            Console.WriteLine("南京工厂不能生产鸭脖。");
            //throw new NotSupportedException("不能生产...");
        }

        public void Produce_Duck_Wing()
        {
            Console.WriteLine("南京工厂只能生产鸭翅。");
        }
    }
    public class ChangshaFactory : IProductionFactory
    {//长沙工厂只能生产鸭脖
        public void Produce_Duck_Neck()
        {
            Console.WriteLine("长沙工厂只能生产鸭脖。");
        }

        public void Produce_Duck_Wing()
        {
            Console.WriteLine("长沙工厂不能生产鸭翅。");
            ////throw new NotSupportedException("不能生产...");
        }
    }
    delegate void ProductionDelegate();
    internal class Homework01
    {
        static void Main(string[] args)
        {
            //创建三个城市工厂的实例
            WuhanFactory wuhanFactory = new WuhanFactory();
            NanjingFactory nanjingFactory = new NanjingFactory();
            ChangshaFactory changshaFactory = new ChangshaFactory();

            //给委托赋值
            ProductionDelegate productionDelegate1 = new ProductionDelegate(wuhanFactory.Produce_Duck_Neck);
            ProductionDelegate productionDelegate2 = new ProductionDelegate(wuhanFactory.Produce_Duck_Wing);
            ProductionDelegate productionDelegate3 = new ProductionDelegate(nanjingFactory.Produce_Duck_Neck);
            ProductionDelegate productionDelegate4 = new ProductionDelegate(nanjingFactory.Produce_Duck_Wing);
            ProductionDelegate productionDelegate5 = new ProductionDelegate(changshaFactory.Produce_Duck_Neck);
            ProductionDelegate productionDelegate6 = new ProductionDelegate(changshaFactory.Produce_Duck_Wing);

            //调用委托进行生产
            Console.WriteLine("武汉工厂：");
            productionDelegate1();
            productionDelegate2();
            Console.WriteLine("南京工厂：");
            productionDelegate3();
            productionDelegate4();
            Console.WriteLine("长沙工厂：");
            productionDelegate5();
            productionDelegate6();
        }
    }
}
