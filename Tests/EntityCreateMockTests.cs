namespace CpfLibrary.Test
{
    using CreateRandomEntityValuesLibrary;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class EntityCreateMockTests
    {
        [TestMethod]
        public void Valid()
        {
            var ret = Entity.CreateMock<test>();

            Assert.IsNotNull(ret);  
        }
    }

    public class test
    {
        public test_2 test_2 { get; set; }
        public byte img { get; set; }
        public sbyte img_2 { get; set; }
        public Guid cody { get; set; }
        public int id { get; set; }
        public int? count { get; set; }
        public char tag { get; set; }
        public char status { get; set; }
        public bool check { get; set; }
        public decimal price { get; set; }
        public double price_2 { get; set; }
        public float price_3 { get; set; }
        public uint count_2 { get; set; }
        public long count_3 { get; set; }
        public ulong count_4 { get; set; }
        public short count_5 { get; set; }
        public ushort count_6 { get; set; }
        public string name { get; set; }
    }

    public class test_2
    {
        public string lastName { get; set; }
    }
}
