using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void ProductAdd(Product product)
        {
            _productDal.Insert(product);
        }

        public void DeleteProduct(Product product)
        {
            _productDal.Delete(product);
        }

        public Product GetByID(int id)
        {
            return _productDal.Get(x => x.ProductId == id);
        }

        public List<Product> GetList()
        {
            return _productDal.List();
        }

        public void UpdaterProduct(Product product)
        {
            _productDal.Update(product);
        }
    }
}
