using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class FeatureManager : IFeatureService
    {
        private readonly IFeature _featuredal;
        public FeatureManager(IFeature feature) {
            _featuredal = feature;
        }
        public void TAdd(Feature entity)
        {
            _featuredal.Add(entity);
        }

        public void TDelete(Feature entity)
        {
            _featuredal.Delete(entity);
        }

        public List<Feature> TGetAll()
        {
            return _featuredal.GetAll();
        }

        public Feature TGetById(int id)
        {
            return _featuredal.GetById(id);
        }

        public void TUpdate(Feature entity)
        {
            _featuredal.Update(entity);
        }
    }
}
