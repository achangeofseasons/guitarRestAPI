using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Web.Http.Cors;


namespace guitarRestAPI.Controllers
{

    //Class that matches the database table guitar_brand
    public class guitarBrand
    {
        public int guitarBrandId { get; set; }
        public string name { get; set; }
    }

    //Class that matches the database table guitar_model
    public class guitarModel
    {
        public int guitarModelId { get; set; }
        public int guitarBrandId { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
    }

    public class guitarModelBrand
    {
        public int guitarModelId { get; set; }
        public int guitarBrandId { get; set; }
        public string modelName { get; set; }
        public decimal modelPrice { get; set; }
        public string brandName { get; set; }
    }

    [EnableCors(origins: "http://localhost:4200,http://localhost:4201", headers: "*", methods: "*")]
    public class GuitarController : ApiController
    {
        guitarSampleDataContext dc = new guitarSampleDataContext();

        
        //Get guitar brands
        public List<guitarBrand> Get()
        {
            //return new string[] { "value1", "value2" };

            var guitarBrandQuery = from result in dc.guitar_brands
                                   orderby result.name
                                   select result;

            //Put the data in an object
            List<guitarBrand> guitarBrandCol = new List<guitarBrand>();
            foreach (var queryItem in guitarBrandQuery.ToList())
            {
                //Add each record to the list
                guitarBrandCol.Add(new guitarBrand
                {
                    guitarBrandId = queryItem.guitar_brand_id,
                    name = queryItem.name
                });
            }

            return guitarBrandCol;
        }
        

        //Get models within a particular brand
        [Route("api/guitar/models/{id}")]
        public List<guitarModel> GetModels(int id)
        {

            //Get all of the guitar brands using Linq
            var guitarModelQuery = from result in dc.guitar_models
                                   where result.guitar_brand_id == id
                                   orderby result.name
                                   select result;

            //Put the data in an object
            List<guitarModel> guitarModelCol = new List<guitarModel>();
            foreach (var queryItem in guitarModelQuery.ToList())
            {
                //Add each record to the list
                guitarModelCol.Add(new guitarModel
                {
                    guitarModelId = queryItem.guitar_model_id,
                    guitarBrandId = queryItem.guitar_brand_id,
                    name = queryItem.name,
                    price = queryItem.price
                });
            }

            return guitarModelCol;
        }


        //Get a list of all guitar models (with brand names)
        [Route("api/guitar/allmodels")]
        public List<guitarModelBrand> GetAllModels()
        {
            //Get all of the guitar brands using Linq
            var guitarModelQuery = from models in dc.guitar_models
                                   join brand in dc.guitar_brands on models.guitar_brand_id equals brand.guitar_brand_id
                                   orderby brand.name, models.name
                                   select new
                                   {
                                       guitar_model_id = models.guitar_model_id,
                                       model_name = models.name,
                                       model_price = models.price,
                                       guitar_brand_id = models.guitar_brand_id,
                                       brand_name = brand.name
                                   };

            //Put the data in an object
            List<guitarModelBrand> guitarModelBrandCol = new List<guitarModelBrand>();
            foreach (var queryItem in guitarModelQuery.ToList())
            {
                //Add each record to the list
                guitarModelBrandCol.Add(new guitarModelBrand
                {
                    guitarModelId = queryItem.guitar_model_id,
                    guitarBrandId = queryItem.guitar_brand_id,
                    modelName = queryItem.model_name,
                    modelPrice = queryItem.model_price,
                    brandName = queryItem.brand_name
                });
            }

            return guitarModelBrandCol;
        }


        //Add a new guitar model
        [Route("api/guitar/newmodel")]
        public HttpResponseMessage PostGuitarModel([FromBody]guitar_model guitarModelInfo)
        {
            guitar_model newGuitarModel = new guitar_model();
            newGuitarModel.name = guitarModelInfo.name;
            newGuitarModel.guitar_brand_id = guitarModelInfo.guitar_brand_id;
            newGuitarModel.price = guitarModelInfo.price;
            dc.guitar_models.InsertOnSubmit(newGuitarModel);
            dc.SubmitChanges();

            return Request.CreateResponse(HttpStatusCode.Created, newGuitarModel.guitar_model_id);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {

        }
        
        //Delete a guitar model
        [HttpDelete]
        [Route("api/guitar/deletemodel/{guitarModelId}")]
        public HttpResponseMessage Delete(int guitarModelId)
        {
            var guitarBrandToDelete = (from gm in dc.guitar_models
                                    where gm.guitar_model_id == guitarModelId
                                    select gm).FirstOrDefault();

            dc.guitar_models.DeleteOnSubmit(guitarBrandToDelete);
            dc.SubmitChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}