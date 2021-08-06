using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteLandis.Crud.Interfaces;
using TesteLandis.Entidades;
using TesteLandis.Useful;

namespace TesteLandis.Crud
{
    public class EndpointCrud : BasicCrud<Endpoint>, IEndpointCrud
    {
        public override void Edit(Endpoint entity)
        {
            var oldEntity = (from oldEndPoint in List()
                             where oldEndPoint.EndpointSerialNumber == entity.EndpointSerialNumber
                             select oldEndPoint).FirstOrDefault();
            Remove(oldEntity);
            Insert(entity);


        }

        public override Endpoint Find(string search)
        {
            var endpoint = List().FirstOrDefault(x => x.EndpointSerialNumber.Equals(search));
            return endpoint;
        }
    }
}
