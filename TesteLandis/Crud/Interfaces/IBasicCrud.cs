using System;
using System.Collections.Generic;
using System.Text;
using TesteLandis.Useful;

namespace TesteLandis.Crud.Interfaces
{
    public interface IBasicCrud<Entity>
    {
        public void Insert(Entity entity);
        public abstract void Edit(Entity entity);
        public void Remove(Entity entity);
        public List<Entity> List();
        public abstract Entity Find(string search);
    }
}
