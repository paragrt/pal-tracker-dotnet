using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Aerospike.Client;
using ProtoBuf;

namespace myApp
{
    class Program
    {
        static AerospikeClient client = new AerospikeClient("192.168.0.117", 3000);

        static string ProtoBufSet = "ProtoBufSet";
        static string FlatDataSet = "FlatDataSet";

        public static void Main(string[] args)
        {
            int count = 10;
            try
            {
                count = Int32.Parse(args[0]);
            }
            catch (Exception ignore) { }
            Console.WriteLine("writing " + count + " person Objects");

            try
            {
                client.Truncate(null, "test", FlatDataSet, DateTime.MinValue);
            }
            catch (Exception ignore) { }
            try
            {
                client.Truncate(null, "test", "flatDataSet", DateTime.MinValue);
            }
            catch (Exception ignore) { }
            try
            {
                client.Truncate(null, "test", ProtoBufSet, DateTime.MinValue);
            }
            catch (Exception ignore) { }
            List<Person> pList = new List<Person>();
            for(int i = 0; i < count; i++)
            {
                pList.Add(Person.GetP());
            }
            storeFlatData(pList);
            storeProtobuf(pList);
        }


        static void storeFlatData(List<Person> pList)
        {

            int i = 0;
            foreach (Person p in pList)
            {
                Key key = new Key("test", FlatDataSet, ""+i++);
                Bin[] binArray = new Bin[21];
                binArray[0] = new Bin("Id", p.Id);
                binArray[1] = new Bin("Name", p.Name);
                binArray[2] = new Bin("Line1", p.Line1);
                binArray[3] = new Bin("Line2", p.Line2);
                binArray[4] = new Bin("Age", p.Age);
                binArray[5] = new Bin("Salary", p.Salary);
                binArray[6] = new Bin("Bal7", p.Bal7);
                binArray[7] = new Bin("Bal8", p.Bal8);
                binArray[8] = new Bin("Bal9", p.Bal9);
                binArray[9] = new Bin("Bal10", p.Bal9);
                binArray[10] = new Bin("Bal11", p.Bal9);
                binArray[11] = new Bin("Bal12", p.Bal9);
                binArray[12] = new Bin("Bal13", p.Bal9);
                binArray[13] = new Bin("Bal14", p.Bal9);
                binArray[14] = new Bin("Bal15", p.Bal9);
                binArray[15] = new Bin("Bal16", p.Bal9);
                binArray[16] = new Bin("Bal17", p.Bal9);
                binArray[17] = new Bin("Bal18", p.Bal9);
                binArray[18] = new Bin("Bal19", p.Bal9);
                binArray[19] = new Bin("Bal20", p.Bal9);
                binArray[20] = new Bin("Bal21", p.Bal9);
                client.Put(null, key, binArray);

                Record r = client.Get(null, key);
                //Console.WriteLine("Person 2 = " + r.GetString("Name"));
            }
        }
        static void storeProtobuf(List<Person> pList)
        {
            int i = 0;
            foreach (Person p in pList)
            {


                Key key = new Key("test", ProtoBufSet, ""+i++);

                byte[] bArr = Person.ProtoSerialize(p);
                Bin b = new Bin("bPerson", bArr);
                client.Put(null, key, b);

                Record r = client.Get(null, key);
                
                Person p2 = Person.ProtoDeserialize((byte[])r.GetValue("bPerson"));

                //Console.WriteLine("Person 2 = " + p2.Name);
            }
        }
    }
    [ProtoContract]
    class Person
    {
        static Random rand = new Random();
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public string Line1 { get; set; }
        [ProtoMember(4)]
        public string Line2 { get; set; }
        [ProtoMember(5)]
        public int Age { get; set; }
        [ProtoMember(6)]
        public double Salary { get; set; }
        [ProtoMember(7)]
        public double Bal7 { get; set; }
        [ProtoMember(8)]
        public double Bal8 { get; set; }
        [ProtoMember(9)]
        public double Bal9 { get; set; }
        [ProtoMember(10)]
        public double Bal10 { get; set; }
        [ProtoMember(11)]
        public double Bal11 { get; set; }
        [ProtoMember(12)]
        public double Bal12 { get; set; }
        [ProtoMember(13)]
        public double Bal13 { get; set; }
        [ProtoMember(14)]
        public double Bal14 { get; set; }
        [ProtoMember(15)]
        public double Bal15 { get; set; }
        [ProtoMember(16)]
        public double Bal16 { get; set; }
        [ProtoMember(17)]
        public double Bal17 { get; set; }
        [ProtoMember(18)]
        public double Bal18 { get; set; }
        [ProtoMember(19)]
        public double Bal19 { get; set; }
        [ProtoMember(20)]
        public double Bal20 { get; set; }
        [ProtoMember(21)]
        public double Bal21 { get; set; }

        public static Person GetP()
        {
            Person p = new Person();
            p.Id = rand.Next();
            p.Name = "MyName_" + rand.Next(1, 2000);
            p.Line1 = "Line 1_" + rand.Next(1, 2000);
            p.Line2 = "Line 2_" + rand.Next(1, 2000);
            p.Age = rand.Next(1, 100);
            p.Salary = rand.Next() * 200000.0D;
            p.Bal7 = rand.Next();
            p.Bal8 = rand.Next();
            p.Bal9 = rand.Next();
            p.Bal10 = rand.Next();
            p.Bal11 = rand.Next();
            p.Bal12 = rand.Next();
            p.Bal13 = rand.Next();
            p.Bal14 = rand.Next();
            p.Bal15 = rand.Next();
            p.Bal16 = rand.Next();
            p.Bal17 = rand.Next();
            p.Bal18 = rand.Next();
            p.Bal19 = rand.Next();
            p.Bal20 = rand.Next();
            p.Bal21 = rand.Next();
            return p;
        }
        public static byte[] ProtoSerialize(Person record)
        {
            if (null == record) return null;

            try
            {
                using (var stream = new MemoryStream())
                {
                    Serializer.Serialize(stream, record);
                    return stream.ToArray();
                }
            }
            catch
            {
                // Log error
                throw;
            }
        }
        public static Person ProtoDeserialize(byte[] data)
        {
            if (null == data) return null;

            try
            {
                using (var stream = new MemoryStream(data))
                {
                    return Serializer.Deserialize<Person>(stream);
                }
            }
            catch
            {
                // Log error
                throw;
            }
        }
    }   
}