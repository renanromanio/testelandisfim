using System;
using System.Collections.Generic;
using System.Text;

namespace TesteLandis.Business.Interface
{
    public interface IEndpointBusiness
    {
        public void List();
        public void Edit();
        public void Find();
        public void Remove();
        public void Insert();
    }
}
