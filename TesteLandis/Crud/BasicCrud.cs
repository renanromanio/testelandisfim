using System.Collections.Generic;
using TesteLandis.Crud.Interfaces;
using TesteLandis.Useful;

namespace TesteLandis.Crud
{
    public abstract class BasicCrud<Entity> : IBasicCrud<Entity>
    {
        private static List<Entity> Database;
        public BasicCrud()
        {
            Database = new List<Entity>();
        }
        public abstract void Edit(Entity entity);

        public abstract Entity Find(string search);

        public void Insert(Entity entity)
        {
            Database.Add(entity);
        }

        public List<Entity> List()
        {
            return Database;
        }

        public void Remove(Entity entity)
        {

            Database.Remove(entity);
        }
    }
}
