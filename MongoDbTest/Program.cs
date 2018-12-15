using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //插入

            MongoClient client = new MongoClient("mongodb://localhost");
            IMongoDatabase database = client.GetDatabase("TestDb1");//相当于数据库

            //IMongoCollection<Person> collection = database.GetCollection<Person>("Persons");//大致相当于“表”
            //Person p1 = new Person();
            //p1.Id = 2;
            //p1.Name = "rupeng";
            //p1.Age = 5;
            //collection.InsertOne(p1);//也支持异步方法，后面建议都用异步的！习惯成自然！

            //IMongoCollection<Dog> dogs = database.GetCollection<Dog>("Dogs");
            //Dog d1 = new Dog();
            //d1.Age = 33;
            //d1.Name = "da huang";
            //Console.WriteLine(d1.Id);
            //dogs.InsertOne(d1);
            //Console.WriteLine(d1.Id);

            //IMongoCollection<BsonDocument> dogs = database.GetCollection<BsonDocument>("Dogs");
            //string json = "{id:8889,Age:81,Name:'xiao lan',gender:true}";
            //BsonDocument p1 = BsonDocument.Parse(json);
            //dogs.InsertOne(p1);

            //IMongoCollection<Dog> dogs = database.GetCollection<Dog>("Dogs");
            //Dog d1 = new Dog();
            //d1.Age = 55;
            //d1.Name = "da zi";
            //Dog d2 = new Dog();
            //d2.Age = 66;
            //d2.Name = "da hong";
            //Dog d3 = new Dog();
            //d3.Age = 77;
            //d3.Name = "da lv";
            //List<Dog> dogList = new List<Dog>();
            //dogList.Add(d1);
            //dogList.Add(d2);
            //dogList.Add(d3);
            //dogs.InsertMany(dogList);

            //查询

            //IMongoCollection<Dog> collection = database.GetCollection<Dog>("Dogs");
            //var filter1 = Builders<Dog>.Filter.Gt(p => p.Age, 5);//Gt：大于。
            //var dogs = collection.Find<Dog>(filter1);
            //foreach (var item in dogs.ToList())
            //{
            //    Console.WriteLine(item.Name+","+item.Age+","+item.Id);
            //}

            //IMongoCollection<Dog> collection = database.GetCollection<Dog>("Dogs");
            //var filter1 = Builders<Dog>.Filter.Gt(p => p.Age, 5);//Gt：大于。
            //using (var personsCursor =  collection.FindAsync<Dog>(filter1,new FindOptions<Dog, Dog>() { BatchSize=100}).Result)
            //{
            //    //while (personsCursor.MoveNext())
            //    //{
            //    //    var persons = personsCursor.Current;
            //    //    foreach (var p in persons)
            //    //    {
            //    //        Console.WriteLine(p.Name);
            //    //    }
            //    //}

            //    var personList = personsCursor.ToList();
            //    foreach (var p in personList)
            //    {
            //        Console.WriteLine(p.Name);
            //    }
            //}

            #region 分页

            //FindOptions<Dog, Dog> findOpt = new FindOptions<Dog, Dog>();
            //findOpt.Limit = 2;//取最多几条
            //findOpt.Skip = 2;//跳过几条

            ////指定排序规则：
            //findOpt.Sort = Builders<Dog>.Sort.Descending(p => p.Age).Ascending(p => p.Name);
            ////findOpt.Sort = Builders<Dog>.Sort.Descending(p => p.Age);
            ////findOpt.Sort = Builders<Dog>.Sort.Ascending(p => p.Age).Descending(p => p.Name);

            ////var filter1 = Builders<Dog>.Filter.Where(p => p.Age >= 5 && p.Name == "da huang");
            //var filter1 = Builders<Dog>.Filter.Where(p => p.Age >= 5);

            //IMongoCollection<Dog> collection = database.GetCollection<Dog>("Dogs");
            //using (var personsCursor =  collection.FindAsync(filter1, findOpt).Result)
            //{
            //    foreach (var p in  personsCursor.ToListAsync().Result)
            //    {
            //        Console.WriteLine(p.Name);
            //    }
            //} 
            
            #endregion



            //BsonDocument

            //IMongoCollection<BsonDocument> persons = database.GetCollection<BsonDocument>("Persons");
            //var filter1 = Builders<BsonDocument>.Filter.Eq("Age", 5);
            //using (var personsCursor =  persons.FindAsync(filter1).Result)
            //{
            //    foreach (var p in  personsCursor.ToListAsync().Result)
            //    {
            //        Console.WriteLine(p.GetValue("Name"));
            //    }
            //}

            //更新、删除

            //IMongoCollection<Person> teachers = database.GetCollection<Person>("Persons");
            //var filter = Builders<Person>.Filter.Where(p => p.Age <= 5);
            //var update = Builders<Person>.Update
            //.Set(p => p.Age, 8);
            //teachers.UpdateMany(filter, update);

            IMongoCollection<Person> teachers = database.GetCollection<Person>("Persons");
            var filter = Builders<Person>.Filter.Where(p => p.Age > 6);
            teachers.DeleteMany(filter);


            Console.WriteLine("ok");

            Console.ReadKey();
        }
    }
}
