using MongoDB.Bson;

namespace MongoDbTest
{
    internal class Dog
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}